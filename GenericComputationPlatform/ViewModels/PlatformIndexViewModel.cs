using System.Collections.Generic;
using DockingDataModels;

namespace GenericComputationPlatform.ViewModels;

public class PlatformIndexViewModel
{
    public IReadOnlyList<Domain> Domains { get; set; }
    public IReadOnlyList<FeaturedProteinCardViewModel> FeaturedProteins { get; set; }
}

public class FeaturedProteinCardViewModel
{
    public string DomainId { get; set; }
    public string CavityId { get; set; }
    public string ProteinId { get; set; }
    public string ProteinName { get; set; }
    public string Organism { get; set; }
    public string Symbol { get; set; }
    public string Gene { get; set; }
    public string BindingSite { get; set; }
    public string ImageUrl { get; set; }
    public string UniProtId { get; set; }
    public string UniProtUrl { get; set; }
    public string ChemblId { get; set; }
    public string ChemblUrl { get; set; }
}