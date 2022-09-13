using System.ComponentModel.DataAnnotations;

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
    }
}
