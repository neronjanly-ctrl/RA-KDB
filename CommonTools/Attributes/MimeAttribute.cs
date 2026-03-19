using System;

namespace CommonTools;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class MimeAttribute : Attribute
{
    public MimeAttribute(string mimeType, string description, params string[] extensions)
    {
        MimeType = mimeType;
        Description = description;
        Extensions = extensions;
    }

    public string MimeType { get; private set; }
    public string Description { get; private set; }
    public string[] Extensions { get; private set; }
}
