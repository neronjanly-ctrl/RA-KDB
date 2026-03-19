using System.IO;
using System.IO.Compression;

namespace CommonTools;

public static class CompressionHelper
{
    public static byte[] DecompressGzip(byte[] bytes)
    {
        using (MemoryStream instream = new(bytes))
        using (GZipStream compressed = new(instream, CompressionMode.Decompress))
        using (MemoryStream outstream = new())
        {
            compressed.CopyTo(outstream);
            return outstream.ToArray();
        }
    }

    public static byte[] DecompressZip(byte[] bytes)
    {
        string tmp = Path.GetTempFileName();
        File.WriteAllBytes(tmp, bytes);

        string tmpdir = Path.GetTempFileName();
        File.Delete(tmpdir);
        Directory.CreateDirectory(tmpdir);

        ZipFile.ExtractToDirectory(tmp, tmpdir);
        File.Delete(tmp);

        string[] files = Directory.GetFiles(tmpdir);
        if (files.Length > 1)
            ; // More than a single file

        byte[] data = File.ReadAllBytes(files[0]);
        Directory.Delete(tmpdir, true);
        return data;
    }
}
