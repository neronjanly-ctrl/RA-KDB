using System.IO;

namespace CommonTools;

public static class VegaHelper
{
    public static string SmilesToPdbqtVega(this string smiles)
    {
        if (string.IsNullOrWhiteSpace(smiles))
            return null;

        string pdb = smiles.SmilesToModel("pdb");
        if (pdb == null)
            return null;

        string tmp = Path.GetTempFileName();
        string pdbName = $"{tmp}.pdb";
        File.Move(tmp, pdbName);
        File.WriteAllText(pdbName, pdb);

        if (!ExternalCommand.RunAndWaitNoInput("vega", $"{pdbName} -o {pdbName}qt -f VINA -c Gasteiger -p VINA -l GEN -r APOLAR -j FLEX -w", out string stdout, out string stderr))
        {
            File.Delete(pdbName);
            return null;
        }

        File.Delete(pdbName);

        string pdbqtName = $"{pdbName}qt";
        if (File.Exists(pdbqtName))
        {
            string pdbqt = File.ReadAllText(pdbqtName);
            File.Delete(pdbqtName);
            return pdbqt;
        }

        return null;
    }
}
