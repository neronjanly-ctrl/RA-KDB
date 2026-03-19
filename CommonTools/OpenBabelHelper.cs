using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommonTools;

public class OpenBabelOptions
{
    public string SvgBackColor { get; set; }
    public bool SvgBlackAndWhite { get; set; }
    public bool SvgShowAtomIndex { get; set; }
    public bool SvgDrawAllCarbons { get; set; }
    public bool SvgUseThickerLines { get; set; }
    public bool SvgOmitXmlDeclaration { get; set; }
    public bool SvgUseRealResolution { get; set; }
    public int MaxRunTime { get; set; }
}

public class MolProperties
{
    public string Formula { get; set; }
    public double MolWeight { get; set; }
    public double ExactMass { get; set; }
    public string Smiles { get; set; }
    public string InChI { get; set; }
    public int NumAtoms { get; set; }
    public int NumBonds { get; set; }
    public int NumResidues { get; set; }
    public int NumRotors { get; set; }
    public string Sequence { get; set; }
    public int NumRings { get; set; }
    public double LogP { get; set; }
    public double PSA { get; set; }
    public double MR { get; set; }
}

public static class OpenBabelHelper
{
    public static IReadOnlyDictionary<string, string> ModelFormats { get; } = new Dictionary<string, string>
    {
        { "smi", "SMILES" },
        { "pdb", "Protein Data Bank" },
        { "pdbqt", "AutoDock PDBQT" },
        { "mol2", "Sybyl Mol2" },
        { "sdf", "MDL MOL" },
    };

    public static string SmilesToPdbqt(this string smiles)
    {
        if (string.IsNullOrWhiteSpace(smiles))
            return null;

        if (!ExternalCommand.RunAndWaitNoInput("obabel", $"-ismi -:\"{smiles}\" -omol2", out string stdout, out string stderr))
            return null;
        Match m = Regex.Match(stderr, @"(\d+) molecules? converted");

        if (!m.Success || !int.TryParse(m.Groups[1].Value, out int result) || result <= 0)
            return null;

        if (!ExternalCommand.RunAndWait("obabel", "-imol2 --gen3d -opdbqt", null, stdout, out string stdout2, out string stderr2))
            return null;

        Match m2 = Regex.Match(stderr2, @"(\d+) molecules? converted");

        if (m2.Success && int.TryParse(m2.Groups[1].Value, out int result2) && result2 > 0)
        {
            return stdout2;
        }

        return null;
    }

    public static string PdbqtToSmiles(this string pdbqt)
    {
        if (string.IsNullOrWhiteSpace(pdbqt))
            return null;

        if (!ExternalCommand.RunAndWait("obabel", "-ipdbqt -osmi", null, pdbqt, out string stdout, out string stderr))
            return null;
        Match m = Regex.Match(stderr, @"(\d+) molecules? converted");

        if (m.Success && int.TryParse(m.Groups[1].Value, out int result) && result > 0)
        {
            return stdout;
        }

        return null;
    }

    public static string SmilesToModel(this string smiles, string modelFormat)
    {
        if (string.IsNullOrWhiteSpace(smiles))
            return null;

        if (!ModelFormats.ContainsKey(modelFormat))
            return null;

        if (!ExternalCommand.RunAndWaitNoInput("obabel", $"-ismi -:\"{smiles}\" --gen3d -o{modelFormat}", out string stdout, out string stderr))
            return null;

        Match m = Regex.Match(stderr, @"(\d+) molecules? converted");

        if (m.Success && int.TryParse(m.Groups[1].Value, out int result) && result > 0)
        {
            return stdout;
        }

        return null;
    }

    public static string NormalizeSmiles(this string smiles)
    {
        if (string.IsNullOrWhiteSpace(smiles))
            return null;

        if (!ExternalCommand.RunAndWaitNoInput("obabel", $"-ismi -:\"{smiles}\" -osmi", out string stdout, out string stderr))
            return null;

        Match m = Regex.Match(stderr, @"(\d+) molecules? converted");

        return m.Success ? stdout : null;
    }

