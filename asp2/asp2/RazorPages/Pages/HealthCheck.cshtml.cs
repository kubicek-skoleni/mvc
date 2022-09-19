using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace RazorPages.Pages
{
    public class HealthCheckModel : PageModel
    {
        private readonly PersonsDbContext db;

        public string Result { get; set; }

        public HealthCheckModel(PersonsDbContext db)
        {
            this.db = db;
        }
        public void OnGet()
        {
                Stopwatch s = new Stopwatch();
                s.Start();
                var persons = db.Persons.ToList();
                s.Stop();

                Result = s.ElapsedMilliseconds switch
                {
                    < 100 => "healthy",
                    >= 100 => "degraded",
                };
            
        }
    }
}
