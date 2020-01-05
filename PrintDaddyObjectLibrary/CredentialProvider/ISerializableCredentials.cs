using System.Net;
using System.Runtime.Serialization;

namespace PrintDaddyObjectLibrary
{
    public interface ISerializableCredentials : ICredentials, ISerializable
    {

    }
}