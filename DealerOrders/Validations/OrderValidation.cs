using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DealerOrders.Validations
{
    public class OrderValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty((string)value)) // checking for Empty Value
            {
                return new ValidationResult("Please provide vehicle!");
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("Vehicle should not contain @");
                }
            }
            return ValidationResult.Success;
        }
    }
}