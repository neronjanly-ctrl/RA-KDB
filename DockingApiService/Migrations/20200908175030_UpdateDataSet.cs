using Microsoft.EntityFrameworkCore.Migrations;

namespace DockingApiService.Migrations
{
    public partial class UpdateDataSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BioactivityCount",
                table: "Proteins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RawBioactivityCount",
                table: "Proteins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "dakb-gpcrs",
                column: "Citation",
                value: @"**DAKB-GPCRs: An Integrated Computational Platform for Drug Abuse Related GPCRs**  
Maozi Chen, Yankang Jing, Lirong Wang, Zhiwei Feng, Xiang-Qun Xie  
*Journal of Chemical Information and Modeling*, 2019, 59(4), pp 1283-1289  
Publication Date: March 5, 2019  
https://doi.org/10.1021/acs.jcim.8b00623  
https://pubmed.ncbi.nlm.nih.gov/30835466/");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "pain-ckb",
                column: "Citation",
                value: @"**Pain-CKB, A Pain-Domain-Specific Chemogenomics Knowledgebase for Target Identification and Systems Pharmacology Research**  
Zhiwei Feng, Maozi Chen, Mingzhe Shen, Tianjian Liang, Hui Chen, Xiang-Qun Xie  
*Journal of Chemical Information and Modeling*, 2020, ??(?), pp ???-???  
Publication Date: August 12, 2020  
https://doi.org/10.1021/acs.jcim.0c00633  
https://pubmed.ncbi.nlm.nih.gov/32786694/");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "virus-ckb",
                columns: new[] { "Citation", "Description" },
                values: new object[] { @"**Virus-CKB: an integrated bioinformatics platform and analysis resource for COVID-19 research**  
Zhiwei Feng, Maozi Chen, Tianjian Liang, Mingzhe Shen, Hui Chen, Xiang-Qun Xie  
*Briefings in Bioinformatics*, 2020, ??(?), pp ???-???  
Publication Date: July 27, 2020  
https://doi.org/10.1093/bib/bbaa155  
https://pubmed.ncbi.nlm.nih.gov/32715315/", "Virus-CKB is a knowledgebase for COVID-19 and similar viral infection research that implemented with our established chemogenomics tools as well as our algorithms for data visualization and analyses. This tool predicts the BioActivities on 92 viral related targets for a query compound and provides a handy user interface for viewing, downloading and plotting the output results.<br/><video class=\"w-100\" controls autoplay loop><source src=\"images/w03.mp4\" /></video>" });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "1433G_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 56, 56 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "1433S_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 15, 15 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT1A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7785, 8305 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT1B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2187, 2333 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT1D_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2406, 2500 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT1E_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 350, 375 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT1F_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 211, 221 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT2A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7198, 9017 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT2B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3498, 5209 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT2C_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6265, 8045 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT3A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1502, 1548 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT3B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT4R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1508, 1615 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT5A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 854, 909 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT6R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6033, 7813 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT7R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3310, 3424 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5NTD_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 75, 79 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "A1AG1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 19, 19 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "A1AG2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "A4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3193, 3394 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AA1R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 11337, 13635 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AA2AR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 10444, 12547 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AA2BR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5570, 5928 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AA3R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 9416, 11579 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AACT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ABCC8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 14, 14 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ABL1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 12386, 12638 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACE_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1152, 1188 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACE2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 78, 78 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACES_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 9930, 12320 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACHA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 63, 64 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACHA2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 40, 40 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACHA3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 77, 91 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACHA4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 81, 81 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACHA7_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1982, 2062 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACHA9_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACHB2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACHB4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 267, 271 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACHD_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 13, 14 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACM1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6067, 7941 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACM2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4042, 5888 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACM3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3705, 5460 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACM4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2701, 4506 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACM5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1999, 3776 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACTB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 14, 14 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACTHR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 32, 34 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACVL1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 303, 315 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACVR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 832, 851 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 106, 120 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADA1D_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2075, 3767 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADA2A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1977, 3616 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADA2B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1170, 2799 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADA2C_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1557, 3216 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADH1B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 23, 23 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADH1G_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 23, 23 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADH7_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 20, 23 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADML_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 35, 35 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADRB1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2799, 4676 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADRB2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5497, 7471 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ADRB3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3497, 5261 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AGAL_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5270, 5323 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AGTR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1703, 1748 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AGTR2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 602, 2371 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AK1BA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 263, 272 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AKT1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7808, 7988 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AKT2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3815, 3844 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AL1A1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 76417, 76445 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AL5AP_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2876, 2919 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ALBU_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1711, 1791 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ALDH2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 313, 357 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ALDR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1162, 1168 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ALK_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4723, 4817 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AMD_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 90, 90 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AMPN_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 621, 685 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ANDR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7836, 8273 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ANF_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 13, 14 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ANPRC_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 89, 92 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AOC3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 406, 407 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AOFA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4665, 6604 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AOFB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4905, 5101 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AOXA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 138, 280 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "APAF_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1188, 1188 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "APEX1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 37921, 37923 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "APJ_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 457, 458 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AQP4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 32, 32 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ARBK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 702, 711 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ARGI1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 73, 75 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ARGI2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 52, 52 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ASAH1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 192, 195 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ATAD5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 122566, 122566 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ATPB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ATS5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 607, 612 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ATX2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 54410, 54410 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AURKA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7351, 7457 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AURKB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5392, 5534 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AVR2A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 141, 141 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AVR2B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 392, 392 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "B2CL1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1936, 1974 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BACE1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 13457, 13651 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BAX_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 33, 33 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BAZ2B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 56043, 56074 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BCAT1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 31, 31 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BCL2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2935, 2975 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BGAT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 13, 13 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BHMT1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 97, 159 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BIP_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3279, 3279 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BIRC2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 870, 875 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BIRC3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 232, 238 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BIRC5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 63, 68 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BKRB2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 997, 2777 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BLM_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4073, 4095 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BMPR2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 405, 408 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BMR1B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 371, 371 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BRAF_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6631, 6694 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BRD2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 627, 638 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BRD3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 544, 555 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BRD4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4227, 4291 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BRDT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 155, 158 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "BTK_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5050, 5140 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "C11B2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2069, 2135 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "C1TC_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 18, 22 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "C5AR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 969, 1025 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CAC1D_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 36, 36 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CAH1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 9512, 9578 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CAH12_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3744, 3776 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CAH13_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 428, 444 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CAH14_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 876, 880 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CAH2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 11817, 13649 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CAH3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 381, 393 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CAH4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 945, 968 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CAH7_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1326, 1341 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CAH9_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4995, 5031 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CALCA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 202, 210 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CALCR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 61, 1803 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CALM1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 69, 80 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CASP1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4296, 6094 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CASP3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3406, 3463 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CASP8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 964, 986 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CASP9_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 130, 138 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CASR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 719, 724 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CATB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2698, 2865 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CATG_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 471, 2249 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CATK_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2615, 2646 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CATL1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2992, 3081 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CBG_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 274, 274 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CBP_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1013, 1051 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CBPB2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 280, 280 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CBPN_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 32, 33 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CBX1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 92420, 92426 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CCKAR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1217, 3023 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CCKN_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CCL2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 76, 76 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CCL5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 38, 38 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CCND1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 11, 12 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CCR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1355, 1413 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CCR2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3296, 5273 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CCR4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 816, 2639 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CCR5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3528, 5378 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CD38_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 224, 266 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3598, 3645 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6555, 6657 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 397, 397 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2391, 2404 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2656, 2739 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK6_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1469, 1471 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK7_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1000, 1015 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK9_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1711, 1715 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CENPE_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 86, 86 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CFAB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 62, 92 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CFTR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 855, 938 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CH60_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 22, 23 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CHIO_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CHIT1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 37, 37 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CHK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6049, 6172 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CHK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3367, 3382 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CHLE_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4111, 4330 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CLK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2767, 2791 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CLTR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 308, 2043 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CMA1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 632, 641 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CNR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 11737, 14126 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CNR2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 12999, 13506 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CO1A2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "COMT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 223, 227 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "COT1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7, 7 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP17A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1978, 3354 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP19A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4821, 4948 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP1A1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 471, 523 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP1A2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 14422, 23817 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP21A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 309, 731 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP27A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7, 7 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP2A6_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 685, 2451 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP2B6_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 729, 834 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP2C8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 763, 869 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP2C9_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 17168, 29123 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP2CJ_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 16723, 26936 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP2D6_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 17065, 30648 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP2E1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 215, 2019 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP3A5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 229, 396 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CPNS1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 137, 176 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CREB1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 23, 28 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CRFR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2562, 2630 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CSF1R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3757, 3783 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CSK21_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2729, 2760 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CTDS1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1012, 1012 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CTNB1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 234, 238 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CXCR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 445, 2203 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CXCR2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1484, 3242 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CXCR3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1998, 2117 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CXCR4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1702, 1839 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DAPK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1339, 1341 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DCE1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DDAH1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 192, 202 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DDR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 591, 598 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DDR2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1710, 1711 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DHI1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5432, 5534 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DHPR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 29, 29 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DHYS_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 76, 96 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DOPO_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 130, 130 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DPP4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6116, 6204 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DRD1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3441, 5257 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DRD2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 14743, 17009 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DRD3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 8248, 10060 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DRD4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4262, 6248 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DRD5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 735, 863 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DUS1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 26, 30 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DUS6_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 54, 55 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "DYR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2604, 2730 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "EAA1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 396, 396 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ECE1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 647, 660 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "EDNRA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2187, 3964 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "EDNRB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1464, 1513 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "EGFR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 19319, 21592 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "EGLN1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1087, 1110 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "EHMT2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 92306, 92344 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ELAV1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 103, 106 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ELNE_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5530, 7558 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ENPL_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 302, 324 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ENPP2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1811, 1860 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "EPHA3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1334, 1358 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "EPHB4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2780, 2870 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ERAP1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 365, 365 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ERBB2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4932, 6784 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ERBB3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 108, 108 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ERBB4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2281, 2304 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ESR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 9581, 11618 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ESR2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5855, 7810 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "EST1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 789, 846 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FA10_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 8902, 9091 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FA11_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1182, 1188 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FA7_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 827, 836 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FA8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 9, 9 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FA9_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 793, 804 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FAAH1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2865, 2952 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FABP4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 428, 444 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FABP5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 106, 106 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FABPH_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 115, 117 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FABPI_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 28, 28 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FABPL_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FAK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3622, 3716 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FAK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2576, 2590 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FAS_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3178, 3190 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FEN1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 12045, 12054 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FGF2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 159, 180 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FGFR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7444, 7555 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FGFR2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2571, 2621 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FHIT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 34, 37 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FINC_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FKB1A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 811, 823 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FKBP5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 164, 168 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FNTA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FNTB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 92, 92 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FOLH1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 487, 491 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FPPS_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 886, 910 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FTO_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 69, 70 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FURIN_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 586, 588 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FYN_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3077, 4837 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "G3P_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1244, 1268 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "G6PD_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 715, 715 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GABR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 30, 31 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GABT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 134, 136 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GASR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2410, 2454 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRA1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 184, 195 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRA2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 152, 155 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRA3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 87, 90 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRA4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5, 7 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRA5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 539, 540 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRA6_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRB1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 56, 66 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRB2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRB3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 26, 26 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRD_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRG2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1207, 1226 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 159, 182 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GBRR2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 11, 11 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GCKR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 189, 190 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GCR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 10051, 12283 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GEMI_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 128009, 128009 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GLCM_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 13826, 13894 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GLP1R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 108959, 108973 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GLRA3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 18, 34 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GLSK_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 16434, 16437 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GLYC_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GNAI1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 161, 166 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GNAO_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 69, 71 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GNAS2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 103405, 103405 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GP_EBOV",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 27, 27 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRB2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 569, 575 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRIA1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 234, 236 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRIA2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 743, 774 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRIA3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 97, 99 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRIA4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 237, 242 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRIK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 323, 323 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRIK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 316, 340 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRIK3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 31, 34 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRIK5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 41, 42 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRK4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 132, 132 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRM1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2129, 2202 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRM2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2674, 2735 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRM3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 571, 614 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRM4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1753, 1877 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRM5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5176, 5340 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRM6_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 328, 332 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRM7_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 232, 240 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRM8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 309, 324 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GSH1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 10, 12 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GSTA1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 98, 104 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GSTA4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GSTM1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 44, 60 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GSTO1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 15, 15 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GSTO2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GSTP1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 300, 313 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GSTT1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GTR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 14194, 14195 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H18N11",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "Hemagglutinin", 637351841066851870L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H3N2",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HBA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 28, 28 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HBB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 329, 329 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HCD2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 20639, 20639 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HCN4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 65, 66 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HD_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 19093, 19125 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HDAC1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6409, 6559 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HDAC2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2004, 2058 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HDAC6_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4543, 4739 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HEM2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 47, 58 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HIF1A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5550, 5649 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HMDH_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 587, 2365 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HMOX1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 9, 9 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HNF4A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 294, 296 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HNF4G_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HNMT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 12, 13 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HPGDS_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 333, 348 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HPRT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 285, 299 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HRH1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2837, 4770 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HRH2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1205, 2948 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HRH3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6414, 6591 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HRH4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3020, 3169 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HS71A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 159, 159 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HS71B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HS90A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3080, 3205 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HS90B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1385, 1561 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HSP72_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HSP7C_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 153, 153 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HSPB1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 42, 46 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HXK4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2551, 2590 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HYES_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2591, 2718 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "IBP2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "IDE_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 684, 687 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "IGF1R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 8028, 8141 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "IKBA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 164, 175 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "IKKB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4831, 4943 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "IL8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 626, 626 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ILK_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 571, 576 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "INSR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5028, 5139 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "IRAK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1426, 1428 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ITA2B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 36, 36 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ITA4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 290, 295 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ITAL_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 147, 164 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ITB7_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "JAK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6528, 6611 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "JAK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 10119, 10298 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "JUN_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 371, 419 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KAT2A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 14208, 14209 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KAT2B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 584, 623 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KAT8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 43, 43 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KC1A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2303, 2314 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KCC1A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1396, 1428 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KCC2A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1623, 1650 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KCC2B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1335, 1365 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KCC2G_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1526, 1560 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KCJ10_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KCJ11_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 111, 111 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KCMA1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 379, 393 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KCNA3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 986, 998 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KCND2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 12, 12 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KCRB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KDM4A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 51909, 51938 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KDM4E_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 40178, 40179 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KDM6A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 26, 26 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KGP1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2415, 2416 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KIF11_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1467, 1490 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KIF3C_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 9, 9 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KINH_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 21, 21 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KIT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7439, 7560 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KITH_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 544, 624 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KLK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 31, 31 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KLKB1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1429, 1453 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KMT2D_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3769, 5630 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3799, 3854 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCE_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1205, 1222 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCG_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2366, 2382 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCL_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1654, 1658 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2765, 2777 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCZ_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2081, 2190 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPYM_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 14395, 14432 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KS6A3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3659, 3733 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KS6A5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2717, 2780 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KS6B2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 58, 60 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LCK_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6464, 8324 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LDHA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 719, 760 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LDHB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 154, 178 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LEG3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 314, 314 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LGUL_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 213, 215 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LIMK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1928, 1968 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LKHA4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1189, 1209 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LMBL1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 14519, 14529 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LMNA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 36751, 36751 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LOX12_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3231, 3241 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LOX15_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6552, 6681 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LOX5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5073, 5257 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "LYN_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3729, 3798 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "M3K14_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 931, 933 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "M3K8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 418, 419 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MAPK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4372, 4464 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MBNL1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 34424, 34424 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MC3R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2240, 4033 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MC4R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6780, 8611 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MC5R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2286, 4069 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MCL1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2634, 2670 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MCR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1695, 1763 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MDHM_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 172, 172 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MDM2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3699, 3848 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MDR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 9756, 10068 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MET_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 8330, 8516 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MGMT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 339, 404 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MIF_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 574, 624 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MK01_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 20725, 22490 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MK03_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2474, 4241 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MK07_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 448, 448 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MK09_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4094, 4157 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MK10_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2703, 2742 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MK11_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2224, 2259 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MK12_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2503, 2536 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MK13_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2325, 2331 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MK14_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 9145, 11027 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MMP1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4867, 6772 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MMP10_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 300, 304 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MMP12_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 835, 899 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MMP13_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3697, 3746 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MMP3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3123, 3175 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MMP7_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 897, 928 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MMP8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1575, 1619 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MMP9_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4163, 6082 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MOT2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 10, 10 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MOT4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 50, 50 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MP2K1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3515, 3561 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MP2K2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 990, 995 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MP2K6_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1002, 1006 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MPP8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 656, 656 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MRP1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1375, 1466 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MRP2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1128, 1170 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MRP3_HUMAN",
                columns: new[] { "BioactivityCount", "ProteinName", "RawBioactivityCount", "Updated" },
                values: new object[] { 681, "Multidrug resistance associated protein", 712, 637351839052239222L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MSHR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2267, 2362 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MTASE_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "Methyltransferase", 637351781826277866L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MTOR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 11952, 12120 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MYG_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H18N11",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "Neuraminidase", 637351841235436163L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_INFB",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 372, 392 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NAGAB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 11, 11 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NALD2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 20, 20 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NCOA1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 241, 241 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NEC2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7, 7 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NEP_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 671, 706 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NF2L2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 94035, 94120 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NFKB1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1440, 1447 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NISCH_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 283, 285 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NK1R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4015, 5821 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NK2R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1484, 3174 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NMDE1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 38, 38 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NMDE2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 204, 205 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NMDE3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 23, 23 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NMDZ1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 120, 120 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NOS1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1577, 1634 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NOS2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1453, 1496 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NOS3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1304, 1343 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NP_HCoV-OC43",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NPBW1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 541, 549 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NPC1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 18911, 18911 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NPFF1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 323, 336 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NPSR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 15752, 15772 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NPY1R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1636, 3470 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NPY2R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1183, 2965 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NPY4R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 263, 290 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NPY5R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1511, 1591 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NQO1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1201, 1254 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NR1H3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2254, 2390 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NR1H4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4037, 4194 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NR1I2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2048, 2115 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NR1I3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 235, 248 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NR4A1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 333, 335 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NR4A3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NRP1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 165, 165 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NS3_HCV1A",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 903, 903 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NS3_HCV1B",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 24, 24 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NS5B_HCV1A",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 243, 244 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NS5B_HCV1B",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 50, 50 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSD2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 585, 586 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSMA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 16, 22 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP1_SARS",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 357, 378 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP15_SARS",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 357, 378 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP15_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "Replicase polyprotein 1ab", 637351785993775682L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP3_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "Replicase polyprotein 1ab", 637351786075397431L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NTRK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5522, 5593 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NTRK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2529, 2539 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NTRK3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1792, 1804 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OPRD_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 9699, 11795 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OPRK_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 10312, 12658 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OPRM_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 10960, 13295 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OPRM_MOUSE",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1058, 1083 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OPRX_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3086, 3318 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OXDA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 564, 596 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "P2RX3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1483, 1484 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "P2RY1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1113, 1173 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "P2Y12_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2092, 2162 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "P53_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 47857, 47893 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "P85A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 275, 275 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PA_INFA",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 394, 395 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PA21B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 682, 689 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PA2GA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 920, 991 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PAFA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1198, 1272 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PAI1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 390, 393 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PAR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1507, 1559 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PARP1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4332, 4439 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PARP4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 35, 42 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PB1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 276, 284 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PCKGC_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 25, 25 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PCNA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 79, 79 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PCP_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 556, 556 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDE1B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 119, 121 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDE2A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1378, 1434 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDE3B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 214, 231 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDE4A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 891, 916 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDE4B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1758, 1800 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDE4D_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1263, 1318 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDE5A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2566, 4374 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDE6C_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 43, 60 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDK4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 14, 14 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDPK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3308, 3376 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDYN_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PEPD_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 89, 89 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PERE_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PERM_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 634, 729 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PGDH_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 24835, 24866 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PGFRA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4710, 4743 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PGH1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4973, 6814 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PGH1_SHEEP",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3921, 4117 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PGH2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 8718, 10677 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PIM2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5334, 5389 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PIN1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 36229, 36236 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PK3CA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 8397, 8574 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PK3CD_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4153, 4254 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PK3CG_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3316, 3403 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PLCB1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 15, 15 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PLCG1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 171, 171 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PLCG2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 48, 78 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PLK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 27348, 27393 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PLK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 683, 699 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PLP_SARS",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 315, 329 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PLP_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "papain-like protease", 637351783998132970L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PMP22_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 699, 699 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PNMT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 415, 417 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PNPH_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 677, 703 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "POLH_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 21676, 21678 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "POLI_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 116820, 116820 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "POLK_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 8649, 8653 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PP2BA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 49, 1793 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PPAP_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 69, 69 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PPARA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6773, 7335 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PPARD_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4643, 5107 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PPARG_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 10849, 11464 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PPM1B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 65, 65 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_HCoV-NL63",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 18, 18 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_HIV1",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 20, 20 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_SARS",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 357, 378 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "3C-like protease", 637351783504412016L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PRGR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4925, 5233 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PROC_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 445, 445 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PRSS8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 25, 25 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PTAFR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 796, 2543 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PTGES_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2463, 2599 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PTGIS_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 81, 98 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PTH1R_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 47046, 47050 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PTN1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6329, 6695 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PTN11_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1091, 1197 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PTN22_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1130, 1149 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PTPRC_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 488, 2260 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PTPRG_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 48, 48 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PTPRU_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "QPCT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 765, 780 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "QRFPR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 169, 181 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RAB9A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 22488, 22488 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RABP1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 12, 14 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RABP2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 17, 18 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RAC1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 178, 186 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RAF1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3437, 3508 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RAGE_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 234, 248 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RARB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1040, 1105 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RASH_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 115, 117 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RASK_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 83, 83 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RASN_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 49, 56 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RDRP_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "RNA-dependent RNA polymerase", 637351783167004263L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RECQ1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5571, 5575 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RENI_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 4858, 4941 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RET_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5106, 5146 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RET4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 561, 579 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RGS4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 13867, 13867 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RHOA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 165, 183 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RIPK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 928, 951 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RIR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 147, 161 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ROCK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3978, 4008 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ROCK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5286, 5352 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RORG_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3876, 3950 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ROS1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1961, 1985 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RSSA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 25, 33 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RT_HIV1",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 360, 363 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RXRA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2668, 2862 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "S100B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 30, 30 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "S22A1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 495, 497 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "S22A2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 230, 230 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "S22A4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 31, 32 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "S22A5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 113, 138 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "S36A1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 100, 100 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SAHH_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 758, 821 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SAMP_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 230, 232 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SAT1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 43, 55 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SC6A1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 215, 215 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SC6A2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5289, 6957 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SC6A3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 5598, 7456 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SC6A4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7628, 9475 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SCN9A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7377, 7422 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SGK1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1912, 1937 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SGK3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1223, 1224 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SGMR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3410, 5093 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SMAD3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 67980, 67980 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SMN_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 34204, 34221 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SO1B1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2548, 2568 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SO1B3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2440, 2470 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SO2B1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 404, 434 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "Spike glycoprotein", 637351782680172147L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SRC_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 8865, 9237 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ST2A1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 10, 12 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "STK4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1734, 1767 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SYUA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 10311, 10311 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TAAR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1327, 1334 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TAU_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 95087, 95096 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TBA1A_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TBA1B_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TBB3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 9, 9 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TBB5_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 27, 27 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "THA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 755, 809 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "THAS_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1507, 3324 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "THB_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7713, 7754 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TLR2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 311, 330 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TLR3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 227, 252 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TLR4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 612, 672 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TLR7_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 815, 857 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TLR8_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 521, 607 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TLR9_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 612, 624 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TMIG3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 200, 200 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TNFA_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1473, 1559 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TPIS_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 16, 17 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TPO_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 834, 834 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRFE_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 88, 88 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRPA1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1187, 1273 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRPM4_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRPM8_FICAL",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "Transient receptor potential cation channel M8", 637351773634366029L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRPV1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 6575, 6866 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRPV1_RAT",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2826, 3206 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRPV3_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 518, 518 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRXR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 23, 29 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRY1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 2152, 2268 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TSHR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 29911, 29930 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TSPO_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 187, 189 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TY3H_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 8, 8 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TYDP1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 345077, 345107 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TYK2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3429, 3447 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "UBP1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 22528, 22528 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "UCHL1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 41, 45 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ULA1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 7, 7 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "V1AR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1723, 3531 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "VACHT_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 268, 268 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "VATB2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "VDR_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 25701, 25830 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "VGFR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 3892, 5748 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "VGFR2_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 16806, 17214 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "VIPR1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 56, 1800 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "XDH_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 692, 764 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "XPO1_HUMAN",
                columns: new[] { "BioactivityCount", "RawBioactivityCount" },
                values: new object[] { 307, 307 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BioactivityCount",
                table: "Proteins");

            migrationBuilder.DropColumn(
                name: "RawBioactivityCount",
                table: "Proteins");

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

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "pain-ckb",
                column: "Citation",
                value: "");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "virus-ckb",
                columns: new[] { "Citation", "Description" },
                values: new object[] { "", "Virus-CKB is a knowledgebase for COVID-19 and similar viral infection research that implemented with our established chemogenomics tools as well as our algorithms for data visualization and analyses. This tool predicts the BioActivities on 92 viral related targets for a query compound and provides a handy user interface for viewing, downloading and plotting the output results.<br/><img class=\"w-50\" src=\"images/w01.jpg\"><img class=\"w-50\" src=\"images/w02.jpg\"><video class=\"w-100\" controls autoplay><source src=\"images/w03.mp4\" /></video>" });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HA_A-H18N11",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "", 637196322475523964L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MRP3_HUMAN",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "", 637117862424204272L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MTASE_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "", 637239668458255002L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NA_A-H18N11",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "", 637196322475544000L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP15_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "", 637239668478900945L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP3_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "", 637239668462005882L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PLP_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "", 637239668467030350L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PR_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "", 637196324535681611L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RDRP_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "", 637239668473105626L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_SARS2",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "", 637196324535701533L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRPM8_FICAL",
                columns: new[] { "ProteinName", "Updated" },
                values: new object[] { "", 637117848165985500L });
        }
    }
}
