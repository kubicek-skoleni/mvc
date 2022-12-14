// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Validation;
using Microsoft.EntityFrameworkCore;

namespace Data.Model
{
    [Index("AddressId", Name = "IX_Persons_AddressId")]
    [Index("Email", Name = "IX_Persons_Email")]
    public partial class Persons
    {
        public Persons()
        {
            Contracts = new HashSet<Contracts>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Jméno je vyžadováno")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Příjmení je vyžadováno")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [IsOverAge]
        public DateTime DateOfBirth { get; set; }
        public int? AddressId { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("Persons")]
        public virtual Addresses? Address { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<Contracts> Contracts { get; set; }

        public int Age()
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }
    }
}