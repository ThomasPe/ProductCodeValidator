using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProductCodeValidator
{
    public static class IsbnValidator
    {

        public static bool IsValidIsbn(String isbn)
        {
            return IsValidIsbnFormat(isbn)  && (IsValidIsnb10Checksum(isbn) || IsValidIsbn13Checksum(isbn));
        }


        public static bool IsValidIsbnFormat(String isbn)
        {
            var isbnRegex = new Regex(@"ISBN(-1(?:(0)|3))?:?\x20+(?(1)(?(2)(?:(?=.{13}$)\d{1,5}([ -])\d{1,7}\3\d{1,6}\3(?:\d|x)$)|(?:(?=.{17}$)97(?:8|9)([ -])\d{1,5}\4\d{1,7}\4\d{1,6}\4\d$))|(?(.{13}$)(?:\d{1,5}([ -])\d{1,7}\5\d{1,6}\5(?:\d|x)$)|(?:(?=.{17}$)97(?:8|9)([ -])\d{1,5}\6\d{1,7}\6\d{1,6}\6\d$)))");
            return isbnRegex.IsMatch(isbn);
        }


        public static bool IsValidIsnb10Checksum(String isbn)
        {
            if (isbn == null)
            {
                return false;
            }

            // Remove leading 'ISBN' String
            isbn = RemoveIsbn10(isbn);

            // Check, if ISBN is digits only and of length 10
            if (!ValidatorHelpers.IsDigitsOnly(isbn) || isbn.Length != 10)
            {
                return false;
            }

            // Calculate checksum
            int sum = 0;
            for (int i = 0; i < 9; i++)
            { 
                sum += (i + 1) * int.Parse(isbn[i].ToString()); 
            }

            int remainder = sum % 11;
            if (remainder == 10)
            {
                return isbn[9] == 'X';
            }
            else
            {
                return isbn[9] == (char)('0' + remainder);
            }

        }

        public static bool IsValidIsbn13Checksum(String isbn)
        {
            isbn = RemoveIsbn13(isbn);
            if (!ValidatorHelpers.IsDigitsOnly(isbn) || isbn.Length != 13)
            {
                return false;
            }


            var weight = 1;
            var sum = 0;
            for (int i = 0; i < isbn.Length -1; i++)
            {
                sum += int.Parse(isbn[i].ToString()) * weight;
                weight = (weight + 2) % 4;
            }
            var remainder = (10 - (sum % 10)) % 10;

            return isbn[isbn.Length - 1] == (char)('0' + remainder);

        }

        private static String RemoveIsbn13(String isbn)
        {
            var removeIsbn = new Regex(@"ISBN(?:-13)?:?\x20*");
            isbn = removeIsbn.Replace(isbn, "");
            return isbn.Replace("-", "").Replace(" ", "");
        }

        private static String RemoveIsbn10(String isbn)
        {
            var removeIsbn = new Regex(@"ISBN(?:-10)?:?\x20*");
            isbn = removeIsbn.Replace(isbn, "");
            return isbn.Replace("-", "").Replace(" ", "");
        }

        public static bool EanIsIsbn(String ean)
        {
            var isbnRegex = new Regex(@"^(97(8|9))?\d{9}(\d|X)$");
            return isbnRegex.IsMatch(ean);
        }

    }
}
