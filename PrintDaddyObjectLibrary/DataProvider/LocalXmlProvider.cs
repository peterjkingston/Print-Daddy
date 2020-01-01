using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PrintDaddyObjectLibrary
{
    public class LocalXmlProvider : IDataProvider
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
            if(_keys == null)
            {
                _keys = LoadKeys();
            }
            return _keys;
        }

        private List<IDataKey> LoadKeys()
        {
            List<IDataKey> keysList = new List<IDataKey>();
            if (File.Exists(_resourceManager.LocalKeyPath))
            {
                using (Stream keyStream = new FileStream(_resourceManager.LocalKeyPathBinary, 
                                                        FileMode.Open, 
                                                        FileAccess.Read, 
                                                        FileShare.ReadWrite))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(DataKey[]));
                    IDataKey[] keys = (IDataKey[])xs.Deserialize(keyStream);

                    keysList = new List<IDataKey>(keys);

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
