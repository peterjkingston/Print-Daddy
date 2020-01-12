using PrintDaddyObjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyTests
{
    public class RemoteMockDataProvider : IRemoteDataProvider
    {
        public List<IDataKey> GetKeys()
        {
            List<IDataKey> keys = new List<IDataKey>();

            keys.Add(new DataKey($"ID-peter",new DateTime(2020,01,01,0,0,0)));
            keys.Add(new DataKey($"ID-Remote2", new DateTime(2020,01,01,0,0,0)));
            
            return keys;
        }

        public bool KeysExist()
        {
            return true;
        }

        public void ReadKeysSync()
        {
            throw new NotImplementedException();
        }
    }
}
