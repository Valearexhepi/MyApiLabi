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
    public class IndexModel : PageModel
    {
        
        private readonly WebApp.DAL.Context.CourseContext _context;
        private List<Student> student;

        public IndexModel(WebApp.DAL.Context.CourseContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Students { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Email { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
            }
            {
                var students = from c in _context.Students
                              select c;
                if (!string.IsNullOrEmpty(SearchString))
                {
                    students = students.Where(s => s.Email.Contains(SearchString));
                }

                Student = await students.ToListAsync();
            }
        }
    }
}
