using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

namespace PrintDaddyObjectLibrary
{
    [Serializable()]
    public struct DataKey : ISerializable, IDataKey
    {
        public string ID { get; private set; }
        public DateTime TimeStamp { get; private set; }

        public DataKey(string id, DateTime timestamp)
        {
            ID = id;
            TimeStamp = timestamp;
        }

        public DataKey(SerializationInfo info, StreamingContext context)
        {
            ID = (string)info.GetValue("ID", typeof(string));
            TimeStamp = (DateTime)info.GetValue("TimeStamp", typeof(DateTime));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", ID);
            info.AddValue("TimeStamp", TimeStamp);
        }
    }
}
