using CommonTools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PrecomputeFingerprints
{
    internal class Program
    {
        private static void PrecomputeFingerprints(string dbdir, string workdir, string fptype)
        {
            Logger.Current.LogInformation("Starting");

            string dataFilePath = Path.Combine(dbdir, $"CompoundFPDB_{fptype.ToLower()}.data");
            var fpdata = FingerprintFile.ReadAllDataV3(dataFilePath);

            Logger.Current.LogInformation($"Loaded {fpdata.Count} fingerprints.");

            foreach (string proteinDir in Directory.GetDirectories(workdir))
            {
                string proteinName = Path.GetFileName(proteinDir);
                string provisionedFilePath = Path.Combine(proteinDir, $"{proteinName}_ProvisionedCompounds.csv");

                try
                {
                    if (!File.Exists(provisionedFilePath))
                        throw new FileNotFoundException($"Cannot find csv file {provisionedFilePath}", provisionedFilePath);

                    string outputFpFile = Path.Combine(proteinDir, $"{proteinName}_ChemblCompounds.{fptype.ToLower()}");

                    var data = File
                        .ReadAllLines(provisionedFilePath)
                        .ParseCsvRows("ID", "Smiles", "IsActive")
                        .Where(o => o[0].StartsWith("CHEMBL"))
                        .Select(o => (Id: o[0], Smiles: o[1], Activity: int.Parse(o[2]), fpdata[o[0]].Fingerprint))
                        .ToArray();

                    if (data.Length == 0)
                        Logger.Current.LogWarning($"No ligands found for {proteinName}");
                    else
                    {
                        FingerprintFile.WriteAllData(outputFpFile, fptype, data);
                        Logger.Current.LogInformation($"Done for {proteinName}");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Current.LogError(ex.Message);
                }
            }
        }

        private static void Main()
        {
            var serviceProvider = new ServiceCollection()
               .AddLogging(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Debug))
               .BuildServiceProvider();

            Logger.Current = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

            var sw = Stopwatch.StartNew();

            string workdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Git", "GenericComputationPlatform", "DockingApiService", "Workspace", "Receptors");
            string dbdir = workdir;

            PrecomputeFingerprints(dbdir, workdir, "FP2");

            Logger.Current.LogInformation($"Time elapsed: {sw.Elapsed}");
            Console.ReadKey();
        }
    }
}