namespace PrintDaddyObjectLibrary
{
    public interface IRecordReader
    {
        string[] GetRecord(IDataKey key);
    }
}