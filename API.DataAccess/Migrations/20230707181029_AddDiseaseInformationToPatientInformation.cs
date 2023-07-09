using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDiseaseInformationToPatientInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DiseaseInformation_Id",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiseaseInformation_Id",
                table: "Patients",
                column: "DiseaseInformation_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_DiseaseInformation_DiseaseInformation_Id",
                table: "Patients",
                column: "DiseaseInformation_Id",
                principalTable: "DiseaseInformation",
                principalColumn: "DiseaseInformationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_DiseaseInformation_DiseaseInformation_Id",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DiseaseInformation_Id",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DiseaseInformation_Id",
                table: "Patients");
        }
    }
}
