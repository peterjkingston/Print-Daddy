using System.Collections.Generic;

namespace PrintDaddyService
{
    internal interface IDataProvider
    {
        List<IDataKey> GetKeys();
        bool KeysExist();
    }
}