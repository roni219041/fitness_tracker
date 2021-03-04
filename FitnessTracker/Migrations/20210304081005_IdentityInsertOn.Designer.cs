﻿// <auto-generated />
using System;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitnessTracker.Migrations
{
    [DbContext(typeof(FitnessTrackerContext))]
    [Migration("20210304081005_IdentityInsertOn")]
    partial class IdentityInsertOn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitnessTracker.Models.BodyPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("BodyPart");
                });

            modelBuilder.Entity("FitnessTracker.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FitnessTracker.Models.Excercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BodypartId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BodypartId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Excercises");
                });

            modelBuilder.Entity("FitnessTracker.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("Carbohydrates")
                        .HasColumnType("int");

                    b.Property<int>("Fat")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Protein")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FitnessTracker.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FitnessTracker.Models.Excercise", b =>
                {
                    b.HasOne("FitnessTracker.Models.BodyPart", "Bodypart")
                        .WithMany("Excercises")
                        .HasForeignKey("BodypartId")
                        .HasConstraintName("FK__Excercise__Bodyp__2E1BDC42");

                    b.HasOne("FitnessTracker.Models.Category", "Category")
                        .WithMany("Excercises")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Excercise__Categ__2F10007B");

                    b.HasOne("FitnessTracker.Models.User", "User")
                        .WithMany("Excercises")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Excercise__UserI__2D27B809");

                    b.Navigation("Bodypart");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessTracker.Models.Food", b =>
                {
                    b.HasOne("FitnessTracker.Models.User", "User")
                        .WithMany("Foods")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Foods__UserId__267ABA7A");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessTracker.Models.BodyPart", b =>
                {
                    b.Navigation("Excercises");
                });

            modelBuilder.Entity("FitnessTracker.Models.Category", b =>
                {
                    b.Navigation("Excercises");
                });

            modelBuilder.Entity("FitnessTracker.Models.User", b =>
                {
                    b.Navigation("Excercises");

                    b.Navigation("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}
