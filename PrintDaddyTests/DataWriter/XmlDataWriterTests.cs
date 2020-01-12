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
    public class XmlDataWriterTests
    {
        [TestMethod()]
        public void WriteKeys_WritesReadableKeys()
        {
            //Arrange
            bool expected = true;

            //Act
            XmlDataWriter dataWriter = new XmlDataWriter(new TestResourceManagerWithDataKeys());
            List<IDataKey> keys = new List<IDataKey>();
            keys.Add(new DataKey($"ID-{Environment.UserName}", DateTime.Now));
            keys.Add(new DataKey($"ID-{Environment.UserName}",DateTime.UtcNow));
            dataWriter.WriteKeys<DataKey>(keys);

            LocalXmlProvider xmlProvider = new LocalXmlProvider(new TestResourceManagerWithDataKeys());
            bool actual = xmlProvider.GetKeys().Count > 0;

            //Assert
            Assert.AreEqual(expected,actual);
        }
    }
}