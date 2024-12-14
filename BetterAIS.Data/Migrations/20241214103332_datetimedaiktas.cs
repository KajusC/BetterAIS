using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterAIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class datetimedaiktas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "paskaitos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_DATE",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "CURRENT_DATE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "data",
                table: "paskaitos",
                type: "date",
                nullable: false,
                defaultValueSql: "CURRENT_DATE",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_DATE");
        }
    }
}
