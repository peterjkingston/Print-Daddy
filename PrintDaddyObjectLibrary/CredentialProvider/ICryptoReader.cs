using System.IO;

namespace PrintDaddyObjectLibrary
{
    public interface ICryptoReader
    {
        T StreamRead<T>(Stream credentialStream);
    }
}