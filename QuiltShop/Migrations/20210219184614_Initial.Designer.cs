﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuiltShop.Models;

namespace QuiltShop.Migrations
{
    [DbContext(typeof(QuiltShopContext))]
    [Migration("20210219184614_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuiltShop.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameFirst");

                    b.Property<string>("NameLast");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("QuiltShop.Models.InstructorProject", b =>
                {
                    b.Property<int>("InstructorProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InstructorId");

                    b.Property<int>("ProjectId");

                    b.HasKey("InstructorProjectId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("ProjectId");

                    b.ToTable("InstructorProject");
                });

            modelBuilder.Entity("QuiltShop.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("QuiltShop.Models.ProjectStudent", b =>
                {
                    b.Property<int>("ProjectStudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId");

                    b.Property<int>("StudentId");

                    b.HasKey("ProjectStudentId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("ProjectStudent");
                });

            modelBuilder.Entity("QuiltShop.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameFirst");

                    b.Property<string>("NameLast");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("QuiltShop.Models.InstructorProject", b =>
                {
                    b.HasOne("QuiltShop.Models.Instructor", "Instructor")
                        .WithMany("Projects")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuiltShop.Models.Project", "Project")
                        .WithMany("Instructors")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuiltShop.Models.ProjectStudent", b =>
                {
                    b.HasOne("QuiltShop.Models.Project", "Project")
                        .WithMany("Students")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuiltShop.Models.Student", "Student")
                        .WithMany("Projects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
