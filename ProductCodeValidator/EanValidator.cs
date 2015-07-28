using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCodeValidator
{
    public static class EanValidator
    {
        public static bool IsValidEan(String ean)
        {
            return IsValidEanFormat(ean) && IsValidEanChecksum(ean);
        }

        public static bool IsValidEanFormat(String ean)
        {
            if (ean.Length == 13)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool IsValidEanChecksum(String ean)
        {
            try
            {
                return ValidatorHelpers.IsStandardChecksumValid(ean);
            }
            catch
            {
                return false;
            }

        }
    }
}
