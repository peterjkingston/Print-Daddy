using System;

namespace PrintDaddyService
{
    public interface IPrintDaddy
    {
        event EventHandler Started;
        event EventHandler Stopped;

        void Start();
        void Stop();
    }
}