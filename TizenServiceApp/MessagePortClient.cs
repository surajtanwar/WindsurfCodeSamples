using System;
using Tizen.Applications;
using Tizen;

namespace TizenServiceApp
{
    public class MessagePortClient
    {
        private const string ServicePortName = "ServicePort";
        private const string ClientPortName = "ClientPort";
        private const string ServiceAppId = "org.tizen.example.TizenServiceApp";

        private LocalMessagePort _localMessagePort;
        private RemoteMessagePort _remoteMessagePort;
        private bool _isInitialized;

        public event EventHandler<string> MessageReceived;

        private static MessagePortClient _instance;
        public static MessagePortClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MessagePortClient();
                }
                return _instance;
            }
        }

        private MessagePortClient()
        {
            _isInitialized = false;
        }

        public void Initialize()
        {
            try
            {
                if (_isInitialized) return;

                // Create local message port for receiving messages from service
                _localMessagePort = new LocalMessagePort(ClientPortName);
                _localMessagePort.MessageReceived += OnMessageReceived;

                // Create remote message port for sending messages to service
                _remoteMessagePort = new RemoteMessagePort(ServiceAppId, ServicePortName);

                _isInitialized = true;
                Logger.Log(LogPriority.Info, "MessagePortClient", "Message ports initialized successfully");
            }
            catch (Exception ex)
            {
                Logger.Log(LogPriority.Error, "MessagePortClient", $"Failed to initialize message ports: {ex.Message}");
            }
        }

        public void SendToService(string message, string key = "message")
        {
            try
            {
                if (!_isInitialized)
                {
                    Logger.Log(LogPriority.Error, "MessagePortClient", "Message ports not initialized");
                    return;
                }

                var bundle = new Bundle();
                bundle.AddItem(key, message);

                _remoteMessagePort.SendMessage(bundle);
                Logger.Log(LogPriority.Info, "MessagePortClient", $"Message sent to service: {message}");
            }
            catch (Exception ex)
            {
                Logger.Log(LogPriority.Error, "MessagePortClient", $"Failed to send message: {ex.Message}");
            }
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                var message = e.Message.GetItem<string>("message");
                Logger.Log(LogPriority.Info, "MessagePortClient", $"Message received from service: {message}");
                
                // Notify subscribers
                MessageReceived?.Invoke(this, message);
            }
            catch (Exception ex)
            {
                Logger.Log(LogPriority.Error, "MessagePortClient", $"Error processing received message: {ex.Message}");
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
