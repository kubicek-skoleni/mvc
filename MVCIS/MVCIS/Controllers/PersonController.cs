using Microsoft.AspNetCore.Mvc;
using MVCIS.Data;
using MVCIS.Models;

namespace MVCIS.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Zobrazeni zpravy z ViewData";
            ViewBag.OsobaJmeno = "Pavel";

            List<Person> data = PersonDataset.GetPeople();

            return View(data);
        }

        public IActionResult Detail(int id)
        {
            var person = PersonDataset.GetPeople()
                        .Where(x => x.Id == id)
                        .First();
            
            return View(person);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            PersonDataset.AddPerson(person);
            
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var person = PersonDataset.People.FirstOrDefault(x => x.Id == id);

            if(person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            var existing = PersonDataset.People.FirstOrDefault(x => x.Id == person.Id);
            
            if(existing == null)
            {
                return BadRequest();
            }

            existing.FirstName = person.FirstName;
            existing.LastName  = person.LastName;
            existing.DateOfBirth = person.DateOfBirth;

            return RedirectToAction("Detail",new {id = existing.Id});
        }
    }
}
