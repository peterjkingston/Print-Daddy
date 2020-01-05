using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyObjectLibrary
{
    public class DefaultPrintManager : IPrintManager
    {
        public void Print(string[] record)
        {
            PrintDocument printDocument = new PrintDocument();
            //TODO
        }

        public void Print(Dictionary<string, string> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
