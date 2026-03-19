using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommonTools;

public static class FingerprintFile
{
    public static int CurrentVersion => 4;
    public static int MinimumVersion => 3;
    public static string HeaderSign => "MFP";

    public static IReadOnlyDictionary<string, int> FingerprintLengths { get; } = new Dictionary<string, int>
    {
        {"MACCS", 32},
        {"FP2", 128},
        {"FP3", 8},
        {"FP4", 64},
        // Extended-Connectivity Fingerprints (ECFPs)
        {"ECFP0", 68},
        {"ECFP2", 136},
        {"ECFP4", 168},
        {"ECFP6", 168},
        {"ECFP8", 168},
        {"ECFP10", 168},
    };

    #region Header reader/writer

    private static int ReadHeader(BinaryReader br, out int count, out string fptype)
    {
        // 8 bytes: sign
        string sign = new(br.ReadChars(8));

        if (!sign.StartsWith(HeaderSign))
            throw new Exception("Input is not a valid fingerprint format.");

        fptype = sign[3..].TrimEnd('_');
        if (fptype == "ECFP1")
            fptype = "ECFP10";

        if (fptype != "INDEX" && !OpenBabelHelper.FingerprintTypes.Contains(fptype))
            throw new Exception($"Invalid fingerprint type {fptype}");

        // 4 bytes: current version
        int ver = br.ReadInt32();
        if (ver < MinimumVersion || ver > CurrentVersion)
            throw new Exception($"Fingerprint format version {ver} is not supported.");

        // At position 12
        // 4 bytes: ligand count, will update later
        count = br.ReadInt32();
        if (count < 0)
            throw new Exception("Fingerprint file corrupted.");

        return ver;
    }

    private static void WriteHeader(BinaryWriter bw, int version, string fptype, out long countPos)
    {
        if (fptype != "INDEX" && !OpenBabelHelper.FingerprintTypes.Contains(fptype))
            throw new Exception($"Invalid fingerprint type {fptype}");

        if (version < MinimumVersion || version > CurrentVersion)
            throw new Exception($"Fingerprint format version {version} is not supported.");

        char[] sign = $"{HeaderSign}{fptype.PadRight(5, '_')[..5]}".ToCharArray();

        // 8 bytes: header
        bw.Write(sign);

        // 4 bytes: format version
        bw.Write(version);

        // At position 12
        countPos = bw.BaseStream.Position;

        // 4 bytes: ligand count, will update later
        bw.Write(0);
    }

    #endregion

    #region Data reader/writer

    public static Dictionary<string, (string Smiles, byte[] Fingerprint)> ReadAllDataV3(string path)
    {
        if (path == null)
            throw new ArgumentNullException(nameof(path));

        IEnumerable<(string Id, string Smiles, byte[] Fingerprint)> data = InternalReadAllDataV3(path);
        return data.ToDictionary(o => o.Id, o => (o.Smiles, o.Fingerprint));
    }

    private static IEnumerable<(string Id, string Smiles, byte[] Fingerprint)> InternalReadAllDataV3(string path)
    {
        using FileStream fs = new(path, FileMode.Open, FileAccess.Read);
        using BinaryReader br = new(fs);
        ReadHeader(br, out int count, out string fptype);
        int fplen = FingerprintLengths[fptype];

        for (int i = 0; i < count; i++)
        {
            // Variable length bytes: prefix length + length of id
            string id = br.ReadString();

            // Variable length bytes: prefix length + length of smiles
            string smiles = br.ReadString();

            // Fixed length bytes: Fingerprint
            byte[] fp = br.ReadBytes(fplen);

            yield return (id, smiles, fp);
        }

        br.Close();
    }

    public static Dictionary<string, (string Smiles, int Activity, byte[] Fingerprint)> ReadAllData(string path)
    {
        if (path == null)
            throw new ArgumentNullException(nameof(path));

        IEnumerable<(string Id, string Smiles, int Activity, byte[] Fingerprint)> data = InternalReadAllData(path);
        return data.ToDictionary(o => o.Id, o => (o.Smiles, o.Activity, o.Fingerprint));
    }

