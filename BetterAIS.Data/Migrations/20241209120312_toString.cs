using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterAIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class toString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "programos_kodas",
                table: "studiju_programa",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "fk_programos_kodas",
                table: "studentai",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "programos_kodas",
                table: "studiju_programa",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "fk_programos_kodas",
                table: "studentai",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");
        }
    }
}
