using System;
using Tizen.Applications;
using TizenServiceApp.Services;
using Tizen;

namespace TizenServiceApp
{
    class Program : ServiceApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            
            // Initialize MessagePort service
            MessagePortService.Instance.Initialize();
            
            // Initialize main service
            ServiceManager.Instance.Start();
            
            Logger.Log(LogPriority.Info, "Service", "Service Created and Initialized");
            
            // Send initial status message to client
            MessagePortService.Instance.SendMessage("Service started successfully");
        }

        protected override void OnTerminate()
        {
            try
            {
                // Cleanup MessagePort service
                MessagePortService.Instance.Cleanup();
                
                // Stop main service
                ServiceManager.Instance.Stop();
                
                Logger.Log(LogPriority.Info, "Service", "Service Terminated");
            }
            catch (Exception ex)
            {
                Logger.Log(LogPriority.Error, "Service", $"Error during termination: {ex.Message}");
            }
            finally
            {
                base.OnTerminate();
            }
        }

        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            base.OnAppControlReceived(e);
            
            try
            {
                // Handle app control and notify client
                var operation = e.AppControl.Operation;
                var data = e.AppControl.ExtraData;
                
                MessagePortService.Instance.SendMessage($"AppControl received: {operation}");
                
                Logger.Log(LogPriority.Info, "Service", $"App Control Received: {operation}");
            }
            catch (Exception ex)
            {
                Logger.Log(LogPriority.Error, "Service", $"Error handling app control: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
