namespace PrintDaddyObjectLibrary
{
    public class PrintAction : IRecordAction
    {
        IPrintManager _printManager;
        IRecordReader _recordReader;

        public PrintAction(IPrintManager printManager, IRecordReader recordReader)
        {
            _printManager = printManager;
            _recordReader = recordReader;
        }

        public void Run(object v)
        {
            _printManager.Print(_recordReader.GetRecord((IDataKey)v));
        }
    }
}
