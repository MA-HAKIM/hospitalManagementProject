using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement_API.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergiesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergiesName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergiesID);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseInformation",
                columns: table => new
                {
                    DiseaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseInformation", x => x.DiseaseID);
                });

            migrationBuilder.CreateTable(
                name: "NCD",
                columns: table => new
                {
                    NCDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCDName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD", x => x.NCDID);
                });

            migrationBuilder.CreateTable(
                name: "PatientInformation",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Epilepsy = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInformation", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_PatientInformation_DiseaseInformation_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "DiseaseInformation",
                        principalColumn: "DiseaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergiesDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    AllergiesID = table.Column<int>(type: "int", nullable: false),
                    PatientsInformationPatientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergiesDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AllergiesDetails_PatientInformation_PatientsInformationPatientID",
                        column: x => x.PatientsInformationPatientID,
                        principalTable: "PatientInformation",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NCDDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    NCDID = table.Column<int>(type: "int", nullable: false),
                    PatientsInformationPatientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NCDDetails_PatientInformation_PatientsInformationPatientID",
                        column: x => x.PatientsInformationPatientID,
                        principalTable: "PatientInformation",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesDetails_PatientsInformationPatientID",
                table: "AllergiesDetails",
                column: "PatientsInformationPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_NCDDetails_PatientsInformationPatientID",
                table: "NCDDetails",
                column: "PatientsInformationPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInformation_DiseaseId",
                table: "PatientInformation",
                column: "DiseaseId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "AllergiesDetails");

            migrationBuilder.DropTable(
                name: "NCD");

            migrationBuilder.DropTable(
                name: "NCDDetails");

            migrationBuilder.DropTable(
                name: "PatientInformation");

            migrationBuilder.DropTable(
                name: "DiseaseInformation");
        }
    }
}
