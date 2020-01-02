using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyObjectLibrary
{
    class DataKeySelector : ISelector
    {
        IDataKeyValidator _validator;
        ILocalDataProvider _localDataProvider;
        IRemoteDataProvider _remoteDataProvider;
        List<IDataKey> dataKeys;
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
            return dataKeys[cursor];
        }

        public bool Next()
        {
            bool result = false;
            
            if(cursor < dataKeys.Count)
            {
                cursor++;
                result = cursor < dataKeys.Count;
            }

            return result;
        }

        public void Reset()
        {
            cursor = -1;
        }
    }
}
