using CommonTools;
using DockingDataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DockingApiService.Services;

/// <summary>
/// Pure computation, not database dependent
/// </summary>
public class ComputingService
{
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _config;
    private readonly ILogger _log;
    private readonly string _docker;

    public ComputingService(IWebHostEnvironment env, IConfiguration config, ILogger<ComputingService> logger)
    {
        _env = env;
        _config = config;
        _docker = _config["ExternalPrograms:Docker"];
        _log = logger;
    }

    public float? ComputeDockingScore(string confPath, string receptorPath, string ligandPath, string outputPath)
    {
        if (!File.Exists(confPath))
            throw new FileNotFoundException($"Cannot find config file for {_docker}.", confPath);

        if (!File.Exists(ligandPath))
            throw new FileNotFoundException($"Cannot find ligand file for {_docker}.", ligandPath);

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!Directory.Exists(outputDir))
            throw new DirectoryNotFoundException($"Cannot find output directory for {_docker}. {outputDir}");

        if (outputDir == Path.GetDirectoryName(ligandPath))
            throw new ArgumentException($"Directory {outputDir} for ligand and output cannot be the same.");

        string outputLogPath = Path.ChangeExtension(outputPath, ".log.csv");
        string ligandNameWoExt = Path.GetFileNameWithoutExtension(ligandPath);

        if (File.Exists(outputPath) ^ File.Exists(outputLogPath))
        {
            File.Delete(outputPath);
            File.Delete(outputLogPath);
        }

        if (!File.Exists(outputPath))
        {
            // Since receptor file path is relative to config file, we use config directory as our work directory.
            string confDir = Path.GetDirectoryName(confPath);
            string confName = Path.GetFileName(confPath);

            string args = $"--receptor {receptorPath} --config {confName} --ligand {ligandPath} --out {outputDir}";
            if (ExternalCommand.RunAndWait(_config["ExternalPrograms:Docker"], args, confDir, out string stdout, out string stderr))
            {
                float? score = ParseDockerOutput(stdout, ligandNameWoExt);
                string targetName = Path.GetFileNameWithoutExtension(receptorPath);
                string logfile = Path.Combine(outputDir, $"{targetName}.csv");

                if (score != null)
                {
                    // Rename output model and log file
                    File.Move(Path.Combine(outputDir, Path.GetFileName(ligandPath)), outputPath);
                    File.Move(logfile, outputLogPath);

                    return score;
                }

                // remove log file for failed running
                if (File.Exists(logfile))
                    File.Delete(logfile);

                if (score == null)
                {
                    throw new Exception($"Error while executing {_config["ExternalPrograms:Docker"]} {args}\n Error output:\n{stderr}");
                }
            }
        }
        else
        {
            string logText = File.ReadAllText(outputLogPath);
            return ParseDockerLog(logText, ligandNameWoExt);
        }

