using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApp.DAL.Models;
using WebApp.Models;


namespace WebApp.DAL.Context
{
    public class CourseContext : DbContext
    {
        public DbSet<Course>? Courses { get; set; }

        public DbSet<Student>? Students { get; set; }

        public CourseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasData(
                    new Course
                    {
                        Id = 1,
                        CourseNumber = 1,
                        CourseTitle = "Svenska1",
                        CourseLength = 120,
                        CourseDescription = "Svenska språket",
                        CourseLevel = "Medel",
                        CourseStatus = "Pensionerad"
                    },
                    new Course
                    {
                        Id = 2,
                        CourseNumber = 2,
                        CourseTitle = "Svenska2",
                        CourseLength = 127,
                        CourseDescription = "Svenska språket2",
                        CourseLevel = "Medel",
                        CourseStatus = "Pensionerad"
                    },
                    new Course
                    {
                        Id = 3,
                        CourseNumber = 3,
                        CourseTitle = "Svenska3",
                        CourseLength = 130,
                        CourseDescription = "Svenska språket3",
                        CourseLevel = "Medel",
                        CourseStatus = "Pensionerad"
                    }
                );
            modelBuilder.Entity<Student>().HasData
                (
                new Student
                {
                    Id = 1,
                    Email = "Hanna@gmail.com",
                    Name = "Hanna",
                    SurName = "Isson",
                    Adress = "Lvägen 2",
                    PhoneNumber = 796854545
                });
        }
    }
}

    

