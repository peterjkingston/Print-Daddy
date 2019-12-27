using System;
using System.Runtime.Serialization;

namespace PrintDaddyService
{
    interface IDataKey
    {
        string ID { get; }
        DateTime TimeStamp { get; }

        void GetObjectData(SerializationInfo info, StreamingContext context);
    }
}