using System.Collections.Generic;

namespace PrintDaddyObjectLibrary
{
    public interface IDataProvider
    {
        List<IDataKey> GetKeys();
        bool KeysExist();
    }
}