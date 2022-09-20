using Data;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return db.Persons.AsNoTracking().Take(100).ToList();
        }

        [HttpPost("add")]
        public ActionResult<Persons> Add (Persons person)
        {
            db.Persons.Add(person);
            db.SaveChanges();

            return Created($"/person/detail/{person.Id}", person);
        }

        [HttpGet("detail/{id:int}")]
        public ActionResult<Persons> Detail(int id)
        {
            return db.Persons.Include(x => x.Address).Include(x => x.Contracts)
                .FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("updatecity/sync/{amount}/{from}/{city}")]
        public ActionResult<IEnumerable<Persons>> GetListSync(int amount, int from, string city)
        {
            var persons = db.Persons.Include(x => x.Address)
                                    .Skip(from)
                                    .Take(amount).ToList();

            foreach(var person in persons)
            {
                if (person.Address != null)
                    person.Address.City = city;
            }

            db.SaveChanges();

            return Ok(persons);
        }

        [HttpGet("update/async/{amount}/{from}/{city}")]
        public async Task<ActionResult<IEnumerable<Persons>>> GetListAsync(int amount, int from, string city)
        {
            var persons = db.Persons.Include(x =>x.Address)
                            .Skip(from)
                            .Take(amount)
                            .ToList();

            foreach (var person in persons)
            {
                if (person.Address != null)
                    person.Address.City = city;
            }

            await db.SaveChangesAsync();

            return Ok(persons);
        }

    }
}
