using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintDaddyObjectLibrary;
using System.Collections.Generic;

namespace PrintDaddyTests
{
    [TestClass()]
    public class LocalXmlProvderTests
    {
        [TestMethod()]
        public void KeysExist_ReturnsTrue_WhenKeysExist()
        {
            //Arrange
            bool expected = true;

            //Act
            bool actual = new LocalXmlProvider(new TestResourceManagerWithDataKeys()).KeysExist();
             
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void KeysExist_ReturnsFalse_WhenKeysDontExist()
        {
            //Arrange
            bool expected = false;

            //Act
            new XmlDataWriter(new TestResourceManagerWithoutDataKeys()).WriteKeys<DataKey>(new List<IDataKey>());
            bool actual = new LocalXmlProvider(new TestResourceManagerWithoutDataKeys()).KeysExist();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void KeysExist_ReturnsFalse_WhenNoFileExists()
        {
            //Arrange
            bool expected = false;

            //Act
            bool actual = new LocalXmlProvider(new DeadEndResourceManager()).KeysExist();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
