﻿using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using PrintDaddyObjectLibrary;

namespace PrintDaddyService
{
    public class PrintDaddy : IPrintDaddy
    {
        public event EventHandler Started;
        public event EventHandler Stopped;

        readonly Timer _timer;
        List<IDataKey> _localKeys;
        List<IDataKey> _remoteKeys;
        ICredentialsProvider _credentialsProvider;
        IDataProvider _remoteDataProvider;
        IDataProvider _localDataProvider;
        IPrintManager _printManager;
        IRecordReader _recordReader;

        /// <summary>
        /// Default constructor. Designated for use with Topshelf.HostFactory.
        /// </summary>
        public PrintDaddy(ILocalDataProvider localDataProvider, 
                          IRemoteDataProvider remoteDataProvider, 
                          IPrintManager printManager,
                          IRecordReader recordReader)
        {
            //Run the service every minute.
            _timer = new Timer(60_000) { AutoReset = true };
            _timer.Elapsed += Time_Elapsed;

            _localDataProvider = localDataProvider;
            _remoteDataProvider = remoteDataProvider;
            _printManager = printManager;
            _recordReader = recordReader;

            UpdateKeys();
        }

        private void UpdateKeys()
        {
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
        }

        private List<IDataKey> ReadLocalKeys()
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
                foreach (IDataKey key in _remoteKeys)
                {
                    if (!_localKeys.Contains(key))
                    {
                        string[] record = _recordReader.GetRecord(key);
                        _printManager.Print(record);
                    }
                }
            }
        }

        private List<IDataKey> ReadRemoteKeysSync()
        {
            return _remoteDataProvider.GetKeys();
        }

        private bool NeedsToRun()
        {
            bool result = false;
            foreach (IDataKey key in _remoteKeys)
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
