using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PrintDaddyService
{
    public class PrintDaddy
    {
        readonly Timer _timer;
        List<string> _localKeys;
        List<string> _remoteKeys;
        IDataRetriever _remoteDataRetriever;
        IPrintManager _printManager;
        IRecordReader _recordReader;

        public PrintDaddy()
        {
            //Run the service every minute.
            _timer = new Timer(60_000) {AutoReset = true };
            _timer.Elapsed += Time_Elapsed;

            if (LocalKeysExist())
            {
                //Load the local keys from the local drive if it's there...
                _localKeys = ReadLocalKeys();
            }
            else
            {
                //Otherwise load the remote keys in. This will result in no pages being printed upon
                //startup.
                _localKeys = ReadRemoteKeysSync();
            }

            _remoteDataRetriever = null; //TODO;
        }

        private List<string> ReadLocalKeys()
        {
            string udt = File.ReadAllText(ResourceManager.LocalKeyPath);
            return new List<string>(udt.Split(ResourceManager.LocalKeyDelimiter));
        }

        private bool LocalKeysExist()
        {
            return File.Exists(ResourceManager.LocalKeyPath);
        }

        private void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            _remoteKeys = ReadRemoteKeysSync();
            if (_remoteKeys != null && this.NeedsToRun())
            {
                foreach (string key in _remoteKeys)
                {
                    if (!_localKeys.Contains(key))
                    {
                        string[] record = _recordReader.GetRecord(key);
                        _printManager.Print(record);
                    }
                }
            }
        }

        private List<string> ReadRemoteKeysSync()
        {
            return _remoteDataRetriever.GetKeys();
        }

        private bool NeedsToRun()
        {
            bool result = false;
            foreach (string key in _remoteKeys)
            {
                if (!_localKeys.Contains(key))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
