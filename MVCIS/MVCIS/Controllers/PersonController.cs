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

        [HttpPost("Add")]
        public IActionResult AddPerson(Person person)
        {

            return View();
        }
    }
}
