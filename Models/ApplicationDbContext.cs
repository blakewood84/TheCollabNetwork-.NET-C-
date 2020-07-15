using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace collabnetwork_.net_c_.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=C:/repos/TheCollabNetwork/TheCollabNetwork-.NET-C-/data.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>(entity =>
            {
                entity.Property(e => e.Id);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("VARCHAR(12500)");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("datetime('now')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.Id);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("datetime('now')");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("VARCHAR(1000)");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.Id);

                entity.Property(e => e.Access)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)")
                    .HasDefaultValueSql("'PUBLIC'");

                entity.Property(e => e.Capacity).HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("datetime('now')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("VARCHAR(12500)");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("VARCHAR(12500)");

                entity.Property(e => e.Qualifiers)
                    .IsRequired()
                    .HasColumnType("VARCHAR(12500)");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnType("VARCHAR(12500)");

                entity.Property(e => e.SkillLevel)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)")
                    .HasDefaultValueSql("BEGINNER");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("datetime('now')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.Property(e => e.Id);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("datetime('now')");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("VARCHAR(12500)");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Reporter)
                    .WithMany(p => p.ReportsReporter)
                    .HasForeignKey(d => d.ReporterId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReportsUser)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .IsUnique();

                entity.Property(e => e.Id);

                entity.Property(e => e.Company).HasColumnType("VARCHAR(60)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.Img).HasColumnType("CHAR(10000)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("VARCHAR(60)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(40)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