    private static IEnumerable<(string Id, string Smiles, int Activity, byte[] Fingerprint)> InternalReadAllData(string path)
    {
        using FileStream fs = new(path, FileMode.Open, FileAccess.Read);
        using BinaryReader br = new(fs);
        ReadHeader(br, out int count, out string fptype);
        int fplen = FingerprintLengths[fptype];

        for (int i = 0; i < count; i++)
        {
            // Variable length bytes: prefix length + length of id
            string id = br.ReadString();

            // Variable length bytes: prefix length + length of smiles
            string smiles = br.ReadString();

            // Fixed length bytes: 4 bytes
            int activity = br.ReadInt32();

            // Fixed length bytes: Fingerprint
            byte[] fp = br.ReadBytes(fplen);

            yield return (id, smiles, activity, fp);
        }

        br.Close();
    }

    public static Dictionary<string, long> WriteAllDataV3(string path, string fptype, IEnumerable<(string Id, string Smiles, byte[] Fingerprint)> data)
    {
        if (path == null)
            throw new ArgumentNullException(nameof(path));
        if (fptype == null)
            throw new ArgumentNullException(nameof(fptype));
        if (data == null)
            throw new ArgumentNullException(nameof(data));
        if (!OpenBabelHelper.FingerprintTypes.Contains(fptype))
            throw new ArgumentException("Unrecognized fingerprint type", nameof(fptype));
        if (fptype.Length > 5)
            throw new ArgumentException("Argument length beyond range.", nameof(fptype));

        IEnumerable<(string Id, long Position)> indices = InternalWriteAllDataV3(path, fptype, data);
        return indices.ToDictionary(o => o.Id, o => o.Position);
    }

    public static Dictionary<string, long> WriteAllData(string path, string fptype, IEnumerable<(string Id, string Smiles, int Activity, byte[] Fingerprint)> data)
    {
        if (path == null)
            throw new ArgumentNullException(nameof(path));
        if (fptype == null)
            throw new ArgumentNullException(nameof(fptype));
        if (data == null)
            throw new ArgumentNullException(nameof(data));
        if (!OpenBabelHelper.FingerprintTypes.Contains(fptype))
            throw new ArgumentException("Unrecognized fingerprint type", nameof(fptype));
        if (fptype.Length > 5)
            throw new ArgumentException("Argument length beyond range.", nameof(fptype));

        IEnumerable<(string Id, long Position)> indices = InternalWriteAllData(path, fptype, data);
        return indices.ToDictionary(o => o.Id, o => o.Position);
    }

    private static IEnumerable<(string Id, long Position)> InternalWriteAllDataV3(string path, string fptype, IEnumerable<(string Id, string Smiles, byte[] Fingerprint)> data)
    {
        using FileStream fs = new(path, FileMode.Create, FileAccess.Write);
        using BinaryWriter bw = new(fs);
        WriteHeader(bw, 3, fptype, out long countPos);

        int count = 0;
        foreach ((string id, string smiles, byte[] fingerprint) in data)
        {
            fptype.ValidateDataV3(id, smiles, fingerprint);

            // Store current position
            long pos = bw.BaseStream.Position;

            // Variable length bytes: prefix length + length of id
            bw.Write(id);

            // Variable length bytes: prefix length + length of smiles
            bw.Write(smiles);

            // Fixed length bytes: Fingerprint
            bw.Write(fingerprint);

            count++;
            yield return (id, pos);
        }

        bw.Seek((int)countPos, SeekOrigin.Begin);
        bw.Write(count);

        bw.Flush();
        bw.Close();
    }

