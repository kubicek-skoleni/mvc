using Data;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPages.Pages.Person
{
    public class DetailModel : PageModel
    {
        private readonly PersonsDbContext db;

        public Persons Person { get; set; }

        public DetailModel(PersonsDbContext db)
        {
            this.db = db;
        }
        public void OnGet(int id)
        {
            Person = db.Persons.Include( x => x.Contracts)
                                .Include(x => x.Address)
                                .FirstOrDefault(x => x.Id == id);
        }
    }
}
