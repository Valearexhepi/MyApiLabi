using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Models;


namespace WebApp.Pages.Shared.Courses
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _http;

        public IndexModel(HttpClient http)
        {
            _http = http;
        }
        public IList<Course> AllCourses { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Courses { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CourseNumber{ get; set; }

        public async Task OnGetAsync()
        {

            AllCourses = await _http.GetFromJsonAsync<IList<Course>>("https://localhost:7022/api/Course") ?? new List<Course>();

            if (!string.IsNullOrEmpty(SearchString) && AllCourses!= null) 
            {
                AllCourses = AllCourses.Where(c => c.CourseNumber.ToString().Contains(SearchString)).ToList();
            }

        }
    }
}

