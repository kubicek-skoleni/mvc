using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCIS.Data;
using MVCIS.Models;
using MVCIS.Services;

namespace MVCIS.Controllers
{
    //routovani
    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-6.0
    // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-6.0

    [Route("[Controller]")]
    [Authorize]
    public class PersonController : Controller
    {
        private readonly SimpleLogger _logger;
        private readonly ApplicationDbContext _db;
        public PersonController(SimpleLogger log, ApplicationDbContext db)
        {
            _logger = log;
            _db = db;
        }

        [Route("[Action]")]
        [Route("")]
        public IActionResult Index(int? page)
        {
            page ??= 1;
            page = Math.Max(page.Value, 1);
            int from = (page.Value - 1) * 100;
            int cnt = _db.Persons.Count();
            int maxpage = (int)Math.Ceiling((double)(cnt / 100.0));

            List<Person> data = _db.Persons.Skip(from).Take(100).ToList();

            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            ViewBag.ShowNext = page < maxpage;
            return View(data);
        }

        [Route("Detail/{id}")]
        [AllowAnonymous]
        public IActionResult Detail(int id)
        {
            var person = _db.Persons
                    .Include(x => x.Constracts)
                    .Include(x => x.Address)
                        .Where(x => x.Id == id)
                        .First();
            return View(person);
        }

        

        [Route("[Action]/first/{firstname}/last/{lastname}")]
        public IActionResult Detail(string? firstname, string? lastname)
        {
            var person = _db.Persons
                        .Where(x => x.FirstName == firstname &&
                                    x.LastName == lastname)
                        .First();
            return View(person);
        }

        [Route("[Action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddPerson(Person person)
        {
            if (User.Identity.IsAuthenticated)
            {
                var login = User.Identity.Name;
                _logger.Log($"uživatel {login} přidává Person{person.Email}");
            }


            if (person == null)
                return BadRequest();

            if (!IsAgeValid(person))
            {
                ViewBag.ErrorMsg = "Osoba musí být plnoletá.";
                return View("Add", person);
            }

            _db.Persons.Add(person);
            _db.SaveChanges();
                        
            return RedirectToAction("Detail",new {id = person.Id});
        }

        [Route("[Action]/{id}")]
        public IActionResult Edit(int id)
        {
           var person = _db.Persons.FirstOrDefault(x => x.Id == id);

            if(person == null)
            {
                _logger.Log($"nenalezena osoba s id{id}");
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult EditPerson(Person person)
        {
            // disconnected entities - prijdou pres sit
            //https://docs.microsoft.com/en-us/ef/core/saving/disconnected-entities

            if (!ModelState.IsValid)
                return View("Edit", person);

            if(!IsAgeValid(person))
            {
                ViewBag.ErrorMsg = "Osoba musí být plnoletá.";
                return View("Edit", person);
            }
            
            // 1. vytahnu z dbContextu a priradim hodnoty z prichozi
            var existing = _db.Persons.FirstOrDefault(x => x.Id == person.Id);

            if (existing == null)
                return BadRequest();

            existing.FirstName = person.FirstName;
            existing.LastName = person.LastName;
            existing.DateOfBirth = person.DateOfBirth;
            existing.Email = person.Email;

            // 2. NEBO predam celou prichozi instanci (odpojenou, napojim)
            //_db.Attach(person);
            //_db.Entry(person).State = EntityState.Modified;
            //_db.Entry(person).Property(p => p.Name).IsModified = true;

            // 3. NEBO aktualizovat vsechny pomoci metody setValues
            //_db.Entry<Person>(existing).CurrentValues.SetValues(person);

            // ULOZ do db
            _db.SaveChanges();

            return RedirectToAction("Detail", new { id = person.Id });
        }

        private bool IsAgeValid(Person person)
        {
            return person.Age > 18;
        }

        [Route("search")]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost("[Action]")]
        public IActionResult SearchResult(string email)
        {
            ViewBag.Search = email;

            var result = _db.Persons.Where(x => x.Email.ToLower().Contains(email.ToLower())).ToList();

            return View(result);
        }

    }
}
