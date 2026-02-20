using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuksKitchen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Appsetnow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 20, 4, 58, 37, 349, DateTimeKind.Utc).AddTicks(4892));
        }
    }
}
