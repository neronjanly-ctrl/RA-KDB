using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DockingApiService.Migrations
{
    public partial class UpdateCitation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "dakb-gpcrs",
                column: "Citation",
                value: "**DAKB-GPCRs: An Integrated Computational Platform for Drug Abuse Related GPCRs**  \nMaozi Chen, Yankang Jing, Lirong Wang, Zhiwei Feng, Xiang-Qun Xie  \n*Journal of Chemical Information and Modeling*, 2019, 59(4), pp 1283-1289  \nPublication Date: March 5, 2019  \nhttps://doi.org/10.1021/acs.jcim.8b00623  \nhttps://pubmed.ncbi.nlm.nih.gov/30835466/");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "pain-ckb",
                column: "Citation",
                value: "**Pain-CKB, A Pain-Domain-Specific Chemogenomics Knowledgebase for Target Identification and Systems Pharmacology Research**  \nZhiwei Feng, Maozi Chen, Mingzhe Shen, Tianjian Liang, Hui Chen, Xiang-Qun Xie  \n*Journal of Chemical Information and Modeling*, 2020, 60(10), pp 4429-4435  \nPublication Date: August 12, 2020  \nhttps://doi.org/10.1021/acs.jcim.0c00633  \nhttps://pubmed.ncbi.nlm.nih.gov/32786694/\n\n**Pain Chemogenomics Knowledgebase (Pain-CKB) for Systems Pharmacology Target Mapping and PBPK Modeling Investigation of Opioid Drug-Drug Interactions**  \nShen, Mingzhe; Chen, Maozi; Liang, Tianjian; Wang, Siyi; Xue, Ying; Bertz, Richard; Xie, Xiang-Qun; Feng, Zhiwei  \n*ACS Chemical Neuroscience*, 2020, 11(20), pp 3245-3258  \nPublication Date: September 23, 2020  \nhttps://doi.org/10.1021/acschemneuro.0c00372  \nhttps://pubmed.ncbi.nlm.nih.gov/32966035/");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "virus-ckb",
                column: "Citation",
                value: "**Virus-CKB: an integrated bioinformatics platform and analysis resource for COVID-19 research**  \nZhiwei Feng, Maozi Chen, Tianjian Liang, Mingzhe Shen, Hui Chen, Xiang-Qun Xie  \n*Briefings in Bioinformatics*, 2021, 22(2), pp 882-895  \nPublication Date: July 27, 2020  \nhttps://doi.org/10.1093/bib/bbaa155  \nhttps://pubmed.ncbi.nlm.nih.gov/32715315/");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "dakb-gpcrs",
                column: "Citation",
                value: "**DAKB-GPCRs: An Integrated Computational Platform for Drug Abuse Related GPCRs**\nMaozi Chen, Yankang Jing, Lirong Wang, Zhiwei Feng, Xiang-Qun Xie\n*Journal of Chemical Information and Modeling*, 2019, 59(4), pp 1283-1289\nPublication Date: March 5, 2019\nhttps://doi.org/10.1021/acs.jcim.8b00623\nhttps://pubmed.ncbi.nlm.nih.gov/30835466/");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "pain-ckb",
                column: "Citation",
                value: "**Pain-CKB, A Pain-Domain-Specific Chemogenomics Knowledgebase for Target Identification and Systems Pharmacology Research**\nZhiwei Feng, Maozi Chen, Mingzhe Shen, Tianjian Liang, Hui Chen, Xiang-Qun Xie\n*Journal of Chemical Information and Modeling*, 2020, 60(10), pp 4429�C4435\nPublication Date: August 12, 2020\nhttps://doi.org/10.1021/acs.jcim.0c00633\nhttps://pubmed.ncbi.nlm.nih.gov/32786694/\n**Pain Chemogenomics Knowledgebase (Pain-CKB) for Systems Pharmacology Target Mapping and PBPK Modeling Investigation of Opioid Drug-Drug Interactions**\nShen, Mingzhe; Chen, Maozi; Liang, Tianjian; Wang, Siyi; Xue, Ying; Bertz, Richard; Xie, Xiang-Qun; Feng, Zhiwei\n*ACS Chemical Neuroscience*, 2020, 11(20), pp 3245�C3258\nPublication Date: September 23, 2020\nhttps://doi.org/10.1021/acschemneuro.0c00372\nhttps://pubmed.ncbi.nlm.nih.gov/32966035/");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "virus-ckb",
                column: "Citation",
                value: "**Virus-CKB: an integrated bioinformatics platform and analysis resource for COVID-19 research**\nZhiwei Feng, Maozi Chen, Tianjian Liang, Mingzhe Shen, Hui Chen, Xiang-Qun Xie\n*Briefings in Bioinformatics*, 2021, 22(2), pp 882�C895\nPublication Date: July 27, 2020\nhttps://doi.org/10.1093/bib/bbaa155\nhttps://pubmed.ncbi.nlm.nih.gov/32715315/");
        }
    }
}
