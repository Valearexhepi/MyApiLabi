using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public int CourseLength { get; set; }
        public string CourseLevel { get; set; }
        public string CourseStatus { get; set; }
       public List<Student> Students { get; set; }

    }
}
