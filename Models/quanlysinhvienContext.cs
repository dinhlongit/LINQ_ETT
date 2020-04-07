using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _102160149_NguyenDinhLong.Models
{
    public partial class quanlysinhvienContext : DbContext
    {
        public quanlysinhvienContext()
        {
        }

        public quanlysinhvienContext(DbContextOptions<quanlysinhvienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sinhvien> Sinhvien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=quanlysinhvien;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sinhvien>(entity =>
            {
                entity.HasKey(e => e.Mssv);

                entity.ToTable("sinhvien");

                entity.Property(e => e.Mssv)
                    .HasColumnName("MSSV")
                    .ValueGeneratedNever();

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Dtb).HasColumnName("DTB");

                entity.Property(e => e.NameLop)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.NameSv)
                    .HasColumnName("NameSV")
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
