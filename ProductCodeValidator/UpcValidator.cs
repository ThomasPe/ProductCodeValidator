using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCodeValidator
{
    public static class UpcValidator
    {
        public static bool IsValidUpc(string upc)
        {
            try 
            {
                return ValidatorHelpers.IsValidGtin(upc);
            }
            catch
            { 
                return false;
            }
        }
    }
}
