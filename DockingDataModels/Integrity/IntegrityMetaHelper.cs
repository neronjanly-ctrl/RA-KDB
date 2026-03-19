using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DockingDataModels;

public static class IntegrityMetaHelper<TIntegrity>
        where TIntegrity : IIntegrity
{
    public static Dictionary<PropertyInfo, IntegrityMetaAttribute> MetaDict = typeof(TIntegrity).GetProperties()
        .Where(o => o.CanRead && o.CanWrite)
        .Where(o => o.PropertyType == typeof(bool))
        .Select(o => new { Prop = o, Meta = o.GetCustomAttributes<IntegrityMetaAttribute>(false).FirstOrDefault() })
        .Where(o => o.Meta != null)
        .ToDictionary(o => o.Prop, o => o.Meta);

    public static string[] FileNames = MetaDict.Values.Select(o => o.FileName).ToArray();
    public static IntegrityMetaAttribute[] Meta = MetaDict.Values.ToArray();
}
