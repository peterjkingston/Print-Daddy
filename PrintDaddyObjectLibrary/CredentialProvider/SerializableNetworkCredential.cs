using System;
using System.Net;
using System.Runtime.Serialization;
using System.Security;

namespace PrintDaddyObjectLibrary
{
    [Serializable()]
    public class SerializableNetworkCredential : NetworkCredential, ISerializableCredentials
    {
        public SerializableNetworkCredential(SerializationInfo info, StreamingContext context)
        {
            this.Domain = (string)info.GetValue("Domain", typeof(string));
            this.Password = (string)info.GetValue("Password", typeof(string));
            this.SecurePassword = (SecureString)info.GetValue("SecurePassword",typeof(SecureString));
            this.UserName = (string)info.GetValue("UserName", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Domain", Domain);
            info.AddValue("Password", Password);
            info.AddValue("SecurePassword", SecurePassword);
            info.AddValue("UserName",UserName);
        }
    }
}
