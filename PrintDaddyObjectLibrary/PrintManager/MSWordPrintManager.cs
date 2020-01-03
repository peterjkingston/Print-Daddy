using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;

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

            foreach(RecordField rf in Enum.GetValues(typeof(RecordField)))
            {
                Find f = word.Selection.Find;
                f.Forward = true;
                f.Wrap = WdFindWrap.wdFindStop;
                f.Text = $"[{rf}]";
                f.Replacement.Text = record[(int)rf];
                f.Execute(Replace: WdReplace.wdReplaceAll);
            }
            
            doc.PrintOut();
            doc.Close(false);
            word.Quit();
        }

        public void Print(Dictionary<string,string> keyValues)
        {
            Application word = new Application();
            try
            {
                foreach (string docPath in _resourceManager.TemplatePaths)
                {
                    Document doc = word.Documents.Open(docPath);

                    new TemplateModifier(doc).Modify(keyValues);

                    doc.Close(false);
                }
            }
            catch(Exception ex)
            {
                //TODO
            }
            finally
            {
                word.Quit();
            }
        }

        internal class TemplateModifier
        {
            Document _template;

            internal TemplateModifier(Document templateDocment)
            {
                _template = templateDocment;
            }

            internal void Modify(Dictionary<string,string> keyValues)
            {
                foreach (string key in keyValues.Keys)
                {
                    Find f = _template.Application.Selection.Find;
                    f.Forward = true;
                    f.Wrap = WdFindWrap.wdFindStop;
                    f.Text = $"[{key}]";
                    f.Replacement.Text = keyValues[key];
                    f.Execute(Replace: WdReplace.wdReplaceAll);
                }
            }
        }
    }
}
