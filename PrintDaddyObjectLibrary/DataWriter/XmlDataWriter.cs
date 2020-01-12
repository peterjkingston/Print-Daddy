using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrintDaddyObjectLibrary
{
    public class XmlDataWriter : IDataWriter
    {
        IResourceManager _resourceManager;

        public XmlDataWriter(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }


        /// <summary>
        /// Writes IDataKeys of type T to file. If T is not a type of an IDataKey, an exception in thrown.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        public void WriteKeys<T>(List<IDataKey> keys)
        {
            if (keys.Count > 0)
            {
                XmlSerializer xs = new XmlSerializer(keys[0].GetType().MakeArrayType());
                TextWriter tw = new StreamWriter(_resourceManager.LocalKeyPathXml);

                List<T> dataKeys = new List<T>();
                foreach (T key in keys)
                {
                    dataKeys.Add(key);
                }

                T[] keyArray = dataKeys.ToArray();
                xs.Serialize(tw, keyArray);

                tw.Close();
            }
        }
    }
}
