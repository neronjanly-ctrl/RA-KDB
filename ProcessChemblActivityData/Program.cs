using CommonTools;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ProcessChemblActivityData
{
    internal class Program
    {
        private static JobLogger Logger { get; } = new JobLogger();

        private static readonly string[] blacklist =
        {
            "nd(insoluble)", "no data", "dose-dependent effect", "no activity detected",
            "not determined", "not tested", "not evaluated", "tde", "bld", "no action", "nt",
        };

        private static readonly string[] activelist =
        {
            "active", "agonist", "partially active", "partial agonist", "weak agonist", "low activity", "slightly active",
            "indirect activator", "transporter substrate", "antagonist", "partial antagonist",
            "inverse agonist", "transporter inhibitor", "limited inhibition", "potent inhibitor",
        };

        private static readonly string[] inactivelist =
        {
            "inactive", "no activity", "not active", "no inhibition", "no significant activity", "no interactions", "ineffective",
        };

        private static string NormalizeComment(string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
                return null;

            var commentlo = comment.ToLower().Trim();

            if (blacklist.Contains(commentlo))
                return null;

            if (activelist.Contains(commentlo))
                return "active";

            if (inactivelist.Contains(commentlo))
                return "inactive";

            string[] fields = commentlo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string f0 = fields[0].ToLower();

            if (f0 == "substrate" || f0 == "inducer" || f0 == "inhibitor" || f0 == "blocker")
                return "active";

            string f1 = fields.Length > 1 ? fields[1] : null;
            if (f0 == "is" && f1 == "not")
                return "inactive";

            Logger.Info($"Unknown Activity: {comment}");
            return null;
        }

        private static void PreprocessBioActivity(string workdir)
        {
            Logger.BeginLog(typeof(Program), workdir);

            string[] headers =
            {
                "Molecule ChEMBL ID", "Smiles", "Standard Type", "Molecular Weight", "Standard Relation", "Standard Value", "Standard Units", "Target Name", "Target Organism", "Comment",
            };

            foreach (string proteinDir in Directory.GetDirectories(workdir))
            {
                string proteinName = Path.GetFileName(proteinDir);
                Logger.PushProtein(proteinName);

                string[] fileNames = { $"{proteinName}_Bioactivities.txt" };

                string[][] data = fileNames
                    .Select(o => Path.Combine(proteinDir, o))
                    .Where(File.Exists)
                    .Select(File.ReadAllLines)
                    .Where(o => o.Length > 0)
                    .Select(o => o.ParseCsvRows(';', headers))
                    .SelectMany(o => o)
                    .Select(o =>
                    {
                        o[2] = o[2].Trim();
                        var type = o[2].ToLower();
                        if (type == "activity" || type == "inhibition")
                            o[^1] = NormalizeComment(o[^1]);
                        return o;
                    })
                    .Where(o =>
                    {
                        if (!string.IsNullOrWhiteSpace(o[5]))
                            return true;
                        var type = o[2].ToLower();
                        if (type == "activity" || type == "inhibition")
                            return o[9] != null;
                        return false;
                    })
                    .ToArray();

                string outputName = $"{proteinName}_Bioactivities.csv";
                string outputPath = Path.Combine(proteinDir, outputName);

                if (data.Length > 0)
                {
                    Logger.Info($"Found {data.Length} records.");
                    File.WriteAllLines(outputPath, data.FormatCsvRows(headers), Encoding.UTF8);
                }
                else
                {
                    Logger.Warn($"No record found. Skipping {outputPath}");
                }

                Logger.PopProtein();
            }

            Logger.EndLog();
        }

        private static void Main()
        {
            string workdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Git", "GenericComputationPlatform", "DockingApiService", "Workspace", "Receptors");

            PreprocessBioActivity(workdir);
        }
    }
}
