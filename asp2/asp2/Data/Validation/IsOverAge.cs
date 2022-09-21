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
        public override bool IsValid(object? value)
        {
            if (value is DateTime)
            {
                return DateTime.Now.Year - ((DateTime)value).Year >= 18;
            }

            return false;
        }
    }
}
