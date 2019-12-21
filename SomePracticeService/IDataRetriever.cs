using System.Collections.Generic;

namespace PrintDaddyService
{
    internal interface IDataProvider
    {
        List<DataKey> GetKeys();
        bool KeysExist();
    }
}