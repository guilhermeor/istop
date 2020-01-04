using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangeColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Parkings",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_Observation",
                table: "Parkings",
                newName: "Observation");

            migrationBuilder.RenameColumn(
                name: "Address_Number",
                table: "Parkings",
                newName: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Parkings",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "Observation",
                table: "Parkings",
                newName: "Address_Observation");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Parkings",
                newName: "Address_Number");
        }
    }
}
