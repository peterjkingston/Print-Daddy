using System;
using System.Timers;
using PrintDaddyObjectLibrary;

namespace PrintDaddyService
{
    public class PrintDaddy : IPrintDaddy
    {
        public event EventHandler Started;
        public event EventHandler Stopped;

        readonly Timer _timer;

        IValidator _validator;
        ISelector _selector;
        IRecordAction _recordAction;

        /// <summary>
        /// Default constructor. Designated for use with Topshelf.HostFactory.
        /// </summary>
        public PrintDaddy(IValidator validator,
                          ISelector selector,
                          IRecordAction recordAction)
        {
            //Run the service every minute.
            _timer = new Timer(60_000) { AutoReset = true };
            _timer.Elapsed += Time_Elapsed;

            _validator = validator;
            _selector = selector;
            _recordAction = recordAction;
        }

        private void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_validator.NeedsToRun())
            {
                _selector.Reload();
                while (_selector.Next())
                {
                    _recordAction.Run(_selector.GetCurrentItem());
                }
                _selector.Reset();
            }
        }

        /// <summary>
        /// Designated start method for use with Topshelf.HostFactory. Starts the service.
        /// </summary>
        public void Start()
        {
            _timer.Start();
            OnStarted(new EventArgs());
        }

        /// <summary>
        /// Designated stop method for use with Topshelf.HostFactory. Stops the service.
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
            OnStopped(new EventArgs());
        }

        protected virtual void OnStarted(EventArgs e)
        {
            Started(this, e);
        }

        protected virtual void OnStopped(EventArgs e)
        {
            Stopped(this, e);
        }
    }
}
