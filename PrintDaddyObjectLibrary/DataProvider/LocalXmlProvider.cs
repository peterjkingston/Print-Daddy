using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PrintDaddyObjectLibrary
{
    public class LocalXmlProvider : ILocalDataProvider
    {
        List<IDataKey> _keys;
        IResourceManager _resourceManager;

        public LocalXmlProvider(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        /// <summary>
        /// Gets DataKeys from the local XML file.
        /// </summary>
        /// <returns>List object of DataKey</returns>
        /// <exceptions>FileNotFoundException</exceptions>"
        public List<IDataKey> GetKeys()
        {
            if (/*_keys == null*/ true) //Always load local keys
            {
                _keys = LoadKeys();
            }
            return _keys;
        }

        private List<IDataKey> LoadKeys()
        {
            List<IDataKey> keysList = new List<IDataKey>();
            if (File.Exists(_resourceManager.LocalKeyPathXml))
            {
                using (Stream keyStream = new FileStream(_resourceManager.LocalKeyPathXml, 
                                                        FileMode.Open, 
                                                        FileAccess.Read, 
                                                        FileShare.ReadWrite))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(DataKey[]));

                    DataKey[] keys = (DataKey[])xs.Deserialize(keyStream);

                    keysList = new List<IDataKey>();
                    foreach (DataKey key in keys)
                    {
                        keysList.Add(key);
                    }

                    keyStream.Close();
                }
            }
            return keysList;
        }

        /// <summary>
        /// Determines if there are valid DataKeys in the local XML file.
        /// </summary>
        /// <returns>Returns true if DataKeys exist in the local XML file.</returns>
        public bool KeysExist()
        {
            _keys = LoadKeys();
            bool result = _keys.Count > 0 ? true : false;
            return result;
        }
    }
}
