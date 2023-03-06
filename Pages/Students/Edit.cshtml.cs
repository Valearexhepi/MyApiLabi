using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Context;
using WebApp.DAL.Models;
using WebApp.Models;

namespace WebApp.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly WebApp.DAL.Context.CourseContext _context;

        public EditModel(WebApp.DAL.Context.CourseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int CourseId { get; set; }
        [BindProperty]
        public Student Student { get; set; } = default!;

        public List<Course> Courses {get; set;}
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses==null || _context.Students == null)
            {
                return NotFound();
            }

            Courses = await _context.Courses.ToListAsync();
            var student =  await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            
            var student = await _context.Students.FirstOrDefaultAsync(s=> s.Id==Student.Id);
            if (_context.Courses != null)
            {
                var course = await _context.Courses.FindAsync(CourseId);
                if (student!=null)
                {
                    student.Name = Student.Name;
                    student.SurName = Student.SurName;
                    student.Email = Student.Email;
                    student.Adress = Student.Adress;
                    student.PhoneNumber = Student.PhoneNumber;
                    if (course != null)
                    {
                        student.Courses = new List<Course>();
                        student.Courses.Add(course);
                    }
                    
                    await _context.SaveChangesAsync();
                }
            }
            

            return RedirectToPage("./Index");
        }

        private bool StudentExists(string id)
        {
          return _context.Students.Any(e => e.Email == id);
        }

        public async Task OnAddCourse() 
            
        {   
            if (_context.Courses != null)
            {
                var course = await _context.Courses.FindAsync(CourseId);
                if (course != null)
                {
                    Student.Courses.Add(course);
                    await _context.SaveChangesAsync();
                }
            }
           
        }
    }

}
