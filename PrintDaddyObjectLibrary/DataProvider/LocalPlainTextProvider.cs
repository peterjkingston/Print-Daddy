using System;
using System.Collections.Generic;
using System.IO;

namespace PrintDaddyObjectLibrary
{
    public class LocalPlainTextProvider : ILocalDataProvider, IDataKeyWriter
    {
        List<IDataKey> _keys;
        IResourceManager _resourceManager;

        public LocalPlainTextProvider(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
            _keys = GetKeys();
        }

        /// <summary>
        /// Gets keys that have already been loaded form the local plain text file. 
        /// </summary>
        /// <returns>List of keys as strings</returns>       
        /// <exception cref="DataMisalignedException">The data does not contain the specified delimiter or is not formatted properly.</exception>
        /// <exception cref="FileNotFoundException">The specified file does not exist.</exception>
        public List<IDataKey> GetKeys()
        {
            if(/*_keys == null*/ true) //Always load local data keys
            {
                _keys = LoadKeys();
            }
            return _keys;
        }

        private List<IDataKey> LoadKeys()
        {
            if (File.Exists(_resourceManager.LocalKeyPath))
            {
                string[] udts = File.ReadAllLines(_resourceManager.LocalKeyPath);

                if (udts[0].Contains(_resourceManager.LocalKeyDelimiter.ToString()))
                {
                    List<IDataKey> keys = new List<IDataKey>();
                    foreach (string udt in udts)
                    {
                        string[] parts = udt.Split(_resourceManager.LocalKeyDelimiter);
                        string keyID = parts[0];
                        DateTime keyTimeStamp = default;
                        DateTime.TryParse(parts[1], out keyTimeStamp);
                        keys.Add(this.CreateDataKey(keyID, keyTimeStamp));
                    }

                    return keys;
                }
                else
                {
                    throw new DataMisalignedException();
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Checks the local file and determines if there is valid data.
        /// </summary>
        /// <returns>Returns true if valid data exist.</returns>
        public bool KeysExist()
        {
            _keys = LoadKeys();
            bool result = _keys.Count > 0 ? true : false;
            return result;
        }

        public IDataKey CreateDataKey(string keyID, DateTime keyTimeStamp)
        {
            return new DataKey(keyID, keyTimeStamp);
        }
    }
}
