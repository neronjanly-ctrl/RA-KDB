using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonTools;

public static class GpcrnHelper
{
    public enum Scheme
    {
        [Name("Ballesteros-Weinstein (Class A)", InternalName = "BW")]
        BW,       // BWA, BW         (default) Ballesteros-Weinstein (Class A)
        [Name("Wootten (Class B)", InternalName = "Wootten")]
        Wootten,  // WB, Wootten     Wootten (Class B)
        [Name("Pin (Class C)", InternalName = "Pin")]
        Pin,      // PC, Pin         Pin (Class C)
        [Name("Wang (Class F)", InternalName = "Wang")]
        Wang,     // WF, Wang        Wang (Class F)
        [Name("GPCRdb (Class A)", InternalName = "GPCRdbA")]
        GPCRdbA,  // GA, GPCRdbA     GPCRdb (Class A)
        [Name("GPCRdb (Class B)", InternalName = "GPCRdbB")]
        GPCRdbB,  // GB, GPCRdbB     GPCRdb (Class B)
        [Name("GPCRdb (Class C)", InternalName = "GPCRdbC")]
        GPCRdbC,  // GC, GPCRdbC     GPCRdb (Class C)
        [Name("GPCRdb (Class F)", InternalName = "GPCRdbF")]
        GPCRdbF,  // GF, GPCRdbF     GPCRdb (Class F)
        [Name("Oliveira", InternalName = "O")]
        Oliveira, // O, Oliveira     Oliveira
        [Name("Baldwin-Schwartz", InternalName = "BS")]
        BS,       // BS              Baldwin-Schwartz
    }

    public static Dictionary<int, string> GetGpcrNumberings(this string target, Scheme scheme = Scheme.BW)
    {
        if (!ExternalCommand.RunAndWait("gpcrn", $"-Hus{scheme} {target.Trim()}:", null, out string stdout))
            return null;
        return stdout.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .ToDictionary(o => int.Parse(o.Substring(39, 3)), o => o[44..]);
    }

    public static (string symbol, string species, string gene_name, string uniprot_id) GetProperties(this string uniProtId)
    {
        if (!ExternalCommand.RunAndWait("gpcrn", $"-Hu {uniProtId}:1", null, out string stdout))
            return default;
        if (string.IsNullOrWhiteSpace(stdout))
            return ("Unknown", "Unknown", "Unknown", uniProtId);
        string[] fields = stdout[..14].TrimEnd().Split('_');
        return (fields[0], fields[1], stdout.Substring(14, 9).TrimEnd(), stdout.Substring(23, 10).TrimEnd());
    }

    public static Dictionary<string, int> GetGpcrResidueSeqs(this string target, Scheme scheme = Scheme.BW)
    {
        if (!ExternalCommand.RunAndWait("gpcrn", $"-Hus{scheme} {target.Trim()}:", null, out string stdout))
            return null;
        return stdout
            .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .ToDictionary(o => o[44..], o => int.Parse(o.Substring(39, 3)));
    }

    public static string GetGpcrNumbering(this string target, int residueSeq, Scheme scheme = Scheme.BW)
    {
        if (!ExternalCommand.RunAndWait("gpcrn", $"-Hus{scheme} {target.Trim()}:{residueSeq}", null, out string stdout))
            return null;
        return stdout
            .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(o => o[44..])
            .FirstOrDefault();
    }

    public static int? GetGpcrResidueSeq(this string target, string numbering, Scheme scheme = Scheme.BW)
    {
        if (!ExternalCommand.RunAndWait("gpcrn", $"-Hus{scheme} {target.Trim()}:{numbering.Trim()}", null, out string stdout))
            return null;
        return stdout
            .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(o => int.TryParse(o.Substring(39, 3), out int seq) ? seq : (int?)null)
            .FirstOrDefault();
    }
}
