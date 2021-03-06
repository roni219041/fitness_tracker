using System;
using System.Collections.Generic;
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

            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        //Add records to the Food table in database, using EF Core and migrations
        public void AddRangeRecords()
        {
            using (FitnessTrackerContext _db = new FitnessTrackerContext())
            {
                List<Food> foods = new List<Food>();

                foods.Add(new Food { Name = "Boneless, Skinless Chicken Breast", Calories = 119, Fat = 3, Protein = 23, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Tuna(water packed), can", Calories = 81, Fat = 1, Protein = 18, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Salmon Filet", Calories = 78, Fat = 2, Protein = 15, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Schrimp", Calories = 123, Fat = 3, Protein = 24, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Extra Lean Ground Beef or Ground Round", Calories = 121, Fat = 4, Protein = 24, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Egg", Calories = 69, Fat = 5, Protein = 6, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Egg Whites", Calories = 52, Fat = 0, Protein = 11, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Rib eye Steak", Calories = 235, Fat = 15, Protein = 25, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Top round Steak", Calories = 212, Fat = 8, Protein = 35, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Sirloin steak", Calories = 275, Fat = 15, Protein = 35, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Filet Mignon", Calories = 200, Fat = 8, Protein = 32, Carbohydrates = 0 });
                foods.Add(new Food { Name = "NY Strip Steak", Calories = 100, Fat = 4, Protein = 16, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Flank Steak(Stir Fry, Fajita)", Calories = 200, Fat = 8, Protein = 32, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Pork Loin", Calories = 146, Fat = 6, Protein = 23, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Ground turkey(Turkey Breast Slices or cutlets(fresh meat, not deli cuts)", Calories = 122, Fat = 2, Protein = 26, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Sweet Potatoes, raw", Calories = 100, Fat = 0, Protein = 2, Carbohydrates = 23 });
                foods.Add(new Food { Name = "Quinoa", Calories = 272, Fat = 0, Protein = 6, Carbohydrates = 62 });
                foods.Add(new Food { Name = "Oats", Calories = 347, Fat = 7, Protein = 11, Carbohydrates = 60 });
                foods.Add(new Food { Name = "Old Fashioned Grifts", Calories = 459, Fat = 3, Protein = 12, Carbohydrates = 96 });
                foods.Add(new Food { Name = "White Rice", Calories = 360, Fat = 0, Protein = 6, Carbohydrates = 84 });
                foods.Add(new Food { Name = "White Potatoes, raw", Calories = 88, Fat = 0, Protein = 2, Carbohydrates = 20 });
                foods.Add(new Food { Name = "Lettuce", Calories = 12, Fat = 0, Protein = 1, Carbohydrates = 2 });
                foods.Add(new Food { Name = "Broccoli", Calories = 32, Fat = 0, Protein = 2, Carbohydrates = 6 });
                foods.Add(new Food { Name = "Asparagus", Calories = 24, Fat = 0, Protein = 2, Carbohydrates = 4 });
                foods.Add(new Food { Name = "Spinach", Calories = 8, Fat = 0, Protein = 1, Carbohydrates = 1 });
                foods.Add(new Food { Name = "Multi Colored Bell Peppers", Calories = 12, Fat = 0, Protein = 1, Carbohydrates = 2 });
                foods.Add(new Food { Name = "Brussels Sprouts", Calories = 20, Fat = 0, Protein = 1, Carbohydrates = 4 });
                foods.Add(new Food { Name = "Cauliflower", Calories = 28, Fat = 0, Protein = 2, Carbohydrates = 5 });
                foods.Add(new Food { Name = "Zucchini", Calories = 24, Fat = 0, Protein = 2, Carbohydrates = 4 });
                foods.Add(new Food { Name = "Cucumber", Calories = 20, Fat = 0, Protein = 1, Carbohydrates = 4 });
                foods.Add(new Food { Name = "Mushrooms", Calories = 16, Fat = 0, Protein = 2, Carbohydrates = 2 });
                foods.Add(new Food { Name = "Apple", Calories = 60, Fat = 0, Protein = 0, Carbohydrates = 15 });
                foods.Add(new Food { Name = "Banana", Calories = 112, Fat = 0, Protein = 1, Carbohydrates = 27 });
                foods.Add(new Food { Name = "Mango", Calories = 80, Fat = 0, Protein = 1, Carbohydrates = 19 });
                foods.Add(new Food { Name = "Navel orange", Calories = 72, Fat = 0, Protein = 2, Carbohydrates = 16 });
                foods.Add(new Food { Name = "Blueberries", Calories = 44, Fat = 0, Protein = 0, Carbohydrates = 11 });
                foods.Add(new Food { Name = "Strawberries", Calories = 40, Fat = 0, Protein = 1, Carbohydrates = 9 });
                foods.Add(new Food { Name = "Blackberries", Calories = 60, Fat = 0, Protein = 1, Carbohydrates = 14 });
                foods.Add(new Food { Name = "Almond Butter", Calories = 704, Fat = 56, Protein = 22, Carbohydrates = 28 });
                foods.Add(new Food { Name = "Olive Oil", Calories = 1008, Fat = 112, Protein = 0, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Clarified or organic butter", Calories = 504, Fat = 56, Protein = 0, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Coconut oil", Calories = 1008, Fat = 112, Protein = 0, Carbohydrates = 0 });
                foods.Add(new Food { Name = "Avocado", Calories = 142, Fat = 14, Protein = 2, Carbohydrates = 2 });

                _db.Foods.AddRange(foods);
                _db.SaveChanges();
            }
        }
    }
}
