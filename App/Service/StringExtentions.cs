using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service
{
    public class StringExtentions
    {
        public static bool IsValidFullName(string fullName)
        {
            return !string.IsNullOrWhiteSpace(fullName) && Regex.IsMatch(fullName, "^[a-zA-Z ]+$");
        }

        public static bool IsValidEmail(string email)
        { 
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
    }
}
