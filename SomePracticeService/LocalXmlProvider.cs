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
            if(_keys == null)
            {
                _keys = LoadKeys();
            }
            return _keys;
        }

        private List<DataKey> LoadKeys()
        {
            List<DataKey> keysList = new List<DataKey>();
            if (File.Exists(ResourceManager.LocalKeyPath))
            {
                using (Stream keyStream = new FileStream(ResourceManager.LocalKeyPathBinary, 
                                                        FileMode.Open, 
                                                        FileAccess.Read, 
                                                        FileShare.ReadWrite))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(DataKey[]));
                    DataKey[] keys = (DataKey[])xs.Deserialize(keyStream);

                    keysList = new List<DataKey>(keys);

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
