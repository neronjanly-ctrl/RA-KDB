using System.IO;

namespace CommonTools;

public static class PropkaHelper
{
    public static bool CalcPka(this string filepath)
    {
        if (string.IsNullOrWhiteSpace(filepath))
            return false;

        if (!File.Exists(filepath))
            return false;

        string dir = Path.GetDirectoryName(filepath);

        if (!ExternalCommand.RunAndWait("propka31", $"\"{filepath}\"", dir, out string stdout))
        {
            return false;
        }

        if (!File.Exists(Path.ChangeExtension(filepath, ".pka")))
        {
            return false;
        }

        return true;
    }
}
