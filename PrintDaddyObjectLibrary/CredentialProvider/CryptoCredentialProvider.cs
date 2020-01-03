using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            ICredentials credential;

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

        private ICredentials CredentialsFromStream(Stream credentialStream)
        {
            return _cryptoReader.StreamRead<ICredentials>(credentialStream);
        }
    }
}
