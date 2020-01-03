using System.Collections.Generic;

namespace PrintDaddyObjectLibrary
{
    public interface IRecordReader
    {
        Dictionary<string, string> GetRecord(IDataKey key);
    }
}