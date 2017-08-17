using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCodeValidator;

namespace ProductCodeValidator.Test
{
    [TestClass]
    public class EanValidatorTests
    {
        [TestMethod]
        public void TestEan()
        {
            String testEan1 = "5051890109941";
            Assert.IsTrue(EanValidator.IsValidEan(testEan1));

            String testEan2 = "5050582788860";
            Assert.IsTrue(EanValidator.IsValidEan(testEan2));

            String testEan3 = "7321921983177";
            Assert.IsTrue(EanValidator.IsValidEan(testEan3));

            String testEan4 = "0025192244094";
            Assert.IsTrue(EanValidator.IsValidEan(testEan4));



        }
    }
}
