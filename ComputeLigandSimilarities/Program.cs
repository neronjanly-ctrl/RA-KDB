using CommonTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ComputeLigandSimilarities
{
    internal class Program
    {
        private static JobLogger Logger { get; } = new JobLogger();

        private static IDictionary<string, (string smiles, byte[] fp)> GetFingerprints(string file, string fptype)
        {
            var data = File
                .ReadAllLines(file)
                .ParseCsvRows("ID", "Smiles")
                .ToDictionary(o => o[0], o => (o[1], o[1].ComputeFingerprint(fptype)));
            return data;
        }

        private static int[] BitsSet { get; } =
            Enumerable.Range(0, 256)
                .Select(o => Enumerable.Range(0, 8).Sum(p => (o >> p) & 1))
                .ToArray();

        private static float? ComputeTanimotoScore(byte[] fp1, byte[] fp2)
        {
            if (fp1.Length != fp2.Length)
                return null;

            int intersect = 0, union = 0;
            for (int i = 0; i < fp1.Length; i++)
            {
                intersect += BitsSet[fp1[i] & fp2[i]];
                union += BitsSet[fp1[i] | fp2[i]];
            }

            return intersect / (float)union;
        }

        private static void ComputeForSiyiLigands()
        {
            string workdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "Siyi_ligands");
            string file1 = Path.Combine(workdir, "OUR_final.csv");
            string file2 = Path.Combine(workdir, "CB2_biased ligand.csv");
            var fp1 = GetFingerprints(file1, "FP2");
            var fp2 = GetFingerprints(file2, "FP2");

            foreach (var (id, (smiles, fp)) in fp2)
            {
                Logger.Info($"Processing {id}");
                var data = fp1.Select(o => new { id = o.Key, o.Value.smiles, similarity = ComputeTanimotoScore(fp, o.Value.fp) })
                    .OrderByDescending(o => o.similarity)
                    .Select(o => new object[] { o.id, o.smiles, o.similarity });
                var rows = CsvHelper.FormatCsvRows(data, new[] { "ID", "Smiles", "Similarity" });
                File.WriteAllLines(Path.Combine(workdir, $"result_for_{id}.csv"), rows);
            }
        }

        private static void ComputeForMingsChemblDataSet(string fptype)
        {
            string workdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "MingsPR_Proteins_computed");

            Logger.BeginLog(typeof(Program), workdir);

            var dataFilePath = Path.Combine(workdir, "Proteins", "CompoundFPDB_fp2.data");
            var fpdata = FingerprintFile.ReadAllData(dataFilePath);

            Logger.Info($"Loaded {fpdata.Count} fingerprints.");

            var ligandFile = Path.Combine(workdir, "MingsPR_Ligands.csv");
            var ligands = File.ReadAllLines(ligandFile).ParseCsvRows("ID", "Smiles").ToDictionary(o => o[0], o => o[1]);

            foreach (var (ligandId, ligandSmiles) in ligands)
            {
                var ligandfp = ligandSmiles.ComputeFingerprint(fptype);
                var mostSimilarLigands = new List<object[]>();

                foreach (var proteinDir in Directory.GetDirectories(Path.Combine(workdir, "Proteins")))
                {
                    var proteinName = Path.GetFileName(proteinDir);
                    var provisionedFilePath = Path.Combine(proteinDir, $"{proteinName}_ProvisionedCompounds.csv");

                    Logger.PushProtein(proteinName);

                    try
                    {
                        if (!File.Exists(provisionedFilePath))
                            throw new FileNotFoundException("Cannot find csv file.", provisionedFilePath);

                        var outputFpFile = Path.Combine(proteinDir, $"{proteinName}_ChemblCompounds.{fptype.ToLower()}");

                        var data = File
                            .ReadAllLines(provisionedFilePath)
                            .ParseCsvRows("ID", "Smiles", "IsActive")
                            .Select(o => new object[] { o[0], o[1], o[2], ComputeTanimotoScore(ligandfp, fpdata[o[0]].Fingerprint) })
                            .ToArray();

                        if (data.Length == 0)
                            Logger.Warn("No active ligands found.");
                        else
                        {
                            var rows = CsvHelper.FormatCsvRows(data, new[] { "ID", "Smiles", "IsActive", "Similarity" });
                            File.WriteAllLines(Path.Combine(proteinDir, $"{proteinName}_similarities_for_{ligandId}.csv"), rows);
                        }

                        var maxSim = data.Max(o => (float)o[3]);
                        var mostSim = data.FirstOrDefault(o => (float)o[3] == maxSim);
                        mostSimilarLigands.Add(new[] { proteinName, mostSim[0], mostSim[1], mostSim[2], mostSim[3] });
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                    }

                    Logger.PopProtein();
                }

                var rows2 = CsvHelper.FormatCsvRows(mostSimilarLigands, new[] { "Protein", "ID", "Smiles", "IsActive", "Similarity" });
                File.WriteAllLines(Path.Combine(workdir, $"similarities_summary_for_{ligandId}.csv"), rows2);
            }

            Logger.EndLog();
        }

        private static void Main()
        {
            //ComputeForSiyiLigands();
            ComputeForMingsChemblDataSet("FP2");
        }
    }
}
