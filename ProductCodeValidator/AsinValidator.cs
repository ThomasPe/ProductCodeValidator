using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProductCodeValidator
{
    public static class AsinValidator
    {
        public static bool IsValidAsin(String asin)
        {
            Regex asinRegex = new Regex(@"^B\d{2}\w{7}|\d{9}(X|\d)$");
            return asinRegex.IsMatch(asin);
        }
    }
}
