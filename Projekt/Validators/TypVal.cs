using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Validators
{
    public class TypVal : ValidationAttribute
    {
        public string Typ { get; set; }

        public TypVal()
        {
            Typ = null;
        }
        public TypVal( string typ)
        {
            Typ = typ;
        }
        

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage = "Podaj \"Narty\" lub \"Snowboard\"";

            if (validationContext.DisplayName == null)
                errorMessage = "Niepoprawny typ! ";
            else
                errorMessage = FormatErrorMessage(validationContext.DisplayName);

            if (value == null)
                return ValidationResult.Success;


            if (value.ToString() == "Narty" || value.ToString() == "Snowboard")
            { }
            else
                return new ValidationResult(errorMessage);

            return ValidationResult.Success;
        }
    }
}