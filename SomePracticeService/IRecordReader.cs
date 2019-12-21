namespace PrintDaddyService
{
    internal interface IRecordReader
    {
        string[] GetRecord(DataKey key);
    }
}