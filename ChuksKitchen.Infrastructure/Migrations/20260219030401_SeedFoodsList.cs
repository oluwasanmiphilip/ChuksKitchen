using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChuksKitchen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedFoodsList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("923311c5-451f-4c0a-b980-66de6e618389"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("a6276fd0-4b70-4c80-b285-a287b0822dbc"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("b0c416ea-66b8-4188-b0a9-7ee2bef316d6"));

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("3f2171c1-ffbd-4818-a974-4ff901525a32"), "Spicy grilled beef skewers", "Suya", 1500m },
                    { new Guid("7647f0ea-b503-47d5-807f-2b3ef56ecec7"), "Yam flour served with melon seed soup", "Pounded Yam & Egusi", 3000m },
                    { new Guid("9c3f3580-ba70-46bf-9f34-ab834488af3a"), "Classic Nigerian party rice with tomato base", "Jollof Rice", 2500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("3f2171c1-ffbd-4818-a974-4ff901525a32"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("7647f0ea-b503-47d5-807f-2b3ef56ecec7"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("9c3f3580-ba70-46bf-9f34-ab834488af3a"));

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("923311c5-451f-4c0a-b980-66de6e618389"), "Classic Nigerian party rice with tomato base", "Jollof Rice", 2500m },
                    { new Guid("a6276fd0-4b70-4c80-b285-a287b0822dbc"), "Yam flour served with melon seed soup", "Pounded Yam & Egusi", 3000m },
                    { new Guid("b0c416ea-66b8-4188-b0a9-7ee2bef316d6"), "Spicy grilled beef skewers", "Suya", 1500m }
                });
        }
    }
}
