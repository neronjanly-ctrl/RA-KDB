using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DockingDataModels;

public static class IntegrityMetaExtensions
{
    public static void Validate<TIntegrity>(this TIntegrity integrity, string dirpath, string subname = null)
        where TIntegrity : IIntegrity
    {
        foreach ((PropertyInfo prop, IntegrityMetaAttribute attr) in IntegrityMetaHelper<TIntegrity>.MetaDict)
        {
            prop.SetValue(integrity, File.Exists(Path.Combine(dirpath, string.Format(attr.FileName, subname)))
                || attr.AlternativeFileName != null && File.Exists(Path.Combine(dirpath, string.Format(attr.AlternativeFileName, subname))));
        }
    }

    public static bool IsDataComplete<TIntegrity>(this TIntegrity integrity)
        where TIntegrity : IIntegrity
    {
        return IntegrityMetaHelper<TIntegrity>
            .MetaDict
            .Keys
            .All(o => (bool)o.GetValue(integrity));
    }

    public static bool IsManualDataComplete<TIntegrity>(this TIntegrity integrity)
        where TIntegrity : IIntegrity
    {
        return IntegrityMetaHelper<TIntegrity>
            .MetaDict
            .Where(o => o.Value.Manual)
            .All(o => (bool)o.Key.GetValue(integrity));
    }

    public static bool IsAutomaticDataComplete<TIntegrity>(this TIntegrity integrity)
        where TIntegrity : IIntegrity
    {
        return IntegrityMetaHelper<TIntegrity>
            .MetaDict
            .Where(o => !o.Value.Manual)
            .All(o => (bool)o.Key.GetValue(integrity));
    }

    public static bool IsRequiredDataComplete<TIntegrity>(this TIntegrity integrity)
        where TIntegrity : IIntegrity
    {
        return IntegrityMetaHelper<TIntegrity>
            .MetaDict
            .Where(o => o.Value.RequiredForComputation || o.Value.RequiredForVisualization)
            .All(o => (bool)o.Key.GetValue(integrity));
    }

    public static bool IsReadyForComputation<TIntegrity>(this TIntegrity integrity)
        where TIntegrity : IIntegrity
    {
        return IntegrityMetaHelper<TIntegrity>
            .MetaDict
            .Where(o => o.Value.RequiredForComputation)
            .All(o => (bool)o.Key.GetValue(integrity));
    }

    public static bool IsReadyForVisualization<TIntegrity>(this TIntegrity integrity)
        where TIntegrity : IIntegrity
    {
        return IntegrityMetaHelper<TIntegrity>
            .MetaDict
            .Where(o => o.Value.RequiredForVisualization)
            .All(o => (bool)o.Key.GetValue(integrity));
    }

    public static List<FileReport> GetFiles<TIntegrity>(this TIntegrity integrity, bool noExistingFiles, bool noOptionalFiles)
        where TIntegrity : IIntegrity
    {
        return IntegrityMetaHelper<TIntegrity>
            .MetaDict
            .Select(o => new FileReport
            {
                FileName = o.Value.FileName,
                Manual = o.Value.Manual,
                RequiredForComputation = o.Value.RequiredForComputation,
                RequiredForVisualization = o.Value.RequiredForVisualization,
                Exists = (bool)o.Key.GetValue(integrity)
            })
            .Where(o => !noExistingFiles || !o.Exists)
            .Where(o => !noOptionalFiles || o.RequiredForComputation || o.RequiredForVisualization)
            .ToList();
    }
}
