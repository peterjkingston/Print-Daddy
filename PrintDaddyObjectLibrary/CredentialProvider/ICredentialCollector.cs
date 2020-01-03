using System.Net;

namespace PrintDaddyObjectLibrary
{
    public interface ICredentialCollector
    {
        ICredentials RequestCredentials();
    }
}