using ChemicalFunctions;
using CommonTools;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MergeDockingResults
{
    internal class Program
    {
        private static float? ParseScore(string workdir, string name)
        {
            string csvFile = Path.Combine(workdir, name);
            if (!File.Exists(csvFile))
                return null;
            string csv = File.ReadAllText(csvFile);
            var m = Regex.Match(csv, @"([0-9A-Za-z]+),\d+,(-?\d+\.\d+),(-?\d+\.\d+)");
            if (!m.Success)
                throw new Exception(@"Failed to parse csv {name}");
            return float.Parse(m.Groups[2].Value).ToSybylScore();
        }

        private static JobLogger Logger { get; } = new JobLogger();

        private static void MergeOutput(string workdir)
        {
            Logger.BeginLog(typeof(Program), workdir);

            //var fpIndexFilePath = Path.Combine(workdir, "LigandFPDB_fp2.idx");
            string fpDataFilePath = Path.Combine(workdir, "LigandFPDB_fp2.data");

            //var indices = FingerprintFile.ReadAllIndices(fpIndexFilePath);
            var data = FingerprintFile.ReadAllData(fpDataFilePath);
            Logger.Info($"Loaded {data.Count} fingerprints.");

            Parallel.ForEach(Directory.GetDirectories(workdir), proteinDir =>
            {
                string proteinName = Path.GetFileNameWithoutExtension(proteinDir);

                string indexFile = Path.Combine(proteinDir, $"{proteinName}_ProvisionedLigands.csv");
                string outputDir = Path.Combine(proteinDir, "Output");

                if (!File.Exists(indexFile))
                {
                    Logger.Warn($"Cannot find file {indexFile}");
                    return;
                }

                if (!Directory.Exists(outputDir))
                {
                    Logger.Warn($"Cannot find directory {outputDir}");
                    return;
                }

                var summary = File
                    .ReadAllLines(indexFile)
                    .ParseCsvRows("ID", "IsActive", "Smiles")
                    .Select(o => new object[]
                    {
                        o[0],
                        o[1],
                        o[2],
                        ParseScore(outputDir, $"{o[0]}_model_1.log.csv"),
                        ParseScore(outputDir, $"{o[0]}_model_2.log.csv"),
                        ParseScore(outputDir, $"{o[0]}_model_3.log.csv"),
                        data[o[0]].Fingerprint.ToHexString(),
                    });

                string resultFile = Path.Combine(proteinDir, $"{proteinName}_ScoresSummary.csv");
                string[] headers = new[] { "ID", "IsActive", "Smiles", "Score1", "Score2", "Score3", "FP2" };

                string[] resultLines = summary.FormatCsvRows(headers).ToArray();

                File.WriteAllLines(resultFile, resultLines, Encoding.UTF8);
                Logger.Info($"Written {resultLines.Length} lines to {resultFile}");
            });

            Logger.EndLog();
        }

        private static void Main()
        {
            string workdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Shared", "DAKB_GPCRs_20180208");

            MergeOutput(workdir);
        }
    }
}
