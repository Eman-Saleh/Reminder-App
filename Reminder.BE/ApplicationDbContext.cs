using Microsoft.EntityFrameworkCore;
using Reminder.DB.Models;

namespace Reminder.BE
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }


        public virtual DbSet<CategoryTbl> CategoryTbls { get; set; } = null!;
        public virtual DbSet<ReminderTbl> ReminderTbls { get; set; } = null!;
        public virtual DbSet<UserTbl> UserTbls { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryTbl>(entity =>
            {
                entity.ToTable("CategoryTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CategoryTbls)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_CategoryTbl_UserTbl");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_CategoryTbl_CategoryTbl");
            });

            modelBuilder.Entity<ReminderTbl>(entity =>
            {
                entity.ToTable("ReminderTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ReminderDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ReminderTbls)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ReminderTbl_CategoryTbl");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ReminderTbls)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_ReminderTbl_UserTbl");
            });

            modelBuilder.Entity<UserTbl>(entity =>
            {
                entity.ToTable("UserTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
