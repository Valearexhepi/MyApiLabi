using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Models;
using WebApp.DAL.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public readonly CourseContext _context;

        public CourseController(CourseContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            return Ok(await _context.Courses.ToListAsync());
        }

        [HttpGet("{courseNumber:int}")]
        public async Task<IActionResult> GetCourse(int courseNumber)
        {
            var course = await _context.Courses.FindAsync(courseNumber);

            if (course == null)
            {

                return BadRequest();
            }
            return Ok(course);

        }



        [HttpPost]

        public async Task<IActionResult> AddCourse(Course course)
        {
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCourse", new { courseNumber = course.CourseNumber }, course);
            }

            return Ok(course);
        }


        [HttpPost("editCourse")]
        //kursen kommer aldrig in här
        public async Task<IActionResult> UpdateCourseAsync(Course course)
        {
            var dbCourse = await _context.Courses.FindAsync(course.Id);
            if (dbCourse== null)
            {
                return BadRequest();
            }

            dbCourse.CourseNumber = course.CourseNumber;
            dbCourse.CourseLevel = course.CourseLevel;
            dbCourse.CourseTitle = course.CourseTitle;
            dbCourse.CourseDescription = course.CourseDescription;
            dbCourse.CourseStatus = course.CourseStatus;
            dbCourse.CourseLength = course.CourseLength;
                
            await _context.SaveChangesAsync();

            return Ok(course);
        }


        [HttpDelete("{coursenumber:int}")]
        public async Task<IActionResult> DeleteCourse(int coursenumber)
        {
            var course = await _context.Courses.FindAsync(coursenumber);
            if (course != null)
            {
                _context.Remove(course);
                await _context.SaveChangesAsync();
                return Ok(course);
            }

            return NotFound();
        }

    }
}

