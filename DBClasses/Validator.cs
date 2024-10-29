using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScottWilliamsC969FinalProject.DBClasses
{
    public static class Validator
    {

        public static bool ValidateCustomer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                
                return false;
            }
            return true;
        }

        // Validates that the address lines are filled in
        public static bool ValidateAddress(string address1, string address2, string postalCode, string city, string country)
        {
            if (string.IsNullOrWhiteSpace(address1) || string.IsNullOrWhiteSpace(address2) || string.IsNullOrWhiteSpace(postalCode) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(country))
            {
                return false;
            }
            return true;
        }

        // validates that the phone number only contains digits and "-"
        public static bool ValidatePhoneNumber(string phoneNumber) 
        {
            phoneNumber = phoneNumber.Trim();
            Regex phoneRegex = new Regex(@"^[\d-]+$");
            if (!phoneRegex.IsMatch(phoneNumber))
            {
                return false;
            }
            string digitsOnly = phoneNumber.Replace("-", "");
            return digitsOnly.Length == 10;
        }
    }
}
