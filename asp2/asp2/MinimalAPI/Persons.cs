using Data;
using Data.Model;

namespace MinimalAPI
{
    public class PersonActions
    {
        public static void AddPerson(PersonsDbContext db, Persons person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }
    }
}
