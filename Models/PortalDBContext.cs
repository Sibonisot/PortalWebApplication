using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PortalWebApplication.Models
{
    public partial class PortalDBContext : DbContext
    {
        public PortalDBContext()
        {
        }

        public PortalDBContext(DbContextOptions<PortalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PortalRole> PortalRoles { get; set; }
        public virtual DbSet<PortalUser> PortalUsers { get; set; }
        public virtual DbSet<PortalUserRole> PortalUserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PortalDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<PortalRole>(entity =>
            {
                entity.ToTable("PortalRole");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.PortalRoleDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PortalUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_PortalUser_1");

                entity.ToTable("PortalUser");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Division)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PortalUserRole>(entity =>
            {
                entity.HasKey(e => e.PortalUserId)
                    .HasName("PK_PortalUserRole_PortalUserID");

                entity.ToTable("PortalUserRole");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.RoleDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PortalRole)
                    .WithMany(p => p.PortalUserRoles)
                    .HasForeignKey(d => d.PortalRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PortalUserRole_PortalRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PortalUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
