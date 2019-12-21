using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyService
{
    class RemoteAPIProvider:IDataProvider, IRecordReader
    {
        public RemoteAPIProvider(ICredintialsProvider credintialsProvider)
        {
            throw new NotImplementedException();
        }

        public List<DataKey> GetKeys()
        {
            throw new NotImplementedException();
        }

        public string[] GetRecord(DataKey key)
        {
            throw new NotImplementedException();
        }

        public bool KeysExist()
        {
            throw new NotImplementedException();
        }
    }
}
