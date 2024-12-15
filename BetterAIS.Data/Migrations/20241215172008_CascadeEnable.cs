using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterAIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class CascadeEnable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "itraukiamas",
                table: "studentai");

            migrationBuilder.DropForeignKey(
                name: "itraukiamas2",
                table: "suvestines");

            migrationBuilder.DropForeignKey(
                name: "priskiriama",
                table: "suvestines");

            migrationBuilder.DropForeignKey(
                name: "registruojama",
                table: "suvestines");

            migrationBuilder.AddForeignKey(
                name: "itraukiamas",
                table: "studentai",
                column: "fk_programos_kodas",
                principalTable: "studiju_programa",
                principalColumn: "programos_kodas",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "itraukiamas2",
                table: "suvestines",
                column: "fk_studentas_vidko",
                principalTable: "studentai",
                principalColumn: "vidko",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "priskiriama",
                table: "suvestines",
                column: "fk_id_uzduotis",
                principalTable: "uzduotys",
                principalColumn: "id_uzduotis",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "registruojama",
                table: "suvestines",
                column: "fk_id_paskaita",
                principalTable: "paskaitos",
                principalColumn: "id_paskaita",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "itraukiamas",
                table: "studentai");

            migrationBuilder.DropForeignKey(
                name: "itraukiamas2",
                table: "suvestines");

            migrationBuilder.DropForeignKey(
                name: "priskiriama",
                table: "suvestines");

            migrationBuilder.DropForeignKey(
                name: "registruojama",
                table: "suvestines");

            migrationBuilder.AddForeignKey(
                name: "itraukiamas",
                table: "studentai",
                column: "fk_programos_kodas",
                principalTable: "studiju_programa",
                principalColumn: "programos_kodas");

            migrationBuilder.AddForeignKey(
                name: "itraukiamas2",
                table: "suvestines",
                column: "fk_studentas_vidko",
                principalTable: "studentai",
                principalColumn: "vidko");

            migrationBuilder.AddForeignKey(
                name: "priskiriama",
                table: "suvestines",
                column: "fk_id_uzduotis",
                principalTable: "uzduotys",
                principalColumn: "id_uzduotis");

            migrationBuilder.AddForeignKey(
                name: "registruojama",
                table: "suvestines",
                column: "fk_id_paskaita",
                principalTable: "paskaitos",
                principalColumn: "id_paskaita");
        }
    }
}
