using System.Collections.Generic;

namespace PrintDaddyObjectLibrary
{
    public interface IPrintManager
    {
        void Print(Dictionary<string, string> dictionary);
    }
}