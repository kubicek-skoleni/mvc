using Microsoft.AspNetCore.Mvc;
using MVCIS.Data;
using MVCIS.Models;

namespace MVCIS.Controllers
{
    //routovani
    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-6.0
    // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-6.0
    [Route("[Controller]")]
    public class PersonController : Controller
    {
        [Route("[Action]")]
        [Route("/osoby/list")]
        [Route("")]
        
        public IActionResult Index()
        {
            ViewData["Message"] = "Zobrazeni zpravy z ViewData";
            ViewBag.OsobaJmeno = "Pavel";

            List<Person> data = PersonDataset.GetPeople();

            return View(data);
        }

        //[Route("Detail/{id?}")]
        //public IActionResult Detail(int id)
        //{
        //    var person = PersonDataset.GetPeople()
        //                .Where(x => x.Id == id)
        //                .First();
            
        //    return View(person);
        //}

        [Route("Detail")]
        public IActionResult Detail(int? id, string? firstname, string? lastname)
        {

            var person = PersonDataset.GetPeople()
                        .Where(x => x.FirstName == firstname && 
                                    x.LastName == lastname)
                        .First();

            return View(person);
        }

        [Route("[Action]/first/{firstname}/last/{lastname}")]
        public IActionResult Detail(string? firstname, string? lastname)
        {

            var person = PersonDataset.GetPeople()
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
            PersonDataset.AddPerson(person);
            
            return RedirectToAction("Index");
        }

        [Route("[Action]")]
        public IActionResult Edit(int id)
        {
           
            var person = PersonDataset.People.FirstOrDefault(x => x.Id == id);

            if(person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        //[HttpPost]
        //public IActionResult EditPerson(IFormCollection data)
        //{
        //    var firstname = data["FirstName"];
        //    var id = data["id"];

        //    return RedirectToAction("Detail", new { id = id });
        //}


        [HttpPost]
        [Route("[Action]")]
        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", person);
            }
            var existing = PersonDataset.People.FirstOrDefault(x => x.Id == person.Id);

            if (existing == null)
            {
                return BadRequest();
            }

            existing.FirstName = person.FirstName;
            existing.LastName = person.LastName;
            existing.DateOfBirth = person.DateOfBirth;
            existing.Email = person.Email;

            return RedirectToAction("Detail", new { id = existing.Id });
        }
    }
}
