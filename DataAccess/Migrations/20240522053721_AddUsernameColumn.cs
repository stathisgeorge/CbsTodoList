using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUsernameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "TaskRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Status", "Username" },
                values: new object[] { new DateTime(2024, 5, 22, 8, 37, 21, 198, DateTimeKind.Local).AddTicks(7900), 1, "georgestathis" });

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Username" },
                values: new object[] { new DateTime(2024, 5, 21, 8, 37, 21, 198, DateTimeKind.Local).AddTicks(7906), "georgestathis" });

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Username" },
                values: new object[] { new DateTime(2024, 5, 20, 8, 37, 21, 198, DateTimeKind.Local).AddTicks(7915), "georgestathis" });

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Username" },
                values: new object[] { new DateTime(2024, 5, 19, 8, 37, 21, 198, DateTimeKind.Local).AddTicks(7918), "georgestathis" });

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Username" },
                values: new object[] { new DateTime(2024, 5, 18, 8, 37, 21, 198, DateTimeKind.Local).AddTicks(7922), "georgestathis" });

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Username" },
                values: new object[] { new DateTime(2024, 5, 17, 8, 37, 21, 198, DateTimeKind.Local).AddTicks(7925), "georgestathis" });

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Username" },
                values: new object[] { new DateTime(2024, 5, 16, 8, 37, 21, 198, DateTimeKind.Local).AddTicks(7929), "georgestathis" });

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Username" },
                values: new object[] { new DateTime(2024, 5, 15, 8, 37, 21, 198, DateTimeKind.Local).AddTicks(7933), "georgestathis" });

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Username" },
                values: new object[] { new DateTime(2024, 5, 14, 8, 37, 21, 198, DateTimeKind.Local).AddTicks(7936), "georgestathis" });

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Username" },
                values: new object[] { new DateTime(2024, 5, 13, 8, 37, 21, 198, DateTimeKind.Local).AddTicks(7940), "georgestathis" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "TaskRecord");

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2024, 5, 21, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9789), 0 });

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 19, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 18, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 16, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 15, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 14, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 13, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "TaskRecord",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 12, 22, 26, 51, 160, DateTimeKind.Local).AddTicks(9841));
        }
    }
}
