using System.Collections.Generic;

namespace PrintDaddyObjectLibrary
{
    public interface IResourceManager
    {
        char[] LocalKeyDelimiter { get; }
        string LocalKeyPath { get; }
        string LocalKeyPathBinary { get; }
        string LocalKeyPathXml { get; }
        object LocalSampleTemplatePath { get; }
        IEnumerable<string> TemplatePaths { get; }
    }
}