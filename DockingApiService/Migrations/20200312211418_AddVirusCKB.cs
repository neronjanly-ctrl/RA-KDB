using Microsoft.EntityFrameworkCore.Migrations;

namespace DockingApiService.Migrations
{
    public partial class AddVirusCKB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "dakb-gpcrs",
                column: "Citation",
                value: @"**DAKB-GPCRs: An Integrated Computational Platform for Drug Abuse Related GPCRs**  
Maozi Chen, Yankang Jing, Lirong Wang, Zhiwei Feng, Xiang-Qun Xie  
*J. Chem. Inf. Model.* 2019, 59, 4, 1283-1289  
Publication Date: March 5, 2019  
https://doi.org/10.1021/acs.jcim.8b00623  
https://www.ncbi.nlm.nih.gov/pubmed/30835466");

            migrationBuilder.InsertData(
                table: "Domains",
                columns: new[] { "Id", "Citation", "Created", "Description", "IsPublic", "Keywords", "Name", "ProteinCount", "Updated" },
                values: new object[] { "virus-ckb", "", 637193088000000000L, "Viral-CKB is a knowledgebase for COVID-19 and similar viral infection research that implemented with our established chemogenomics tools as well as our algorithms for data visualization and analyses. This tool predicts the BioActivities on 92 viral related targets for a query compound and provides a handy user interface for viewing, downloading and plotting the output results.<br/><img class=\"w-50\" src=\"images/w01.jpg\"><img class=\"w-50\" src=\"images/w02.jpg\"><video class=\"w-100\" controls autoplay><source src=\"images/w03.mp4\" /></video>", true, "[\"COVID-19\",\"SARS-CoV-2\",\"Knowledgabase\",\"Computational Systems Pahrmacology\",\"Drug Repurposing\",\"Drug Combination\"]", "Virus Chemogenomics Knowledgebase", 101, 0L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "GP160_HIV2", 637196402402893628L, 1, "GP160", false, false, false, "Human immunodeficiency virus type 2 subtype A,isolate ST,HIV-2", "HIV2", "Envelope glycoprotein gp160", "GP160", 1, 637196323846428849L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PLP_SARS", 637196402450046647L, 1, "PLP", true, true, false, "Human SARS coronavirus,SARS-CoV,Severe acute respiratory syndrome coronavirus", "SARS", "Replicase polyprotein 1a", "PLP", 3, 637196324438916086L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PB4_A-H3N2", 637196402449556615L, 1, "PB4", false, false, false, "Influenza A virus,strain A/Beijing/39/1975 H3N2", "A-H3N2", "Polymerase basic protein 2", "PB4", 1, 637196322757573564L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PB3_A-H3N2", 637196402449166676L, 1, "PB3", false, false, false, "Influenza A virus,strain A/Beijing/39/1975 H3N2", "A-H3N2", "Polymerase basic protein 2", "PB3", 1, 637196322741428706L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PB2_INFB", 637196402448686647L, 1, "PB2", false, false, false, "Influenza B virus,strain B/Lee/1940", "INFB", "Polymerase basic protein 2", "PB2", 1, 637196324171659139L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PB2_A-H5N1", 637196402447686680L, 1, "PB2", false, false, false, "Influenza A virus,A/duck/Shantou/4610/2003,H5N1", "A-H5N1", "Polymerase basic protein 2", "PB2", 3, 637196322954728382L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PB2_A-H3N2", 637196402447016660L, 1, "PB2", false, false, false, "Influenza A virus,strain A/Beijing/39/1975 H3N2", "A-H3N2", "Polymerase basic protein 2", "PB2", 2, 637196322731022364L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PA_INFB", 637196402446596672L, 1, "PA", false, false, false, "Influenza B virus,B/Memphis/13/2003", "INFB", "Polymerase acidic protein", "PA", 1, 637196324161419089L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PA_INFA", 637196402445646657L, 1, "PA", true, true, false, "Influenza A virus,strain A/Puerto Rico/8/1934 H1N1", "INFA", "Polymerase acidic protein", "PA", 3, 637196324069360812L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PA_A-H5N1", 637196402444156738L, 1, "PA", false, false, false, "Influenza A virus,strain A/Goose/Guangdong/1/1996 H5N1 genotype Gs/Gd", "A-H5N1", "Polymerase acidic protein", "PA", 3, 637196322922444780L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PA_A-H1N1", 637196402443206643L, 1, "PA", false, false, false, "Influenza A virus,strain swl A/California/04/2009 H1N1", "A-H1N1", "Polymerase acidic protein", "PA", 3, 637196322577533141L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PA_A-H17N10", 637196402445136677L, 1, "PA", false, false, false, "Influenza A virus,A/little yellow-shouldered bat/Guatemala/060/2010,H17N10", "A-H17N10", "Polymerase acidic protein", "PA", 1, 637196322475504278L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NSP9_HCoV-229E", 637196402442026671L, 1, "NSP9", false, false, false, "Human coronavirus 229E,HCoV-229E", "HCoV-229E", "Replicase polyprotein 1ab", "NSP9", 2, 637196323264694789L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NSP3_MHV", 637196402441666654L, 1, "NSP3", false, false, false, "Murine coronavirus,strain A59,MHV-A59,Murine hepatitis virus", "MHV", "Replicase polyprotein 1ab", "NSP3", 1, 637196324303931187L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NSP3_IBV", 637196402441216699L, 1, "NSP3", false, false, false, "Avian infectious bronchitis virus,strain M41,IBV", "IBV", "Replicase polyprotein 1a", "NSP3", 1, 637196324003917929L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NSP3_HCoV-229E", 637196402440836650L, 1, "NSP3", false, false, false, "Human coronavirus 229E,HCoV-229E", "HCoV-229E", "Replicase polyprotein 1a", "NSP3", 1, 637196323230130466L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NSP1_SARS", 637196402440476696L, 1, "NSP1", true, true, false, "Human SARS coronavirus,SARS-CoV,Severe acute respiratory syndrome coronavirus", "SARS", "Replicase polyprotein 1ab", "NSP1", 1, 637196324364369280L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NSP1_INFB", 637196402439766687L, 1, "NSP1", false, false, false, "Influenza B virus,strain B/Lee/1940", "INFB", "Non-structural protein 1", "NSP1", 2, 637196324150210769L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NSP15_SARS", 637196402442846643L, 1, "NSP15", true, true, false, "Human SARS coronavirus,SARS-CoV,Severe acute respiratory syndrome coronavirus", "SARS", "Replicase polyprotein 1ab", "NSP15", 1, 637196324388419260L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NS5B_HCV2A", 637196402439016706L, 1, "NS5B", false, false, false, "Hepatitis C virus genotype 2a,isolate JFH-1,HCV", "HCV2A", "Genome polyprotein", "NS5B", 2, 637196323627384958L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NS5B_HCV1B", 637196402437986646L, 1, "NS5B", true, true, false, "Hepatitis C virus genotype 1b,isolate BK,HCV", "HCV1B", "Genome polyprotein", "NS5B", 3, 637196323594167219L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NS5B_HCV1A", 637196402436926653L, 1, "NS5B", true, true, false, "Hepatitis C virus genotype 1a,isolate 1,HCV", "HCV1A", "Genome polyprotein", "NS5B", 3, 637196323514309330L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_FCoV", 637196402451086670L, 1, "PR", false, false, false, "Feline coronavirus,strain FIPV WSU-79/1146,FCoV", "FCoV", "Replicase polyprotein 1ab", "PR", 1, 637196323215130715L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_HCoV-229E", 637196402451556637L, 1, "PR", false, false, false, "Human coronavirus 229E,HCoV-229E", "HCoV-229E", "Replicase polyprotein 1a", "PR", 2, 637196323294145442L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_HCoV-NL63", 637196402452256654L, 1, "PR", false, true, false, "Human coronavirus NL63,HCoV-NL63", "HCoV-NL63", "Replicase polyprotein 1a", "PR", 2, 637196323339735508L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_HIV1", 637196402452966647L, 1, "PR", true, true, false, "Human immunodeficiency virus type 1 group M subtype B,isolate ARV2/SF2,HIV-1", "HIV1", "Gag-Pol polyprotein", "PR", 3, 637196323770242169L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "VP36_EBOV", 637196402465506682L, 1, "VP36", false, false, false, "Zaire ebolavirus,strain Mayinga-76,ZEBOV,Zaire Ebola virus", "EBOV", "Polymerase cofactor VP35", "VP36", 1, 637196323187956141L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "VP35_EBOV", 637196402465106643L, 1, "VP35", false, false, false, "Zaire ebolavirus,strain Mayinga-76,ZEBOV,Zaire Ebola virus", "EBOV", "Polymerase cofactor VP35", "VP35", 1, 637196323174797844L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "SPIKE_SARS2", 637196402464736679L, 1, "SPIKE", false, false, false, "", "SARS2", "", "SPIKE", 1, 637196324535701533L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "SPIKE_SARS", 637196402464136598L, 1, "SPIKE", false, false, false, "Human SARS coronavirus,SARS-CoV,Severe acute respiratory syndrome coronavirus", "SARS", "Spike glycoprotein", "SPIKE", 2, 637196324535661592L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "SPIKE_PDCoV", 637196402463696650L, 1, "SPIKE", false, false, false, "Deltacoronavirus PDCoV/USA/Ohio137/2014", "PDCoV", "Spike protein", "SPIKE", 1, 637196324322507414L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "SPIKE_MHV", 637196402463306645L, 1, "SPIKE", false, false, false, "Murine hepatitis virus", "MHV", "Spike glycoprotein", "SPIKE", 1, 637196324313381713L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "SPIKE_MERs", 637196402462376675L, 1, "SPIKE", false, false, false, "Middle East respiratory syndrome-related coronavirus,isolate United Kingdom/H123990006/2012,Betacoronavirus England 1,Human coronavirus EMC", "MERs", "Spike glycoprotein", "SPIKE", 3, 637196324276298673L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "SPIKE_IBV", 637196402461996678L, 1, "SPIKE", false, false, false, "Infectious bronchitis virus", "IBV", "Spike glycoprotein", "SPIKE", 1, 637196324026849824L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "SPIKE_HKU4", 637196402461636663L, 1, "SPIKE", false, false, false, "Bat coronavirus HKU4,BtCoV,BtCoV/HKU4/2004", "HKU4", "Spike glycoprotein", "SPIKE", 1, 637196323991179127L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "SPIKE_HCoV-OC43", 637196402461236679L, 1, "SPIKE", false, false, false, "Human coronavirus OC43,HCoV-OC43", "HCoV-OC43", "Spike glycoprotein", "SPIKE", 1, 637196323404457326L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NS3_HCV3A", 637196402435866688L, 1, "NS3", false, false, false, "Hepacivirus C", "HCV3A", "NS3 protease", "NS3", 3, 637196323652049426L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "SPIKE_HCoV-NL63", 637196402460866602L, 1, "SPIKE", false, false, false, "Human coronavirus NL63,HCoV-NL63", "HCoV-NL63", "Spike glycoprotein", "SPIKE", 1, 637196323352652156L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "RT_HIV1", 637196402459356663L, 1, "RT", true, true, false, "Human immunodeficiency virus type 1 group M subtype B,isolate HXB2,HIV-1", "HIV1", "Gag-Pol polyprotein", "RT", 3, 637196323834712534L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_TGEV", 637196402458966683L, 1, "PR", false, false, false, "Porcine transmissible gastroenteritis coronavirus,strain Purdue,TGEV", "TGEV", "Replicase polyprotein 1a", "PR", 1, 637196324549822018L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_SARS2", 637196402458606649L, 1, "PR", false, false, false, "", "SARS2", "", "PR", 1, 637196324535681611L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_SARS", 637196402457506645L, 1, "PR", true, true, false, "Human SARS coronavirus,SARS-CoV,Severe acute respiratory syndrome coronavirus", "SARS", "Replicase polyprotein 1ab", "PR", 3, 637196324502351622L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_PEDV", 637196402457136673L, 1, "PR", false, false, false, "Porcine epidemic diarrhea virus", "PEDV", "Polyprotein 1a", "PR", 1, 637196324332283782L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_MERs", 637196402456446705L, 1, "PR", false, false, false, "Middle East respiratory syndrome-related coronavirus", "MERs", "Orf1a", "PR", 2, 637196324237906995L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_IBV", 637196402455996688L, 1, "PR", false, false, false, "Avian infectious bronchitis virus,strain M41,IBV", "IBV", "Replicase polyprotein 1a", "PR", 1, 637196324016902557L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_HKU4", 637196402455096666L, 1, "PR", false, false, false, "Bat coronavirus HKU4,BtCoV,BtCoV/HKU4/2004", "HKU4", "Replicase polyprotein 1ab", "PR", 3, 637196323978528165L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_HKU1", 637196402454716644L, 1, "PR", false, false, false, "Human coronavirus HKU1,isolate N1,HCoV-HKU1", "HKU1", "Replicase polyprotein 1a", "PR", 1, 637196323887326880L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PR_HIV2", 637196402454036595L, 1, "PR", false, false, false, "Human immunodeficiency virus type 2 subtype A,isolate ROD,HIV-2", "HIV2", "Gag-Pol polyprotein", "PR", 2, 637196323875534279L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "SPIKE_HCoV-229E", 637196402460486592L, 1, "SPIKE", false, false, false, "Human coronavirus 229E,HCoV-229E", "HCoV-229E", "Spike glycoprotein", "SPIKE", 1, 637196323305327916L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "GP160_HIV1", 637196402401783647L, 1, "GP160", false, false, false, "Human immunodeficiency virus 1", "HIV1", "Envelope glycoprotein gp160", "GP160", 3, 637196323690105199L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NS3_HCV1B", 637196402434886648L, 1, "NS3", true, true, false, "Hepacivirus C", "HCV1B", "NS3 protease", "NS3", 3, 637196323542075679L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NP_SARS", 637196402433356612L, 1, "NP", false, false, false, "Human SARS coronavirus,SARS-CoV,Severe acute respiratory syndrome coronavirus", "SARS", "Nucleoprotein", "NP", 1, 637196324343519636L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_INFD", 637196402416056652L, 1, "HA", false, false, false, "Influenza D virus,D/swine/Oklahoma/1334/2011", "INFD", "Hemagglutinin-esterase", "HA", 1, 637196324181946926L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_INFB", 637196402415366649L, 1, "HA", false, false, false, "Influenza B virus,strain B/Hong Kong/8/1973", "INFB", "Hemagglutinin", "HA", 2, 637196324092602524L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H7N9", 637196402412316593L, 1, "HA", false, false, false, "Influenza A virus,A/Hangzhou/1/2013,H7N9", "A-H7N9", "Hemagglutinin", "HA", 1, 637196323053479514L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H7N7", 637196402411713730L, 1, "HA", false, false, false, "Influenza A virus,A/Netherlands/219/2003,H7N7", "A-H7N7", "Hemagglutinin", "HA", 2, 637196323042512662L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H7N2", 637196402410743637L, 1, "HA", false, false, false, "Influenza A virus,A/chicken/New Jersey/Sg-00421/2004,H7N2", "A-H7N2", "Hemagglutinin", "HA", 3, 637196323022412652L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H6N6", 637196402410353615L, 1, "HA", false, false, false, "Influenza A virus,A/chicken/Guangdong/S1414/2010,H6N6", "A-H6N6", "Hemagglutinin", "HA", 1, 637196322993708564L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H6N1", 637196402409853619L, 1, "HA", false, false, false, "H6N1 subtype", "A-H6N1", "Hemagglutinin", "HA", 1, 637196322984488703L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H5N3", 637196402408933626L, 1, "HA", false, false, false, "Influenza A virus,strain A/Duck/Singapore/3/1997 H5N3,Influenza A virus,strain A/Duck/Malaysia/F119-3/1997 H5N3", "A-H5N3", "Hemagglutinin", "HA", 2, 637196322975408731L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H5N1", 637196402407073620L, 1, "HA", false, false, false, "Influenza A virus,A/Vietnam/1194/2004,H5N1", "A-H5N1", "Hemagglutinin", "HA", 3, 637196322854394775L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H3N8", 637196402405903616L, 1, "HA", false, false, false, "Influenza A virus,A/eq/Newmarket/93/,H3N8", "A-H3N8", "Hemagglutinin", "HA", 3, 637196322787497594L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H3N2", 637196402404833631L, 1, "HA", false, true, false, "Influenza A virus", "A-H3N2", "Hemagglutinin", "HA", 3, 637196322688266765L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H2N2", 637196402404003636L, 1, "HA", false, false, false, "Influenza A virus,strain A/Japan/305/1957 H2N2", "A-H2N2", "Hemagglutinin", "HA", 2, 637196322602213994L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H1N1", 637196402403283625L, 1, "HA", false, false, false, "Influenza A virus,A/WDK/JX/12416/2005,H1N1", "A-H1N1", "Hemagglutinin", "HA", 2, 637196322495393823L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H18N11", 637196402415006647L, 1, "HA", false, false, false, "", "A-H18N11", "", "HA", 1, 637196322475523964L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H17N10", 637196402414626682L, 1, "HA", false, false, false, "Influenza A virus,A/little yellow-shouldered bat/Guatemala/060/2010,H17N10", "A-H17N10", "Hemagglutinin", "HA", 1, 637196322455978509L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H15N9", 637196402414236626L, 1, "HA", false, false, false, "Influenza A virus,A/shearWater/Australia/2576/1979,H15N9", "A-H15N9", "Hemagglutinin", "HA", 1, 637196322446048044L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H14N6", 637196402413796603L, 1, "HA", false, false, false, "Influenza A virus,strain A/Mallard/Astrakhan/244/1982 H14N6,Influenza A virus,strain A/Mallard/Gurjev/244/1982 H14N6", "A-H14N6", "Hemagglutinin", "HA", 1, 637196322435998048L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H13N6", 637196402413456600L, 1, "HA", false, false, false, "Influenza A virus,strain A/Gull/Maryland/704/1977 H13N6", "A-H13N6", "Hemagglutinin", "HA", 1, 637196322410398756L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H10N8", 637196402413066686L, 1, "HA", false, false, false, "Influenza A virus,A/Jiangxi/IPB13/2013,H10N8", "A-H10N8", "Hemagglutinin", "HA", 1, 637196322289204385L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HA_A-H10N7", 637196402412706653L, 1, "HA", false, false, false, "Influenza A virus,strain A/Chicken/Germany/n/1949 H10N7", "A-H10N7", "Hemagglutinin", "HA", 1, 637196322276932361L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "GP_EBOV", 637196402400423628L, 1, "GP", true, true, false, "Zaire ebolavirus,strain Mayinga-76,ZEBOV,Zaire Ebola virus", "EBOV", "Envelope glycoprotein", "GP", 3, 637196323162609298L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HE_BCV", 637196402416416647L, 1, "HE", false, false, false, "Bovine coronavirus,strain Mebus,BCoV,BCV", "BCV", "Hemagglutinin-esterase", "HE", 2, 637196323112910693L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HE_HCoV-OC43", 637196402417056660L, 1, "HE", false, false, false, "Human coronavirus OC43,HCoV-OC43", "HCoV-OC43", "Hemagglutinin-esterase", "HE", 1, 637196323364149990L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "HE_MHV", 637196402417456646L, 1, "HE", false, false, false, "Murine coronavirus,strain DVIM,MHV-DVIM,Murine hepatitis virus", "MHV", "Hemagglutinin-esterase", "HE", 1, 637196324287878694L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "IN_HIV1", 637196402417846717L, 1, "IN", false, false, false, "Human immunodeficiency virus type 1 group M subtype B,isolate NY5,HIV-1", "HIV1", "Gag-Pol polyprotein", "IN", 2, 637196323725089568L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NP_INFD", 637196402432996634L, 1, "NP", false, false, false, "Influenza D virus,D/bovine/France/2986/2012", "INFD", "NP", "NP", 1, 637196324190173105L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NP_INFB", 637196402432546649L, 1, "NP", false, false, false, "Influenza B virus,B/Managua/4577.01/2008", "INFB", "Nucleoprotein", "NP", 1, 637196324129203813L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NP_HCoV-OC43", 637196402431526742L, 1, "NP", true, true, false, "Human coronavirus OC43,HCoV-OC43", "HCoV-OC43", "Nucleoprotein", "NP", 3, 637196323393051538L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NP_HCoV-NL63", 637196402430966676L, 1, "NP", false, false, false, "Human coronavirus NL63,HCoV-NL63", "HCoV-NL63", "Nucleoprotein", "NP", 1, 637196323315847741L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NP_A-H5N1", 637196402430596649L, 1, "NP", false, false, false, "Influenza A virus,A/Chicken/Hong Kong/786/97,H5N1", "A-H5N1", "Nucleoprotein", "NP", 1, 637196322886604773L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NP_A-H1N1", 637196402429666637L, 1, "NP", false, false, false, "Influenza A virus,strain A/Wilson-Smith/1933 H1N1,Influenza A virus,strain A/WS/1933 H1N1", "A-H1N1", "Nucleoprotein", "NP", 3, 637196322539836940L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_INFB", 637196402428956669L, 1, "NA", true, true, false, "Influenza B virus,strain B/Lee/1940", "INFB", "Neuraminidase", "NA", 2, 637196324119223769L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H7N9", 637196402423866651L, 1, "NA", false, false, false, "Influenza A virus,A/Shanghai/02/2013,H7N9", "A-H7N9", "Neuraminidase", "NA", 3, 637196323084562054L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H5N1", 637196402423496641L, 1, "NA", false, false, false, "Influenza A virus,A/American green-winged teal/Washington/195750/2014,H5N1", "A-H5N1", "Neuraminidase", "NA", 1, 637196322875034699L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H3N8", 637196402422516687L, 1, "NA", false, false, false, "Influenza A virus,strain A/Duck/Ukraine/1/1963 H3N8", "A-H3N8", "Neuraminidase", "NA", 3, 637196322820692656L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "VP37_EBOV", 637196402465936641L, 1, "VP37", false, false, false, "Zaire ebolavirus,strain Mayinga-76,ZEBOV,Zaire Ebola virus", "EBOV", "Polymerase cofactor VP35", "VP37", 1, 637196323200186899L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H3N2", 637196402421876654L, 1, "NA", false, false, false, "Mus musculus,Mouse", "A-H3N2", "Ig heavy chain Mem5", "NA", 2, 637196322711172351L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H1N1", 637196402420516635L, 1, "NA", false, false, false, "Influenza A virus,A/Texas/17/2009,H1N1", "A-H1N1", "Neuraminidase", "NA", 1, 637196322506597827L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H18N11", 637196402428406748L, 1, "NA", false, false, false, "", "A-H18N11", "", "NA", 1, 637196322475544000L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H17N10", 637196402427986645L, 1, "NA", false, false, false, "Influenza A virus,A/little yellow-shouldered bat/Guatemala/164/2009,H17N10", "A-H17N10", "Neuraminidase", "NA", 1, 637196322466229334L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H13N9", 637196402427626656L, 1, "NA", false, false, false, "Influenza A virus,strain A/Whale/Maine/1/1984 H13N9", "A-H13N9", "Neuraminidase", "NA", 1, 637196322423897665L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H12N5", 637196402426696675L, 1, "NA", false, false, false, "Influenza A virus,strain A/Duck/Alberta/60/1976 H12N5", "A-H12N5", "Neuraminidase", "NA", 3, 637196322398914609L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H11N9", 637196402425766668L, 1, "NA", false, false, false, "Influenza A virus,strain A/Tern/Australia/G70C/1975 H11N9", "A-H11N9", "Neuraminidase", "NA", 3, 637196322368099171L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H11N6", 637196402424846885L, 1, "NA", false, false, false, "Influenza A virus,strain A/Duck/England/1/1956 H11N6", "A-H11N6", "Neuraminidase", "NA", 3, 637196322327306126L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "MX2_A-H5N1", 637196402420106708L, 1, "MX2", false, false, false, "Influenza A virus,strain A/Goose/Guangdong/1/1996 H5N1 genotype Gs/Gd", "A-H5N1", "Matrix protein 2", "MX2", 1, 637196322864224387L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "MD_MERs", 637196402419476645L, 1, "MD", false, false, false, "Middle East respiratory syndrome-related coronavirus,isolate United Kingdom/H123990006/2012,Betacoronavirus England 1,Human coronavirus EMC", "MERs", "Replicase polyprotein 1a", "MD", 2, 637196324216912882L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "MD_HKU4", 637196402418476645L, 1, "MD", false, false, false, "Bat coronavirus HKU4,BtCoV,BtCoV/HKU4/2004", "HKU4", "Replicase polyprotein 1ab", "MD", 3, 637196323933196168L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NA_A-H2N2", 637196402420926689L, 1, "NA", false, false, false, "Influenza A virus,strain A/Tokyo/3/1967 H2N2", "A-H2N2", "Neuraminidase", "NA", 3, 637196322657261815L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NS3_HCV1A", 637196402433846638L, 1, "NS3", true, true, false, "Hepatitis C virus genotype 1a,isolate H,HCV", "HCV1A", "Genome polyprotein", "NS3", 3, 637196323469613217L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 7093171442464223862L, "orthosteric", 637196402401823620L, "GP160_HIV1", 3, "[true,true,true]", "[1,1,1]", 637196402402503627L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -301257636530356541L, "orthosteric", 637196402425806654L, "NA_A-H11N9", 3, "[false,true,true]", "[1,1,1]", 637196402426346668L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -242049240043911318L, "orthosteric", 637196402461266685L, "SPIKE_HCoV-OC43", 1, "[true]", "[1]", 637196402461306685L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -8235401691306039847L, "orthosteric", 637196402456486725L, "PR_MERs", 2, "[true,true]", "[1,1]", 637196402456776641L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 1956200189350455062L, "orthosteric", 637196402424876645L, "NA_A-H11N6", 3, "[true,true,true]", "[1,1,1]", 637196402425436650L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2590541954298672216L, "orthosteric", 637196402442876741L, "NSP15_SARS", 1, "[false]", "[1]", 637196402442916680L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -8489289755120389149L, "orthosteric", 637196402420136677L, "MX2_A-H5N1", 1, "[true]", "[1]", 637196402420176704L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2969350817401079966L, "orthosteric", 637196402439796683L, "NSP1_INFB", 2, "[false,false]", "[1,1]", 637196402440056652L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 5067353867499437422L, "orthosteric", 637196402419496663L, "MD_MERs", 2, "[true,false]", "[1,1]", 637196402419806713L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 6605277735121113275L, "orthosteric", 637196402461666623L, "SPIKE_HKU4", 1, "[false]", "[1]", 637196402461706631L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 8747472946734632848L, "orthosteric", 637196402418516677L, "MD_HKU4", 3, "[true,true,true]", "[1,1,1]", 637196402419126673L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 50008268315844408L, "orthosteric", 637196402440496698L, "NSP1_SARS", 1, "[false]", "[1]", 637196402440536672L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 5269927716098830578L, "orthosteric", 637196402456026682L, "PR_IBV", 1, "[true]", "[1]", 637196402456056693L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 403638485696797036L, "orthosteric", 637196402417876675L, "IN_HIV1", 2, "[true,true]", "[1,1]", 637196402418176645L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 7650185638111666594L, "orthosteric", 637196402440866649L, "NSP3_HCoV-229E", 1, "[true]", "[1]", 637196402440896654L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -957424590644289583L, "orthosteric", 637196402417486650L, "HE_MHV", 1, "[false]", "[1]", 637196402417516779L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -6164381918649516809L, "orthosteric", 637196402462026650L, "SPIKE_IBV", 1, "[false]", "[1]", 637196402462056644L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -7030475524457147395L, "orthosteric", 637196402417096700L, "HE_HCoV-OC43", 1, "[false]", "[1]", 637196402417136645L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -665561656627536551L, "orthosteric", 637196402441246677L, "NSP3_IBV", 1, "[true]", "[1]", 637196402441296634L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -9100459219184827355L, "orthosteric", 637196402458636761L, "PR_SARS2", 1, "[true]", "[1]", 637196402458676644L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -2918000322122842432L, "orthosteric", 637196402441686633L, "NSP3_MHV", 1, "[false]", "[1]", 637196402441726645L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 4458988227912794195L, "orthosteric", 637196402416076674L, "HA_INFD", 1, "[false]", "[1]", 637196402416116650L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 1072331945716584447L, "orthosteric", 637196402462406647L, "SPIKE_MERs", 3, "[false,false,false]", "[1,1,1]", 637196402462956665L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -4120045831199128135L, "orthosteric", 637196402415396673L, "HA_INFB", 2, "[true,true]", "[1,1]", 637196402415716680L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2082979118763922837L, "orthosteric", 637196402455126666L, "PR_HKU4", 3, "[true,true,true]", "[1,1,1]", 637196402455686649L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 281319347400019704L, "orthosteric", 637196402442066668L, "NSP9_HCoV-229E", 2, "[true,true]", "[1,1]", 637196402442376647L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -7524106280427146489L, "orthosteric", 637196402439046684L, "NS5B_HCV2A", 2, "[true,true]", "[1,1]", 637196402439386690L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2863432470013529596L, "orthosteric", 637196402426726689L, "NA_A-H12N5", 3, "[false,true,true]", "[1,1,1]", 637196402427296687L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -1337739520828764931L, "orthosteric", 637196402427656647L, "NA_A-H13N9", 1, "[false]", "[1]", 637196402427686649L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 8546224597772558872L, "orthosteric", 637196402438006659L, "NS5B_HCV1B", 3, "[true,true,true]", "[1,1,1]", 637196402438646635L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 883091514397573356L, "orthosteric", 637196402430996696L, "NP_HCoV-NL63", 1, "[false]", "[1]", 637196402431056654L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 8490504442079014776L, "orthosteric", 637196402432586671L, "NP_INFB", 1, "[true]", "[1]", 637196402432636640L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2044591495024759508L, "orthosteric", 637196402430626737L, "NP_A-H5N1", 1, "[true]", "[1]", 637196402430656679L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -6578575101409681208L, "orthosteric", 637196402433026648L, "NP_INFD", 1, "[false]", "[1]", 637196402433056719L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 7613623469306449977L, "orthosteric", 637196402429696649L, "NP_A-H1N1", 3, "[true,true,true]", "[1,1,1]", 637196402430276611L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 5618511454157090880L, "orthosteric", 637196402457666668L, "PR_SARS", 3, "[true,true,true]", "[1,1,1]", 637196402458266645L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 1872973139781068285L, "orthosteric", 637196402458996657L, "PR_TGEV", 1, "[false]", "[1]", 637196402459036693L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 7892303066444267602L, "orthosteric", 637196402428986680L, "NA_INFB", 2, "[true,true]", "[1,1]", 637196402429316652L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -2049611342196008875L, "orthosteric", 637196402433396637L, "NP_SARS", 1, "[false]", "[1]", 637196402433436702L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 4323105175943048197L, "orthosteric", 637196402423906634L, "NA_A-H7N9", 3, "[true,true,true]", "[1,1,1]", 637196402424506653L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -1433670812217117972L, "orthosteric", 637196402433876666L, "NS3_HCV1A", 3, "[true,true,true]", "[1,1,1]", 637196402434446676L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -4175252559121933339L, "orthosteric", 637196402423526668L, "NA_A-H5N1", 1, "[false]", "[1]", 637196402423566677L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -6814136620749759278L, "orthosteric", 637196402412356588L, "HA_A-H7N9", 1, "[true]", "[1]", 637196402412386608L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -8704127147396061018L, "orthosteric", 637196402459546653L, "RT_HIV1", 3, "[true,true,true]", "[1,1,1]", 637196402460156700L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -3611740801321136024L, "orthosteric", 637196402434916655L, "NS3_HCV1B", 3, "[true,true,true]", "[1,1,1]", 637196402435526680L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 5842474478118004459L, "orthosteric", 637196402421906647L, "NA_A-H3N2", 2, "[false,false]", "[1,1]", 637196402422186666L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -4257367663023912033L, "orthosteric", 637196402451596609L, "PR_HCoV-229E", 2, "[false,false]", "[1,1]", 637196402451916635L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -2276765159745676623L, "orthosteric", 637196402420966688L, "NA_A-H2N2", 3, "[true,true,true]", "[1,1,1]", 637196402421546666L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 4899220541200285866L, "orthosteric", 637196402460516601L, "SPIKE_HCoV-229E", 1, "[false]", "[1]", 637196402460556664L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 5847031129161083759L, "orthosteric", 637196402435886800L, "NS3_HCV3A", 3, "[true,true,true]", "[1,1,1]", 637196402436466678L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 772908198962668604L, "orthosteric", 637196402420546638L, "NA_A-H1N1", 1, "[true]", "[1]", 637196402420576683L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -3640637760515103087L, "orthosteric", 637196402457166661L, "PR_PEDV", 1, "[false]", "[1]", 637196402457216633L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -6558285941114696926L, "orthosteric", 637196402428436609L, "NA_A-H18N11", 1, "[false]", "[1]", 637196402428476651L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 8572324593866944657L, "orthosteric", 637196402436956637L, "NS5B_HCV1A", 3, "[true,true,true]", "[1,1,1]", 637196402437526686L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -3032824679694898389L, "orthosteric", 637196402428026717L, "NA_A-H17N10", 1, "[false]", "[1]", 637196402428066621L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 3692134124478738684L, "orthosteric", 637196402460896663L, "SPIKE_HCoV-NL63", 1, "[false]", "[1]", 637196402460926669L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 3882425025535722525L, "orthosteric", 637196402422546676L, "NA_A-H3N8", 3, "[true,true,true]", "[1,1,1]", 637196402423146675L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -5612494110248177836L, "orthosteric", 637196402445156614L, "PA_A-H17N10", 1, "[true]", "[1]", 637196402445196634L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -2686246146403624428L, "orthosteric", 637196402416446651L, "HE_BCV", 2, "[false,false]", "[1,1]", 637196402416746646L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2018918786060414569L, "orthosteric", 637196402431556665L, "NP_HCoV-OC43", 3, "[true,true,true]", "[1,1,1]", 637196402432216645L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -6621179517358550914L, "orthosteric", 637196402413836737L, "HA_A-H14N6", 1, "[true]", "[1]", 637196402413886645L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -4049336189823579742L, "orthosteric", 637196402464166674L, "SPIKE_SARS", 2, "[false,false]", "[1,1]", 637196402464426738L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 3487149310279799938L, "orthosteric", 637196402404863619L, "HA_A-H3N2", 3, "[true,true,true]", "[1,1,1]", 637196402405523624L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -8081953811632666512L, "orthosteric", 637196402465536709L, "VP36_EBOV", 1, "[true]", "[1]", 637196402465566684L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -5714615048382812488L, "orthosteric", 637196402454066604L, "PR_HIV2", 2, "[true,true]", "[1,1]", 637196402454376664L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -7737333266689075166L, "orthosteric", 637196402404043656L, "HA_A-H2N2", 2, "[false,false]", "[1,1]", 637196402404363619L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -7300021075287053086L, "orthosteric", 637196402447046689L, "PB2_A-H3N2", 2, "[true,true]", "[1,1]", 637196402447336640L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 4403149430178897900L, "orthosteric", 637196402413086675L, "HA_A-H10N8", 1, "[true]", "[1]", 637196402413136672L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -5143425767058699890L, "orthosteric", 637196402403323626L, "HA_A-H1N1", 2, "[true,true]", "[1,1]", 637196402403643626L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 5942723027128670584L, "orthosteric", 637196402446626688L, "PA_INFB", 1, "[true]", "[1]", 637196402446666658L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -4058645023288619707L, "orthosteric", 637196402464766682L, "SPIKE_SARS2", 1, "[false]", "[1]", 637196402464806682L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 4191329061714548831L, "orthosteric", 637196402411743650L, "HA_A-H7N7", 2, "[true,true]", "[1,1]", 637196402412013658L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -8016147709636077880L, "orthosteric", 637196402415036709L, "HA_A-H18N11", 1, "[true]", "[1]", 637196402415066657L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 5200780864725164628L, "orthosteric", 637196402447726625L, "PB2_A-H5N1", 3, "[true,true,true]", "[1,1,1]", 637196402448326668L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -472644960433884999L, "orthosteric", 637196402413476610L, "HA_A-H13N6", 1, "[false]", "[1]", 637196402413516599L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -5788469372983292511L, "orthosteric", 637196402414656608L, "HA_A-H17N10", 1, "[true]", "[1]", 637196402414696605L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2988465955223406714L, "orthosteric", 637196402448716667L, "PB2_INFB", 1, "[true]", "[1]", 637196402448746671L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -7371096713491547550L, "orthosteric", 637196402414266620L, "HA_A-H15N9", 1, "[true]", "[1]", 637196402414306661L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 4944775172720482117L, "orthosteric", 637196402465136653L, "VP35_EBOV", 1, "[true]", "[1]", 637196402465166666L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -6963932294249849891L, "orthosteric", 637196402453126806L, "PR_HIV1", 3, "[true,true,true]", "[1,1,1]", 637196402453686733L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -69781506867200169L, "orthosteric", 637196402449586631L, "PB4_A-H3N2", 1, "[true]", "[1]", 637196402449616624L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -3249733638923725489L, "orthosteric", 637196402405933622L, "HA_A-H3N8", 3, "[true,true,true]", "[1,1,1]", 637196402406583625L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 6591465821529131653L, "orthosteric", 637196402449196627L, "PB3_A-H3N2", 1, "[true]", "[1]", 637196402449236618L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 1219990520152534512L, "orthosteric", 637196402450086715L, "PLP_SARS", 3, "[true,true,true]", "[1,1,1]", 637196402450716606L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 6220502229929552289L, "orthosteric", 637196402463336648L, "SPIKE_MHV", 1, "[false]", "[1]", 637196402463376637L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 1767693762405330606L, "orthosteric", 637196402410783649L, "HA_A-H7N2", 3, "[true,true,true]", "[1,1,1]", 637196402411373645L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -3108816072978716400L, "orthosteric", 637196402465976720L, "VP37_EBOV", 1, "[true]", "[1]", 637196402466016699L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -6453878123671001285L, "orthosteric", 637196402443236672L, "PA_A-H1N1", 3, "[true,true,true]", "[1,1,1]", 637196402443806701L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -3312288386219443198L, "orthosteric", 637196402410383635L, "HA_A-H6N6", 1, "[true]", "[1]", 637196402410423631L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -455116379065447313L, "orthosteric", 637196402402933629L, "GP160_HIV2", 1, "[false]", "[1]", 637196402402973629L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -6439732228708196463L, "orthosteric", 637196402412736657L, "HA_A-H10N7", 1, "[true]", "[1]", 637196402412766646L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -482653893857494396L, "orthosteric", 637196402451116650L, "PR_FCoV", 1, "[true]", "[1]", 637196402451156652L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -7948786994371912182L, "orthosteric", 637196402409883622L, "HA_A-H6N1", 1, "[true]", "[1]", 637196402409923639L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -5351545181728830974L, "orthosteric", 637196402463716700L, "SPIKE_PDCoV", 1, "[false]", "[1]", 637196402463756693L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -7908155078585916504L, "orthosteric", 637196402454746664L, "PR_HKU1", 1, "[true]", "[1]", 637196402454786631L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -4711605374898453730L, "orthosteric", 637196402400463614L, "GP_EBOV", 3, "[true,true,true]", "[1,1,1]", 637196402401363643L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -5243726574043799506L, "orthosteric", 637196402444196723L, "PA_A-H5N1", 3, "[true,true,true]", "[1,1,1]", 637196402444786616L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 1703022165787516192L, "orthosteric", 637196402408983634L, "HA_A-H5N3", 2, "[true,true]", "[1,1]", 637196402409413635L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 6275669838524203807L, "orthosteric", 637196402452396635L, "PR_HCoV-NL63", 2, "[false,true]", "[1,1]", 637196402452656617L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 5916138029700665692L, "orthosteric", 637196402407143624L, "HA_A-H5N1", 3, "[true,true,true]", "[1,1,1]", 637196402408293730L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -3700660234162323339L, "orthosteric", 637196402445676661L, "PA_INFA", 3, "[true,true,true]", "[1,1,1]", 637196402446276658L });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NP_HCoV-OC43" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PB3_A-H3N2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_PEDV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_FCoV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NP_INFD" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_HCoV-NL63" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PB4_A-H3N2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NP_INFB" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NS3_HCV1A" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PLP_SARS" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "VP37_EBOV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NP_SARS" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_MERs" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NS3_HCV3A" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PA_A-H17N10" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_HKU1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NSP3_MHV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PA_A-H1N1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_HKU4" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NSP3_IBV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NSP3_HCoV-229E" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PA_A-H5N1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NSP1_SARS" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_HIV2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NS3_HCV1B" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PA_INFA" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NSP1_INFB" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NSP15_SARS" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PA_INFB" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PB2_A-H3N2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NS5B_HCV2A" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NS5B_HCV1B" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_HIV1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PB2_A-H5N1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NS5B_HCV1A" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PB2_INFB" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_IBV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NSP9_HCoV-229E" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "RT_HIV1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NP_HCoV-NL63" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H5N1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "SPIKE_PDCoV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H5N3" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H6N1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H6N6" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "SPIKE_MHV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H3N8" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H7N2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H7N9" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "SPIKE_MERs" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_INFB" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_SARS" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HE_BCV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "SPIKE_IBV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H7N7" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HE_HCoV-OC43" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H3N2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H2N2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "GP160_HIV1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "GP160_HIV2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "VP36_EBOV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "GP_EBOV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H10N7" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H10N8" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "SPIKE_SARS" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H13N6" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H14N6" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H15N9" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H17N10" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "SPIKE_SARS2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H18N11" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_A-H1N1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "VP35_EBOV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HE_MHV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "HA_INFD" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "SPIKE_HCoV-229E" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_SARS2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NP_A-H5N1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NP_A-H1N1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_INFB" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_TGEV" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H7N9" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H5N1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H3N8" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H3N2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H2N2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H1N1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "IN_HIV1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H18N11" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H17N10" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H13N9" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PR_HCoV-229E" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H12N5" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "SPIKE_HCoV-NL63" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "SPIKE_HKU4" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "MD_HKU4" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "MX2_A-H5N1" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H11N9" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "MD_MERs" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "SPIKE_HCoV-OC43" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NA_A-H11N6" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "SPIKE_MHV", "", "", "", "[]", "Q9J3E7" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "VP35_EBOV", "", "", "", "[]", "Q05127" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "PR_HCoV-NL63", "", "", "", "[]", "CHEMBL3232683", "P0C6U6" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "SPIKE_HCoV-OC43", "", "", "", "[]", "Q696P8" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms" },
                values: new object[] { "PR_SARS2", "", "", "", "[]" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "PR_SARS", "", "", "", "[]", "CHEMBL5118", "P0C6X7" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "VP36_EBOV", "", "", "", "[]", "Q05127" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PR_HCoV-229E", "", "", "", "[]", "P0C6U2" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PR_HKU4", "", "", "", "[]", "P0C6W3" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "SPIKE_IBV", "", "", "", "[]", "F4MIW6" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "PR_HIV1", "", "", "", "[]", "CHEMBL3638331", "P03369" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PR_TGEV", "", "", "", "[]", "P0C6V2" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms" },
                values: new object[] { "SPIKE_SARS2", "", "", "", "[]" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PR_IBV", "", "", "", "[]", "P0C6V5" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "RT_HIV1", "", "", "", "[]", "CHEMBL3638360", "P04585" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "SPIKE_SARS", "", "", "", "[]", "P59594" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "SPIKE_MERs", "", "", "", "[]", "K9N5Q8" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PR_HKU1", "", "", "", "[]", "P0C6U3" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "SPIKE_PDCoV", "", "", "", "[]", "A0A075E3D7" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "SPIKE_HCoV-229E", "", "", "", "[]", "P15423" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PR_HIV2", "", "", "", "[]", "P04584" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PR_MERs", "", "", "", "[]", "V9TU12" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "SPIKE_HCoV-NL63", "", "", "", "[]", "Q6Q1S2" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PR_PEDV", "", "", "", "[]", "U6BPB2" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "SPIKE_HKU4", "", "", "", "[]", "A3EX94" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "NS3_HCV1A", "", "", "", "[]", "CHEMBL3638344", "P27958" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "PLP_SARS", "", "", "", "[]", "CHEMBL3927", "P0C6U8" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H7N7", "", "", "", "[]", "Q6VMK1" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H7N9", "", "", "", "[]", "M4YV75" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_INFB", "", "", "", "[]", "P03462" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_INFD", "", "", "", "[]", "K9LG83" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HE_BCV", "", "", "", "[]", "P15776" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HE_HCoV-OC43", "", "", "", "[]", "Q4VID6" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HE_MHV", "", "", "", "[]", "O92367" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "IN_HIV1", "", "", "", "[]", "P12497" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "MD_HKU4", "", "", "", "[]", "P0C6W3" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "MD_MERs", "", "", "", "[]", "K9N638" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "MX2_A-H5N1", "", "", "", "[]", "Q9Q0L9" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NA_A-H11N6", "", "", "", "[]", "Q6XV27" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NA_A-H11N9", "", "", "", "[]", "P03472" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NA_A-H12N5", "", "", "", "[]", "A1ILL9" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NA_A-H13N9", "", "", "", "[]", "P05803" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H7N2", "", "", "", "[]", "B7NY59" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NA_A-H17N10", "", "", "", "[]", "H6QM85" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H6N6", "", "", "", "[]", "A0A067YZ73" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H5N3", "", "", "", "[]", "A5Z226" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "GP160_HIV1", "", "", "", "[]", "C6G099" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "GP160_HIV2", "", "", "", "[]", "P20872" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "GP_EBOV", "", "", "", "[]", "CHEMBL4105829", "Q05320" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H10N7", "", "", "", "[]", "P12581" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H10N8", "", "", "", "[]", "A0A059T4A1" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H13N6", "", "", "", "[]", "P13103" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H14N6", "", "", "", "[]", "P26137" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H15N9", "", "", "", "[]", "L0L3X3" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H17N10", "", "", "", "[]", "H6QM93" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms" },
                values: new object[] { "HA_A-H18N11", "", "", "", "[]" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H1N1", "", "", "", "[]", "C7C6F1" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H2N2", "", "", "", "[]", "P03451" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "HA_A-H3N2", "", "", "", "[]", "CHEMBL2366448", "K7N5L2" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H3N8", "", "", "", "[]", "Q82847" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H5N1", "", "", "", "[]", "Q6DQ34" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "HA_A-H6N1", "", "", "", "[]", "A0A0J9X268" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PR_FCoV", "", "", "", "[]", "Q98VG9" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms" },
                values: new object[] { "NA_A-H18N11", "", "", "", "[]" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NA_A-H2N2", "", "", "", "[]", "P06820" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "NSP1_SARS", "", "", "", "[]", "CHEMBL5118", "P0C6X7" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NSP3_HCoV-229E", "", "", "", "[]", "P0C6U2" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NSP3_IBV", "", "", "", "[]", "P0C6V5" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NSP3_MHV", "", "", "", "[]", "P0C6X9" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NSP9_HCoV-229E", "", "", "", "[]", "P0C6X1" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PA_A-H17N10", "", "", "", "[]", "H6QM92" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PA_A-H1N1", "", "", "", "[]", "C3W5S0" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PA_A-H5N1", "", "", "", "[]", "Q9Q0U9" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "PA_INFA", "", "", "", "[]", "CHEMBL1169598", "P03433" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PA_INFB", "", "", "", "[]", "Q5V8Z9" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PB2_A-H3N2", "", "", "", "[]", "Q30NP1" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PB2_A-H5N1", "", "", "", "[]", "Q2LG68" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PB2_INFB", "", "", "", "[]", "Q9QLL6" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PB3_A-H3N2", "", "", "", "[]", "Q30NP1" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "PB4_A-H3N2", "", "", "", "[]", "Q30NP1" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NSP1_INFB", "", "", "", "[]", "P03502" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NA_A-H1N1", "", "", "", "[]", "C6KP13" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "NSP15_SARS", "", "", "", "[]", "CHEMBL5118", "P0C6X7" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "NS5B_HCV1B", "", "", "", "[]", "CHEMBL6040", "P26663" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NA_A-H3N2", "", "", "", "[]", "P84751" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NA_A-H3N8", "", "", "", "[]", "Q07599" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NA_A-H5N1", "", "", "", "[]", "A0A0C5BL75" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NA_A-H7N9", "", "", "", "[]", "R4NFR6" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "NA_INFB", "", "", "", "[]", "CHEMBL3377", "P03474" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NP_A-H1N1", "", "", "", "[]", "Q1K9H2" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NP_A-H5N1", "", "", "", "[]", "Q9PX50" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NP_HCoV-NL63", "", "", "", "[]", "Q6Q1R8" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "NP_HCoV-OC43", "", "", "", "[]", "CHEMBL3232681", "P33469" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NP_INFB", "", "", "", "[]", "C4LQ26" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NP_INFD", "", "", "", "[]", "A0A0E3VZU8" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NP_SARS", "", "", "", "[]", "P59595" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "NS3_HCV1B", "", "", "", "[]", "CHEMBL3988605", "Q91RS4" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NS3_HCV3A", "", "", "", "[]", "A0A0B4WYC6" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "UniProt_Id" },
                values: new object[] { "NS5B_HCV1A", "", "", "", "[]", "CHEMBL4620", "P26664" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "NS5B_HCV2A", "", "", "", "[]", "Q99IB8" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[] { "VP37_EBOV", "", "", "", "[]", "Q05127" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7093171442464223862L, 0, 637196402402073614L, true, 1, -1211722629752643376L, -1211722629752643376L, 637196323665879207L, "5F4L" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 281319347400019704L, 1, 637196402442566683L, true, 1, 8855316906542671864L, 8855316906542671864L, 637196323264704452L, "2J98" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5612494110248177836L, 0, 637196402445386726L, true, 1, 1375690530802579281L, 1375690530802579281L, 637196322475513882L, "4NFZ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6453878123671001285L, 0, 637196402443446649L, true, 1, -2630250922116285607L, 4075666249737270920L, 637196322552292554L, "5W92" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6453878123671001285L, 1, 637196402443726665L, true, 1, -1528188486082370082L, -7229983009515791560L, 637196322564969632L, "5WA6" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6453878123671001285L, 2, 637196402444016674L, true, 1, -1521774572194205085L, 4281772019973830006L, 637196322577552662L, "5WE7" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5243726574043799506L, 0, 637196402444426607L, true, 1, 4838259271067540991L, 4838259271067540991L, 637196322898254395L, "3HW3" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5243726574043799506L, 1, 637196402444716600L, true, 1, -7582420415813727485L, -7582420415813727485L, 637196322910964300L, "3HW4" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5243726574043799506L, 2, 637196402444986642L, true, 1, 8609532172918504100L, 8609532172918504100L, 637196322922454307L, "3HW5" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 281319347400019704L, 0, 637196402442306718L, true, 1, 5722181626600227684L, 5722181626600227684L, 637196323246554414L, "2J97" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3700660234162323339L, 0, 637196402445916672L, true, 1, 3916220015143441326L, 3916220015143441326L, 637196324040890953L, "4ZI0" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3700660234162323339L, 2, 637196402446466594L, true, 1, -6717542540461627133L, -6717542540461627133L, 637196324069370894L, "5FDD" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5942723027128670584L, 0, 637196402446866671L, true, 1, -5469060655960558546L, -5469060655960558546L, 637196324161428700L, "6FS8" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7300021075287053086L, 0, 637196402447256663L, true, 1, -5924115291875851415L, -2448806466342191916L, 637196322721142456L, "5F79" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7300021075287053086L, 1, 637196402447536698L, true, 1, 4543459626819877855L, 7649589858842206141L, 637196322731032352L, "5JUR" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5200780864725164628L, 0, 637196402447966763L, true, 1, 7950039949190293905L, 7950039949190293905L, 637196322933514628L, "4CB4" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5200780864725164628L, 1, 637196402448236638L, true, 1, -6182705482413285847L, -6182705482413285847L, 637196322943904393L, "4CB5" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5200780864725164628L, 2, 637196402448546604L, true, 1, 4067295806960792730L, 4067295806960792730L, 637196322954738290L, "4CB6" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2988465955223406714L, 0, 637196402448976605L, true, 1, -6804956595379231327L, -6804956595379231327L, 637196324171668793L, "5EFA" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3700660234162323339L, 1, 637196402446196671L, true, 1, 3663401988263203502L, 3663401988263203502L, 637196324055286323L, "4ZQQ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2918000322122842432L, 0, 637196402441886654L, false, 1, 218297055449129555L, -624102314472273022L, 637196324303931187L, "4YPT" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -665561656627536551L, 0, 637196402441516673L, true, 1, -5679446899330023741L, -5679446899330023741L, 637196324003917929L, "3EWP" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7650185638111666594L, 0, 637196402441076652L, true, 1, 327829874314193243L, 327829874314193243L, 637196323230130466L, "3EWR" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1433670812217117972L, 2, 637196402434636651L, true, 1, -8411525459914864759L, -8411525459914864759L, 637196323469632898L, "2OC1" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3611740801321136024L, 0, 637196402435176648L, true, 1, -6340618116047810490L, -6340618116047810490L, 637196323523883875L, "2A4Q" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3611740801321136024L, 1, 637196402435446693L, true, 1, -2116676060754620683L, -2116676060754620683L, 637196323532979186L, "2F9U" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3611740801321136024L, 2, 637196402435716655L, true, 1, -6332105674237506015L, -6332105674237506015L, 637196323542085202L, "2OBO" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5847031129161083759L, 0, 637196402436116600L, true, 1, 8542158156026376298L, -3015428022103643419L, 637196323635654957L, "5EQR" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5847031129161083759L, 1, 637196402436386665L, true, 1, 3876310002262968150L, 8013535072615973588L, 637196323643828974L, "5EQS" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5847031129161083759L, 2, 637196402436676680L, true, 1, -8277525778366446490L, 1824064110205095833L, 637196323652058815L, "5ESB" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8572324593866944657L, 0, 637196402437166633L, true, 1, -5229976822089749763L, -5229976822089749763L, 637196323485369317L, "3HKW" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8572324593866944657L, 1, 637196402437446823L, true, 1, -6227445179723988285L, 6381590238237875735L, 637196323499519451L, "3QGH" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8572324593866944657L, 2, 637196402437726648L, true, 1, -7798097409506319037L, -6623513950081806041L, 637196323514319321L, "3QGI" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8546224597772558872L, 0, 637196402438276651L, true, 1, 8172332567022159868L, -2428946978261999526L, 637196323558609242L, "2HAI" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8546224597772558872L, 1, 637196402438556684L, true, 1, 1526009158233761656L, 1526009158233761656L, 637196323577426980L, "2HWH" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8546224597772558872L, 2, 637196402438836657L, true, 1, -380639037151792649L, -380639037151792649L, 637196323594187304L, "2HWI" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7524106280427146489L, 0, 637196402439296672L, true, 1, -3039398999969836924L, -5235504682471345976L, 637196323611921085L, "5QJ0" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7524106280427146489L, 1, 637196402439586658L, true, 1, 9128928348871527433L, 4775188617637884880L, 637196323627395052L, "5TWM" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2590541954298672216L, 0, 637196402443076643L, false, 1, 6977214866053621998L, 6977214866053621998L, 637196324388469311L, "2H85" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2969350817401079966L, 0, 637196402439986649L, false, 1, -5155264419386718854L, -5155264419386718854L, 637196324139980432L, "3R66" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2969350817401079966L, 1, 637196402440216651L, false, 1, 5519438006150800156L, 5519438006150800156L, 637196324150220452L, "3SDL" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 50008268315844408L, 0, 637196402440706668L, false, 1, 5448398583462143478L, 5448398583462143478L, 637196324364409549L, "2HSX" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 6591465821529131653L, 0, 637196402449426702L, true, 1, -780074746773673795L, -7611314182855366487L, 637196322741438274L, "5JUN" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1433670812217117972L, 1, 637196402434376707L, true, 1, -3066881055549631115L, -3066881055549631115L, 637196323448531620L, "2OC0" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -69781506867200169L, 0, 637196402449796684L, true, 1, 5354487941452200555L, -79358803977263006L, 637196322757585258L, "5BUH" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1219990520152534512L, 1, 637196402450606658L, true, 1, -1976250303435181540L, -1976250303435181540L, 637196324421566067L, "4OVZ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1872973139781068285L, 0, 637196402459206629L, false, 1, -7233828070973623041L, -7233828070973623041L, 637196324549841547L, "3MP2" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8704127147396061018L, 0, 637196402459776663L, true, 1, 343205092392708338L, 5640263395210386672L, 637196323791832426L, "1DTQ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8704127147396061018L, 1, 637196402460056690L, true, 1, -8766464227703437417L, -8766464227703437417L, 637196323815332480L, "1REV" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8704127147396061018L, 2, 637196402460346644L, true, 1, -4729299619240689012L, -271972920212129337L, 637196323834742469L, "3LP1" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4899220541200285866L, 0, 637196402460726609L, false, 1, -961048105583485433L, -961048105583485433L, 637196323305327916L, "6ATK" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3692134124478738684L, 0, 637196402461106655L, false, 1, 139672326635065125L, 139672326635065125L, 637196323352661785L, "3KBH" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -242049240043911318L, 0, 637196402461486653L, true, 1, -862851599953885418L, -862851599953885418L, 637196323404466868L, "6NZK" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 6605277735121113275L, 0, 637196402461866679L, false, 1, -8069831981869045622L, -8069831981869045622L, 637196323991188871L, "4QZV" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -9100459219184827355L, 0, 637196402458846683L, true, 1, 4014149300735515250L, 4014149300735515250L, 637196324535691646L, "6LU7" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6164381918649516809L, 0, 637196402462226669L, false, 1, -4600215027447607337L, 2811717522112573316L, 637196324026859788L, "6CV0" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1072331945716584447L, 1, 637196402462876700L, false, 1, 7854465984956593844L, 7854465984956593844L, 637196324263758717L, "5W9I" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1072331945716584447L, 2, 637196402463146608L, false, 1, -2424455383157136757L, -2424455383157136757L, 637196324276308726L, "5YY5" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 6220502229929552289L, 0, 637196402463546640L, false, 1, 263587192426151480L, 1059521784436658678L, 637196324313391115L, "3R4D" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5351545181728830974L, 0, 637196402463936667L, false, 1, -6177418110965526647L, 6892805679321399852L, 637196324322517445L, "6B7N" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4049336189823579742L, 0, 637196402464356675L, false, 1, 7088315189527071735L, 7088315189527071735L, 637196324519051541L, "2DD8" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4049336189823579742L, 1, 637196402464586637L, false, 1, 4145441955741369801L, 4145441955741369801L, 637196324535671625L, "3D0H" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4058645023288619707L, 0, 637196402464976749L, false, 1, 333604594743797149L, 1911219531279703827L, 637196324535711541L, "6VSB" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4944775172720482117L, 0, 637196402465356642L, true, 1, -9071029034250519511L, -9071029034250519511L, 637196323174807514L, "4IBG" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1072331945716584447L, 0, 637196402462626659L, false, 1, -34525789922459441L, -34525789922459441L, 637196324250576229L, "5W9H" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5618511454157090880L, 2, 637196402458466637L, true, 1, -5663695438083445323L, -5663695438083445323L, 637196324502371593L, "4TWY" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5618511454157090880L, 1, 637196402458186671L, true, 1, -1053539416096575039L, -1053539416096575039L, 637196324479711679L, "2D2D" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5618511454157090880L, 0, 637196402457926655L, true, 1, -5126928171468584975L, -5126928171468584975L, 637196324459951916L, "2AMD" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1219990520152534512L, 2, 637196402450946627L, true, 1, -104257577514441061L, -104257577514441061L, 637196324438926065L, "4OW0" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -482653893857494396L, 0, 637196402451376648L, true, 1, 4489315596996889897L, 4231746984799945848L, 637196323215140649L, "4ZRO" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4257367663023912033L, 0, 637196402451836662L, false, 1, -4005407418126077922L, 6998523893187872627L, 637196323279149128L, "1P9S" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4257367663023912033L, 1, 637196402452076634L, false, 1, 8907778946861734034L, 8907778946861734034L, 637196323294155018L, "2ZU2" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 6275669838524203807L, 0, 637196402452586652L, false, 1, -4419126544738384092L, -4419126544738384092L, 637196323327337403L, "3TLO" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 6275669838524203807L, 1, 637196402452826653L, true, 1, -4599232170524315986L, -4599232170524315986L, 637196323339735508L, "5GWY" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6963932294249849891L, 0, 637196402453366643L, true, 1, -6284054880141579742L, -6284054880141579742L, 637196323739622178L, "1AID" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6963932294249849891L, 1, 637196402453606724L, true, 1, -8155718965109551788L, 3753528671862563278L, 637196323754732138L, "1D4K" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6963932294249849891L, 2, 637196402453896802L, true, 1, 2517949148906082027L, 2517949148906082027L, 637196323770262156L, "2AID" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5714615048382812488L, 0, 637196402454306681L, true, 1, 3196905824669827549L, 3196905824669827549L, 637196323861232525L, "5UPJ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5714615048382812488L, 1, 637196402454576672L, true, 1, 5708641579951146569L, 5708641579951146569L, 637196323875543955L, "6UPJ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7908155078585916504L, 0, 637196402454966654L, true, 1, -2052410204337637870L, -2052410204337637870L, 637196323887336837L, "3D23" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2082979118763922837L, 0, 637196402455356689L, true, 1, -3333275291740598868L, -3333275291740598868L, 637196323948011763L, "4YOG" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2082979118763922837L, 1, 637196402455616676L, true, 1, 5491202804428493846L, 5491202804428493846L, 637196323964332013L, "4YOI" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2082979118763922837L, 2, 637196402455866607L, true, 1, -2370539329486945747L, -2370539329486945747L, 637196323978538166L, "4YOJ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5269927716098830578L, 0, 637196402456306670L, true, 1, -1074564863291879616L, -1074564863291879616L, 637196324016912053L, "2Q6F" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8235401691306039847L, 0, 637196402456706676L, true, 1, -6345754567393681167L, -6345754567393681167L, 637196324228512833L, "4RSP" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8235401691306039847L, 1, 637196402456986677L, true, 1, -7866746045727045339L, -7866746045727045339L, 637196324237906995L, "4YLU" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3640637760515103087L, 0, 637196402457376647L, false, 1, -2667128301228892624L, -2667128301228892624L, 637196324332293644L, "5HYO" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1219990520152534512L, 0, 637196402450326682L, true, 1, -84972429826391113L, -84972429826391113L, 637196324406154270L, "3MJ5" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1433670812217117972L, 0, 637196402434106694L, true, 1, -9147233850640269755L, -9147233850640269755L, 637196323425481608L, "2OBQ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2049611342196008875L, 0, 637196402433596720L, false, 1, -4477244618554373891L, -4477244618554373891L, 637196324343528864L, "1SSK" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6578575101409681208L, 0, 637196402433216656L, false, 1, -3336873197272911503L, 6687542684534322705L, 637196324190183040L, "5N2U" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5916138029700665692L, 0, 637196402407613637L, true, 1, -2207365088160095325L, -2207365088160095325L, 637196322831947080L, "3ZNK" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5916138029700665692L, 1, 637196402408103631L, true, 1, -7009079247548318099L, -7009079247548318099L, 637196322843274309L, "3ZP0" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5916138029700665692L, 2, 637196402408683664L, true, 1, -5541899369158573950L, -5541899369158573950L, 637196322854404361L, "3ZP1" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1703022165787516192L, 0, 637196402409313618L, true, 1, 2164656747762391564L, 7305334037055757112L, 637196322964998368L, "1JSN" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1703022165787516192L, 1, 637196402409663614L, true, 1, -2909864367824465170L, 732468320571026188L, 637196322975418360L, "1JSO" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7948786994371912182L, 0, 637196402410143621L, true, 1, -7238604269935273471L, -7238604269935273471L, 637196322984498275L, "4XKE" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3312288386219443198L, 0, 637196402410603632L, true, 1, 5951138504367713298L, 5951138504367713298L, 637196322993718276L, "5BQY" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1767693762405330606L, 0, 637196402411013704L, true, 1, 7557179632011922176L, -7241948040589110173L, 637196323003968391L, "3M5H" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3249733638923725489L, 2, 637196402406793631L, true, 1, 5819429173306725413L, 676924190836111635L, 637196322787507118L, "4UNZ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1767693762405330606L, 1, 637196402411293664L, true, 1, 848999891618739426L, 848999891618739426L, 637196323013442299L, "3M5I" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4191329061714548831L, 0, 637196402411953719L, true, 1, -6942006683433844102L, -6942006683433844102L, 637196323032642215L, "4DJ7" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4191329061714548831L, 1, 637196402412186982L, true, 1, -6407568658962729635L, -6407568658962729635L, 637196323042522212L, "4DJ8" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6814136620749759278L, 0, 637196402412566664L, true, 1, -3695265004548197515L, -3695265004548197515L, 637196323053479514L, "4BSE" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4120045831199128135L, 0, 637196402415636674L, true, 1, 6192953482685782276L, 6192953482685782276L, 637196324080810883L, "2RFT" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4120045831199128135L, 1, 637196402415926637L, true, 1, -1034224972627920970L, -1034224972627920970L, 637196324092612446L, "2RFU" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4458988227912794195L, 0, 637196402416276622L, false, 1, -4802008064951352817L, -4802008064951352817L, 637196324181956912L, "5E64" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2686246146403624428L, 0, 637196402416666852L, false, 1, 1704251630109315847L, 1704251630109315847L, 637196323099042136L, "3CL4" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2686246146403624428L, 1, 637196402416906649L, false, 1, 531159051746065774L, 531159051746065774L, 637196323112920632L, "3CL5" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1767693762405330606L, 2, 637196402411583686L, true, 1, -1300373814321237040L, 8544806592608843587L, 637196323022422313L, "3M5J" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3249733638923725489L, 1, 637196402406493618L, true, 1, 8718592813497210338L, -155260393358356296L, 637196322778247186L, "4UNY" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3249733638923725489L, 0, 637196402406193632L, true, 1, -488615357193673308L, -488615357193673308L, 637196322767743057L, "4UNX" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3487149310279799938L, 2, 637196402405733636L, true, 1, -7176608774641909017L, -7176608774641909017L, 637196322688276756L, "2YP5" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7093171442464223862L, 1, 637196402402413630L, true, 1, -9072353423873490963L, -9072353423873490963L, 637196323678779193L, "5F4P" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7093171442464223862L, 2, 637196402402723667L, true, 1, -7889701828992944611L, 78163539924177727L, 637196323690114711L, "5F4R" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -455116379065447313L, 0, 637196402403143620L, false, 1, 1054496126206988534L, -4057400073407317451L, 637196323846438914L, "5CAY" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4711605374898453730L, 0, 637196402400803635L, true, 1, -6457271034719516043L, 2957329832963789844L, 637196323128595469L, "5JQ7" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4711605374898453730L, 1, 637196402401203629L, true, 1, 4891122576296706374L, -5445921084973877150L, 637196323146165019L, "5JQB" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4711605374898453730L, 2, 637196402401613625L, true, 1, 2527002267736658215L, -3461611271109241473L, 637196323162624599L, "6NAE" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6439732228708196463L, 0, 637196402412936644L, true, 1, 4445740274996934719L, 4445740274996934719L, 637196322276972751L, "4D00" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4403149430178897900L, 0, 637196402413326645L, true, 1, -7238604269935273471L, -7238604269935273471L, 637196322289214355L, "4XQO" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -472644960433884999L, 0, 637196402413666605L, false, 1, 2341181715631100039L, 8375453984128103215L, 637196322410408769L, "4KPQ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6621179517358550914L, 0, 637196402414086609L, true, 1, -873598804290801681L, -8082053005653984510L, 637196322436007608L, "3EYK" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7371096713491547550L, 0, 637196402414486696L, true, 1, -7995892188414747422L, -7995892188414747422L, 637196322446057658L, "5TG8" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5788469372983292511L, 0, 637196402414876632L, true, 1, 2108769264439816840L, 2108769264439816840L, 637196322456003543L, "4I78" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8016147709636077880L, 0, 637196402415246654L, true, 1, 7663621374218005449L, 7663621374218005449L, 637196322475533844L, "4K3X" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5143425767058699890L, 0, 637196402403553620L, true, 1, 8581305612935356477L, 8581305612935356477L, 637196322485663896L, "3HTP" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5143425767058699890L, 1, 637196402403843628L, true, 1, -7744577861627787398L, -7744577861627787398L, 637196322495393823L, "3HTT" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7737333266689075166L, 0, 637196402404273641L, false, 1, 2421700621599028257L, 2421700621599028257L, 637196322589833956L, "4HFU" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7737333266689075166L, 1, 637196402404553620L, false, 1, -8458569962114835866L, -8458569962114835866L, 637196322602223904L, "4HG4" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3487149310279799938L, 0, 637196402405123614L, true, 1, -1783309303992962323L, -1783309303992962323L, 637196322668124574L, "2YP3" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3487149310279799938L, 1, 637196402405433646L, true, 1, -6515839302675581027L, -6515839302675581027L, 637196322677956781L, "2YP4" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7030475524457147395L, 0, 637196402417316630L, false, 1, 1045015100871598139L, 1045015100871598139L, 637196323364159678L, "5N11" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -957424590644289583L, 0, 637196402417686655L, false, 1, 6764613996250655740L, 6764613996250655740L, 637196324287888636L, "5JIF" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 403638485696797036L, 0, 637196402418106756L, true, 1, 1493073555389719828L, 1493073555389719828L, 637196323707349142L, "3LPT" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 403638485696797036L, 1, 637196402418356647L, true, 1, -3329279741066746690L, -3329279741066746690L, 637196323725119230L, "3LPU" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5842474478118004459L, 1, 637196402422346644L, false, 1, 2596407509389025013L, 2596407509389025013L, 637196322711182384L, "2AEQ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3882425025535722525L, 0, 637196402422786866L, true, 1, 5766332191703148539L, 5766332191703148539L, 637196322798587196L, "4D8S" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3882425025535722525L, 1, 637196402423066768L, true, 1, -7802078485535944301L, -7802078485535944301L, 637196322809587232L, "4MJU" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3882425025535722525L, 2, 637196402423346607L, true, 1, -6538170701769594972L, -6538170701769594972L, 637196322820702301L, "4MJV" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4175252559121933339L, 0, 637196402423726653L, false, 1, 469060726562927961L, 469060726562927961L, 637196322875044410L, "5HUG" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4323105175943048197L, 0, 637196402424166634L, true, 1, -7748287091341744078L, -7748287091341744078L, 637196323064310401L, "5L15" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4323105175943048197L, 1, 637196402424426647L, true, 1, -9219900854958655456L, -9219900854958655456L, 637196323074560337L, "5L17" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4323105175943048197L, 2, 637196402424696649L, true, 1, -1121429969795664354L, -1121429969795664354L, 637196323084571992L, "5L18" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7892303066444267602L, 0, 637196402429236646L, true, 1, -7647281605051136947L, -7647281605051136947L, 637196324106193481L, "1INF" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7892303066444267602L, 1, 637196402429506667L, true, 1, -6228921371776487059L, -6228921371776487059L, 637196324119223769L, "1IVB" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7613623469306449977L, 0, 637196402429936675L, true, 1, 5939383066838058359L, -824053442797967652L, 637196322516929743L, "3RO5" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7613623469306449977L, 1, 637196402430186678L, true, 1, 7221169371405960443L, 2709978459458367380L, 637196322527996697L, "3TG6" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7613623469306449977L, 2, 637196402430476751L, true, 1, -4141331681265292494L, -1678933745719989864L, 637196322539856697L, "6J1U" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2044591495024759508L, 0, 637196402430836647L, true, 1, 6587810676392032821L, 6156912503464729002L, 637196322886614307L, "2Q06" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 883091514397573356L, 0, 637196402431226720L, false, 1, 8826314902029154417L, -6849532885220178012L, 637196323315857413L, "5N4K" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2018918786060414569L, 0, 637196402431796605L, true, 1, 6967840499910773734L, 6967840499910773734L, 637196323374495915L, "4KXJ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2018918786060414569L, 1, 637196402432126781L, true, 1, -6861294257734877994L, -6861294257734877994L, 637196323383335919L, "4LI4" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2018918786060414569L, 2, 637196402432406783L, true, 1, 6081538635415628916L, 6081538635415628916L, 637196323393061055L, "4LM7" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8490504442079014776L, 0, 637196402432836672L, true, 1, 7974289228647645259L, 7974289228647645259L, 637196324129203813L, "3TJ0" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5842474478118004459L, 0, 637196402422106614L, false, 1, -6131219425147937898L, -6131219425147937898L, 637196322700482759L, "2AEP" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8081953811632666512L, 0, 637196402465806673L, true, 1, -8515900817530947300L, -8515900817530947300L, 637196323187965315L, "4IBD" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2276765159745676623L, 2, 637196402421746689L, true, 1, -1780072502197047387L, -1780072502197047387L, 637196322657271803L, "1IVE" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2276765159745676623L, 0, 637196402421196650L, true, 1, -2519975705962826018L, -2519975705962826018L, 637196322629064318L, "1IVC" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8747472946734632848L, 0, 637196402418746672L, true, 1, -7973458075167344605L, -7973458075167344605L, 637196323902085553L, "6MEA" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8747472946734632848L, 1, 637196402419046678L, true, 1, 7242947529055081186L, 7242947529055081186L, 637196323916935564L, "6MEB" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8747472946734632848L, 2, 637196402419316666L, true, 1, 2719389971753726607L, 2719389971753726607L, 637196323933205486L, "6MEN" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5067353867499437422L, 0, 637196402419726671L, true, 1, -1145190280203817859L, -1145190280203817859L, 637196324203992899L, "5DUS" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 5067353867499437422L, 1, 637196402419956640L, false, 1, 9112013003321501276L, 9112013003321501276L, 637196324216922832L, "5HIH" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8489289755120389149L, 0, 637196402420376827L, true, 1, -3599851711478657983L, -3599851711478657983L, 637196322864224387L, "6BKK" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1956200189350455062L, 0, 637196402425106614L, true, 1, 1177885651993299083L, 1177885651993299083L, 637196322301411213L, "2CML" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1956200189350455062L, 1, 637196402425366650L, true, 1, -2866716798732612364L, -2866716798732612364L, 637196322313560687L, "6HFY" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1956200189350455062L, 2, 637196402425626694L, true, 1, 3818965426496634776L, 3818965426496634776L, 637196322327316112L, "6HG5" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -301257636530356541L, 0, 637196402425996652L, false, 1, -3468199577243159362L, -3468199577243159362L, 637196322340937352L, "1A14" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -301257636530356541L, 1, 637196402426256731L, true, 1, -1707842224193355618L, -1707842224193355618L, 637196322355396337L, "1F8B" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -301257636530356541L, 2, 637196402426546669L, true, 1, 4673530341204064585L, 4673530341204064585L, 637196322368119144L, "6HEB" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2863432470013529596L, 0, 637196402426916640L, false, 1, -4416535198438625832L, -4416535198438625832L, 637196322378258190L, "3SAL" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2863432470013529596L, 1, 637196402427206612L, true, 1, 3952727498903944474L, 7172816495176160305L, 637196322388424100L, "3SAN" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2863432470013529596L, 2, 637196402427496651L, true, 1, -64138342066921719L, -363678738901988410L, 637196322398924613L, "3TI8" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1337739520828764931L, 0, 637196402427846642L, false, 1, 3935617912151996400L, 3935617912151996400L, 637196322423907968L, "1NMB" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3032824679694898389L, 0, 637196402428246683L, false, 1, -238089606402683743L, -238089606402683743L, 637196322466249272L, "4GDI" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6558285941114696926L, 0, 637196402428636684L, false, 1, -6236561856319302409L, -6236561856319302409L, 637196322475553828L, "4K3Y" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 772908198962668604L, 0, 637196402420776686L, true, 1, 4609082757846526070L, 4609082757846526070L, 637196322506607290L, "6G01" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2276765159745676623L, 1, 637196402421476654L, true, 1, -4366281347704544995L, -4366281347704544995L, 637196322643376835L, "1IVD" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3108816072978716400L, 0, 637196402466196647L, true, 1, -5317932711473299662L, -5317932711473299662L, 637196323200196926L, "4IBC" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "GP_EBOV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "GP160_HIV1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "GP160_HIV2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H10N7" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H10N8" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H13N6" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H14N6" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H15N9" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H17N10" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H18N11" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H1N1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H2N2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H3N2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H3N8" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H5N1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H5N3" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H6N1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H6N6" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H7N2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H7N7" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_A-H7N9" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_INFB" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HA_INFD" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HE_BCV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HE_HCoV-OC43" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "HE_MHV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "IN_HIV1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "MD_HKU4" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "MD_MERs" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "MX2_A-H5N1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H11N6" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H11N9" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H12N5" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H13N9" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H17N10" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H18N11" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H1N1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H2N2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H3N2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H3N8" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H5N1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_A-H7N9" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NA_INFB" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NP_A-H1N1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NP_A-H5N1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NP_HCoV-NL63" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NP_HCoV-OC43" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NP_INFB" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NP_INFD" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NP_SARS" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NS3_HCV1A" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NS3_HCV1B" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NS3_HCV3A" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NS5B_HCV1A" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NS5B_HCV1B" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NS5B_HCV2A" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NSP1_INFB" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NSP1_SARS" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NSP15_SARS" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NSP3_HCoV-229E" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NSP3_IBV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NSP3_MHV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NSP9_HCoV-229E" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PA_A-H17N10" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PA_A-H1N1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PA_A-H5N1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PA_INFA" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PA_INFB" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PB2_A-H3N2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PB2_A-H5N1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PB2_INFB" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PB3_A-H3N2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PB4_A-H3N2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PLP_SARS" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_FCoV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_HCoV-229E" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_HCoV-NL63" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_HIV1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_HIV2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_HKU1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_HKU4" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_IBV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_MERs" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_PEDV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_SARS" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_SARS2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PR_TGEV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "RT_HIV1" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "SPIKE_HCoV-229E" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "SPIKE_HCoV-NL63" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "SPIKE_HCoV-OC43" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "SPIKE_HKU4" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "SPIKE_IBV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "SPIKE_MERs" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "SPIKE_MHV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "SPIKE_PDCoV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "SPIKE_SARS" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "SPIKE_SARS2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "VP35_EBOV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "VP36_EBOV" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "VP37_EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "GP_EBOV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "GP160_HIV1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "GP160_HIV2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H10N7");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H10N8");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H13N6");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H14N6");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H15N9");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H17N10");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H18N11");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H1N1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H2N2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H3N2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H3N8");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H5N1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H5N3");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H6N1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H6N6");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H7N2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H7N7");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_A-H7N9");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_INFB");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HA_INFD");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HE_BCV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HE_HCoV-OC43");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HE_MHV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "IN_HIV1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "MD_HKU4");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "MD_MERs");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "MX2_A-H5N1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H11N6");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H11N9");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H12N5");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H13N9");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H17N10");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H18N11");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H1N1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H2N2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H3N2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H3N8");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H5N1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_A-H7N9");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NA_INFB");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NP_A-H1N1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NP_A-H5N1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NP_HCoV-NL63");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NP_HCoV-OC43");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NP_INFB");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NP_INFD");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NP_SARS");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NS3_HCV1A");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NS3_HCV1B");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NS3_HCV3A");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NS5B_HCV1A");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NS5B_HCV1B");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NS5B_HCV2A");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NSP1_INFB");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NSP1_SARS");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NSP15_SARS");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NSP3_HCoV-229E");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NSP3_IBV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NSP3_MHV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NSP9_HCoV-229E");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PA_A-H17N10");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PA_A-H1N1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PA_A-H5N1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PA_INFA");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PA_INFB");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PB2_A-H3N2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PB2_A-H5N1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PB2_INFB");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PB3_A-H3N2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PB4_A-H3N2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PLP_SARS");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_FCoV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_HCoV-229E");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_HCoV-NL63");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_HIV1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_HIV2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_HKU1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_HKU4");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_IBV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_MERs");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_PEDV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_SARS");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_SARS2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PR_TGEV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "RT_HIV1");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "SPIKE_HCoV-229E");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "SPIKE_HCoV-NL63");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "SPIKE_HCoV-OC43");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "SPIKE_HKU4");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "SPIKE_IBV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "SPIKE_MERs");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "SPIKE_MHV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "SPIKE_PDCoV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "SPIKE_SARS");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "SPIKE_SARS2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "VP35_EBOV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "VP36_EBOV");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "VP37_EBOV");

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -9100459219184827355L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8704127147396061018L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8704127147396061018L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8704127147396061018L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8489289755120389149L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8235401691306039847L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8235401691306039847L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8081953811632666512L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8016147709636077880L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7948786994371912182L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7908155078585916504L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7737333266689075166L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7737333266689075166L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7524106280427146489L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7524106280427146489L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7371096713491547550L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7300021075287053086L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7300021075287053086L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7030475524457147395L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6963932294249849891L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6963932294249849891L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6963932294249849891L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6814136620749759278L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6621179517358550914L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6578575101409681208L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6558285941114696926L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6453878123671001285L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6453878123671001285L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6453878123671001285L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6439732228708196463L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6164381918649516809L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5788469372983292511L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5714615048382812488L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5714615048382812488L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5612494110248177836L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5351545181728830974L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5243726574043799506L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5243726574043799506L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5243726574043799506L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5143425767058699890L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5143425767058699890L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4711605374898453730L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4711605374898453730L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4711605374898453730L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4257367663023912033L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4257367663023912033L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4175252559121933339L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4120045831199128135L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4120045831199128135L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4058645023288619707L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4049336189823579742L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4049336189823579742L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3700660234162323339L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3700660234162323339L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3700660234162323339L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3640637760515103087L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3611740801321136024L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3611740801321136024L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3611740801321136024L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3312288386219443198L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3249733638923725489L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3249733638923725489L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3249733638923725489L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3108816072978716400L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3032824679694898389L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2918000322122842432L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2686246146403624428L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2686246146403624428L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2276765159745676623L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2276765159745676623L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2276765159745676623L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2049611342196008875L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1433670812217117972L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1433670812217117972L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1433670812217117972L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1337739520828764931L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -957424590644289583L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -665561656627536551L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -482653893857494396L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -472644960433884999L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -455116379065447313L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -301257636530356541L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -301257636530356541L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -301257636530356541L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -242049240043911318L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -69781506867200169L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 50008268315844408L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 281319347400019704L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 281319347400019704L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 403638485696797036L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 403638485696797036L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 772908198962668604L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 883091514397573356L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1072331945716584447L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1072331945716584447L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1072331945716584447L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1219990520152534512L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1219990520152534512L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1219990520152534512L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1703022165787516192L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1703022165787516192L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1767693762405330606L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1767693762405330606L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1767693762405330606L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1872973139781068285L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1956200189350455062L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1956200189350455062L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1956200189350455062L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2018918786060414569L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2018918786060414569L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2018918786060414569L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2044591495024759508L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2082979118763922837L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2082979118763922837L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2082979118763922837L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2590541954298672216L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2863432470013529596L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2863432470013529596L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2863432470013529596L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2969350817401079966L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2969350817401079966L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2988465955223406714L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3487149310279799938L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3487149310279799938L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3487149310279799938L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3692134124478738684L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3882425025535722525L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3882425025535722525L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3882425025535722525L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4191329061714548831L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4191329061714548831L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4323105175943048197L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4323105175943048197L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4323105175943048197L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4403149430178897900L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4458988227912794195L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4899220541200285866L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4944775172720482117L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5067353867499437422L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5067353867499437422L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5200780864725164628L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5200780864725164628L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5200780864725164628L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5269927716098830578L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5618511454157090880L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5618511454157090880L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5618511454157090880L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5842474478118004459L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5842474478118004459L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5847031129161083759L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5847031129161083759L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5847031129161083759L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5916138029700665692L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5916138029700665692L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5916138029700665692L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5942723027128670584L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 6220502229929552289L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 6275669838524203807L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 6275669838524203807L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 6591465821529131653L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 6605277735121113275L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7093171442464223862L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7093171442464223862L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7093171442464223862L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7613623469306449977L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7613623469306449977L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7613623469306449977L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7650185638111666594L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7892303066444267602L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7892303066444267602L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8490504442079014776L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8546224597772558872L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8546224597772558872L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8546224597772558872L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8572324593866944657L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8572324593866944657L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8572324593866944657L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8747472946734632848L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8747472946734632848L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8747472946734632848L, 2 });

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -9100459219184827355L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -8704127147396061018L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -8489289755120389149L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -8235401691306039847L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -8081953811632666512L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -8016147709636077880L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -7948786994371912182L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -7908155078585916504L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -7737333266689075166L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -7524106280427146489L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -7371096713491547550L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -7300021075287053086L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -7030475524457147395L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -6963932294249849891L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -6814136620749759278L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -6621179517358550914L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -6578575101409681208L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -6558285941114696926L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -6453878123671001285L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -6439732228708196463L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -6164381918649516809L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -5788469372983292511L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -5714615048382812488L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -5612494110248177836L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -5351545181728830974L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -5243726574043799506L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -5143425767058699890L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4711605374898453730L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4257367663023912033L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4175252559121933339L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4120045831199128135L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4058645023288619707L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4049336189823579742L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -3700660234162323339L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -3640637760515103087L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -3611740801321136024L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -3312288386219443198L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -3249733638923725489L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -3108816072978716400L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -3032824679694898389L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -2918000322122842432L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -2686246146403624428L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -2276765159745676623L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -2049611342196008875L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -1433670812217117972L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -1337739520828764931L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -957424590644289583L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -665561656627536551L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -482653893857494396L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -472644960433884999L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -455116379065447313L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -301257636530356541L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -242049240043911318L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -69781506867200169L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 50008268315844408L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 281319347400019704L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 403638485696797036L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 772908198962668604L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 883091514397573356L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 1072331945716584447L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 1219990520152534512L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 1703022165787516192L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 1767693762405330606L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 1872973139781068285L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 1956200189350455062L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 2018918786060414569L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 2044591495024759508L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 2082979118763922837L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 2590541954298672216L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 2863432470013529596L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 2969350817401079966L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 2988465955223406714L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 3487149310279799938L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 3692134124478738684L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 3882425025535722525L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 4191329061714548831L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 4323105175943048197L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 4403149430178897900L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 4458988227912794195L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 4899220541200285866L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 4944775172720482117L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 5067353867499437422L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 5200780864725164628L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 5269927716098830578L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 5618511454157090880L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 5842474478118004459L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 5847031129161083759L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 5916138029700665692L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 5942723027128670584L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 6220502229929552289L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 6275669838524203807L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 6591465821529131653L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 6605277735121113275L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 7093171442464223862L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 7613623469306449977L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 7650185638111666594L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 7892303066444267602L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 8490504442079014776L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 8546224597772558872L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 8572324593866944657L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 8747472946734632848L);

            migrationBuilder.DeleteData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "virus-ckb");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GP_EBOV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GP160_HIV1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GP160_HIV2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H10N7");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H10N8");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H13N6");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H14N6");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H15N9");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H17N10");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H18N11");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H1N1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H2N2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H3N2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H3N8");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H5N1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H5N3");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H6N1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H6N6");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H7N2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H7N7");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H7N9");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_INFB");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_INFD");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HE_BCV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HE_HCoV-OC43");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HE_MHV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "IN_HIV1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MD_HKU4");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MD_MERs");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MX2_A-H5N1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H11N6");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H11N9");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H12N5");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H13N9");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H17N10");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H18N11");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H1N1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H2N2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H3N2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H3N8");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H5N1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H7N9");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_INFB");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NP_A-H1N1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NP_A-H5N1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NP_HCoV-NL63");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NP_HCoV-OC43");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NP_INFB");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NP_INFD");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NP_SARS");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NS3_HCV1A");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NS3_HCV1B");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NS3_HCV3A");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NS5B_HCV1A");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NS5B_HCV1B");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NS5B_HCV2A");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP1_INFB");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP1_SARS");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP15_SARS");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP3_HCoV-229E");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP3_IBV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP3_MHV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP9_HCoV-229E");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PA_A-H17N10");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PA_A-H1N1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PA_A-H5N1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PA_INFA");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PA_INFB");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PB2_A-H3N2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PB2_A-H5N1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PB2_INFB");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PB3_A-H3N2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PB4_A-H3N2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PLP_SARS");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_FCoV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_HCoV-229E");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_HCoV-NL63");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_HIV1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_HIV2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_HKU1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_HKU4");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_IBV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_MERs");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_PEDV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_SARS");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_SARS2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_TGEV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RT_HIV1");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_HCoV-229E");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_HCoV-NL63");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_HCoV-OC43");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_HKU4");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_IBV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_MERs");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_MHV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_PDCoV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_SARS");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_SARS2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "VP35_EBOV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "VP36_EBOV");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "VP37_EBOV");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "dakb-gpcrs",
                column: "Citation",
                value: @"**DAKB-GPCRs: An Integrated Computational Platform for Drug Abuse Related GPCRs**  
Maozi Chen, Yankang Jing, Lirong Wang, Zhiwei Feng, Xiang-Qun Xie  
*J. Chem. Inf. Model.* 2019, 59, 4, 1283-1289  
Publication Date: March 5, 2019  
https://doi.org/10.1021/acs.jcim.8b00623  
https://www.ncbi.nlm.nih.gov/pubmed/30835466");
        }
    }
}
