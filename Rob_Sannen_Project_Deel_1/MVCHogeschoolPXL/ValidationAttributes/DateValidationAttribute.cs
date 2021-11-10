using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.ValidationAttributes
{
    public class DateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime)value < Convert.ToDateTime("1/1/1980") 
                || (DateTime)value > Convert.ToDateTime($"10/1/{DateTime.Now.Year}"))
            {
                return new ValidationResult(ErrorMessage ?? "Wrong date!");
            }
            return ValidationResult.Success;
        }
    }
}
