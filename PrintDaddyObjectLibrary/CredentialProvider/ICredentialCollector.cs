using System.Net;

namespace PrintDaddyObjectLibrary
{
    public interface ICredentialCollector
    {
        ISerializableCredentials RequestCredentials();
    }
}