        return null;
    }

    private static float? ParseDockerOutput(string data, string ligandName)
    {
        // Parse docker result
        Match m = Regex.Match(data, $@"^\s*\d+\|?\s*""?{ligandName}""?\|?\s*\d+\|?\s*\d+\|?\s*\d+\|?\s*(-?\d+\.\d+)\s*(\|?(-?\d+\.\d+)\s*)?$",
            RegexOptions.Multiline);

        if (m.Success)
        {
            float score = float.Parse(m.Groups[1].Captures[0].Value);
            //float rfscore = float.Parse(m.Groups[2].Captures[0].Value);

            return score;
        }

        return null;
    }

    private static float? ParseDockerLog(string data, string ligandName)
    {
        Match m = Regex.Match(data, $@"^""?{ligandName}""?,\d+,\d+,\d+,(-?\d+\.\d+)(,(-?\d+\.\d+))?\r?$",
            RegexOptions.Multiline);

        if (m.Success)
        {
            float score = float.Parse(m.Groups[1].Value);
            //float rfscore = float.Parse(m.Groups[2].Value);

            return score;
        }

        return null;
    }

    private static int[] BitsSet { get; } =
        Enumerable.Range(0, 256)
            .Select(o => Enumerable.Range(0, 8).Sum(p => (o >> p) & 1))
            .ToArray();

    public static float? ComputeTanimotoScore(byte[] fp1, byte[] fp2)
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

    public SimilarChemblCompound[] ComputeSimilarityScore(string proteinName, byte[] fingerprint)
    {
        string filepath = Path.Combine(_env.ContentRootPath, "Workspace", "Receptors", proteinName, $"{proteinName}_ChemblCompounds.fp2");

        if (!File.Exists(filepath))
            return null;

        SimilarChemblCompound bestActive = null, best = null;

        foreach ((string id, (string smiles, int activity, byte[] fp)) in FingerprintFile.ReadAllData(filepath))
        {
            float? score = ComputeTanimotoScore(fp, fingerprint);

            if (score <= bestActive?.Similarity)
                continue;

            BioActivity act = activity switch
            {
                0 => BioActivity.Moderate,
                1 => BioActivity.Active,
                -1 => BioActivity.Inactive,
                _ => BioActivity.Unknown
            };

            if (act != BioActivity.Active && score <= best?.Similarity)
                continue;

            SimilarChemblCompound comp = new()
            {
                Id = id,
                Smiles = smiles,
                Activity = act,
                Similarity = score.Value,
                Fingerprint = fp,
            };

            if (act == BioActivity.Active)
            {
                bestActive = comp;
                if (best == null || score > best.Similarity)
                    best = comp;
            }
            else
            {
                best = comp;
            }
        }

        return new[] { best, bestActive };
    }

    public Prediction ComputePrediction(string modelName, params float?[] scores)
    {
        // The trained classifier requires 3 docking score and 1 similarity score.
        Debug.Assert(scores.Length == 4);

        // Prepare the arguments
        string workdir = Path.Combine(_env.ContentRootPath, "Workspace");
        object[] args = new object[]
        {
            Path.Combine(workdir, _config["ExternalPrograms:Predictor"]),
            modelName,
            scores[0],
            scores[1],
            scores[2],
            scores[3],
        };

        // Run the prediction
        if (ExternalCommand.RunAndWait(_config["ExternalPrograms:Python"], string.Join(' ', args), Path.Combine(workdir, "Receptors"), out string stdout, out string stderr))
        {
            Match m = Regex.Match(stdout, @"(-?\d+) (?:N/A|(\d+(?:\.\d+)?)%)");

            if (m.Success)
            {
                int prediction = int.Parse(m.Groups[1].Value);
                BioActivity pred = prediction switch
                {
                    -1 => BioActivity.Inactive,
                    0 => BioActivity.Moderate,
                    1 => BioActivity.Active,
                    _ => BioActivity.Unknown,
                };
                if (float.TryParse(m.Groups[2].Value, out float result))
                    return new Prediction { Activity = pred, ConfidenceLevel = result / 100 };
                return new Prediction { Activity = pred, ConfidenceLevel = null };
            }
        }

        _log.LogError($"Error while running predictor {_config["ExternalPrograms:Python"]} {string.Join(' ', args)} at {Path.Combine(workdir, "Receptors")}. output: {stdout}, error: {stderr}");

        return null;
    }

    public string GetDockerName()
    {
        if (ExternalCommand.RunAndWait(_config["ExternalPrograms:Docker"], "--version", null, out string stdout) && Regex.IsMatch(stdout, @"\d+\.\d+"))
        {
            return $"{_docker} {stdout.Trim(" \r\n\t\v".ToCharArray())}";
        }
        throw new Exception($"Failed to fetch {_docker} version");
    }

    public static float[] ParseSearchingSpace(string confpath)
    {
        float[] res = new float[6];
        bool[] used = new bool[6];
        foreach (string line in File.ReadAllLines(confpath))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;
            string[] fields = line.Split('=').Select(o => o.Trim()).ToArray();
            if (fields.Length != 2 || !float.TryParse(fields[1], out float val))
                throw new InvalidDataException($"Conf file {confpath} contains invalid data format.");
            int id = fields[0] switch
            {
                "center_x" => 0,
                "center_y" => 1,
                "center_z" => 2,
                "size_x" => 3,
                "size_y" => 4,
                "size_z" => 5,
                _ => throw new InvalidDataException($"Conf file {confpath} contains unknown name {fields[0]}")
            };
            if (used[id])
                throw new InvalidDataException($"Conf file {confpath} contains duplicate field {fields[0]}");
            used[id] = true;
            res[id] = val;
        }
        if (!used.All(o => o))
            throw new InvalidDataException($"Conf file {confpath} has missing fields");
        return res;
    }
}
