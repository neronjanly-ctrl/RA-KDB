using CommonTools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BuildFingerprintDatabase
{
    internal class Program
    {
        private static IEnumerable<(string Id, string Smiles)> CollectLigands(string workdir)
        {
            foreach (string proteinDir in Directory.GetDirectories(workdir))
            {
                string proteinName = Path.GetFileName(proteinDir);
                string csvFilePath = Path.Combine(proteinDir, $"{proteinName}_ProvisionedCompounds.csv");

                if (!File.Exists(csvFilePath))
                {
                    Logger.Current.LogWarning($"Cannot find csv file {csvFilePath}");
                    continue;
                }

                foreach (string[] fields in File
                    .ReadAllLines(csvFilePath)
                    .ParseCsvRows("ID", "Smiles"))
                {
                    yield return (fields[0], fields[1]);
                }
            }
        }

        private static void BuildFingerprintDatabase(string dbdir, string workdir, string fptype)
        {
            Logger.Current.LogInformation("Starting");

            string datafile = Path.Combine(dbdir, $"CompoundFPDB_{fptype.ToLower()}.data");
            string indexfile = Path.Combine(dbdir, $"CompoundFPDB_{fptype.ToLower()}.idx");

            // Load data from existing database and convert to a concurrent dictionary
            var data = File.Exists(datafile) ? FingerprintFile.ReadAllDataV3(datafile) : new Dictionary<string, (string Smiles, byte[] Fingerprint)>();
            var resultDict = new ConcurrentDictionary<string, (string Smiles, byte[] Fingerprint)>(data);
            var usedDict = new ConcurrentDictionary<string, string>();

            int currentCount = data.Count;
            Logger.Current.LogInformation($"Found {currentCount} records in current database.");

            var ligandArr = CollectLigands(workdir).ToArray();
            Logger.Current.LogInformation($"Found {ligandArr.Length} ligands to be filtered.");

            int cnt = 0, distinct = 0;
            var sw = new Stopwatch();

            Parallel.ForEach(ligandArr,
                new ParallelOptions { MaxDegreeOfParallelism = 20 },
                o =>
                {
                    if (cnt++ % 500 == 0)
                    {
                        Logger.Current.LogInformation($"Discovered {distinct}/{cnt} ligands, time {sw.Elapsed:g}");
                        sw.Restart();
                    }

                    var (id, smiles) = o;
                    if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(smiles))
                        return;

                    if (resultDict.ContainsKey(id))
                        return;

                    if (!usedDict.ContainsKey(id))
                    {
                        ++distinct;
                        string smiles2 = smiles.NormalizeSmiles();
                        usedDict[id] = smiles2;

                        byte[] fp2 = smiles2.ComputeFingerprint(fptype);
                        resultDict[id] = (smiles2, fp2);
                    }

                    if (usedDict[id] == smiles)
                        return;

                    string smiles3 = smiles.NormalizeSmiles();

                    if (usedDict[id] == smiles3)
                        return;

                    Logger.Current.LogWarning($"Inconsistent ligands {id}: {smiles3} != {usedDict[id]}");
                });

            Logger.Current.LogInformation($"{resultDict.Count - currentCount} ligands are added to current database.");
            Logger.Current.LogInformation("Flushing data and index files.");

            var indices = FingerprintFile.WriteAllDataV3(datafile, fptype, resultDict.Select(o => (o.Key, o.Value.Smiles, o.Value.Fingerprint)));
            FingerprintFile.WriteAllIndices(indexfile, indices);
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

            BuildFingerprintDatabase(dbdir, workdir, "FP2");

            Logger.Current.LogInformation($"Time elapsed: {sw.Elapsed}");
            Console.ReadKey();
        }
    }
}
