using System;
using System.Collections.Generic;
using Tizen.Applications;
using Tizen;

namespace TizenServiceApp.Services
{
    public class MessagePortService
    {
        private const string ServicePortName = "ServicePort";
        private const string ClientPortName = "ClientPort";
        private const string RemoteAppId = "org.tizen.example.TizenClientApp";
        
        private LocalMessagePort _localMessagePort;
        private RemoteMessagePort _remoteMessagePort;
        private bool _isInitialized;

        private static MessagePortService _instance;
        public static MessagePortService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MessagePortService();
                }
                return _instance;
            }
        }

        private MessagePortService()
        {
            _isInitialized = false;
        }

        public void Initialize()
        {
            try
            {
                if (_isInitialized) return;

                // Create local message port for receiving messages
                _localMessagePort = new LocalMessagePort(ServicePortName);
                _localMessagePort.MessageReceived += OnMessageReceived;

                // Create remote message port for sending messages
                _remoteMessagePort = new RemoteMessagePort(RemoteAppId, ClientPortName);

                _isInitialized = true;
                Logger.Log(LogPriority.Info, "MessagePort", "Message ports initialized successfully");
            }
            catch (Exception ex)
            {
                Logger.Log(LogPriority.Error, "MessagePort", $"Failed to initialize message ports: {ex.Message}");
            }
        }

        public void SendMessage(string message, string key = "message")
        {
            try
            {
                if (!_isInitialized)
                {
                    Logger.Log(LogPriority.Error, "MessagePort", "Message ports not initialized");
                    return;
                }

                var bundle = new Bundle();
                bundle.AddItem(key, message);

                _remoteMessagePort.SendMessage(bundle);
                Logger.Log(LogPriority.Info, "MessagePort", $"Message sent: {message}");
            }
            catch (Exception ex)
            {
                Logger.Log(LogPriority.Error, "MessagePort", $"Failed to send message: {ex.Message}");
            }
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                var message = e.Message.GetItem<string>("message");
                Logger.Log(LogPriority.Info, "MessagePort", $"Message received: {message}");
                
                // Handle received message
                ProcessReceivedMessage(message);
            }
            catch (Exception ex)
            {
                Logger.Log(LogPriority.Error, "MessagePort", $"Error processing received message: {ex.Message}");
            }
        }

        private void ProcessReceivedMessage(string message)
        {
            // Add your message processing logic here
            // You can trigger different actions based on the message content
            switch (message.ToLower())
            {
                case "start":
                    ServiceManager.Instance.Start();
                    SendMessage("Service started");
                    break;
                    
                case "stop":
                    ServiceManager.Instance.Stop();
                    SendMessage("Service stopped");
                    break;
                    
                case "status":
                    var status = ServiceManager.Instance.IsRunning ? "running" : "stopped";
                    SendMessage($"Service is {status}");
                    break;
                    
                default:
                    SendMessage($"Unknown command: {message}");
                    break;
            }
        }

        public void Cleanup()
        {
            if (!_isInitialized) return;

            _localMessagePort.MessageReceived -= OnMessageReceived;
            _localMessagePort.Dispose();
            _remoteMessagePort.Dispose();
            _isInitialized = false;
        }
    }
}
