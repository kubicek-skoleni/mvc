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
    }
}
