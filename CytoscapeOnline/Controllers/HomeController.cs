using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using CytoscapeOnline.Models;
using System.ComponentModel.DataAnnotations;

namespace CytoscapeOnline.Controllers
{
    public class HomeController : Controller
    {
        Network ConstructGraph(IEnumerable<string[]> data, int source, int target)
        {
            var nodes = new Dictionary<string, int>();
            var edges = new Dictionary<int, HashSet<int>>();

            var id = 0;

            foreach (var item in data)
            {
                var src = item[source];
                if (!nodes.ContainsKey(src))
                {
                    nodes[src] = id;
                    edges[id++] = new HashSet<int>();
                }

                var tgt = item[target];
                if (!nodes.ContainsKey(tgt))
                {
                    nodes[tgt] = id;
                    edges[id++] = new HashSet<int>();
                }

                var nsrc = nodes[src];
                var ntgt = nodes[tgt];
                edges[nsrc].Add(ntgt);
            }

            var network = new Network();
            network.Nodes = nodes.Keys.ToArray();
            network.Edges = edges.OrderBy(o => o.Key).Select(o => o.Value.ToArray()).ToArray();

            return network;
        }

        public ActionResult Index2()
        {
            using (var parser = new OpenXmlExcelParser())
            {
                var filepath = Server.MapPath("~/Content/galFiltered.xlsx");
                var data = parser.GetDataRaw(filepath);
                var network = ConstructGraph(data.Skip(1), 0, 1);
                ViewBag.Data = JsonConvert.SerializeObject(network);
            }

            return View();
        }

        public class Interaction
        {
            public short DrugId;
            public short TargetId;
            public short Value;
            public bool Known;
        }

        DrugModel ConvertToModel(IEnumerable<string[]> data, int colValue, int colDrug, int colTarget, int colKnown)
        {
            var targets = new Dictionary<string, short>();
            var drugs = new Dictionary<string, short>();
            var interactions = new List<Interaction>();

            foreach (var item in data)
            {
                if (!drugs.ContainsKey(item[colDrug]))
                    drugs[item[colDrug]] = (short)drugs.Count;

                if (!targets.ContainsKey(item[colTarget]))
                    targets[item[colTarget]] = (short)targets.Count;

                interactions.Add(new Interaction
                {
                    DrugId = drugs[item[colDrug]],
                    TargetId = targets[item[colTarget]],
                    Value = Convert.ToInt16(double.Parse(item[colValue]) * 1000),
                    Known = Convert.ToInt32(item[colKnown]) != 0,
                });
            }

            return new DrugModel
            {
                Drugs = drugs
                    .OrderBy(o => o.Value)
                    .Select(o => o.Key)
                    .ToArray(),
                Targets = targets
                    .OrderBy(o => o.Value)
                    .Select(o => o.Key)
                    .ToArray(),
                TargetStates = interactions
                    .GroupBy(o => o.TargetId, o => o.Known)
                    .OrderBy(o => o.Key)
                    .Select(o => o.Any(p => p) ? 1 : 0)
                    .ToArray(),
                TargetDrugs = interactions
                    .GroupBy(o => o.TargetId, o => o.DrugId)
                    .OrderBy(o => o.Key)
                    .Select(o => o.ToArray())
                    .ToArray(),
                DrugTargets = interactions
                    .GroupBy(o => o.DrugId, o => o.TargetId)
                    .OrderBy(o => o.Key)
                    .Select(o => o.ToArray())
                    .ToArray(),
                Interactions = interactions
                    .Select(o => new[] { o.DrugId, o.TargetId, o.Value, o.Known ? 1 : 0 })
                    .ToArray(),
            };
        }

        public ActionResult Plot(string id)
        {
            var filepath = Path.Combine(Server.MapPath("~/uploads"), id + ".xlsx");

            try
            {
                using (var parser = new OpenXmlExcelParser())
                {
                    var data = parser.GetDataRaw(filepath);
                    var header = data.First().ToList();

                    var value = header.FindIndex(o => o.Trim().Equals("Value", StringComparison.CurrentCultureIgnoreCase));
                    var drug = header.FindIndex(o => o.Trim().Equals("Drug", StringComparison.CurrentCultureIgnoreCase));
                    var shortname = header.FindIndex(o => o.Trim().Equals("Short Name", StringComparison.CurrentCultureIgnoreCase));
                    var known = header.FindIndex(o => o.Trim().Equals("Known", StringComparison.CurrentCultureIgnoreCase));

                    if (value == -1)
                        throw new Exception("Can not find 'Value' column.");

                    if (drug == -1)
                        throw new Exception("Can not find 'Drug' column.");

                    if (shortname == -1)
                        throw new Exception("Can not find 'Short Name' column.");

                    if (known == -1)
                        throw new Exception("Can not find 'Known' column.");

                    var model = ConvertToModel(data.Skip(1), value, drug, shortname, known);

                    ViewBag.Data = JsonConvert.SerializeObject(model);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrMessage"] = ex.Message;
                System.IO.File.Delete(filepath);
                return RedirectToAction("index");
            }

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.ErrMessage = TempData["ErrMessage"];
            return View();
        }

        public ActionResult Process()
        {
            if (!Request.Files.AllKeys.Contains("DataFile")
                || Request.Files["DataFile"].ContentLength <= 0)
            {
                TempData["ErrMessage"] = "Data file is required.";
                return RedirectToAction("index");
            }

            var path = Server.MapPath("~/uploads");
            var name = Guid.NewGuid().ToString("N").Substring(0, 8);
            var filepath = Path.Combine(path, name + ".xlsx");

            Request.Files["DataFile"].SaveAs(filepath);

            return RedirectToAction("plot", new { id = name });
        }
    }
}