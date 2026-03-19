using CommonTools;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ComputeNextDockingJob
{
    internal class Program
    {
        private static JobLogger Logger { get; } = new JobLogger();

        private static float[] ComputeDockingScore(string confPath, string ligandPath, string outputPath)
        {
            // Validate argument
            if (string.IsNullOrWhiteSpace(confPath))
                throw new ArgumentException("Argument cannot be null or empty.", nameof(confPath));

            if (string.IsNullOrWhiteSpace(ligandPath))
                throw new ArgumentException("Argument cannot be null or empty.", nameof(ligandPath));

            if (string.IsNullOrWhiteSpace(outputPath))
                throw new ArgumentException("Argument cannot be null or empty.", nameof(outputPath));

            // Check file existence
            if (!File.Exists(confPath))
                throw new FileNotFoundException("Cannot find config file for idock.", confPath);

            if (!File.Exists(ligandPath))
                throw new FileNotFoundException("Cannot find ligand file for idock.", ligandPath);

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
                throw new DirectoryNotFoundException($"Cannot find output directory for idock. {outputDir}");

            if (outputDir == Path.GetDirectoryName(ligandPath))
                throw new ArgumentException($"Directory {outputDir} for ligand and output cannot be the same.");

            string ligandNameWoExt = Path.GetFileNameWithoutExtension(ligandPath);

            // Since receptor file path is relative to config file, we use config directory as our work directory.
            string confDir = Path.GetDirectoryName(confPath);
            string confName = Path.GetFileName(confPath);

            string args = $"--config {confName} --ligand {ligandPath} --out {outputDir}";
            if (!ExternalCommand.RunAndWait("idock", args, confDir, out string stdout))
                return null;

            // Parse idock result
            var m = Regex.Match(stdout, $@"^\s*\d+\s+{ligandNameWoExt}\s+\d+\s+(-?\d+\.\d+)\s+(-?\d+\.\d+)\s*$", RegexOptions.Multiline);

            string logfile = Path.Combine(outputDir, "log.csv");

            if (m.Success)
            {
                float score = float.Parse(m.Groups[1].Captures[0].Value);
                float rfscore = float.Parse(m.Groups[2].Captures[0].Value);

                // Rename output model and log file
                File.Move(Path.Combine(outputDir, Path.GetFileName(ligandPath)), outputPath);
                File.Move(logfile, Path.ChangeExtension(outputPath, ".log.csv"));

                return new[] { score, rfscore };
            }

            // remove log file for failed running
            if (File.Exists(logfile))
                File.Delete(logfile);

            return null;
        }

        private static void ComputeNext(string workdir)
        {
            Logger.BeginLog(typeof(Program), workdir);

            int jobFetched = 0, jobDone = 0, jobFailed = 0;

            foreach (string proteinDir in Directory.GetDirectories(workdir))
            {
                string proteinName = Path.GetFileName(proteinDir);

                Logger.PushProtein(proteinName);

                // Prepare output directories
                string inputDir = Path.Combine(proteinDir, "Ligands");
                string outputDir = Path.Combine(proteinDir, "Output");
                string lockDir = Path.Combine(proteinDir, "Locks");

                if (!Directory.Exists(inputDir))
                {
                    Logger.Warn($"Cannot find path {inputDir}");
                    continue;
                }

                Directory.CreateDirectory(outputDir);
                Directory.CreateDirectory(lockDir);

                // Check pocket existence
                bool[] hasPockets = new bool[3];

                for (int i = 1; i <= 3; i++)
                {
                    string inputConfFileName = $"{proteinName}_model_{i}.conf";
                    string inputModelFileName = $"{proteinName}_model_{i}.pdbqt";
                    string inputConfFilePath = Path.Combine(proteinDir, inputConfFileName);
                    string inputModelFilePath = Path.Combine(proteinDir, inputModelFileName);

                    hasPockets[i - 1] = File.Exists(inputConfFilePath) && File.Exists(inputModelFilePath);

                    Logger.Info($"Has {(hasPockets[i - 1] ? "" : "no ")}pocket for model {i}");
                }

                // Cache pre-existing output files
                var outputFileNames = Directory.GetFiles(outputDir).Select(Path.GetFileName).ToLookup(o => o);
                int localJobFailed = 0, localJobFinished = 0, localJobFetched = 0;

                foreach (string ligandFilePath in Directory.GetFiles(inputDir))
                {
                    string ligandId = Path.GetFileNameWithoutExtension(ligandFilePath);

                    for (int i = 1; i <= 3; i++)
                    {
                        if (!hasPockets[i - 1])
                            continue;

                        string jobName = $"{ligandId}_model_{i}";
                        Logger.PushJob(jobName);

                        // So far, a job was pushed to logger

                        // ****************************************************
                        #region Stage 1: Check existence of output model and log

                        string outputModelFileName = $"{jobName}.pdbqt";
                        string outputLogFileName = $"{jobName}.log.csv";

                        if (outputFileNames.Contains(outputModelFileName) && outputFileNames.Contains(outputLogFileName))
                        {
                            localJobFinished++;
                            Logger.PopJob();
                            continue;
                        }

                        #endregion

                        // ****************************************************
                        #region Stage 2: Try to lock the job

                        string outputLockFileName = $"{jobName}.lock";
                        string outputLockFilePath = Path.Combine(lockDir, outputLockFileName);

                        if (File.Exists(outputLockFilePath))
                        {
                            Logger.PopJob();
                            continue;
                        }

                        try
                        {
                            using (var fs = new FileStream(outputLockFilePath, FileMode.CreateNew))
                            {
                                byte[] bytes = Encoding.UTF8.GetBytes(Environment.MachineName);
                                fs.Write(bytes, 0, bytes.Length);
                                fs.Flush();
                                fs.Close();
                            }
                        }
                        catch (Exception)
                        {
                            Logger.Warn("The job was locked.");

                            Logger.PopJob();
                            continue;
                        }

                        #endregion

                        // So far, a job was pushed to logger, a lock file was created

                        // ****************************************************
                        #region Stage 3: Check if there was an error discovered

                        string outputErrorFileName = $"{jobName}.err";
                        string outputErrorFilePath = Path.Combine(lockDir, outputErrorFileName);

                        if (File.Exists(outputErrorFilePath))
                        {
                            localJobFailed++;

                            try
                            {
                                File.Delete(outputLockFilePath);
                            }
                            catch (Exception)
                            {
                                Logger.Warn("Unable to unlock the job.");
                            }

                            Logger.PopJob();
                            continue;
                        }

                        #endregion

                        // ****************************************************
                        #region Stage 4: Check existence of output model and log again

                        string outputModelFilePath = Path.Combine(outputDir, outputModelFileName);
                        string outputLogFilePath = Path.Combine(outputDir, outputLogFileName);

                        if (File.Exists(outputModelFilePath) && File.Exists(outputLogFilePath))
                        {
                            localJobFinished++;

                            try
                            {
                                File.Delete(outputLockFilePath);
                            }
                            catch (Exception)
                            {
                                Logger.Warn("Unable to unlock the job.");
                            }

                            Logger.PopJob();
                            continue;
                        }

                        #endregion

                        // ****************************************************
                        #region Stage 5: Prepare temporary work dir

                        string tmpOutputDir = null;
                        for (int j = 0; j < 10; j++)
                        {
                            tmpOutputDir = Path.Combine(Path.GetTempPath(), $"{jobName}_{j}");

                            try
                            {
                                if (Directory.Exists(tmpOutputDir))
                                    Directory.Delete(tmpOutputDir, true);
                                Directory.CreateDirectory(tmpOutputDir);
                                break;
                            }
                            catch (Exception)
                            {
                                tmpOutputDir = null;
                            }
                        }

                        if (tmpOutputDir == null)
                        {
                            Logger.Error("Failed to create temporary work dir.");

                            try
                            {
                                File.Delete(outputLockFilePath);
                            }
                            catch (Exception)
                            {
                                Logger.Warn("Unable to unlock the job.");
                            }

                            Logger.PopJob();
                            continue;
                        }

                        #endregion

                        // So far, a job was pushed to logger, a lock file was created, a temporary work dir was created

                        // ****************************************************
                        #region Stage 6: Compute the unfinished job

                        localJobFetched++;
                        jobFetched++;
                        Logger.Info($"Job fetched {jobFetched}");

                        string inputConfFileName = $"{proteinName}_model_{i}.conf";
                        string inputConfFilePath = Path.Combine(proteinDir, inputConfFileName);

                        string errorMessage = null;
                        try
                        {
                            var sw = Stopwatch.StartNew();

                            // Compute docking score
                            float[] scores = ComputeDockingScore(inputConfFilePath, ligandFilePath, Path.Combine(tmpOutputDir, $"{ligandId}.pdbqt"));

                            if (scores == null)
                            {
                                throw new Exception($"Unable to get docking scores, Time elappsed: {sw.Elapsed:g}");
                            }

                            // move result and clean up
                            File.Move(Path.Combine(tmpOutputDir, $"{ligandId}.pdbqt"), outputModelFilePath);
                            File.Move(Path.Combine(tmpOutputDir, $"{ligandId}.log.csv"), outputLogFilePath);

                            localJobFinished++;
                            jobDone++;
                            Logger.Info($"Job done {jobDone}/{jobFetched}, Time elappsed: {sw.Elapsed:g}");
                        }
                        catch (Exception ex)
                        {
                            jobFailed++;
                            errorMessage = ex.Message;
                            Logger.Error($"Job failed {jobFailed}/{jobFetched}", ex);
                        }

                        #endregion

                        // ****************************************************
                        #region Stage 7: Cleanup temporary work dir

                        try
                        {
                            Directory.Delete(tmpOutputDir, true);
                        }
                        catch (Exception)
                        {
                            Logger.Warn($"Unable to delete temporary work dir {tmpOutputDir}");
                        }

                        #endregion

                        // So far, a job was pushed to logger, a lock file was created

                        // ****************************************************
                        #region Stage 8: Unlock the job

                        try
                        {
                            if (errorMessage != null)
                            {
                                File.AppendAllText(outputLockFilePath, $", Message: {errorMessage}");
                                File.Move(outputLockFilePath, outputErrorFilePath);
                            }
                            else
                            {
                                File.Delete(outputLockFilePath);
                            }
                        }
                        catch (Exception)
                        {
                            Logger.Warn("Unable to unlock the job.");
                        }

                        #endregion

                        // So far, a job was pushed to logger

                        Logger.PopJob();

                        // So far, all clear
                    }
                }

                Logger.Info($"===== Summary: {localJobFinished} finished, {localJobFailed} errors, {localJobFetched} fetched =====");
                Logger.PopProtein();
            }

            Logger.EndLog();
        }

        private static void Main()
        {
            ComputeNext(Environment.CurrentDirectory);
        }
    }
}
