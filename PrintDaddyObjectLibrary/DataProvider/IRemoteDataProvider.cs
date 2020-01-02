using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyObjectLibrary
{
    public interface IRemoteDataProvider : IDataProvider
    {
        void ReadKeysSync();
    }
}
