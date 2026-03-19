namespace GenericComputationPlatform;

public class ManifestSettings
{
    public string AppName { get; set; }
    public string Keywords { get; set; }
    public string Description { get; set; }
    public string CopyrightLine { get; set; }
    public string Address { get; set; }
}

public class ExternalUrlsSettings
{
    public string Hosting { get; set; }
    public string DockingApiDoc { get; set; }
    public string DockingApi { get; set; }
    public string JobHub { get; set; }
}

public class TargetListSettings
{
    public string[] PropFields { get; set; }
}

public class PageSizeSettings
{
    public int JobOutput { get; set; }
    public int JobList { get; set; }
    public int Guestbook { get; set; }
}

public class PlottingSettings
{
    public float DockingThresholdInteraction { get; set; }
    public float ThresholdForInteraction { get; set; }
    public float ThresholdForKnown { get; set; }
}

public class FormattingSettings
{
    public int FingerprintBlockBytes { get; set; }
    public int FingerprintRowBlocks { get; set; }
}

public class DisplaySettings
{
    public bool PreviewLigandModels { get; set; }
    public bool PreviewLigandFingerprints { get; set; }
}

public class PartnerLogoSettings
{
    public string Image { get; set; }
    public string Alt { get; set; }
    public string Url { get; set; }
}

public class BrandingSettings
{
    public string DefaultLogoId { get; set; }
    public string NavbarBackgroundColor { get; set; }
    public string NavbarBorderColor { get; set; }
    public string NavbarTopOffset { get; set; }
    public string NavbarBorderRadius { get; set; }
    public string NavbarHorizontalPadding { get; set; }
    public string NavbarLogoWidth { get; set; }
    public string NavbarLogoHeight { get; set; }
    public PartnerLogoSettings[] PartnerLogos { get; set; }
}


public class OptionsSettings
{
    public int MaxInputLigands { get; set; }
    public double JobFailureThreshold { get; set; }
}

public class TestSettings
{
    public bool UseMockDataForPlotting { get; set; }
    public int PlottingMockDataSize { get; set; }
}

public class AppSettings
{
    public ManifestSettings Manifest { get; set; }
    public ExternalUrlsSettings ExternalUrls { get; set; }
    public TargetListSettings TargetList { get; set; }
    public PageSizeSettings PageSize { get; set; }
    public PlottingSettings Plotting { get; set; }
    public FormattingSettings Formatting { get; set; }
    public DisplaySettings Display { get; set; }
    public BrandingSettings Branding { get; set; }
    public OptionsSettings Options { get; set; }
    public TestSettings Test { get; set; }
    public string[] ContactEmails { get; set; }
}
