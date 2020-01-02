using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyObjectLibrary
{
    static class Factory
    {
        static IResourceManager resourceManager = new ResourceManager();

        public static ICredentialsProvider CreateCredentialsProvider()
        {
            return new CryptoCredentialProvider();
        }

        public static ILocalDataProvider CreateLocalDataProvider()
        {
            return new LocalBinaryProvider(resourceManager);
        }

        public static IRemoteDataProvider CreateRemoteDataProvider()
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
