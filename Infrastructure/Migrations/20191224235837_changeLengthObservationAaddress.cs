using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class changeLengthObservationAaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "Parkings",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "AvailableSpaces", "ClosingHour", "Description", "Name", "OpeningHour", "Spaces" },
                values: new object[] { new Guid("c04eed3d-fb05-4f55-b550-33d3896b33dc"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HappyParking", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: new Guid("c04eed3d-fb05-4f55-b550-33d3896b33dc"));

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "Parkings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
