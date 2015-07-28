using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCodeValidator;

namespace ProductCodeValidatorTest
{
    [TestClass]
    public class UpcValidatorTests
    {
        [TestMethod]
        public void TestUpc()
        {
            String testUpc1 = "5051890109941";
            Assert.IsTrue(UpcValidator.IsValidUpc(testUpc1));

            String testUpc2 = "5050582788860";
            Assert.IsTrue(UpcValidator.IsValidUpc(testUpc2));

            String testUpc3 = "788687200516";
            Assert.IsTrue(UpcValidator.IsValidUpc(testUpc3));

            String testUpc4 = "0025192244094";
            Assert.IsTrue(UpcValidator.IsValidUpc(testUpc4));
        }
    }
}
