using WebApp.DAL.Models;

namespace WebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int PhoneNumber { get; set; }
        public string Adress { get; set; }
        public List<Course> Courses { get; set; }
    }
}
