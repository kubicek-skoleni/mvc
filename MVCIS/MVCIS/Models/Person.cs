using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCIS.Models
{
    public class Person
    { 
        public int Id { get; set; }

        [Display(Name = "Jméno")]
        [MaxLength(100)]
        public string FirstName {get; set; }
        
        
        [Display(Name = "Příjmení")]
        [MaxLength(100)]
        public string LastName {get; set; }
        
        [EmailAddress]
        public string Email {get; set; }

        [Display(Name = "Datum narození")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                //zjednoduseny vypocet
                return DateTime.Today.Year - DateOfBirth.Year;
            }
        }

        public Address? Address { get; set; }

        // doporucene u koleci (navigacni property)
        public ICollection<Contract> Constracts { get; set; } = new HashSet<Contract>();
    }
}
