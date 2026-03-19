using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DockingApiService.Migrations
{
    public partial class SeedingProteinTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "ADNV", "Andes orthohantavirus (ADNV)" });

            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "CoV", "Coronavirus (CoV)" });

            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "DENV", "Dengue virus (DENV)" });

            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "EBOV", "Ebola virus (EBOV)" });

            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "EV", "Enterovirus (EV)" });

            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "flu", "Influenza virus" });

            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "HCV", "Hepatitis C virus (HCV)" });

            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "HIV", "Human immunodeficiency virus (HIV)" });

            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "HSV", "Herpes simplex virus (HSV)" });

            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "LASV", "Lassa virus (LASV)" });

            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "NORV", "Norovirus (NORV)" });

            migrationBuilder.InsertData(
                table: "ProteinTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { "ZIKV", "Zika virus (ZIKV)" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "2A_HE71", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "2A_HE71M", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "2C_HE71", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "3A_9ENTO", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "3A_HE71M", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "3A_HED68", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "3C_HE71", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "3C_HED68", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "3D_HE71", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "3D_HED68", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "CAPSD_9ENTO", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "CAPSD_DEN2P", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "CAPSD_HCV77", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "CAPSD_HED68", "EV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "CAPSD_ZIKV", "ZIKV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "DPM_HHV1K", "HSV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "E1_9HEPC", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "E1_HCV77", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "E1_HCVJ1", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "E2_9HEPC", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "E2_HCV77", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "ENV_9FLAV", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "ENV_DEN1B", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "ENV_DEN2P", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "ENV_DEN3P", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "ENV_HHV2H", "HSV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "ENV_ZIKV", "ZIKV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "ENV_ZIKVK", "ZIKV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "G1_ADNV", "ADNV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "G2_ADNV", "ADNV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "GB_HHV11", "HSV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "GB_HHV1K", "HSV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "GD_HHV1", "HSV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "GP_EBOV", "EBOV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "GP_LASSJ", "LASV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "GP160_HIV1", "HIV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "GP160_HIV2", "HIV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H10N7", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H10N8", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H13N6", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H14N6", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H15N9", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H17N10", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H18N11", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H1N1", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H2N2", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H3N2", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H3N8", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H5N1", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H5N3", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H6N1", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H6N6", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H7N2", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H7N7", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_A-H7N9", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_INFB", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HA_INFD", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HE_BCV", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HE_HCoV-OC43", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "HE_MHV", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "IN_HIV1", "HIV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "MD_HKU4", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "MD_MERs", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "MEM_9FLAV", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "MTASE_SARS2", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "MX_9MONO", "EBOV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "MX_LASSJ", "LASV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "MX2_A-H5N1", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H11N6", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H11N9", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H12N5", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H13N9", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H17N10", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H18N11", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H1N1", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H2N2", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H3N2", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H3N8", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H5N1", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_A-H7N9", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NA_INFB", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NP_9ADNV", "ADNV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NP_A-H1N1", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NP_A-H5N1", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NP_EBOZM", "EBOV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NP_HCoV-NL63", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NP_HCoV-OC43", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NP_INFB", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NP_INFD", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NP_LASSJ", "LASV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NP_SARS", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS1_9CALI", "NORV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS1_9FLAV", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS1_DEN1W", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS1_ZIKV", "ZIKV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS2A_9FLAV", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS2B_DEN1W", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS2B_DEN2P", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS2B_ZIKV", "ZIKV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS2B_ZIKVF", "ZIKV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS3_9FLAV", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS3_DEN4T", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS3_HCV1A", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS3_HCV1B", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS3_HCV3A", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS3_ZIKV", "ZIKV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS5_9FLAV", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS5_DEN3S", "DENV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS5_ZIKV", "ZIKV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS5_ZIKVF", "ZIKV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS5B_HCV1A", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS5B_HCV1B", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS5B_HCV2A", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NS6_9CALI", "NORV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NSP1_INFB", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NSP1_SARS", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NSP15_SARS", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NSP15_SARS2", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NSP3_HCoV-229E", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NSP3_MHV", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NSP3_SARS2", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "NSP9_HCoV-229E", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "P_9CALI", "NORV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PA_A-H17N10", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PA_A-H1N1", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PA_A-H5N1", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PA_INFA", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PA_INFB", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PB2_A-H3N2", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PB2_A-H5N1", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PB2_INFB", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PB3_A-H3N2", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PB4_A-H3N2", "flu" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PLP_SARS", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PLP_SARS2", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PM_9VIRU", "LASV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PR_FCoV", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PR_HCoV-229E", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PR_HCoV-NL63", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PR_HIV1", "HIV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PR_HIV2", "HIV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PR_HKU1", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PR_HKU4", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PR_MERs", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PR_SARS", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PR_SARS2", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "PR_TGEV", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "RDRP_SARS2", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "RT_HIV1", "HIV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "SPIKE_HCoV-229E", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "SPIKE_HCoV-NL63", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "SPIKE_HCoV-OC43", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "SPIKE_HKU4", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "SPIKE_MERs", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "SPIKE_MHV", "HCV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "SPIKE_PDCoV", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "SPIKE_SARS", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "SPIKE_SARS2", "CoV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "VP1_9CALI", "NORV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "VP24_EBORE", "EBOV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "VP24_EBOSU", "EBOV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "VP24_EBOZM", "EBOV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "VP30_EBOZ5", "EBOV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "VP30_EBOZM", "EBOV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "VP35_EBORR", "EBOV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "VP35_EBOZM", "EBOV" });

            migrationBuilder.InsertData(
                table: "ProteinProteinTag",
                columns: new[] { "ProteinsId", "TagsId" },
                values: new object[] { "VP40_EBOZM", "EBOV" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "2A_HE71", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "2A_HE71M", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "2C_HE71", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "3A_9ENTO", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "3A_HE71M", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "3A_HED68", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "3C_HE71", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "3C_HED68", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "3D_HE71", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "3D_HED68", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "CAPSD_9ENTO", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "CAPSD_DEN2P", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "CAPSD_HCV77", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "CAPSD_HED68", "EV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "CAPSD_ZIKV", "ZIKV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "DPM_HHV1K", "HSV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "E1_9HEPC", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "E1_HCV77", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "E1_HCVJ1", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "E2_9HEPC", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "E2_HCV77", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "ENV_9FLAV", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "ENV_DEN1B", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "ENV_DEN2P", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "ENV_DEN3P", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "ENV_HHV2H", "HSV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "ENV_ZIKV", "ZIKV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "ENV_ZIKVK", "ZIKV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "G1_ADNV", "ADNV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "G2_ADNV", "ADNV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "GB_HHV11", "HSV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "GB_HHV1K", "HSV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "GD_HHV1", "HSV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "GP_EBOV", "EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "GP_LASSJ", "LASV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "GP160_HIV1", "HIV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "GP160_HIV2", "HIV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H10N7", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H10N8", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H13N6", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H14N6", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H15N9", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H17N10", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H18N11", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H1N1", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H2N2", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H3N2", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H3N8", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H5N1", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H5N3", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H6N1", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H6N6", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H7N2", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H7N7", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_A-H7N9", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_INFB", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HA_INFD", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HE_BCV", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HE_HCoV-OC43", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "HE_MHV", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "IN_HIV1", "HIV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "MD_HKU4", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "MD_MERs", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "MEM_9FLAV", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "MTASE_SARS2", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "MX_9MONO", "EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "MX_LASSJ", "LASV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "MX2_A-H5N1", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H11N6", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H11N9", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H12N5", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H13N9", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H17N10", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H18N11", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H1N1", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H2N2", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H3N2", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H3N8", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H5N1", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_A-H7N9", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NA_INFB", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NP_9ADNV", "ADNV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NP_A-H1N1", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NP_A-H5N1", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NP_EBOZM", "EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NP_HCoV-NL63", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NP_HCoV-OC43", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NP_INFB", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NP_INFD", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NP_LASSJ", "LASV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NP_SARS", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS1_9CALI", "NORV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS1_9FLAV", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS1_DEN1W", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS1_ZIKV", "ZIKV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS2A_9FLAV", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS2B_DEN1W", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS2B_DEN2P", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS2B_ZIKV", "ZIKV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS2B_ZIKVF", "ZIKV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS3_9FLAV", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS3_DEN4T", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS3_HCV1A", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS3_HCV1B", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS3_HCV3A", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS3_ZIKV", "ZIKV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS5_9FLAV", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS5_DEN3S", "DENV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS5_ZIKV", "ZIKV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS5_ZIKVF", "ZIKV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS5B_HCV1A", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS5B_HCV1B", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS5B_HCV2A", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NS6_9CALI", "NORV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NSP1_INFB", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NSP1_SARS", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NSP15_SARS", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NSP15_SARS2", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NSP3_HCoV-229E", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NSP3_MHV", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NSP3_SARS2", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "NSP9_HCoV-229E", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "P_9CALI", "NORV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PA_A-H17N10", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PA_A-H1N1", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PA_A-H5N1", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PA_INFA", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PA_INFB", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PB2_A-H3N2", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PB2_A-H5N1", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PB2_INFB", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PB3_A-H3N2", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PB4_A-H3N2", "flu" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PLP_SARS", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PLP_SARS2", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PM_9VIRU", "LASV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PR_FCoV", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PR_HCoV-229E", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PR_HCoV-NL63", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PR_HIV1", "HIV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PR_HIV2", "HIV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PR_HKU1", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PR_HKU4", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PR_MERs", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PR_SARS", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PR_SARS2", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "PR_TGEV", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "RDRP_SARS2", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "RT_HIV1", "HIV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "SPIKE_HCoV-229E", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "SPIKE_HCoV-NL63", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "SPIKE_HCoV-OC43", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "SPIKE_HKU4", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "SPIKE_MERs", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "SPIKE_MHV", "HCV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "SPIKE_PDCoV", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "SPIKE_SARS", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "SPIKE_SARS2", "CoV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "VP1_9CALI", "NORV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "VP24_EBORE", "EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "VP24_EBOSU", "EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "VP24_EBOZM", "EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "VP30_EBOZ5", "EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "VP30_EBOZM", "EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "VP35_EBORR", "EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "VP35_EBOZM", "EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinProteinTag",
                keyColumns: new[] { "ProteinsId", "TagsId" },
                keyValues: new object[] { "VP40_EBOZM", "EBOV" });

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "ADNV");

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "CoV");

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "DENV");

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "EBOV");

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "EV");

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "flu");

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "HCV");

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "HIV");

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "HSV");

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "LASV");

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "NORV");

            migrationBuilder.DeleteData(
                table: "ProteinTags",
                keyColumn: "Id",
                keyValue: "ZIKV");
        }
    }
}
