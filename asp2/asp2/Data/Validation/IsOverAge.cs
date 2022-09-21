using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Validation
{
    public class IsOverAge : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                if (DateTime.Now.Year - ((DateTime)value).Year >= 18)
                    return ValidationResult.Success;
            }

            return new ValidationResult("Osoba není plnoletá");
        }
    }
}
