using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreateIndexLatAndLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("c04eed3d-fb05-4f55-b550-33d3896b33dc"));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Parkings",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Parkings",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_Id",
                table: "Parkings",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Parkings_Id",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Parkings");

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "AvailableSpaces", "ClosingHour", "Description", "Name", "OpeningHour", "Spaces" },
                values: new object[] { new Guid("c04eed3d-fb05-4f55-b550-33d3896b33dc"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HappyParking", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120 });
        }
    }
}
