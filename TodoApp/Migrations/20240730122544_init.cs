using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 30, 13, 25, 43, 733, DateTimeKind.Local).AddTicks(7707), new DateTime(2024, 7, 30, 13, 25, 43, 733, DateTimeKind.Local).AddTicks(7720) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 7, 30, 13, 18, 38, 515, DateTimeKind.Local).AddTicks(7368), new DateTime(2024, 7, 30, 13, 18, 38, 515, DateTimeKind.Local).AddTicks(7381) });
        }
    }
}
