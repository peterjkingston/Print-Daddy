using System;

namespace PrintDaddyObjectLibrary
{
    public interface IDataKeyWriter
    {
        IDataKey CreateDataKey(string keyID, DateTime keyTimeStamp);
    }
}