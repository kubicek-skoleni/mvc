using Microsoft.AspNetCore.Mvc;
using MVCIS.Data;
using MVCIS.Models;
using System.Diagnostics;

namespace MVCIS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //return Content("hello");
            return View();
        }

        public IActionResult Seed()
        {
            return Content("jiz bylo naseedovano");

            //var data = JsonData.LoadData(@"C:\skoleni\data.json");

            //db.Persons.AddRange(data);
            //db.SaveChanges();

            //return Content("ok");
        }

        public IActionResult Ex()
        {
            throw new Exception("závažná chyba");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}