using CommonTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProvisionLigandsForDocking
{
    internal class Program
    {
        internal static int GreatestPrime(int upbound)
        {
            for (int i = upbound; i >= 0; i--)
            {
                bool prime = true;
                for (int j = 2; j * j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        prime = false;
                        break;
                    }
                }

                if (prime)
                {
                    return i;
                }
            }

            throw new Exception("Impossible case.");
        }

        private const int ActiveThreshold = 1000, InactiveThreshold = 10000, InvalidThreshold = 200000, TooFewThreshold = 100;

        internal static void ProvisionLigandsForDocking(string workdir, (string Id, string Smiles)[] ligands)
        {
            Logger.BeginLog(typeof(Program), workdir);

            Logger.Info("Loading non active ligands");

            if (ligands.Any())
            {
                int prime = GreatestPrime(ligands.Length - 1);
                if (ligands.Length != prime)
                    ligands = ligands.Take(prime).ToArray(); // the greatest prime
            }

            Logger.Info($"{ligands.Length} ligands found");

            var smilesDict = ligands.ToDictionary(o => o.Id, o => o.Smiles);

            var rand = new Random(17);

            IEnumerable<(string Id, string Smiles)> GetSubset(int count, ICollection<string> mustHaveIds)
            {
                // Return all
                if (count >= ligands.Length)
                {
                    foreach (var (id, smiles) in ligands)
                        yield return (id, smiles);
                    yield break;
                }

                foreach (var (id, smiles) in ligands)
                {
                    if (mustHaveIds.Contains(id))
                    {
                        count--;
                        yield return (id, smiles);
                    }
                }

                int start = rand.Next();
                int step = rand.Next();

                for (int i = start; count > 0; i += step)
                {
                    i %= ligands.Length;
                    if (mustHaveIds.Contains(ligands[i].Id))
                        continue;
                    yield return (ligands[i].Id, ligands[i].Smiles);
                    count--;
                }
            }

            int tooFewCount = 0;

            foreach (string proteinDir in Directory.GetDirectories(workdir))
            {
                string proteinName = Path.GetFileName(proteinDir);
                string bioactivityFilePath = Path.Combine(proteinDir, $"{proteinName}_Bioactivities.csv");

                Logger.PushProtein(proteinName);

                try
                {
                    if (!File.Exists(bioactivityFilePath))
                        throw new FileNotFoundException("Cannot find csv file.", bioactivityFilePath);

                    var ligandBioActivities = new Dictionary<string, int>();

                    int totalLigands = 0, invalidLigands = 0;
                    string prefName = null, organism = null;

                    foreach (string[] fields in File
                        .ReadAllLines(bioactivityFilePath)
                        .ParseCsvRows("Molecule ChEMBL ID", "Smiles", "Standard Type", "Molecular Weight", "Standard Relation", "Standard Value", "Standard Units", "Target Name", "Target Organism", "Comment"))
                    {
                        if (fields[2] != "Ki" && fields[2] != "EC50" && fields[2] != "IC50" && fields[2] != "Activity" && fields[2] != "Inhibition")
                            continue;

                        if (prefName == null)
                        {
                            prefName = fields[7];
                            Logger.Info($"Pref name is {prefName}");
                        }
                        else if (prefName != fields[7])
                        {
                            Logger.Warn($"Different pref name {fields[7]} found.");
                        }

                        if (organism == null)
                        {
                            organism = fields[8];
                            Logger.Info($"Organism is {organism}");
                        }
                        else if (organism != fields[8])
                        {
                            Logger.Warn($"Different organism {fields[8]} found.");
                        }

                        Logger.PushJob(fields[0]);

                        totalLigands++;

                        fields[4] = fields[4].Trim('\'');
                        if (!ParseBioActivityRecord(fields, smilesDict, ligandBioActivities))
                            invalidLigands++;

                        Logger.PopJob();
                    }

                    Logger.Info(
                        $"Found {totalLigands} bioactivity records in total, out of which {invalidLigands} are invalid and {ligandBioActivities.Count} are valid and unique.");

                    int activeCount = ligandBioActivities.Count(o => o.Value > 0);
                    int moderateCount = ligandBioActivities.Count(o => o.Value == 0);
                    int inactiveCount = ligandBioActivities.Count(o => o.Value < 0);

                    if (activeCount < TooFewThreshold)
                        tooFewCount++;
                    Logger.Info(
                        $"Stat: {activeCount} active, {moderateCount} moderate, {inactiveCount} inactive in book.");

                    // Pad the inactive list to be as large as the active list
                    int diff = Math.Max(0, activeCount - inactiveCount);
                    if (diff == 0)
                        Logger.Info("Inactive count is greater than active count.");

                    var inactiveIds = GetInactiveLigandsFromOutput(proteinDir).ToHashSet();
                    var inactiveLigands = GetSubset(diff, inactiveIds).ToArray();
                    diff = inactiveLigands.Length;

                    if (diff > 0)
                    {
                        foreach (var (id, _) in inactiveLigands)
                        {
                            ligandBioActivities.Add(id, -1);
                        }

                        inactiveCount += diff;
                        Logger.Info($"Padded the inactive list by {diff}, now we got {activeCount} active, {moderateCount} moderate, {inactiveCount} inactive ligands.");
                    }

                    string[] headers = new[] { "ID", "IsActive", "Smiles" };
                    var rows = ligandBioActivities
                        .Select(o => new[] { o.Key, (o.Value > 0 ? 1 : o.Value < 0 ? -1 : 0).ToString(), smilesDict[o.Key] })
                        .FormatCsvRows(headers);

                    string outputPath = Path.Combine(proteinDir, $"{proteinName}_ProvisionedCompounds.csv");
                    File.WriteAllLines(outputPath, rows, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }

                Logger.PopProtein();
            }

            Logger.Info($"{tooFewCount} proteins have less than {TooFewThreshold} active ligands.");

            Logger.EndLog();
        }

        private static IEnumerable<string> GetInactiveLigandsFromOutput(string proteinDir)
        {
            string outputDir = Path.Combine(proteinDir, "Output");

            if (Directory.Exists(outputDir))
            {
                return Directory
                    .GetFiles(outputDir)
                    .Select(Path.GetFileName)
                    .Where(o => o.StartsWith("ZINC"))
                    .Select(o => Regex.Replace(o, @"(ZINC\d+)_model_\d\.(log\.csv|pdbqt)", "$1"))
                    .Distinct();
            }
            return new List<string>();
        }

        private static bool ParseBioActivityRecord(IReadOnlyList<string> fields, IDictionary<string, string> smilesDict, IDictionary<string, int> ligandBioActivities)
        {
            if (string.IsNullOrWhiteSpace(fields[1]))
            {
                Logger.Warn("Smiles is empty.");
                return false;
            }

            var m = Regex.Match(fields[0], @"CHEMBL(\d+)");
            if (!m.Success)
            {
                Logger.Warn($"Cannot parse CHEMBL Id {fields[0]}.");
                return false;
            }

            if (!int.TryParse(m.Groups[1].Value, out int chemblId))
            {
                Logger.Warn($"CHEMBL Id is not an integer: {fields[0]}.");
                return false;
            }

            if (chemblId.ToString() != m.Groups[1].Value)
            {
                Logger.Warn($"CHEMBL Id {m.Groups[1].Value} != {chemblId}.");
                return false;
            }

            int? category = null;

            if (fields[^1] == "active" || fields[^1] == "inactive")
            {
                category = fields[^1][0] == 'a' ? 1 : -1;
            }
            else
            {
                if (!float.TryParse(fields[5], out float bioact))
                {
                    Logger.Warn($"Standard value is not a float: {fields[5]}.");
                    return false;
                }

                if (fields[5] == "0")
                {
                    Logger.Warn("Standard value is zero.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(fields[4]))
                {
                    Logger.Warn("Relation is empty.");
                    return false;
                }

                if (!"~<<=>>=".Contains(fields[4]))
                {
                    Logger.Warn($"Unknown relation: {fields[4]}.");
                    return false;
                }

                switch (fields[6])
                {
                    case "uM":
                        bioact *= 1000;
                        break;
                    case "ug.mL-1":
                        if (string.IsNullOrEmpty(fields[2]))
                        {
                            Logger.Warn("Molweight is empty.");
                            return false;
                        }
                        if (!float.TryParse(fields[2], out float molmass))
                        {
                            Logger.Warn($"Molweight {fields[2]} is not a float.");
                            return false;
                        }

                        bioact *= 1000000 / molmass;
                        break;
                    case "/nM":
                    case "nM":
                        break;
                    case "":
                        Logger.Warn("Unit is empty.");
                        return false;
                    default:
                        Logger.Warn($"Unknown unit: '{fields[6]}'.");
                        return false;
                }

                if (bioact > InvalidThreshold)
                {
                    // Keep this kind of record
                    Logger.Warn($"Standard value {fields[5]} is outside typical range.");
                }

                // inactive
                if (bioact >= InactiveThreshold && "~>>=".Contains(fields[4]))
                    category = -1;

                // moderate
                else if (bioact >= ActiveThreshold && bioact <= InactiveThreshold && "~=".Contains(fields[4]))
                    category = 0;

                // active
                else if (bioact <= ActiveThreshold && "~<<=".Contains(fields[4]))
                    category = 1;
            }

            if (smilesDict.TryGetValue(fields[0], out string smiles))
            {
                if (smiles != fields[1])
                {
                    Logger.Warn("Found active ligands that share the same ChEMBL Id but with different smiles.");
                    return false;
                }
            }
            else
            {
                smilesDict.Add(fields[0], fields[1]);
            }

            if (category != null)
            {
                if (!ligandBioActivities.ContainsKey(fields[0]))
                    ligandBioActivities[fields[0]] = category.Value;
                else
                    ligandBioActivities[fields[0]] += category.Value;
            }

            return true;
        }

        private static JobLogger Logger { get; } = new JobLogger();

        private static void Main()
        {
            string workspace = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Git", "GenericComputationPlatform", "DockingApiService", "Workspace", "Receptors");

            //string workdir = Path.Combine(workspace, "Receptors");

            //string ligandsDir = Path.Combine(workspace, "RandomSelectedCompounds.csv");
            //var ligands = File.ReadAllLines(ligandsDir)
            //    .ParseCsvRows("ID", "Smiles")
            //    .Select(o => (o[0], o[1]))
            //    .ToArray();

            ProvisionLigandsForDocking(workspace, new (string Id, string Smiles)[0]);
        }
    }
}
