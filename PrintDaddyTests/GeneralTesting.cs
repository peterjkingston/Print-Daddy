using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrintDaddyTests
{
    [TestClass()]
    public class GeneralTesting
    {
        [TestMethod()]
        public void AlwaysPasses()
        {
            //Assert
            bool expected = true;

            //Act
            bool actual = true;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AlwaysFails()
        {
            Assert.Fail("");
        }
    }
}
