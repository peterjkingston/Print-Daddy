using System.Net;

namespace PrintDaddyObjectLibrary
{
    public interface ICredentialsProvider
    {
        ICredentials GetCredentials();
    }
}