using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;
using System.Web;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CytoscapeOnline
{
    public class OpenXmlExcelParser : IDisposable
    {
        public IEnumerable<Dictionary<string, string>> GetData(HttpPostedFileBase file)
        {
            var tempfile = Path.GetTempFileName();
            TempFilePath = tempfile;
            file.SaveAs(tempfile);
            return GetData(tempfile);
        }
        public IEnumerable<string[]> GetDataRaw(HttpPostedFileBase file)
        {
            var tempfile = Path.GetTempFileName();
            TempFilePath = tempfile;
            file.SaveAs(tempfile);
            return GetDataRaw(tempfile);
        }


        private string GetString(Cell cell, SharedStringTable strings)
        {
            return (cell.DataType != null && cell.DataType.HasValue && cell.DataType == CellValues.SharedString)
                ? strings.ChildElements[int.Parse(cell.InnerText)].InnerText
                : cell.InnerText;
        }

        public IEnumerable<Dictionary<string, string>> GetData(string filepath)
        {
            using (var document = SpreadsheetDocument.Open(filepath, false))
            {
                var workbook = document.WorkbookPart.Workbook;
                var strings = document.WorkbookPart.SharedStringTablePart.SharedStringTable;

                foreach (var sheet in workbook.Descendants<Sheet>())
                {
                    var part = (WorksheetPart)document.WorkbookPart.GetPartById(sheet.Id);

                    var rows = part.Worksheet.Descendants<Row>().ToArray();

                    if (rows.Length <= 0)
                        throw new Exception(string.Format("工作表“{0}”没有内容", sheet.Name));

                    var headers = rows[0].Descendants<Cell>().ToArray();

                    for (var i = 1; i < rows.Length; i++)
                    {
                        var dict = new Dictionary<string, string>();
                        var cells = rows[i].Descendants<Cell>().ToArray();

                        for (var j = 0; j < Math.Min(headers.Length, cells.Length); j++)
                        {
                            var fieldName = GetString(headers[j], strings);
                            var fieldValue = GetString(cells[j], strings);

                            if (string.IsNullOrWhiteSpace(fieldValue))
                                throw new Exception(string.Format("工作表“{0}”，第{1}行{2}列不能为空", sheet.Name, i + 1, fieldName));

                            if (dict.ContainsKey(fieldName))
                                throw new Exception(string.Format("字段“{0}”重复", fieldName));

                            dict.Add(fieldName, fieldValue);
                        }

                        yield return dict;
                    }
                }
            }
        }

        public IEnumerable<string[]> GetDataRaw(string filepath)
        {
            using (var document = SpreadsheetDocument.Open(filepath, false))
            {
                var workbook = document.WorkbookPart.Workbook;
                var strings = document.WorkbookPart.SharedStringTablePart.SharedStringTable;

                foreach (var sheet in workbook.Descendants<Sheet>())
                {
                    var part = (WorksheetPart)document.WorkbookPart.GetPartById(sheet.Id);

                    var rows = part.Worksheet.Descendants<Row>().ToArray();

                    if (rows.Length <= 0)
                        throw new Exception(string.Format("工作表“{0}”没有内容", sheet.Name));

                    for (var i = 0; i < rows.Length; i++)
                    {
                        var cells = rows[i].Descendants<Cell>().ToArray();
                        var result = new string[cells.Length];

                        for (var j = 0; j < cells.Length; j++)
                        {
                            result[j] = GetString(cells[j], strings);
                        }

                        yield return result;
                    }
                }
            }
        }
        
        private string TempFilePath = null;

        void IDisposable.Dispose()
        {
            if (TempFilePath != null)
            {
                File.Delete(TempFilePath);
                TempFilePath = null;
            }
        }

    }
}
