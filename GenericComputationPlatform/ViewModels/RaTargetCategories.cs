using System;
using System.Collections.Generic;

namespace GenericComputationPlatform.ViewModels;

public static class RaTargetCategories
{
    public static IReadOnlyList<RaTargetCategoryDefinition> All { get; } = new List<RaTargetCategoryDefinition>
    {
        new()
        {
            Key = "inflammation-immune",
            Name = "Inflammation & Immune Regulation",
            Description = "Core RA inflammatory amplification, autoimmunity activation, cytokine signaling, and innate immune regulation.",
            Symbols = CreateSymbols(
                "AHR_HUMAN","BTK_HUMAN","CASP1_HUMAN","CCR5_HUMAN","CXCR1_HUMAN","CXCR4_HUMAN","DRB1_HUMAN","E2AK2_HUMAN","GCR_HUMAN","IKBA_HUMAN","IKKA_HUMAN","IKKB_HUMAN","IL2RB_HUMAN","IL2_HUMAN","IL6_HUMAN","JAK1_HUMAN","JAK2_HUMAN","NFKB1_HUMAN","NOS2_HUMAN","PADI4_HUMAN","RELB_HUMAN","STAT3_HUMAN","SYK_HUMAN","TF65_HUMAN","TLR7_HUMAN","TNFA_HUMAN","TYK2_HUMAN")
        },
        new()
        {
            Key = "signal-proliferation",
            Name = "Signal Transduction & Cell Proliferation",
            Description = "Synoviocyte activation, kinase networks, and cell proliferation/migration signaling.",
            Symbols = CreateSymbols(
                "AKT1_HUMAN","FAK1_HUMAN","FAK2_HUMAN","FOXO3_HUMAN","HCK_HUMAN","HGF_HUMAN","KI20A_HUMAN","MET_HUMAN","MK01_HUMAN","MK14_HUMAN","PLK1_HUMAN","PTEN_HUMAN","PTN1_HUMAN","PTN22_HUMAN","RAF1_HUMAN","SRC_HUMAN")
        },
        new()
        {
            Key = "tissue-remodeling",
            Name = "Tissue Destruction & Synovial Remodeling",
            Description = "Synovial invasion, matrix degradation, cytoskeleton remodeling, angiogenesis, and microenvironment changes.",
            Symbols = CreateSymbols(
                "MMP2_HUMAN","MMP8_HUMAN","MMP9_HUMAN","NOS3_HUMAN","RAC1_HUMAN","RHOA_HUMAN","VGFR2_HUMAN","HMR1_HUMAN","TNAP3_HUMAN")
        },
        new()
        {
            Key = "metabolic-supportive",
            Name = "Metabolic & Supportive Regulation",
            Description = "Metabolic regulation, drug response, lipid inflammatory mediators, transport, and supportive control.",
            Symbols = CreateSymbols(
                "A1AG1_HUMAN","A1AG2_HUMAN","ABCG2_HUMAN","PD2R2_HUMAN","PE2R4_HUMAN","PGH1_HUMAN","PGH2_HUMAN","PPARA_HUMAN","PPARG_HUMAN","PPIA_HUMAN","S19A1_HUMAN","XCT_HUMAN")
        }
    };

    private static IReadOnlySet<string> CreateSymbols(params string[] symbols)
    {
        return new HashSet<string>(symbols, StringComparer.OrdinalIgnoreCase);
    }
}