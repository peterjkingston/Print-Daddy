using System;
using System.Runtime.Serialization;

namespace PrintDaddyObjectLibrary
{
    public interface IDataKey 
    {
        string ID { get; }
        DateTime TimeStamp { get; }

        void GetObjectData(SerializationInfo info, StreamingContext context);
    }
}