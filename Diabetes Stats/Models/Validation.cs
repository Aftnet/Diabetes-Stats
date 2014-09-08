using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace DiabetesStats.Models
{
    public class StringNotNullValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string Input = value as string;
            if (Input == null)
            {
                return new ValidationResult(false, "Input is not a string");
            }

            if (string.IsNullOrEmpty(Input) == true || string.IsNullOrWhiteSpace(Input) == true)
            {
                return new ValidationResult(false, "Input is empty or null");
            }

            return new ValidationResult(true, null);
        }
    }

    public class SSNValidation : ValidationRule
    {
        public const string SSNRegex = @"^[A-Z]{6}[\d]{2}[A-Z][\d]{2}[A-Z][\d]{3}[A-Z]$";
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string Input = value as string;
            if (Input == null)
            {
                return new ValidationResult(false, "Input is not a string");
            }

            Input = Input.ToUpper();
            if (string.IsNullOrEmpty(Input) == true || string.IsNullOrWhiteSpace(Input) == true)
            {
                return new ValidationResult(false, "Input is empty or null");
            }

            if (Input.Length > 16)
            {
                return new ValidationResult(false, "Input is too long");
            }

            if (System.Text.RegularExpressions.Regex.Match(Input, SSNRegex).Success == false)
            {
                return new ValidationResult(false, "Input is not an SSN");
            }

            return new ValidationResult(true, null);
        }
    }
}
