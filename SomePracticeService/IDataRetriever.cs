using System.Collections.Generic;

namespace PrintDaddyService
{
    internal interface IDataRetriever
    {
        List<string> GetKeys();
    }
}