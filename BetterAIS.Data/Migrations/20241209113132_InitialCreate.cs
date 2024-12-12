using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BetterAIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fakultetai",
                columns: table => new
                {
                    id_fakultetas = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pavadinimas = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    fakulteto_kodas = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    dekanas = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    adresas = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    telefonas = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fakultetai_pkey", x => x.id_fakultetas);
                });

            migrationBuilder.CreateTable(
                name: "finansavimo_tipai",
                columns: table => new
                {
                    id_finansavimo_tipai = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("finansavimo_tipai_pkey", x => x.id_finansavimo_tipai);
                });

            migrationBuilder.CreateTable(
                name: "kabinetai",
                columns: table => new
                {
                    id_kabinetas = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numeris = table.Column<int>(type: "integer", nullable: false),
                    aukstas = table.Column<int>(type: "integer", nullable: false),
                    fakulteto_kodas = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("kabinetai_pkey", x => x.id_kabinetas);
                });

            migrationBuilder.CreateTable(
                name: "moksliniai_laipsniai",
                columns: table => new
                {
                    id_moksliniai_laipsniai = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("moksliniai_laipsniai_pkey", x => x.id_moksliniai_laipsniai);
                });

            migrationBuilder.CreateTable(
                name: "paskaitos_tipai",
                columns: table => new
                {
                    id_paskaitos_tipai = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("paskaitos_tipai_pkey", x => x.id_paskaitos_tipai);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id_roles = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_pkey", x => x.id_roles);
                });

            migrationBuilder.CreateTable(
                name: "statusai",
                columns: table => new
                {
                    id_statusai = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("statusai_pkey", x => x.id_statusai);
                });

            migrationBuilder.CreateTable(
                name: "studento_statusai",
                columns: table => new
                {
                    id_studento_statusai = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("studento_statusai_pkey", x => x.id_studento_statusai);
                });

            migrationBuilder.CreateTable(
                name: "uzsiemimo_tipai",
                columns: table => new
                {
                    id_uzsiemimo_tipai = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("uzsiemimo_tipai_pkey", x => x.id_uzsiemimo_tipai);
                });

            migrationBuilder.CreateTable(
                name: "studiju_programa",
                columns: table => new
                {
                    programos_kodas = table.Column<string>(type: "text", nullable: false),
                    pavadinimas = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    trukme = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    kreditu_kiekis = table.Column<int>(type: "integer", nullable: false),
                    fakulteto_id = table.Column<int>(type: "integer", nullable: false),
                    programos_aprasymas = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    mokslinis_laipsnis = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("studiju_programa_pkey", x => x.programos_kodas);
                    table.ForeignKey(
                        name: "studiju_programa_mokslinis_laipsnis_fkey",
                        column: x => x.mokslinis_laipsnis,
                        principalTable: "moksliniai_laipsniai",
                        principalColumn: "id_moksliniai_laipsniai");
                });

            migrationBuilder.CreateTable(
                name: "vartotojai",
                columns: table => new
                {
                    vidko = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    vardas = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    pavarde = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    gimimo_data = table.Column<DateOnly>(type: "date", nullable: false),
                    telefono_nr = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    el_pastas = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    slaptazodis = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("vartotojai_pkey", x => x.vidko);
                    table.ForeignKey(
                        name: "vartotojai_role_id_fkey",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id_roles");
                });

            migrationBuilder.CreateTable(
                name: "uzduotys",
                columns: table => new
                {
                    id_uzduotis = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pavadinimas = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    aprasymas = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    terminas = table.Column<DateOnly>(type: "date", nullable: false),
                    griztamasis_rysys = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    tipas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("uzduotys_pkey", x => x.id_uzduotis);
                    table.ForeignKey(
                        name: "uzduotys_tipas_fkey",
                        column: x => x.tipas,
                        principalTable: "uzsiemimo_tipai",
                        principalColumn: "id_uzsiemimo_tipai");
                });

            migrationBuilder.CreateTable(
                name: "destytojai",
                columns: table => new
                {
                    vidko = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    kvalifikacija = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("destytojai_pkey", x => x.vidko);
                    table.ForeignKey(
                        name: "destytojai_vidko_fkey",
                        column: x => x.vidko,
                        principalTable: "vartotojai",
                        principalColumn: "vidko");
                });

            migrationBuilder.CreateTable(
                name: "studentai",
                columns: table => new
                {
                    vidko = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    studiju_pradzia = table.Column<DateOnly>(type: "date", nullable: false),
                    statusas = table.Column<int>(type: "integer", nullable: false),
                    finansavimas = table.Column<int>(type: "integer", nullable: false),
                    fk_programos_kodas = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("studentai_pkey", x => x.vidko);
                    table.ForeignKey(
                        name: "itraukiamas",
                        column: x => x.fk_programos_kodas,
                        principalTable: "studiju_programa",
                        principalColumn: "programos_kodas");
                    table.ForeignKey(
                        name: "studentai_finansavimas_fkey",
                        column: x => x.finansavimas,
                        principalTable: "finansavimo_tipai",
                        principalColumn: "id_finansavimo_tipai");
                    table.ForeignKey(
                        name: "studentai_statusas_fkey",
                        column: x => x.statusas,
                        principalTable: "studento_statusai",
                        principalColumn: "id_studento_statusai");
                    table.ForeignKey(
                        name: "studentai_vidko_fkey",
                        column: x => x.vidko,
                        principalTable: "vartotojai",
                        principalColumn: "vidko");
                });

            migrationBuilder.CreateTable(
                name: "moduliai",
                columns: table => new
                {
                    kodas = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    pavadinimas = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    destytojas = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    uzsiemimu_kiekis = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    kalba = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    fk_destytojas_vidko = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("moduliai_pkey", x => x.kodas);
                    table.ForeignKey(
                        name: "atsakingas",
                        column: x => x.fk_destytojas_vidko,
                        principalTable: "destytojai",
                        principalColumn: "vidko");
                });

            migrationBuilder.CreateTable(
                name: "paskaitos",
                columns: table => new
                {
                    id_paskaita = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    trukmė = table.Column<int>(type: "integer", nullable: false),
                    privalomas = table.Column<bool>(type: "boolean", nullable: false),
                    tipas = table.Column<int>(type: "integer", nullable: false),
                    fk_modulis_kodas = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    fk_id_fakultetas = table.Column<int>(type: "integer", nullable: false),
                    fk_destytojas_vidko = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("paskaitos_pkey", x => x.id_paskaita);
                    table.ForeignKey(
                        name: "itraukiama",
                        column: x => x.fk_modulis_kodas,
                        principalTable: "moduliai",
                        principalColumn: "kodas");
                    table.ForeignKey(
                        name: "paskaitos_tipas_fkey",
                        column: x => x.tipas,
                        principalTable: "paskaitos_tipai",
                        principalColumn: "id_paskaitos_tipai");
                    table.ForeignKey(
                        name: "randasi",
                        column: x => x.fk_id_fakultetas,
                        principalTable: "fakultetai",
                        principalColumn: "id_fakultetas");
                    table.ForeignKey(
                        name: "veda",
                        column: x => x.fk_destytojas_vidko,
                        principalTable: "destytojai",
                        principalColumn: "vidko");
                });

            migrationBuilder.CreateTable(
                name: "paskaitos_kabinetai",
                columns: table => new
                {
                    fk_id_paskaita = table.Column<int>(type: "integer", nullable: false),
                    fk_id_kabinetas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("paskaitos_kabinetai_pkey", x => new { x.fk_id_paskaita, x.fk_id_kabinetas });
                    table.ForeignKey(
                        name: "vykdoma",
                        column: x => x.fk_id_paskaita,
                        principalTable: "paskaitos",
                        principalColumn: "id_paskaita");
                });

            migrationBuilder.CreateTable(
                name: "suvestines",
                columns: table => new
                {
                    id_suvestine = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dalyvavo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    fk_studentas_vidko = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    fk_id_uzduotis = table.Column<int>(type: "integer", nullable: false),
                    fk_id_paskaita = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("suvestines_pkey", x => x.id_suvestine);
                    table.ForeignKey(
                        name: "itraukiamas2",
                        column: x => x.fk_studentas_vidko,
                        principalTable: "studentai",
                        principalColumn: "vidko");
                    table.ForeignKey(
                        name: "priskiriama",
                        column: x => x.fk_id_uzduotis,
                        principalTable: "uzduotys",
                        principalColumn: "id_uzduotis");
                    table.ForeignKey(
                        name: "registruojama",
                        column: x => x.fk_id_paskaita,
                        principalTable: "paskaitos",
                        principalColumn: "id_paskaita");
                });

            migrationBuilder.CreateTable(
                name: "pazymiai",
                columns: table => new
                {
                    id_pazymys = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ivertinimas = table.Column<double>(type: "double precision", nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    fk_id_suvestine = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pazymiai_pkey", x => x.id_pazymys);
                    table.ForeignKey(
                        name: "irasomas",
                        column: x => x.fk_id_suvestine,
                        principalTable: "suvestines",
                        principalColumn: "id_suvestine");
                });

            migrationBuilder.CreateIndex(
                name: "IX_moduliai_fk_destytojas_vidko",
                table: "moduliai",
                column: "fk_destytojas_vidko");

            migrationBuilder.CreateIndex(
                name: "IX_paskaitos_fk_destytojas_vidko",
                table: "paskaitos",
                column: "fk_destytojas_vidko");

            migrationBuilder.CreateIndex(
                name: "IX_paskaitos_fk_id_fakultetas",
                table: "paskaitos",
                column: "fk_id_fakultetas");

            migrationBuilder.CreateIndex(
                name: "IX_paskaitos_fk_modulis_kodas",
                table: "paskaitos",
                column: "fk_modulis_kodas");

            migrationBuilder.CreateIndex(
                name: "IX_paskaitos_tipas",
                table: "paskaitos",
                column: "tipas");

            migrationBuilder.CreateIndex(
                name: "IX_pazymiai_fk_id_suvestine",
                table: "pazymiai",
                column: "fk_id_suvestine");

            migrationBuilder.CreateIndex(
                name: "IX_studentai_finansavimas",
                table: "studentai",
                column: "finansavimas");

            migrationBuilder.CreateIndex(
                name: "IX_studentai_fk_programos_kodas",
                table: "studentai",
                column: "fk_programos_kodas");

            migrationBuilder.CreateIndex(
                name: "IX_studentai_statusas",
                table: "studentai",
                column: "statusas");

            migrationBuilder.CreateIndex(
                name: "IX_studiju_programa_mokslinis_laipsnis",
                table: "studiju_programa",
                column: "mokslinis_laipsnis");

            migrationBuilder.CreateIndex(
                name: "IX_suvestines_fk_id_paskaita",
                table: "suvestines",
                column: "fk_id_paskaita");

            migrationBuilder.CreateIndex(
                name: "IX_suvestines_fk_id_uzduotis",
                table: "suvestines",
                column: "fk_id_uzduotis");

            migrationBuilder.CreateIndex(
                name: "IX_suvestines_fk_studentas_vidko",
                table: "suvestines",
                column: "fk_studentas_vidko");

            migrationBuilder.CreateIndex(
                name: "IX_uzduotys_tipas",
                table: "uzduotys",
                column: "tipas");

            migrationBuilder.CreateIndex(
                name: "IX_vartotojai_role_id",
                table: "vartotojai",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "unique_email",
                table: "vartotojai",
                column: "el_pastas",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kabinetai");

            migrationBuilder.DropTable(
                name: "paskaitos_kabinetai");

            migrationBuilder.DropTable(
                name: "pazymiai");

            migrationBuilder.DropTable(
                name: "statusai");

            migrationBuilder.DropTable(
                name: "suvestines");

            migrationBuilder.DropTable(
                name: "studentai");

            migrationBuilder.DropTable(
                name: "uzduotys");

            migrationBuilder.DropTable(
                name: "paskaitos");

            migrationBuilder.DropTable(
                name: "studiju_programa");

            migrationBuilder.DropTable(
                name: "finansavimo_tipai");

            migrationBuilder.DropTable(
                name: "studento_statusai");

            migrationBuilder.DropTable(
                name: "uzsiemimo_tipai");

            migrationBuilder.DropTable(
                name: "moduliai");

            migrationBuilder.DropTable(
                name: "paskaitos_tipai");

            migrationBuilder.DropTable(
                name: "fakultetai");

            migrationBuilder.DropTable(
                name: "moksliniai_laipsniai");

            migrationBuilder.DropTable(
                name: "destytojai");

            migrationBuilder.DropTable(
                name: "vartotojai");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
