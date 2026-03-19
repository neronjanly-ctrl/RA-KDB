using System;

namespace DockingDataModels;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public sealed class IntegrityMetaAttribute : Attribute
{
    public string FileName { get; }

    public string AlternativeFileName { get; set; }

    public bool Manual { get; }

    public bool RequiredForComputation { get; set; }

    public bool RequiredForVisualization { get; set; }

    public IntegrityMetaAttribute(string name, bool isManual = false)
    {
        FileName = name;
        Manual = isManual;
    }
}
