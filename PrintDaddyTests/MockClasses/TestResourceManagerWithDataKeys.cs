using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintDaddyObjectLibrary;

namespace PrintDaddyTests
{
    public class TestResourceManagerWithDataKeys : IResourceManager
    {
        public char[] LocalKeyDelimiter => throw new NotImplementedException();

        public string LogoPath => throw new NotImplementedException();

        public string LocalKeyPathBinary => "BinaryFileWithDataKeys.dat";

        public string LocalKeyPathXml => "XmlFileWithDataKeys.xml";

        public object LocalSampleTemplatePath => throw new NotImplementedException();

        public IEnumerable<string> TemplatePaths => throw new NotImplementedException();

        public string CredentialPath => throw new NotImplementedException();
    }
}
