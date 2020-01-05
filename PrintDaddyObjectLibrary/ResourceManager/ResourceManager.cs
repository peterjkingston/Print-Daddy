using System.Collections.Generic;

namespace PrintDaddyObjectLibrary
{
    public class ResourceManager : IResourceManager
    {
        public string LogoPath { get; private set; }
        public char[] LocalKeyDelimiter { get; private set; }
        public string LocalKeyPathXml { get; private set; }
        public string LocalKeyPathBinary { get; private set; }

        public object LocalSampleTemplatePath => throw new System.NotImplementedException();

        public IEnumerable<string> TemplatePaths => throw new System.NotImplementedException();

        public string CredentialPath => throw new System.NotImplementedException();
    }
}