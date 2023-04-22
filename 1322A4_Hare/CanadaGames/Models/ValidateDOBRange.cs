using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Models
{
    public class ValidateDOBRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // your validation logic
            var date = (DateTime)value;
            if (date >= Convert.ToDateTime("1992-08-22") && date <= Convert.ToDateTime("2010-08-06"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Age out of range.  DOB must be between 1992-08-22 and 2010-08-06.");
            }
        }
    }
}
