using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CitiesManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "CityName" },
                values: new object[,]
                {
                    { new Guid("0235b75e-479c-4554-a59b-8b2ced2eebca"), "Los Angeles" },
                    { new Guid("5952ebc3-b5a0-4bfb-9a31-73adc581cff6"), "Chicago" },
                    { new Guid("a7e4857b-1309-4fd8-8c61-439229e67e7a"), "Houston" },
                    { new Guid("b9bc23f6-e88d-4de3-aa20-c7a1b33e7f0c"), "New York" },
                    { new Guid("ed760560-e2aa-4c42-9932-085cc3a252de"), "London" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
