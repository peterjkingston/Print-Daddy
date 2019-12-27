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
        List<DataKey> _localKeys;
        List<DataKey> _remoteKeys;
        ICredentialsProvider _credentialsProvider;
        IDataProvider _remoteDataProvider;
        IDataProvider _localDataProvider;
        IPrintManager _printManager;
        IRecordReader _recordReader;

        /// <summary>
        /// Default constructor. Designated for use with Topshelf.HostFactory.
        /// </summary>
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

            _localDataProvider = Factory.CreateLocalDataProvider();
            _credentialsProvider = Factory.CreateCredentialsProvider();
            _remoteDataProvider = Factory.CreateRemoteDataProvider();
            _printManager = Factory.CreatePrintManager();
            _recordReader = (IRecordReader)_remoteDataProvider; 
        }

        private List<DataKey> ReadLocalKeys()
        {
            return _localDataProvider.GetKeys();
        }

        private bool LocalKeysExist()
        {
            //return File.Exists(ResourceManager.LocalKeyPath);
            return _localDataProvider.KeysExist();
        }

        private void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            _remoteKeys = ReadRemoteKeysSync();
            if (_remoteKeys != null && this.NeedsToRun())
            {
                foreach (DataKey key in _remoteKeys)
                {
                    if (!_localKeys.Contains(key))
                    {
                        string[] record = _recordReader.GetRecord(key);
                        _printManager.Print(record);
                    }
                }
            }
        }

        private List<DataKey> ReadRemoteKeysSync()
        {
            return _remoteDataProvider.GetKeys();
        }

        private bool NeedsToRun()
        {
            bool result = false;
            foreach (DataKey key in _remoteKeys)
            {
                if (!_localKeys.Contains(key))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Designated start method for use with Topshelf.HostFactory. Starts the service.
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }

        /// <summary>
        /// Designated stop method for use with Topshelf.HostFactory. Stops the service.
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
        }
    }
}
