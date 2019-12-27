using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyService
{
    class RemoteAPIProvider:IDataProvider, IRecordReader
    {
        public RemoteAPIProvider(ICredentialsProvider credintialsProvider)
        {
            throw new NotImplementedException();
        }

        public List<IDataKey> GetKeys()
        {
            throw new NotImplementedException();
        }

        public string[] GetRecord(IDataKey key)
        {
            throw new NotImplementedException();
        }

        public bool KeysExist()
        {
            throw new NotImplementedException();
        }
    }
}
