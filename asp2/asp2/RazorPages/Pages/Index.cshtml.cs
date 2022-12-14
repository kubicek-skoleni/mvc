using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PersonsDbContext db;

        public int PersonCount { get; set; }

        public IndexModel(ILogger<IndexModel> logger, PersonsDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            //return NotFound();

            //PersonCount = db.Persons.Count();

            var pathbase = HttpContext.Request.PathBase;
            var path = HttpContext.Request.Path;
            var ip = HttpContext.Connection.RemoteIpAddress;

        }
    }
}