using CommonTools;

namespace DockingDataModels;

public enum BbbFingerprint : int
{
    // Name.Name for being shown on page
    // Name.InternalName as argument passing to cbligand.org/BBB
    [Match("MACCS")]
    [Name("MACCS", InternalName = "MACCS")]
    MACCS = 0,

    [Match("PubChem")]
    [Name("PubChem", InternalName = "PubChem")]
    PubChem = 1,

    [Match("Molprint2D")]
    [Name("Molprint 2D", InternalName = "Molprint2D")]
    Molprint2D = 2,

    [Match("FP2", "DayLight")]
    [Name("FP2", InternalName = "DayLight")]
    FP2 = 3,
}
