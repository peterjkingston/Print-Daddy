using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyService
{
    static class Factory
    {
        public static ICredentialsProvider CreateCredentialsProvider()
        {
            return new CryptoCredentialProvider();
        }

        public static IDataProvider CreateLocalDataProvider()
        {
            return new LocalBinaryProvider();
        }

        public static IDataProvider CreateRemoteDataProvider()
        {
            return new RemoteAPIProvider(CreateCredentialsProvider());
        }

        public static IPrintManager CreatePrintManager()
        {
            return new DefaultPrintManager();
        }

        public static IRecordReader CreateRecordReader()
        {
            return new RemoteAPIRecordReader();
        }

        public static IDataKey CreateDataKey(string id, DateTime timeStamp)
        {
            return new DataKey(id, timeStamp);
        }
    }
}
