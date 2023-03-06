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

namespace WebApp.Pages.Shared.Courses
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _http;

        public EditModel(HttpClient http)
        {
            _http = http;
        }
       

        [BindProperty]
        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var course = await _http.GetFromJsonAsync<Course>($"https://localhost:7022/api/Course/{id}");
            if (course == null)
            {
                return NotFound();
            }
            Course = course;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _http.PostAsJsonAsync<Course>("https://localhost:7022/api/Course/editCourse", Course);
            if (response.IsSuccessStatusCode)
            {

            }
            return RedirectToPage("./Index");
        }
    }
}
