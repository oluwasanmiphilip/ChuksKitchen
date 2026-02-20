using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuksKitchen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateValidUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "Phone", "ReferralCode", "Verified" },
                values: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), "oluwasanmi@example.com", true, "08012345678", "REF123", true });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "FoodId", "Quantity", "UserId" },
                values: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 2, 20, 4, 58, 37, 349, DateTimeKind.Utc).AddTicks(4892), new Guid("11111111-1111-1111-1111-111111111111"), 2, new Guid("44444444-4444-4444-4444-444444444444") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));
        }
    }
}
