using Data;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonsDbContext db;

        public PersonController(PersonsDbContext db)
        {
            this.db = db;
        }

        [HttpGet("list")]
        public ActionResult<IEnumerable<Persons>> List()
        {
            return db.Persons.Take(100).ToList();
        }

        [HttpPost("add")]
        public ActionResult<Persons> Add (Persons person)
        {
            db.Persons.Add(person);
            db.SaveChanges();

            return Created($"/person/detail/{person.Id}", person);
        }
    }
}
