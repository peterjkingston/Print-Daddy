using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PrintDaddyService
{
    class LocalXmlProvider: IDataProvider
    {
        List<DataKey> _keys;

        /// <summary>
        /// Gets DataKeys from the local XML file.
        /// </summary>
        /// <returns>List object of DataKey</returns>
        /// <exceptions>FileNotFoundException</exceptions>"
        public List<DataKey> GetKeys()
        {
            if(_keys != null)
            {
                return _keys;
            }
            else
            {
                if (File.Exists(ResourceManager.LocalKeyPathXml))
                {
                    using (Stream keyStream = new FileStream(ResourceManager.LocalKeyPathXml, FileMode.Open))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(DataKey[]));
                        DataKey[] keys = (DataKey[])xs.Deserialize(keyStream);                       
                        
                        _keys = new List<DataKey>(keys);                       

                        keyStream.Close();
                    }
                    return _keys;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
        }

        /// <summary>
        /// Determines if there are valid DataKeys in the local XML file.
        /// </summary>
        /// <returns>Returns true if DataKeys exist in the local XML file.</returns>
        public bool KeysExist()
        {
            bool result = false;
            if (File.Exists(ResourceManager.LocalKeyPathXml))
            {
                using (Stream keyStream = new FileStream(ResourceManager.LocalKeyPathXml, FileMode.Open))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(DataKey[]));
                    DataKey[] keys = (DataKey[])xs.Deserialize(keyStream);
                    result = keys.Length > 0 ? true : false;
                    if (result)
                    {
                        _keys = new List<DataKey>(keys);
                    }

                    keyStream.Close();
                }
            }
            return result;
        }
    }
}
