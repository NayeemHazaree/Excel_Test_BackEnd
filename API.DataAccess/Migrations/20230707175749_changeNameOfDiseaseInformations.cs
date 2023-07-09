using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeNameOfDiseaseInformations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiseaseInformations",
                table: "DiseaseInformations");

            migrationBuilder.RenameTable(
                name: "DiseaseInformations",
                newName: "DiseaseInformation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiseaseInformation",
                table: "DiseaseInformation",
                column: "DiseaseInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiseaseInformation",
                table: "DiseaseInformation");

            migrationBuilder.RenameTable(
                name: "DiseaseInformation",
                newName: "DiseaseInformations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiseaseInformations",
                table: "DiseaseInformations",
                column: "DiseaseInformationId");
        }
    }
}
