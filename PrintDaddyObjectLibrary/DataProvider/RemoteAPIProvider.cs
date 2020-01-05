using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyObjectLibrary
{
    public class RemoteAPIProvider :IRemoteDataProvider, IRecordReader
    {
        List<IDataKey> _keys;

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

        public void ReadKeysSync()
        {
            _keys = DownloadKeys();
        }

        private List<IDataKey> DownloadKeys()
        {
            throw new NotImplementedException();
        }

        Dictionary<string, string> IRecordReader.GetRecord(IDataKey key)
        {
            throw new NotImplementedException();
        }
    }
}
