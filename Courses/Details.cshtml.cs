using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Context;
using WebApp.DAL.Models;

namespace WebApp.Pages.Shared.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient _http;

        public DetailsModel(HttpClient http)
        {
            _http = http;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var course = await _http.GetFromJsonAsync<Course>($"https://localhost:7022/api/Course/{id}");
            if (course == null)
            {
                return NotFound();
            }
            else 
            {
                Course = course;
            }
            return Page();
        }
    }
}
