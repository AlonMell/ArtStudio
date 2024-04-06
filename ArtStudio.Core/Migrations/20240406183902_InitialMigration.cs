using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStudio.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValue: new DateTime(2024, 4, 6, 21, 39, 2, 594, DateTimeKind.Local).AddTicks(2413)),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arts");
        }
    }
}
