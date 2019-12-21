﻿using System;
using System.Collections.Generic;
using System.IO;

namespace PrintDaddyService
{
    class LocalPlainTextProvider : IDataProvider
    {
        /// <summary>
        /// Gets keys that have already been loaded form the local file.
        /// </summary>
        /// <returns>List of keys as strings</returns>
        /// <exceptions>DataMisalignedException, FileNotFoundException</exceptions>
        public List<DataKey> GetKeys()
        {
            if (File.Exists(ResourceManager.LocalKeyPath))
            {
                string[] udts = File.ReadAllLines(ResourceManager.LocalKeyPath);

                if (udts[0].Contains(ResourceManager.LocalKeyDelimiter.ToString()))
                {
                    List<DataKey> keys = new List<DataKey>();
                    foreach(string udt in udts)
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
            return (File.Exists(ResourceManager.LocalKeyPath) && 
                File.ReadAllText(ResourceManager.LocalKeyPath).Contains(ResourceManager.LocalKeyDelimiter.ToString()));
        }
    }
}