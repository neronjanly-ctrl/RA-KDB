using System;

namespace CommonTools;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class NameAttribute : Attribute
{
    public NameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public string InternalName { get; set; }
}
