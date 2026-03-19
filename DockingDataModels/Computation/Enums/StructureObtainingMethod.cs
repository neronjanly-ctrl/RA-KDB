namespace DockingDataModels;

public enum StructureObtainingMethod
{
    /// <summary>
    /// Unknown method
    /// </summary>
    Unknown,

    /// <summary>
    /// Obtained by imaging technique other than by modeling
    /// </summary>
    ImagingTechnique,

    /// <summary>
    /// X-ray Crystallography
    /// </summary>
    XrayCrystallography,

    /// <summary>
    /// Nuclear Magnetic Resonance Spectroscopy of Proteins
    /// </summary>
    ProteinNMR,

    /// <summary>
    /// Electron Cryotomography or Cryotomography Electron Microscopy
    /// </summary>
    ElectronCryotomography,

    /// <summary>
    /// Homology Modeling
    /// </summary>
    HomologyModeling,
}

public static class StructureObtainingMethodExtensions
{
    public static bool IsNatural(this StructureObtainingMethod method)
    {
        return method == StructureObtainingMethod.ImagingTechnique
            || method == StructureObtainingMethod.XrayCrystallography
            || method == StructureObtainingMethod.ProteinNMR
            || method == StructureObtainingMethod.ElectronCryotomography;
    }
}
