using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FitnessTracker.Models
{
    public partial class FitnessTrackerContext : DbContext
    {
        public FitnessTrackerContext()
        {
        }

        public FitnessTrackerContext(DbContextOptions<FitnessTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BodyPart> BodyParts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Excercise> Excercises { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=FitnessTracker;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BodyPart>(entity =>
            {
                entity.ToTable("BodyPart");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Excercise>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Bodypart)
                    .WithMany(p => p.Excercises)
                    .HasForeignKey(d => d.BodypartId)
                    .HasConstraintName("FK__Excercise__Bodyp__2E1BDC42");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Excercises)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Excercise__Categ__2F10007B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Excercises)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Excercise__UserI__2D27B809");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Foods__UserId__267ABA7A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
