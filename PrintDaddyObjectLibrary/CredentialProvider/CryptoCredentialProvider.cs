using System.IO;
using System.Net;

namespace PrintDaddyObjectLibrary
{
    public class CryptoCredentialProvider : ICredentialsProvider
    {
        private IResourceManager _resourceManager;
        private ICryptoReader _cryptoReader;
        private ICredentialCollector _credentialCollector;

        public CryptoCredentialProvider(IResourceManager resourceManager, 
                                        ICryptoReader cryptoReader,
                                        ICredentialCollector collector)
        {
            _resourceManager = resourceManager;
            _cryptoReader = cryptoReader;
            _credentialCollector = collector;
        }

        public ICredentials GetCredentials()
        {
            ISerializableCredentials credential;

            if (File.Exists(_resourceManager.CredentialPath))
            {
                credential = CredentialsFromStream(File.Open(_resourceManager.CredentialPath, FileMode.Open));
            }
            else
            {
                credential = _credentialCollector.RequestCredentials();
            }

            return credential;
        }

        private ISerializableCredentials CredentialsFromStream(Stream credentialStream)
        {
            return _cryptoReader.StreamRead<ISerializableCredentials>(credentialStream);
        }
    }
}
