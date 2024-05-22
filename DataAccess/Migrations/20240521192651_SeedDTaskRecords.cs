using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDTaskRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskRecord",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "Description", "ModifiedAt", "Status", "Title" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 5, 21, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9789), "Description 1", null, 0, "Task 1" },
                    { 2, null, new DateTime(2024, 5, 20, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9795), "Description 2", null, 1, "Task 2" },
                    { 3, null, new DateTime(2024, 5, 19, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9802), "Description 3", null, 1, "Task 3" },
                    { 4, null, new DateTime(2024, 5, 18, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9808), "Description 4", null, 1, "Task 4" },
                    { 5, null, new DateTime(2024, 5, 17, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9814), "Description 5", null, 1, "Task 5" },
                    { 6, null, new DateTime(2024, 5, 16, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9819), "Description 6", null, 1, "Task 6" },
                    { 7, null, new DateTime(2024, 5, 15, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9824), "Description 7", null, 1, "Task 7" },
                    { 8, null, new DateTime(2024, 5, 14, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9830), "Description 8", null, 0, "Task 8" },
                    { 9, null, new DateTime(2024, 5, 13, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9835), "Description 9", null, 0, "Task 9" },
                    { 10, null, new DateTime(2024, 5, 12, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9841), "Description 10", null, 0, "Task 10" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
