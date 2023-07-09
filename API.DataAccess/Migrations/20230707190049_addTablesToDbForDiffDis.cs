using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addTablesToDbForDiffDis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergiesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllergiesName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergiesID);
                });

            migrationBuilder.CreateTable(
                name: "Allergies_Details",
                columns: table => new
                {
                    AllergiesDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllergiesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies_Details", x => x.AllergiesDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "NCD",
                columns: table => new
                {
                    NCDID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NCDName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD", x => x.NCDID);
                });

            migrationBuilder.CreateTable(
                name: "NCD_Details",
                columns: table => new
                {
                    NCD_Details_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NCDID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD_Details", x => x.NCD_Details_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Allergies_Details");

            migrationBuilder.DropTable(
                name: "NCD");

            migrationBuilder.DropTable(
                name: "NCD_Details");
        }
    }
}