    public static string SmilesToSvg(this string smiles, bool use3D, OpenBabelOptions options = null)
    {
        if (string.IsNullOrWhiteSpace(smiles))
            return null;

        string args = string.Empty;
        if (options != null)
        {
            if (!string.IsNullOrWhiteSpace(options.SvgBackColor))
                args += $" -xb{options.SvgBackColor}";
            if (options.SvgBlackAndWhite)
                args += " -xu";
            if (options.SvgDrawAllCarbons)
                args += " -xa";
            if (options.SvgOmitXmlDeclaration)
                args += " -xx";
            if (options.SvgShowAtomIndex)
                args += " -xi";
            if (options.SvgUseThickerLines)
                args += " -xt";
        }

        if (!ExternalCommand.RunAndWaitNoInput("obabel", $"-ismi -:\"{smiles}\" --gen{(use3D ? 3 : 2)}d -osvg{args}", out string stdout, out string stderr, maxRunTime: options.MaxRunTime))
            return null;

        Match m = Regex.Match(stderr, @"(\d+) molecules? converted");

        if (m.Success && int.TryParse(m.Groups[1].Value, out int result) && result > 0)
        {
            if (options?.SvgUseRealResolution == true)
                return AdjustSvgDimensions(stdout);
            return stdout;
        }

        return null;
    }

    private static string AdjustSvgDimensions(string svg)
    {
        if (string.IsNullOrWhiteSpace(svg))
            return null;

        MatchCollection ms = Regex.Matches(svg, $@"viewBox=""0 0 (\d+(?:\.\d+)?) (\d+(?:\.\d+)?)""");
        if (ms.Count != 2)
            return svg;

        string width = ms[1].Groups[1].Value, height = ms[1].Groups[2].Value;

        svg = Regex.Replace(svg, @" width=""100"" height=""100""", "");
        svg = Regex.Replace(svg, @" viewBox=""0 0 100 100""", "");
        svg = Regex.Replace(svg, @"width=""200px"" height=""200px""", $@"width=""{width}px"" height=""{height}px""");

        return svg;
    }

    public static IEnumerable<string> FingerprintTypes { get; } = new[]
    {
        "MACCS",
        "FP2",
        "FP3",
        "FP4",
        // Extended-Connectivity Fingerprints (ECFPs)
        "ECFP0",
        "ECFP2",
        "ECFP4",
        "ECFP6",
        "ECFP8",
        "ECFP10",
    };

    public static byte[] ComputeFingerprint(this string smiles, string type)
    {
        if (string.IsNullOrEmpty(smiles))
            return null;

        if (!FingerprintTypes.Contains(type))
            return null;

        if (!ExternalCommand.RunAndWaitNoInput("obabel", $"-ismi -:\"{smiles}\" -ofpt -xf{type}", out string stdout, out string stderr))
            return null;

        Match m = Regex.Match(stderr, @"(\d+) molecules? converted");

        if (!m.Success)
            return null;

        Match m2 = Regex.Match(stdout, @"([0-9a-f]{8}\s+){1,42}");
        return !m2.Success ? null : m2.Value.ToBytes();
    }

    public static MolProperties ComputeMolProp(this string smiles)
    {
        if (string.IsNullOrEmpty(smiles))
            return null;

        string filename = Path.GetTempFileName() + ".sdf";
        if (!ExternalCommand.RunAndWaitNoInput("obabel", $"-ismi -:\"{smiles}\" -osdf -O \"{filename}\"", out string stdout2, out string stderr2))
        {
            File.Delete(filename);
            return null;
        }

        if (!ExternalCommand.RunAndWait("obprop", filename, null, out string stdout, out string stderr))
        {
            File.Delete(filename);
            return null;
        }

        MatchCollection ms = Regex.Matches(stdout, @"^(\w+)\s+(.+)$");
        Dictionary<string, string> dict = ms.Cast<Match>().ToDictionary(o => o.Groups[1].Value, o => o.Groups[2].Value);

        return new MolProperties
        {
            Formula = dict["formula"],
            MolWeight = double.Parse(dict["mol_weight"]),
            ExactMass = double.Parse(dict["exact_mass"]),
            Smiles = dict["canonical_SMILES"],
            InChI = dict["InChI"],
            NumAtoms = int.Parse(dict["num_atoms"]),
            NumBonds = int.Parse(dict["num_bonds"]),
            NumResidues = int.Parse(dict["num_residues"]),
            NumRotors = int.Parse(dict["num_rotors"]),
            Sequence = dict["sequence"],
            NumRings = int.Parse(dict["num_rings"]),
            LogP = double.Parse(dict["logP"]),
            PSA = double.Parse(dict["PSA"]),
            MR = double.Parse(dict["MR"]),
        };
    }
}
