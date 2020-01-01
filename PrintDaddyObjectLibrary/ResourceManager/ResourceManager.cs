namespace PrintDaddyObjectLibrary
{
    public class ResourceManager : IResourceManager
    {
        public string LocalKeyPath { get; private set; }
        public char[] LocalKeyDelimiter { get; private set; }
        public string LocalKeyPathXml { get; private set; }
        public string LocalKeyPathBinary { get; private set; }
    }
}