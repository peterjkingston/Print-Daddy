using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace PrintDaddyObjectLibrary
{
    public class LocalBinaryProvider : ILocalDataProvider
    {
        List<IDataKey> _keys;
        IResourceManager _resourceManager;

        public LocalBinaryProvider(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public List<IDataKey> GetKeys()
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
                    BinaryFormatter bf = new BinaryFormatter();
                    IDataKey[] keys = (IDataKey[])bf.Deserialize(keyStream);
                    
                    keysList = new List<IDataKey>(keys);

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
