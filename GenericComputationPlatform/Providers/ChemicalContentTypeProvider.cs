using ChemicalFunctions;
using Microsoft.AspNetCore.StaticFiles;

namespace GenericComputationPlatform.Providers;

public class ChemicalContentTypeProvider : FileExtensionContentTypeProvider
{
    public ChemicalContentTypeProvider()
    {
        // Use provider.Mappings to add new MIME types.
        // Providing a dictionary argument to the constructor will replace all built-in MIME types.

        // see https://en.wikipedia.org/wiki/Chemical_file_format#The_Chemical_MIME_Project

        string[] exts = new[] { ".mol2", ".sdf", ".pdb", ".pdbqt", ".smi" };
        foreach (string ext in exts)
        {
            Mappings[ext] = ChemicalFormatExtensions.MimeTypes[ext];
        }

        Mappings.Remove(".sh");
    }
}
