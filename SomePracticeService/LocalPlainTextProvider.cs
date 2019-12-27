using System;
using System.Collections.Generic;
using System.IO;

namespace PrintDaddyService
{
    class LocalPlainTextProvider : IDataProvider
    {
        List<DataKey> _keys;

        /// <summary>
        /// Gets keys that have already been loaded form the local plain text file. 
        /// </summary>
        /// <returns>List of keys as strings</returns>       
        /// <exception cref="DataMisalignedException">The data does not contain the specified delimiter or is not formatted properly.</exception>
        /// <exception cref="FileNotFoundException">The specified file does not exist.</exception>
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
            if (File.Exists(ResourceManager.LocalKeyPath))
            {
                string[] udts = File.ReadAllLines(ResourceManager.LocalKeyPath);

                if (udts[0].Contains(ResourceManager.LocalKeyDelimiter.ToString()))
                {
                    List<DataKey> keys = new List<DataKey>();
                    foreach (string udt in udts)
                    {
                        string[] parts = udt.Split(ResourceManager.LocalKeyDelimiter);
                        string keyID = parts[0];
                        DateTime keyTimeStamp = default;
                        DateTime.TryParse(parts[1], out keyTimeStamp);
                        keys.Add(new DataKey(keyID, keyTimeStamp));
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
    }
}
