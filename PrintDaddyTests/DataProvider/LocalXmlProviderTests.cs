using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintDaddyObjectLibrary;
using System.Collections.Generic;

namespace PrintDaddyTests
{
    [TestClass()]
    public class LocalXmlProviderTests
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

        [TestMethod()]
        public void GetKeys_GetsValidKeys()
        {
            //Arrange
            bool expected = true;

            //Act
            IDataKey key = new LocalXmlProvider(new TestResourceManagerWithDataKeys()).GetKeys()[0];

            bool key_hasID = key.ID.Length > 0;
            bool key_hasTimeStamp = key.TimeStamp != System.DateTime.MinValue;
            bool actual = key_hasID && key_hasTimeStamp;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
