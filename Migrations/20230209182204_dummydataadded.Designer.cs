﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.DAL.Context;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(CourseContext))]
    [Migration("20230209182204_dummydataadded")]
    partial class dummydataadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("WebApp.DAL.Models.AllCourses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseLength")
                        .HasColumnType("int");

                    b.Property<string>("CourseLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseNumber")
                        .HasColumnType("int");

                    b.Property<string>("CourseStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseDescription = "Svenska språket",
                            CourseLength = 120,
                            CourseLevel = "Medel",
                            CourseNumber = 1,
                            CourseStatus = "Pensionerad",
                            CourseTitle = "Svenska1"
                        },
                        new
                        {
                            Id = 2,
                            CourseDescription = "Svenska språket2",
                            CourseLength = 127,
                            CourseLevel = "Medel",
                            CourseNumber = 2,
                            CourseStatus = "Pensionerad",
                            CourseTitle = "Svenska2"
                        },
                        new
                        {
                            Id = 3,
                            CourseDescription = "Svenska språket3",
                            CourseLength = 130,
                            CourseLevel = "Medel",
                            CourseNumber = 3,
                            CourseStatus = "Pensionerad",
                            CourseTitle = "Svenska3"
                        });
                });

            modelBuilder.Entity("WebApp.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Lvägen 2",
                            Email = "Hanna@gmail.com",
                            Name = "Hanna",
                            PhoneNumber = 796854545,
                            SurName = "Isson"
                        });
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("WebApp.DAL.Models.AllCourses", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
