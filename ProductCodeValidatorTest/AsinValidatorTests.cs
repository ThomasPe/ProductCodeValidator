using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCodeValidator;

namespace ProductCodeValidatorTest
{
    [TestClass]
    public class AsinValidatorTests
    {
        [TestMethod]
        public void TestAsin()
        {
            String asinTrue1 = "B00801ZR2C"; // amazon.de
            String asinTrue2 = "0385537859"; // amazon.com
            String asinTrue3 = "B003Q6D2B4"; // amazon.com

            String asinFalse1 = "test";

            Assert.IsTrue(AsinValidator.IsValidAsin(asinTrue1));
            Assert.IsTrue(AsinValidator.IsValidAsin(asinTrue2));
            Assert.IsTrue(AsinValidator.IsValidAsin(asinTrue3));

            Assert.IsFalse(AsinValidator.IsValidAsin(asinFalse1));
        }
    }
}
