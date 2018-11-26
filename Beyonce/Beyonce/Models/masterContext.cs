using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Beyonce.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dienst> Dienst { get; set; }
        public virtual DbSet<Land> Land { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dienst>(entity =>
            {
                entity.Property(e => e.DienstId).HasColumnName("DienstID");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dienstart)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Land>(entity =>
            {
                entity.Property(e => e.LandId).HasColumnName("LandID");

                entity.Property(e => e.Kuerzel)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.LandBez)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