    private static IEnumerable<(string Id, long Position)> InternalWriteAllData(string path, string fptype, IEnumerable<(string Id, string Smiles, int Activity, byte[] Fingerprint)> data)
    {
        using FileStream fs = new(path, FileMode.Create, FileAccess.Write);
        using BinaryWriter bw = new(fs);
        WriteHeader(bw, 4, fptype, out long countPos);

        int count = 0;
        foreach ((string id, string smiles, int activity, byte[] fingerprint) in data)
        {
            fptype.ValidateDataV3(id, smiles, fingerprint);
            if (activity < -1 || activity > 1)
                throw new ArgumentOutOfRangeException(nameof(activity));

            // Store current position
            long pos = bw.BaseStream.Position;

            // Variable length bytes: prefix length + length of id
            bw.Write(id);

            // Variable length bytes: prefix length + length of smiles
            bw.Write(smiles);

            // Fixed length bytes: 4 bytes
            bw.Write(activity);

            // Fixed length bytes: Fingerprint
            bw.Write(fingerprint);

            count++;
            yield return (id, pos);
        }

        bw.Seek((int)countPos, SeekOrigin.Begin);
        bw.Write(count);

        bw.Flush();
        bw.Close();
    }

    private static void ValidateDataV3(this string fptype, string id, string smiles, byte[] fp)
    {
        if (fptype == null)
            throw new ArgumentNullException(nameof(fptype));
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentNullException(nameof(id), "Data contains blank ligand id.");
        if (string.IsNullOrWhiteSpace(smiles))
            throw new ArgumentNullException(nameof(smiles), $"Data contains blank smiles for id {id}.");
        if (fp == null)
            throw new ArgumentNullException(nameof(fp), $"Data contains null fingerprint for id {id}.");
        if (FingerprintLengths[fptype] != fp.Length)
            throw new ArgumentException(nameof(fp), $"Data contains wrong fingerprint length {fp.Length} for id {id}.");
    }

    #endregion

    #region Index reader/writer

    public static ILookup<long, long> ReadAllIndices(string path)
    {
        if (path == null)
            throw new ArgumentNullException(nameof(path));

        IEnumerable<(long Key, long Position)> indicies = InternalReadAllIndices(path);
        return indicies.ToLookup(o => o.Key, o => o.Position);
    }

    private static IEnumerable<(long Key, long Position)> InternalReadAllIndices(string path)
    {
        using FileStream fs = new(path, FileMode.Open, FileAccess.Read);
        using BinaryReader br = new(fs);
        ReadHeader(br, out int count, out string fptype);

        if (fptype != "INDEX")
            throw new Exception("Input is not a valid fingerprint index format.");

        for (int i = 0; i < count; i++)
        {
            // 8 bytes: index key
            long key = br.ReadInt64();

            // 8 bytes: position
            long pos = br.ReadInt64();

            yield return (key, pos);
        }

        br.Close();
    }

    public static void WriteAllIndices(string path, IReadOnlyDictionary<string, long> indices)
    {
        if (path == null)
            throw new ArgumentNullException(nameof(path));
        if (indices == null)
            throw new ArgumentNullException(nameof(indices));

        using FileStream fs = new(path, FileMode.Create, FileAccess.Write);
        using BinaryWriter bw = new(fs);
        WriteHeader(bw, 3, "INDEX", out long countPos);

        int count = 0;
        foreach (var ligand in indices
            .Select(o => new { Key = o.Key.ComputeHashInt64(), o.Value })
            .OrderBy(o => o.Key))
        {
            // 8 bytes: key
            bw.Write(ligand.Key);

            // 8 bytes: position
            bw.Write(ligand.Value);

            count++;
        }

        bw.Seek((int)countPos, SeekOrigin.Begin);
        bw.Write(count);

        bw.Flush();
        bw.Close();
    }

    #endregion

    #region Index lookup

    public static byte[] LookupFingerprint(this ILookup<long, long> lookup, string path, string ligandId)
    {
        long[] result = lookup[ligandId.ComputeHashInt64()].ToArray();

        if (!result.Any())
            return null;

        using FileStream fs = new(path, FileMode.Open, FileAccess.Read);
        using BinaryReader br = new(fs);
        int ver = ReadHeader(br, out int _, out string fptype);

        int fplen = FingerprintLengths[fptype];

        foreach (long pos in result)
        {
            br.BaseStream.Seek(pos, SeekOrigin.Begin);

            string id = br.ReadString();
            if (id != ligandId)
                continue;

            br.ReadString();
            if (ver == 4)
                br.ReadInt32();

            byte[] fp = br.ReadBytes(fplen);

            br.Close();
            return fp;
        }

        br.Close();

        return null;
    }

    #endregion
}
