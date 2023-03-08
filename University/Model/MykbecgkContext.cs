using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace University;

public partial class MykbecgkContext : DbContext
{
    public MykbecgkContext()
    {
    }

    public MykbecgkContext(DbContextOptions<MykbecgkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }

    public virtual DbSet<DistanceLearning> DistanceLearnings { get; set; }

    public virtual DbSet<FullTimeStudent> FullTimeStudents { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=suleiman.db.elephantsql.com;Port=5432;Database=mykbecgk;Username=mykbecgk;Password=x42RujVqLPqBvQSR3_zcKd4Lg6DlmkD8");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("btree_gin")
            .HasPostgresExtension("btree_gist")
            .HasPostgresExtension("citext")
            .HasPostgresExtension("cube")
            .HasPostgresExtension("dblink")
            .HasPostgresExtension("dict_int")
            .HasPostgresExtension("dict_xsyn")
            .HasPostgresExtension("earthdistance")
            .HasPostgresExtension("fuzzystrmatch")
            .HasPostgresExtension("hstore")
            .HasPostgresExtension("intarray")
            .HasPostgresExtension("ltree")
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgcrypto")
            .HasPostgresExtension("pgrowlocks")
            .HasPostgresExtension("pgstattuple")
            .HasPostgresExtension("tablefunc")
            .HasPostgresExtension("unaccent")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("xml2");

        modelBuilder.Entity<CompetitionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("competition_type_pkey");

            entity.ToTable("competition_type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TypeOfCompetition).HasColumnName("type_of_competition");
        });

        modelBuilder.Entity<DistanceLearning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("distance_learning_pkey");

            entity.ToTable("distance_learning");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Achievements).HasColumnName("achievements");
            entity.Property(e => e.Approval).HasColumnName("approval");
            entity.Property(e => e.CompetitionTypeId).HasColumnName("competition_type_id");
            entity.Property(e => e.Original).HasColumnName("original");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.CompetitionType).WithMany(p => p.DistanceLearnings)
                .HasForeignKey(d => d.CompetitionTypeId)
                .HasConstraintName("distance_learning_competition_type_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.DistanceLearnings)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("distance_learning_person_id_fkey");
        });

        modelBuilder.Entity<FullTimeStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("full_time_student_pkey");

            entity.ToTable("full_time_student");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Achievements).HasColumnName("achievements");
            entity.Property(e => e.Approval).HasColumnName("approval");
            entity.Property(e => e.CompetitionTypeId).HasColumnName("competition_type_id");
            entity.Property(e => e.Original).HasColumnName("original");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.CompetitionType).WithMany(p => p.FullTimeStudents)
                .HasForeignKey(d => d.CompetitionTypeId)
                .HasConstraintName("full_time_student_competition_type_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.FullTimeStudents)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("full_time_student_person_id_fkey");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Person_pkey");

            entity.ToTable("person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Snils).HasColumnName("SNILS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
