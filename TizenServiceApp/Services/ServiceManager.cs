using System;
using System.Threading.Tasks;
using Tizen;

namespace TizenServiceApp.Services
{
    public class ServiceManager
    {
        private static ServiceManager _instance;
        private bool _isRunning;

        public static ServiceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceManager();
                }
                return _instance;
            }
        }

        private ServiceManager()
        {
            _isRunning = false;
        }

        public void Start()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                StartServiceLoop();
                Logger.Log(LogPriority.Info, "ServiceManager", "Service Started");
            }
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;
                Logger.Log(LogPriority.Info, "ServiceManager", "Service Stopped");
            }
        }

        private async void StartServiceLoop()
        {
            while (_isRunning)
            {
                try
                {
                    // Add your service logic here
                    await Task.Delay(1000); // Delay between service operations
                }
                catch (Exception ex)
                {
                    Logger.Log(LogPriority.Error, "ServiceManager", $"Error in service loop: {ex.Message}");
                }
            }
        }

        public bool IsRunning => _isRunning;
    }
}
