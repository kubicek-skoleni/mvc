using MVCIS.Models;

namespace MVCIS.Data
{
    public class PersonDataset
    {
        //public static List<Person> People { get; set; } 
        //    = new List<Person>();

        internal static List<Person> GetPeople()
        {
            return new List<Person>()
            {
                new Person()
                {
                    FirstName = "Martin",
                    LastName = "Novák",
                    Email = "martin@novak.cz",
                    DateOfBirth = new DateTime(2000,2,2)
                },
                new Person()
                {
                    FirstName = "Jana",
                    LastName = "Stará",
                    Email = "jana@email.cz",
                    DateOfBirth = new DateTime(2005,8,12)
                },
            };
        }
    }
}
