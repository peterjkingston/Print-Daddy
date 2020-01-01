namespace PrintDaddyObjectLibrary
{
    public interface IResourceManager
    {
        char[] LocalKeyDelimiter { get; }
        string LocalKeyPath { get; }
        string LocalKeyPathBinary { get; }
        string LocalKeyPathXml { get; }
    }
}