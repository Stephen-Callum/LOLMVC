using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LOLMVC
{
    public partial class LOLDBContext : DbContext
    {
        public LOLDBContext()
        {
        }

        public LOLDBContext(DbContextOptions<LOLDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChampStat> ChampStat { get; set; }
        public virtual DbSet<Champion> Champion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LOLDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChampStat>(entity =>
            {
                entity.HasKey(e => e.StatId)
                    .HasName("PK__ChampSta__3A162D1E01A17491");

                entity.Property(e => e.StatId).HasColumnName("StatID");

                entity.Property(e => e.BanRate).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.ChampId).HasColumnName("ChampID");

                entity.Property(e => e.LanePlayed)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PickRate).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Tier)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WinRate).HasColumnType("numeric(4, 2)");

                entity.HasOne(d => d.Champ)
                    .WithMany(p => p.ChampStat)
                    .HasForeignKey(d => d.ChampId)
                    .HasConstraintName("FK__ChampStat__Champ__25869641");
            });

            modelBuilder.Entity<Champion>(entity =>
            {
                entity.HasKey(e => e.ChampId)
                    .HasName("PK__Champion__DEBA70844C0AE85B");

                entity.Property(e => e.ChampId).HasColumnName("ChampID");

                entity.Property(e => e.ChampImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ChampName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ChampReleaseDate).HasColumnType("date");

                entity.Property(e => e.ChampResource)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ChampRole)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Lore).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
