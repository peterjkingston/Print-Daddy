using System.Collections.Generic;

namespace PrintDaddyObjectLibrary
{
    public class DataKeySelector : ISelector
    {
        IDataKeyValidator _validator;
        ILocalDataProvider _localDataProvider;
        IRemoteDataProvider _remoteDataProvider;
        List<IDataKey> _dataKeys;
        int cursor = -1;

        public DataKeySelector(IDataKeyValidator validator,
                               ILocalDataProvider localDataProvider,
                               IRemoteDataProvider remoteDataProvider)
        {
            _validator = validator;
            _localDataProvider = localDataProvider;
            _remoteDataProvider = remoteDataProvider;
        }

        public object GetCurrentItem()
        {
            return _dataKeys[cursor];
        }

        public bool Next()
        {
            bool result = false;
            
            if(cursor < _dataKeys.Count)
            {
                cursor++;
                result = cursor < _dataKeys.Count;
            }

            return result;
        }

        public void Reload()
        {
            _dataKeys = new List<IDataKey>();

            List<IDataKey> localKeys = _localDataProvider.GetKeys();
            foreach (IDataKey remoteDataKey in _remoteDataProvider.GetKeys())
            {
                if (!localKeys.Contains(remoteDataKey))
                {
                    _dataKeys.Add(remoteDataKey);
                }
            }
        }

        public void Reset()
        {
            cursor = -1;
        }
    }
}
