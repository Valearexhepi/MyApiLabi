using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using WebApp.DAL.Context;
using WebApp.DAL.Models;
using WebApp.Migrations;
using WebApp.Models;

namespace WebApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public CourseContext studentContext;

        public StudentController(CourseContext _courseContext)
        {
            this.studentContext = _courseContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await studentContext.Students.ToListAsync());
        }



        [HttpGet("{email}")]

        public async Task<IActionResult> GetStudentByEmail(string email)
        {
            var student = await studentContext.Students.FindAsync(email);

            if (student == null)
            {

                return NotFound();
            }
            return Ok(student);


        }


        [HttpGet("{student_email}/course")]






        //[HttpPut("{student_email}/course")]

        [HttpPost]

        public async Task<IActionResult> AddStudent(Student student)

        {

            {
                studentContext.Students.Add(student);
                await studentContext.SaveChangesAsync();
                return CreatedAtAction("GetStudent", new { email = student.Email }, student);
            }
        }



        [HttpPut]

        public async Task<IActionResult> UpdateCourseAsync(string email, Student student)

        {
            if (studentContext.Students.All(u => u.Email != email))
            {
                return BadRequest();
            }

            student.Email = email;
            studentContext.Students.Update(student);
            studentContext.SaveChangesAsync();

            return Ok(student);
        }



    }

}


