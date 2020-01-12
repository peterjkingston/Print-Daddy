using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintDaddyObjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyTests
{
    [TestClass()]
    public class DataKeyValidatorTests
    {
        [TestMethod()]
        public void NeedsToRun_ReturnsTrue_WhenNewRemoteKeysArePresent()
        {
            //Arrange
            bool expected = true;
            ILocalDataProvider local = new LocalXmlProvider(new TestResourceManagerWithDataKeys());
            IRemoteDataProvider remote = new RemoteMockDataProvider();
            DataKeyValidator validator = new DataKeyValidator(local, remote);

            //Act
            bool actual = validator.NeedsToRun();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidKey_ReturnsTrue_WhenKeyExistsRemoteAndNotLocal()
        {
            //Arrange
            bool expected = true;
            ILocalDataProvider local = new LocalXmlProvider(new TestResourceManagerWithDataKeys());
            IRemoteDataProvider remote = new RemoteMockDataProvider();
            DataKeyValidator validator = new DataKeyValidator(local, remote);
            IDataKey keyBoth = remote.GetKeys()[0];
            IDataKey keyRemote = remote.GetKeys()[1];


            //Act
            bool actual = !validator.IsValidKey(keyBoth) &&
                          validator.IsValidKey(keyRemote);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}