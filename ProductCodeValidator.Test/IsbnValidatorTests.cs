using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCodeValidator;

namespace ProductCodeValidator.Test
{
    [TestClass]
    public class IsbnValidatorTests
    {
        [TestMethod]
        public void TestISBN()
        {
            //
            // Correct Format & Checksum
            // ISBN-13
            //
            const string isbn13N1 = "ISBN 978-0-672-33601-0";
            Assert.IsTrue(IsbnValidator.IsValidIsbn(isbn13N1));

            const string isbn13N2 = "ISBN-13: 978-1-4028-9462-6";
            Assert.IsTrue(IsbnValidator.IsValidIsbn(isbn13N2));

            const string isbn13N3 = "ISBN-13 978-1-4028-9462-6";
            Assert.IsTrue(IsbnValidator.IsValidIsbn(isbn13N3));

            const string isbn13N4 = "ISBN 978-1-4028-9462-6";
            Assert.IsTrue(IsbnValidator.IsValidIsbn(isbn13N4));

            const string isbn13N5 = "ISBN: 978-1-4028-9462-6";
            Assert.IsTrue(IsbnValidator.IsValidIsbn(isbn13N5));

            // ISBN-10
            const string isbn10N1 = "ISBN-10: 3-55155-167-7";
            Assert.IsTrue(IsbnValidator.IsValidIsbn(isbn10N1));

            const string isbn10N2 = "ISBN-10 3-55155-167-7";
            Assert.IsTrue(IsbnValidator.IsValidIsbn(isbn10N2));

            const string isbn10N3 = "ISBN: 3-55155-167-7";
            Assert.IsTrue(IsbnValidator.IsValidIsbn(isbn10N3));

            const string isbn10N4 = "ISBN 3-55155-167-7";
            Assert.IsTrue(IsbnValidator.IsValidIsbn(isbn10N4));

            //
            // Wrong Format, Correct Checksum
            // ISBN-13
            //
            const string isbn13N6 = "9781402894626";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13N6));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn13N6));
            Assert.IsTrue(IsbnValidator.IsValidIsbn13Checksum(isbn13N6));

            const string isbn13N7 = "978-3551551672";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13N7));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn13N7));
            Assert.IsTrue(IsbnValidator.IsValidIsbn13Checksum(isbn13N7));

            const string isbn13N8 = "9783551551672";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13N8));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn13N8));
            Assert.IsTrue(IsbnValidator.IsValidIsbn13Checksum(isbn13N8));

            const string isbn13N9 = "978-1-4028-9462-6";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13N9));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn13N9));
            Assert.IsTrue(IsbnValidator.IsValidIsbn13Checksum(isbn13N9));

            //
            // ISBN-10
            //
            const string isbn10N6 = "3-55155-167-7";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10N6));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn10N6));
            Assert.IsTrue(IsbnValidator.IsValidIsnb10Checksum(isbn10N6));

            const string isbn10N7 = "3551551677";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10N7));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn10N7));
            Assert.IsTrue(IsbnValidator.IsValidIsnb10Checksum(isbn10N7));

            const string isbn10N8 = "ISBN: 355155167-7";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10N8));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn10N8));
            Assert.IsTrue(IsbnValidator.IsValidIsnb10Checksum(isbn10N8));

            const string isbn10N9 = "ISBN3-551551677";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10N9));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn10N9));
            Assert.IsTrue(IsbnValidator.IsValidIsnb10Checksum(isbn10N9));


            //
            // Correct Format, Wrong Checksum
            // ISBN-13
            //
            const string isbn13N10 = "ISBN 978-0-672-33601-1";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13N10));
            Assert.IsTrue(IsbnValidator.IsValidIsbnFormat(isbn13N10));
            Assert.IsFalse(IsbnValidator.IsValidIsbn13Checksum(isbn13N10));

            const string isbn13N11 = "ISBN-13: 978-1-4028-9462-2";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13N11));
            Assert.IsTrue(IsbnValidator.IsValidIsbnFormat(isbn13N11));
            Assert.IsFalse(IsbnValidator.IsValidIsbn13Checksum(isbn13N11));

            const string isbn13N12 = "ISBN-13 978-1-4028-9462-3";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13N12));
            Assert.IsTrue(IsbnValidator.IsValidIsbnFormat(isbn13N12));
            Assert.IsFalse(IsbnValidator.IsValidIsbn13Checksum(isbn13N12));

            const string isbn13N13 = "ISBN 978-1-4028-9462-4";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13N13));
            Assert.IsTrue(IsbnValidator.IsValidIsbnFormat(isbn13N13));
            Assert.IsFalse(IsbnValidator.IsValidIsbn13Checksum(isbn13N13));

            const string isbn13N14 = "ISBN: 978-1-4028-9462-5";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13N14));
            Assert.IsTrue(IsbnValidator.IsValidIsbnFormat(isbn13N14));
            Assert.IsFalse(IsbnValidator.IsValidIsbn13Checksum(isbn13N14));

            //
            // ISBN-10
            //
            const string isbn10N11 = "ISBN-10: 3-55155-167-1";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10N11));
            Assert.IsTrue(IsbnValidator.IsValidIsbnFormat(isbn10N11));
            Assert.IsFalse(IsbnValidator.IsValidIsnb10Checksum(isbn10N11));

            const string isbn10N12 = "ISBN-10 3-55155-167-2";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10N12));
            Assert.IsTrue(IsbnValidator.IsValidIsbnFormat(isbn10N12));
            Assert.IsFalse(IsbnValidator.IsValidIsnb10Checksum(isbn10N12));

            const string isbn10N13 = "ISBN: 3-55155-167-3";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10N13));
            Assert.IsTrue(IsbnValidator.IsValidIsbnFormat(isbn10N13));
            Assert.IsFalse(IsbnValidator.IsValidIsnb10Checksum(isbn10N13));

            const string isbn10N14 = "ISBN 3-55155-167-4";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10N14));
            Assert.IsTrue(IsbnValidator.IsValidIsbnFormat(isbn10N14));
            Assert.IsFalse(IsbnValidator.IsValidIsnb10Checksum(isbn10N14));

            //
            // Wrong Format, Wrong Checksum
            // ISBN-13
            //
            const string isbn13False1 = "978355155167";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13False1));
            Assert.IsFalse(IsbnValidator.IsValidIsbn13Checksum(isbn13False1));

            const string isbn13False2 = "1234567890";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13False2));
            Assert.IsFalse(IsbnValidator.IsValidIsbn13Checksum(isbn13False2));

            const string isbn13False3 = "1234567890123";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn13False3));
            Assert.IsFalse(IsbnValidator.IsValidIsbn13Checksum(isbn13False3));

            //
            // ISBN-10
            //
            const string isbn10False1 = "ISBN-10: 3551551671";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10False1));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn10False1));
            Assert.IsFalse(IsbnValidator.IsValidIsnb10Checksum(isbn10False1));

            const string isbn10False2 = "3-55155-167-2";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10False2));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn10False2));
            Assert.IsFalse(IsbnValidator.IsValidIsnb10Checksum(isbn10False2));

            const string isbn10False3 = "3551551673";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10False3));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn10False3));
            Assert.IsFalse(IsbnValidator.IsValidIsnb10Checksum(isbn10False3));

            const string isbn10False4 = "355155167-1";
            Assert.IsFalse(IsbnValidator.IsValidIsbn(isbn10False4));
            Assert.IsFalse(IsbnValidator.IsValidIsbnFormat(isbn10False4));
            Assert.IsFalse(IsbnValidator.IsValidIsnb10Checksum(isbn10False4));


            // 
            // EanIsIsbn
            //
            const string ean1 = "0014633730616";
            Assert.IsFalse(IsbnValidator.EanIsIsbn(ean1));

            const string ean2 = "9783551551672";
            Assert.IsTrue(IsbnValidator.EanIsIsbn(ean2));

        }

    }
}
