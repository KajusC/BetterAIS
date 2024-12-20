﻿// <auto-generated />
using System;
using BetterAIS.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BetterAIS.Data.Migrations
{
    [DbContext(typeof(BetterAisContext))]
    [Migration("20241209115418_Second")]
    partial class Second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BetterAIS.Data.Models.Destytojai", b =>
                {
                    b.Property<string>("Vidko")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("vidko");

                    b.Property<string>("Kvalifikacija")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("kvalifikacija");

                    b.HasKey("Vidko")
                        .HasName("destytojai_pkey");

                    b.ToTable("destytojai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Fakultetai", b =>
                {
                    b.Property<int>("IdFakultetas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_fakultetas");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdFakultetas"));

                    b.Property<string>("Adresas")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("adresas");

                    b.Property<string>("Dekanas")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("dekanas");

                    b.Property<string>("FakultetoKodas")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("fakulteto_kodas");

                    b.Property<string>("Pavadinimas")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("pavadinimas");

                    b.Property<string>("Telefonas")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("telefonas");

                    b.HasKey("IdFakultetas")
                        .HasName("fakultetai_pkey");

                    b.ToTable("fakultetai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.FinansavimoTipai", b =>
                {
                    b.Property<int>("IdFinansavimoTipai")
                        .HasColumnType("integer")
                        .HasColumnName("id_finansavimo_tipai");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("name");

                    b.HasKey("IdFinansavimoTipai")
                        .HasName("finansavimo_tipai_pkey");

                    b.ToTable("finansavimo_tipai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Kabinetai", b =>
                {
                    b.Property<int>("IdKabinetas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_kabinetas");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdKabinetas"));

                    b.Property<int>("Aukstas")
                        .HasColumnType("integer")
                        .HasColumnName("aukstas");

                    b.Property<string>("FakultetoKodas")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("fakulteto_kodas");

                    b.Property<int>("Numeris")
                        .HasColumnType("integer")
                        .HasColumnName("numeris");

                    b.HasKey("IdKabinetas")
                        .HasName("kabinetai_pkey");

                    b.ToTable("kabinetai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Moduliai", b =>
                {
                    b.Property<string>("Kodas")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("kodas");

                    b.Property<string>("Destytojas")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("destytojas");

                    b.Property<string>("FkDestytojasVidko")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("fk_destytojas_vidko");

                    b.Property<string>("Kalba")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("kalba");

                    b.Property<string>("Pavadinimas")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("pavadinimas");

                    b.Property<string>("UzsiemimuKiekis")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("uzsiemimu_kiekis");

                    b.HasKey("Kodas")
                        .HasName("moduliai_pkey");

                    b.HasIndex("FkDestytojasVidko");

                    b.ToTable("moduliai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.MoksliniaiLaipsniai", b =>
                {
                    b.Property<int>("IdMoksliniaiLaipsniai")
                        .HasColumnType("integer")
                        .HasColumnName("id_moksliniai_laipsniai");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("name");

                    b.HasKey("IdMoksliniaiLaipsniai")
                        .HasName("moksliniai_laipsniai_pkey");

                    b.ToTable("moksliniai_laipsniai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Paskaitos", b =>
                {
                    b.Property<int>("IdPaskaita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_paskaita");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPaskaita"));

                    b.Property<DateOnly>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("data")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<string>("FkDestytojasVidko")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("fk_destytojas_vidko");

                    b.Property<int>("FkIdFakultetas")
                        .HasColumnType("integer")
                        .HasColumnName("fk_id_fakultetas");

                    b.Property<string>("FkModulisKodas")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("fk_modulis_kodas");

                    b.Property<bool>("Privalomas")
                        .HasColumnType("boolean")
                        .HasColumnName("privalomas");

                    b.Property<int>("Tipas")
                        .HasColumnType("integer")
                        .HasColumnName("tipas");

                    b.Property<int>("Trukmė")
                        .HasColumnType("integer")
                        .HasColumnName("trukmė");

                    b.HasKey("IdPaskaita")
                        .HasName("paskaitos_pkey");

                    b.HasIndex("FkDestytojasVidko");

                    b.HasIndex("FkIdFakultetas");

                    b.HasIndex("FkModulisKodas");

                    b.HasIndex("Tipas");

                    b.ToTable("paskaitos", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.PaskaitosKabinetai", b =>
                {
                    b.Property<int>("FkIdPaskaita")
                        .HasColumnType("integer")
                        .HasColumnName("fk_id_paskaita");

                    b.Property<int>("FkIdKabinetas")
                        .HasColumnType("integer")
                        .HasColumnName("fk_id_kabinetas");

                    b.HasKey("FkIdPaskaita", "FkIdKabinetas")
                        .HasName("paskaitos_kabinetai_pkey");

                    b.ToTable("paskaitos_kabinetai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.PaskaitosTipai", b =>
                {
                    b.Property<int>("IdPaskaitosTipai")
                        .HasColumnType("integer")
                        .HasColumnName("id_paskaitos_tipai");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("name");

                    b.HasKey("IdPaskaitosTipai")
                        .HasName("paskaitos_tipai_pkey");

                    b.ToTable("paskaitos_tipai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Pazymiai", b =>
                {
                    b.Property<int>("IdPazymys")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_pazymys");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPazymys"));

                    b.Property<DateOnly>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("data")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<int?>("FkIdSuvestine")
                        .HasColumnType("integer")
                        .HasColumnName("fk_id_suvestine");

                    b.Property<double>("Ivertinimas")
                        .HasColumnType("double precision")
                        .HasColumnName("ivertinimas");

                    b.HasKey("IdPazymys")
                        .HasName("pazymiai_pkey");

                    b.HasIndex("FkIdSuvestine");

                    b.ToTable("pazymiai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Role", b =>
                {
                    b.Property<int>("IdRoles")
                        .HasColumnType("integer")
                        .HasColumnName("id_roles");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name");

                    b.HasKey("IdRoles")
                        .HasName("roles_pkey");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Statusai", b =>
                {
                    b.Property<int>("IdStatusai")
                        .HasColumnType("integer")
                        .HasColumnName("id_statusai");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("name");

                    b.HasKey("IdStatusai")
                        .HasName("statusai_pkey");

                    b.ToTable("statusai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Studentai", b =>
                {
                    b.Property<string>("Vidko")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("vidko");

                    b.Property<int>("Finansavimas")
                        .HasColumnType("integer")
                        .HasColumnName("finansavimas");

                    b.Property<string>("FkProgramosKodas")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fk_programos_kodas");

                    b.Property<int>("Statusas")
                        .HasColumnType("integer")
                        .HasColumnName("statusas");

                    b.Property<DateOnly>("StudijuPradzia")
                        .HasColumnType("date")
                        .HasColumnName("studiju_pradzia");

                    b.HasKey("Vidko")
                        .HasName("studentai_pkey");

                    b.HasIndex("Finansavimas");

                    b.HasIndex("FkProgramosKodas");

                    b.HasIndex("Statusas");

                    b.ToTable("studentai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.StudentoStatusai", b =>
                {
                    b.Property<int>("IdStudentoStatusai")
                        .HasColumnType("integer")
                        .HasColumnName("id_studento_statusai");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("name");

                    b.HasKey("IdStudentoStatusai")
                        .HasName("studento_statusai_pkey");

                    b.ToTable("studento_statusai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.StudijuPrograma", b =>
                {
                    b.Property<string>("ProgramosKodas")
                        .HasColumnType("text")
                        .HasColumnName("programos_kodas");

                    b.Property<int>("FakultetoId")
                        .HasColumnType("integer")
                        .HasColumnName("fakulteto_id");

                    b.Property<int>("KredituKiekis")
                        .HasColumnType("integer")
                        .HasColumnName("kreditu_kiekis");

                    b.Property<int>("MokslinisLaipsnis")
                        .HasColumnType("integer")
                        .HasColumnName("mokslinis_laipsnis");

                    b.Property<string>("Pavadinimas")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("pavadinimas");

                    b.Property<string>("ProgramosAprasymas")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("programos_aprasymas");

                    b.Property<string>("Trukme")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("trukme");

                    b.HasKey("ProgramosKodas")
                        .HasName("studiju_programa_pkey");

                    b.HasIndex("MokslinisLaipsnis");

                    b.ToTable("studiju_programa", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Suvestine", b =>
                {
                    b.Property<int>("IdSuvestine")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_suvestine");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdSuvestine"));

                    b.Property<bool>("Dalyvavo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("dalyvavo");

                    b.Property<int>("FkIdPaskaita")
                        .HasColumnType("integer")
                        .HasColumnName("fk_id_paskaita");

                    b.Property<int>("FkIdUzduotis")
                        .HasColumnType("integer")
                        .HasColumnName("fk_id_uzduotis");

                    b.Property<string>("FkStudentasVidko")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("fk_studentas_vidko");

                    b.HasKey("IdSuvestine")
                        .HasName("suvestines_pkey");

                    b.HasIndex("FkIdPaskaita");

                    b.HasIndex("FkIdUzduotis");

                    b.HasIndex("FkStudentasVidko");

                    b.ToTable("suvestines", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Uzduotys", b =>
                {
                    b.Property<int>("IdUzduotis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_uzduotis");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdUzduotis"));

                    b.Property<string>("Aprasymas")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("aprasymas");

                    b.Property<string>("GriztamasisRysys")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("griztamasis_rysys");

                    b.Property<string>("Pavadinimas")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("pavadinimas");

                    b.Property<DateOnly>("Terminas")
                        .HasColumnType("date")
                        .HasColumnName("terminas");

                    b.Property<int>("Tipas")
                        .HasColumnType("integer")
                        .HasColumnName("tipas");

                    b.HasKey("IdUzduotis")
                        .HasName("uzduotys_pkey");

                    b.HasIndex("Tipas");

                    b.ToTable("uzduotys", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.UzsiemimoTipai", b =>
                {
                    b.Property<int>("IdUzsiemimoTipai")
                        .HasColumnType("integer")
                        .HasColumnName("id_uzsiemimo_tipai");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.HasKey("IdUzsiemimoTipai")
                        .HasName("uzsiemimo_tipai_pkey");

                    b.ToTable("uzsiemimo_tipai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Vartotojai", b =>
                {
                    b.Property<string>("Vidko")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("vidko");

                    b.Property<string>("ElPastas")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("el_pastas");

                    b.Property<DateOnly>("GimimoData")
                        .HasColumnType("date")
                        .HasColumnName("gimimo_data");

                    b.Property<string>("Pavarde")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("pavarde");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<string>("Slaptazodis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("slaptazodis");

                    b.Property<string>("TelefonoNr")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("telefono_nr");

                    b.Property<string>("Vardas")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("vardas");

                    b.HasKey("Vidko")
                        .HasName("vartotojai_pkey");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "ElPastas" }, "unique_email")
                        .IsUnique();

                    b.ToTable("vartotojai", (string)null);
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Destytojai", b =>
                {
                    b.HasOne("BetterAIS.Data.Models.Vartotojai", "VidkoNavigation")
                        .WithOne("Destytojai")
                        .HasForeignKey("BetterAIS.Data.Models.Destytojai", "Vidko")
                        .IsRequired()
                        .HasConstraintName("destytojai_vidko_fkey");

                    b.Navigation("VidkoNavigation");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Moduliai", b =>
                {
                    b.HasOne("BetterAIS.Data.Models.Destytojai", "FkDestytojasVidkoNavigation")
                        .WithMany("Moduliai")
                        .HasForeignKey("FkDestytojasVidko")
                        .IsRequired()
                        .HasConstraintName("atsakingas");

                    b.Navigation("FkDestytojasVidkoNavigation");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Paskaitos", b =>
                {
                    b.HasOne("BetterAIS.Data.Models.Destytojai", "FkDestytojasVidkoNavigation")
                        .WithMany("Paskaitos")
                        .HasForeignKey("FkDestytojasVidko")
                        .IsRequired()
                        .HasConstraintName("veda");

                    b.HasOne("BetterAIS.Data.Models.Fakultetai", "FkIdFakultetasNavigation")
                        .WithMany("Paskaitos")
                        .HasForeignKey("FkIdFakultetas")
                        .IsRequired()
                        .HasConstraintName("randasi");

                    b.HasOne("BetterAIS.Data.Models.Moduliai", "FkModulisKodasNavigation")
                        .WithMany("Paskaitos")
                        .HasForeignKey("FkModulisKodas")
                        .IsRequired()
                        .HasConstraintName("itraukiama");

                    b.HasOne("BetterAIS.Data.Models.PaskaitosTipai", "TipasNavigation")
                        .WithMany("Paskaitos")
                        .HasForeignKey("Tipas")
                        .IsRequired()
                        .HasConstraintName("paskaitos_tipas_fkey");

                    b.Navigation("FkDestytojasVidkoNavigation");

                    b.Navigation("FkIdFakultetasNavigation");

                    b.Navigation("FkModulisKodasNavigation");

                    b.Navigation("TipasNavigation");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.PaskaitosKabinetai", b =>
                {
                    b.HasOne("BetterAIS.Data.Models.Paskaitos", "FkIdPaskaitaNavigation")
                        .WithMany("PaskaitosKabinetais")
                        .HasForeignKey("FkIdPaskaita")
                        .IsRequired()
                        .HasConstraintName("vykdoma");

                    b.Navigation("FkIdPaskaitaNavigation");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Pazymiai", b =>
                {
                    b.HasOne("BetterAIS.Data.Models.Suvestine", "FkIdSuvestineNavigation")
                        .WithMany("Pazymiais")
                        .HasForeignKey("FkIdSuvestine")
                        .HasConstraintName("irasomas");

                    b.Navigation("FkIdSuvestineNavigation");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Studentai", b =>
                {
                    b.HasOne("BetterAIS.Data.Models.FinansavimoTipai", "FinansavimasNavigation")
                        .WithMany("Studentais")
                        .HasForeignKey("Finansavimas")
                        .IsRequired()
                        .HasConstraintName("studentai_finansavimas_fkey");

                    b.HasOne("BetterAIS.Data.Models.StudijuPrograma", "FkProgramosKodasNavigation")
                        .WithMany("Studentais")
                        .HasForeignKey("FkProgramosKodas")
                        .IsRequired()
                        .HasConstraintName("itraukiamas");

                    b.HasOne("BetterAIS.Data.Models.StudentoStatusai", "StatusasNavigation")
                        .WithMany("Studentais")
                        .HasForeignKey("Statusas")
                        .IsRequired()
                        .HasConstraintName("studentai_statusas_fkey");

                    b.HasOne("BetterAIS.Data.Models.Vartotojai", "VidkoNavigation")
                        .WithOne("Studentai")
                        .HasForeignKey("BetterAIS.Data.Models.Studentai", "Vidko")
                        .IsRequired()
                        .HasConstraintName("studentai_vidko_fkey");

                    b.Navigation("FinansavimasNavigation");

                    b.Navigation("FkProgramosKodasNavigation");

                    b.Navigation("StatusasNavigation");

                    b.Navigation("VidkoNavigation");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.StudijuPrograma", b =>
                {
                    b.HasOne("BetterAIS.Data.Models.MoksliniaiLaipsniai", "MokslinisLaipsnisNavigation")
                        .WithMany("StudijuProgramas")
                        .HasForeignKey("MokslinisLaipsnis")
                        .IsRequired()
                        .HasConstraintName("studiju_programa_mokslinis_laipsnis_fkey");

                    b.Navigation("MokslinisLaipsnisNavigation");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Suvestine", b =>
                {
                    b.HasOne("BetterAIS.Data.Models.Paskaitos", "FkIdPaskaitaNavigation")
                        .WithMany("Suvestines")
                        .HasForeignKey("FkIdPaskaita")
                        .IsRequired()
                        .HasConstraintName("registruojama");

                    b.HasOne("BetterAIS.Data.Models.Uzduotys", "FkIdUzduotisNavigation")
                        .WithMany("Suvestines")
                        .HasForeignKey("FkIdUzduotis")
                        .IsRequired()
                        .HasConstraintName("priskiriama");

                    b.HasOne("BetterAIS.Data.Models.Studentai", "FkStudentasVidkoNavigation")
                        .WithMany("Suvestines")
                        .HasForeignKey("FkStudentasVidko")
                        .IsRequired()
                        .HasConstraintName("itraukiamas2");

                    b.Navigation("FkIdPaskaitaNavigation");

                    b.Navigation("FkIdUzduotisNavigation");

                    b.Navigation("FkStudentasVidkoNavigation");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Uzduotys", b =>
                {
                    b.HasOne("BetterAIS.Data.Models.UzsiemimoTipai", "TipasNavigation")
                        .WithMany("Uzduoties")
                        .HasForeignKey("Tipas")
                        .IsRequired()
                        .HasConstraintName("uzduotys_tipas_fkey");

                    b.Navigation("TipasNavigation");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Vartotojai", b =>
                {
                    b.HasOne("BetterAIS.Data.Models.Role", "Role")
                        .WithMany("Vartotojai")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("vartotojai_role_id_fkey");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Destytojai", b =>
                {
                    b.Navigation("Moduliai");

                    b.Navigation("Paskaitos");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Fakultetai", b =>
                {
                    b.Navigation("Paskaitos");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.FinansavimoTipai", b =>
                {
                    b.Navigation("Studentais");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Moduliai", b =>
                {
                    b.Navigation("Paskaitos");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.MoksliniaiLaipsniai", b =>
                {
                    b.Navigation("StudijuProgramas");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Paskaitos", b =>
                {
                    b.Navigation("PaskaitosKabinetais");

                    b.Navigation("Suvestines");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.PaskaitosTipai", b =>
                {
                    b.Navigation("Paskaitos");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Role", b =>
                {
                    b.Navigation("Vartotojai");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Studentai", b =>
                {
                    b.Navigation("Suvestines");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.StudentoStatusai", b =>
                {
                    b.Navigation("Studentais");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.StudijuPrograma", b =>
                {
                    b.Navigation("Studentais");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Suvestine", b =>
                {
                    b.Navigation("Pazymiais");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Uzduotys", b =>
                {
                    b.Navigation("Suvestines");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.UzsiemimoTipai", b =>
                {
                    b.Navigation("Uzduoties");
                });

            modelBuilder.Entity("BetterAIS.Data.Models.Vartotojai", b =>
                {
                    b.Navigation("Destytojai");

                    b.Navigation("Studentai");
                });
#pragma warning restore 612, 618
        }
    }
}
