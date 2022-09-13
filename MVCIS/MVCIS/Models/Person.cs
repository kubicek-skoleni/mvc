using System.ComponentModel.DataAnnotations;

namespace MVCIS.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Jméno")]
        public string? FirstName {get; set; }
        
        [MaxLength(10)]
        [Display(Name = "Příjmení")]

        public string? LastName {get; set; }
        
        [EmailAddress]
        public string? Email {get; set; }

        [Display(Name = "Datum narození")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
