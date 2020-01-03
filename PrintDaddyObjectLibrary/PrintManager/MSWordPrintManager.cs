using Microsoft;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyObjectLibrary
{
    public class MSWordPrintManager : IPrintManager
    {
        IResourceManager _resourceManager;

        public MSWordPrintManager(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public void Print(string[] record)
        {
            Application word = new Application();
            Document doc = word.Documents.Open(_resourceManager.LocalSampleTemplatePath);

            string body = doc.Content.Text;

            doc.Close(false);
        }
    }
}
