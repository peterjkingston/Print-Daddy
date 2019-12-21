using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace PrintDaddyService
{
    class LocalBinaryProvider : IDataProvider
    {
        List<DataKey> _keys;

        public List<DataKey> GetKeys()
        {
            if(_keys != null)
            {
                return _keys;
            }
            else
            {
                return LoadKeys();
            }
        }

        private List<DataKey> LoadKeys()
        {
            List<DataKey> keysList = new List<DataKey>();
            if (File.Exists(ResourceManager.LocalKeyPath))
            {
                using (Stream keyStream = new FileStream(ResourceManager.LocalKeyPathBinary, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    DataKey[] keys = (DataKey[])bf.Deserialize(keyStream);
                    
                    keysList = new List<DataKey>(keys);

                    keyStream.Close();
                }
            }
            return keysList;
        }

        public bool KeysExist()
        {
            _keys = LoadKeys();
            bool result = _keys.Count > 0 ? true : false;
            return result;
        }
    }
}
