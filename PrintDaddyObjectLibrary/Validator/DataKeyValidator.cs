using System.Collections.Generic;

namespace PrintDaddyObjectLibrary
{
    public class DataKeyValidator : IDataKeyValidator
    {
        ILocalDataProvider _localDataProvdier;
        IRemoteDataProvider _remoteDataProvider;

        public DataKeyValidator(ILocalDataProvider localDataProvider, IRemoteDataProvider remoteDataProvider)
        {
            _localDataProvdier = localDataProvider;
            _remoteDataProvider = remoteDataProvider;
        }

        public bool NeedsToRun()
        {
            List<IDataKey> localKeys = _localDataProvdier.GetKeys();
            List<IDataKey> remoteKeys = _remoteDataProvider.GetKeys();
            bool result = false;

            foreach (IDataKey remoteKey in remoteKeys)
            {
                if (!localKeys.Contains(remoteKey))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public bool IsValidKey(IDataKey dataKey)
        {
            return !(_localDataProvdier.GetKeys().Contains(dataKey)) &&
                   (_remoteDataProvider.GetKeys().Contains(dataKey));
        }
    }
}
