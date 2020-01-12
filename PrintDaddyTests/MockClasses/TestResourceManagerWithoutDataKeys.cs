using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintDaddyObjectLibrary;

namespace PrintDaddyTests
{
    class TestResourceManagerWithoutDataKeys : IResourceManager
    {
        public char[] LocalKeyDelimiter => throw new NotImplementedException();

        public string LogoPath => throw new NotImplementedException();

        public string LocalKeyPathBinary => throw new NotImplementedException();

        public string LocalKeyPathXml => "XmlDataKeysWithoutKeys.xml";

        public object LocalSampleTemplatePath => throw new NotImplementedException();

        public IEnumerable<string> TemplatePaths => throw new NotImplementedException();

        public string CredentialPath => throw new NotImplementedException();
    }
}
