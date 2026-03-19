using CommonTools;

namespace DockingDataModels;

public enum Fingerprint
{
    [Match("MACCS")]
    [Name("MACCS", InternalName = "MACCS")]
    MACCS,

    [Match("FP2")]
    [Name("FP2", InternalName = "FP2")]
    FP2,

    [Match("FP3")]
    [Name("FP3", InternalName = "FP3")]
    FP3,

    [Match("FP4")]
    [Name("FP4", InternalName = "FP4")]
    FP4,

    [Match("ECFP0")]
    [Name("ECFP0", InternalName = "ECFP0")]
    ECFP0,

    [Match("ECFP2")]
    [Name("ECFP2", InternalName = "ECFP2")]
    ECFP2,

    [Match("ECFP4")]
    [Name("ECFP4", InternalName = "ECFP4")]
    ECFP4,

    [Match("ECFP6")]
    [Name("ECFP6", InternalName = "ECFP6")]
    ECFP6,

    [Match("ECFP8")]
    [Name("ECFP8", InternalName = "ECFP8")]
    ECFP8,

    [Match("ECFP10")]
    [Name("ECFP10", InternalName = "ECFP10")]
    ECFP10,
}
