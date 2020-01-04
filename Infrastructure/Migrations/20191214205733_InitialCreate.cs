using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Address_Street = table.Column<string>(maxLength: 50, nullable: true),
                    Address_Number = table.Column<string>(maxLength: 5, nullable: true),
                    Address_Observation = table.Column<string>(maxLength: 100, nullable: true),
                    Spaces = table.Column<int>(nullable: false),
                    AvailableSpaces = table.Column<int>(nullable: false),
                    OpeningHour = table.Column<DateTime>(nullable: false),
                    ClosingHour = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parkings");
        }
    }
}
