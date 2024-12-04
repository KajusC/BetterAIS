using System;
using System.Collections.Generic;
using BetterAIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Data.Context;

public partial class BetterAisContext : DbContext
{
    public BetterAisContext()
    {
    }

    public BetterAisContext(DbContextOptions<BetterAisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Destytojai> Destytojai { get; set; }

    public virtual DbSet<Fakultetai> Fakultetai { get; set; }

    public virtual DbSet<FinansavimoTipai> FinansavimoTipai { get; set; }

    public virtual DbSet<Kabinetai> Kabinetai { get; set; }

    public virtual DbSet<Moduliai> Moduliai { get; set; }

    public virtual DbSet<MoksliniaiLaipsniai> MoksliniaiLaipsniai { get; set; }

    public virtual DbSet<Paskaitos> Paskaitos { get; set; }

    public virtual DbSet<PaskaitosKabinetai> PaskaitosKabinetai { get; set; }

    public virtual DbSet<PaskaitosTipai> PaskaitosTipai { get; set; }

    public virtual DbSet<Pazymiai> Pazymiai { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Statusai> Statusai { get; set; }

    public virtual DbSet<Studentai> Studentai { get; set; }

    public virtual DbSet<StudentoStatusai> StudentoStatusai { get; set; }

    public virtual DbSet<StudijuPrograma> StudijuPrograma { get; set; }

    public virtual DbSet<Suvestine> Suvestine { get; set; }

    public virtual DbSet<Uzduotys> Uzduotys { get; set; }

    public virtual DbSet<UzsiemimoTipai> UzsiemimoTipai { get; set; }

    public virtual DbSet<Vartotojai> Vartotojai { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=BetterAIS;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Destytojai>(entity =>
        {
            entity.HasKey(e => e.Vidko).HasName("destytojai_pkey");

            entity.ToTable("destytojai");

            entity.Property(e => e.Vidko)
                .HasMaxLength(10)
                .HasColumnName("vidko");
            entity.Property(e => e.Kvalifikacija)
                .HasMaxLength(20)
                .HasColumnName("kvalifikacija");

            entity.HasOne(d => d.VidkoNavigation).WithOne(p => p.Destytojai)
                .HasForeignKey<Destytojai>(d => d.Vidko)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("destytojai_vidko_fkey");
        });

        modelBuilder.Entity<Fakultetai>(entity =>
        {
            entity.HasKey(e => e.IdFakultetas).HasName("fakultetai_pkey");

            entity.ToTable("fakultetai");

            entity.Property(e => e.IdFakultetas).HasColumnName("id_fakultetas");
            entity.Property(e => e.Adresas)
                .HasMaxLength(255)
                .HasColumnName("adresas");
            entity.Property(e => e.Dekanas)
                .HasMaxLength(255)
                .HasColumnName("dekanas");
            entity.Property(e => e.FakultetoKodas)
                .HasMaxLength(10)
                .HasColumnName("fakulteto_kodas");
            entity.Property(e => e.Pavadinimas)
                .HasMaxLength(50)
                .HasColumnName("pavadinimas");
            entity.Property(e => e.Telefonas)
                .HasMaxLength(15)
                .HasColumnName("telefonas");
        });

        modelBuilder.Entity<FinansavimoTipai>(entity =>
        {
            entity.HasKey(e => e.IdFinansavimoTipai).HasName("finansavimo_tipai_pkey");

            entity.ToTable("finansavimo_tipai");

            entity.Property(e => e.IdFinansavimoTipai)
                .ValueGeneratedNever()
                .HasColumnName("id_finansavimo_tipai");
            entity.Property(e => e.Name)
                .HasMaxLength(3)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Kabinetai>(entity =>
        {
            entity.HasKey(e => e.IdKabinetas).HasName("kabinetai_pkey");

            entity.ToTable("kabinetai");

            entity.Property(e => e.IdKabinetas).HasColumnName("id_kabinetas");
            entity.Property(e => e.Aukstas).HasColumnName("aukstas");
            entity.Property(e => e.FakultetoKodas)
                .HasMaxLength(255)
                .HasColumnName("fakulteto_kodas");
            entity.Property(e => e.Numeris).HasColumnName("numeris");
        });

        modelBuilder.Entity<Moduliai>(entity =>
        {
            entity.HasKey(e => e.Kodas).HasName("moduliai_pkey");

            entity.ToTable("moduliai");

            entity.Property(e => e.Kodas)
                .HasMaxLength(10)
                .HasColumnName("kodas");
            entity.Property(e => e.Destytojas)
                .HasMaxLength(20)
                .HasColumnName("destytojas");
            entity.Property(e => e.FkDestytojasVidko)
                .HasMaxLength(10)
                .HasColumnName("fk_destytojas_vidko");
            entity.Property(e => e.Kalba)
                .HasMaxLength(10)
                .HasColumnName("kalba");
            entity.Property(e => e.Pavadinimas)
                .HasMaxLength(30)
                .HasColumnName("pavadinimas");
            entity.Property(e => e.UzsiemimuKiekis)
                .HasMaxLength(10)
                .HasColumnName("uzsiemimu_kiekis");

            entity.HasOne(d => d.FkDestytojasVidkoNavigation).WithMany(p => p.Moduliais)
                .HasForeignKey(d => d.FkDestytojasVidko)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("atsakingas");
        });

        modelBuilder.Entity<MoksliniaiLaipsniai>(entity =>
        {
            entity.HasKey(e => e.IdMoksliniaiLaipsniai).HasName("moksliniai_laipsniai_pkey");

            entity.ToTable("moksliniai_laipsniai");

            entity.Property(e => e.IdMoksliniaiLaipsniai)
                .ValueGeneratedNever()
                .HasColumnName("id_moksliniai_laipsniai");
            entity.Property(e => e.Name)
                .HasMaxLength(13)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Paskaitos>(entity =>
        {
            entity.HasKey(e => e.IdPaskaita).HasName("paskaitos_pkey");

            entity.ToTable("paskaitos");

            entity.Property(e => e.IdPaskaita).HasColumnName("id_paskaita");
            entity.Property(e => e.Data)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("data");
            entity.Property(e => e.FkDestytojasVidko)
                .HasMaxLength(10)
                .HasColumnName("fk_destytojas_vidko");
            entity.Property(e => e.FkIdFakultetas).HasColumnName("fk_id_fakultetas");
            entity.Property(e => e.FkModulisKodas)
                .HasMaxLength(10)
                .HasColumnName("fk_modulis_kodas");
            entity.Property(e => e.Privalomas).HasColumnName("privalomas");
            entity.Property(e => e.Tipas).HasColumnName("tipas");
            entity.Property(e => e.Trukmė).HasColumnName("trukmė");

            entity.HasOne(d => d.FkDestytojasVidkoNavigation).WithMany(p => p.Paskaitos)
                .HasForeignKey(d => d.FkDestytojasVidko)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("veda");

            entity.HasOne(d => d.FkIdFakultetasNavigation).WithMany(p => p.Paskaitos)
                .HasForeignKey(d => d.FkIdFakultetas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("randasi");

            entity.HasOne(d => d.FkModulisKodasNavigation).WithMany(p => p.Paskaitos)
                .HasForeignKey(d => d.FkModulisKodas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("itraukiama");

            entity.HasOne(d => d.TipasNavigation).WithMany(p => p.Paskaitos)
                .HasForeignKey(d => d.Tipas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paskaitos_tipas_fkey");
        });

        modelBuilder.Entity<PaskaitosKabinetai>(entity =>
        {
            entity.HasKey(e => new { e.FkIdPaskaita, e.FkIdKabinetas }).HasName("paskaitos_kabinetai_pkey");

            entity.ToTable("paskaitos_kabinetai");

            entity.Property(e => e.FkIdPaskaita).HasColumnName("fk_id_paskaita");
            entity.Property(e => e.FkIdKabinetas).HasColumnName("fk_id_kabinetas");

            entity.HasOne(d => d.FkIdPaskaitaNavigation).WithMany(p => p.PaskaitosKabinetais)
                .HasForeignKey(d => d.FkIdPaskaita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vykdoma");
        });

        modelBuilder.Entity<PaskaitosTipai>(entity =>
        {
            entity.HasKey(e => e.IdPaskaitosTipai).HasName("paskaitos_tipai_pkey");

            entity.ToTable("paskaitos_tipai");

            entity.Property(e => e.IdPaskaitosTipai)
                .ValueGeneratedNever()
                .HasColumnName("id_paskaitos_tipai");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Pazymiai>(entity =>
        {
            entity.HasKey(e => e.IdPazymys).HasName("pazymiai_pkey");

            entity.ToTable("pazymiai");

            entity.Property(e => e.IdPazymys).HasColumnName("id_pazymys");
            entity.Property(e => e.Data)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("data");
            entity.Property(e => e.FkIdSuvestine).HasColumnName("fk_id_suvestine");
            entity.Property(e => e.Ivertinimas).HasColumnName("ivertinimas");

            entity.HasOne(d => d.FkIdSuvestineNavigation).WithMany(p => p.Pazymiais)
                .HasForeignKey(d => d.FkIdSuvestine)
                .HasConstraintName("irasomas");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRoles).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.IdRoles)
                .ValueGeneratedNever()
                .HasColumnName("id_roles");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Statusai>(entity =>
        {
            entity.HasKey(e => e.IdStatusai).HasName("statusai_pkey");

            entity.ToTable("statusai");

            entity.Property(e => e.IdStatusai)
                .ValueGeneratedNever()
                .HasColumnName("id_statusai");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Studentai>(entity =>
        {
            entity.HasKey(e => e.Vidko).HasName("studentai_pkey");

            entity.ToTable("studentai");

            entity.Property(e => e.Vidko)
                .HasMaxLength(10)
                .HasColumnName("vidko");
            entity.Property(e => e.Finansavimas).HasColumnName("finansavimas");
            entity.Property(e => e.FkProgramosKodas).HasColumnName("fk_programos_kodas");
            entity.Property(e => e.Statusas).HasColumnName("statusas");
            entity.Property(e => e.StudijuPradzia).HasColumnName("studiju_pradzia");

            entity.HasOne(d => d.FinansavimasNavigation).WithMany(p => p.Studentais)
                .HasForeignKey(d => d.Finansavimas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studentai_finansavimas_fkey");

            entity.HasOne(d => d.FkProgramosKodasNavigation).WithMany(p => p.Studentais)
                .HasForeignKey(d => d.FkProgramosKodas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("itraukiamas");

            entity.HasOne(d => d.StatusasNavigation).WithMany(p => p.Studentais)
                .HasForeignKey(d => d.Statusas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studentai_statusas_fkey");

            entity.HasOne(d => d.VidkoNavigation).WithOne(p => p.Studentai)
                .HasForeignKey<Studentai>(d => d.Vidko)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studentai_vidko_fkey");
        });

        modelBuilder.Entity<StudentoStatusai>(entity =>
        {
            entity.HasKey(e => e.IdStudentoStatusai).HasName("studento_statusai_pkey");

            entity.ToTable("studento_statusai");

            entity.Property(e => e.IdStudentoStatusai)
                .ValueGeneratedNever()
                .HasColumnName("id_studento_statusai");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<StudijuPrograma>(entity =>
        {
            entity.HasKey(e => e.ProgramosKodas).HasName("studiju_programa_pkey");

            entity.ToTable("studiju_programa");

            entity.Property(e => e.ProgramosKodas)
                .ValueGeneratedNever()
                .HasColumnName("programos_kodas");
            entity.Property(e => e.FakultetoId).HasColumnName("fakulteto_id");
            entity.Property(e => e.KredituKiekis).HasColumnName("kreditu_kiekis");
            entity.Property(e => e.MokslinisLaipsnis).HasColumnName("mokslinis_laipsnis");
            entity.Property(e => e.Pavadinimas)
                .HasMaxLength(30)
                .HasColumnName("pavadinimas");
            entity.Property(e => e.ProgramosAprasymas)
                .HasMaxLength(255)
                .HasColumnName("programos_aprasymas");
            entity.Property(e => e.Trukme)
                .HasMaxLength(10)
                .HasColumnName("trukme");

            entity.HasOne(d => d.MokslinisLaipsnisNavigation).WithMany(p => p.StudijuProgramas)
                .HasForeignKey(d => d.MokslinisLaipsnis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studiju_programa_mokslinis_laipsnis_fkey");
        });

        modelBuilder.Entity<Suvestine>(entity =>
        {
            entity.HasKey(e => e.IdSuvestine).HasName("suvestines_pkey");

            entity.ToTable("suvestines");

            entity.Property(e => e.IdSuvestine).HasColumnName("id_suvestine");
            entity.Property(e => e.Dalyvavo)
                .HasDefaultValue(false)
                .HasColumnName("dalyvavo");
            entity.Property(e => e.FkIdPaskaita).HasColumnName("fk_id_paskaita");
            entity.Property(e => e.FkIdUzduotis).HasColumnName("fk_id_uzduotis");
            entity.Property(e => e.FkStudentasVidko)
                .HasMaxLength(10)
                .HasColumnName("fk_studentas_vidko");

            entity.HasOne(d => d.FkIdPaskaitaNavigation).WithMany(p => p.Suvestines)
                .HasForeignKey(d => d.FkIdPaskaita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registruojama");

            entity.HasOne(d => d.FkIdUzduotisNavigation).WithMany(p => p.Suvestines)
                .HasForeignKey(d => d.FkIdUzduotis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("priskiriama");

            entity.HasOne(d => d.FkStudentasVidkoNavigation).WithMany(p => p.Suvestines)
                .HasForeignKey(d => d.FkStudentasVidko)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("itraukiamas2");
        });

        modelBuilder.Entity<Uzduotys>(entity =>
        {
            entity.HasKey(e => e.IdUzduotis).HasName("uzduotys_pkey");

            entity.ToTable("uzduotys");

            entity.Property(e => e.IdUzduotis).HasColumnName("id_uzduotis");
            entity.Property(e => e.Aprasymas)
                .HasMaxLength(255)
                .HasColumnName("aprasymas");
            entity.Property(e => e.GriztamasisRysys)
                .HasMaxLength(255)
                .HasColumnName("griztamasis_rysys");
            entity.Property(e => e.Pavadinimas)
                .HasMaxLength(255)
                .HasColumnName("pavadinimas");
            entity.Property(e => e.Terminas).HasColumnName("terminas");
            entity.Property(e => e.Tipas).HasColumnName("tipas");

            entity.HasOne(d => d.TipasNavigation).WithMany(p => p.Uzduoties)
                .HasForeignKey(d => d.Tipas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("uzduotys_tipas_fkey");
        });

        modelBuilder.Entity<UzsiemimoTipai>(entity =>
        {
            entity.HasKey(e => e.IdUzsiemimoTipai).HasName("uzsiemimo_tipai_pkey");

            entity.ToTable("uzsiemimo_tipai");

            entity.Property(e => e.IdUzsiemimoTipai)
                .ValueGeneratedNever()
                .HasColumnName("id_uzsiemimo_tipai");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Vartotojai>(entity =>
        {
            entity.HasKey(e => e.Vidko).HasName("vartotojai_pkey");

            entity.ToTable("vartotojai");

            entity.HasIndex(e => e.ElPastas, "unique_email").IsUnique();

            entity.Property(e => e.Vidko)
                .HasMaxLength(10)
                .HasColumnName("vidko");
            entity.Property(e => e.ElPastas)
                .HasMaxLength(30)
                .HasColumnName("el_pastas");
            entity.Property(e => e.GimimoData).HasColumnName("gimimo_data");
            entity.Property(e => e.Pavarde)
                .HasMaxLength(30)
                .HasColumnName("pavarde");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Slaptazodis)
                .HasMaxLength(255)
                .HasColumnName("slaptazodis");
            entity.Property(e => e.TelefonoNr)
                .HasMaxLength(15)
                .HasColumnName("telefono_nr");
            entity.Property(e => e.Vardas)
                .HasMaxLength(20)
                .HasColumnName("vardas");

            entity.HasOne(d => d.Role).WithMany(p => p.Vartotojai)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vartotojai_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
