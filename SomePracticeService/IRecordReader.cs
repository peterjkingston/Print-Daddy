namespace PrintDaddyService
{
    internal interface IRecordReader
    {
        string[] GetRecord(IDataKey key);
    }
}