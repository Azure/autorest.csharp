using System;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc.Messaging;

namespace AutoRest.CSharp.V3.JsonRpc
{
    internal class AutoRestInterface
    {
        private readonly Connection _connection;
        private readonly string _sessionId;
        public string PluginName { get; }

        public AutoRestInterface(Connection connection, string pluginName, string sessionId)
        {
            _connection = connection;
            PluginName = pluginName;
            _sessionId = sessionId;
        }

        // Basic Interfaces
        public Task<string> ReadFile(string filename) => ProcessRequest<string>(requestId => OutgoingMessages.ReadFile(requestId, _sessionId, filename));
        public Task<T> GetValue<T>(string key) => ProcessRequest<T>(requestId => OutgoingMessages.GetValue(requestId, _sessionId, key));
        public Task<string[]> ListInputs(string? artifactType = null) => ProcessRequest<string[]>(requestId => OutgoingMessages.ListInputs(requestId, _sessionId, artifactType));
        public Task<string> ProtectFiles(string path) => ProcessRequest<string>(requestId => OutgoingMessages.ProtectFiles(requestId, _sessionId, path));
        public Task Message(IMessage message) => _connection.Notification(OutgoingMessages.Message(_sessionId, message));

        public Task WriteFile(string filename, string content, string artifactType, RawSourceMap? sourceMap = null) =>
            _connection.Notification(OutgoingMessages.WriteFile(_sessionId, filename, content, artifactType, sourceMap));
        public Task WriteFile(string filename, string content, string artifactType, Mapping[] sourceMap) =>
            _connection.Notification(OutgoingMessages.WriteFile(_sessionId, filename, content, artifactType, sourceMap));

        // Convenience Interfaces
        public Task Message(string text, Channel channel = Channel.Warning) => Message(new Message { Channel = channel, Text = text });

        private Task<T> ProcessRequest<T>(Func<string, string> requestMethod)
        {
            var requestId = Guid.NewGuid().ToString();
            return _connection.Request<T>(requestId, requestMethod(requestId));
        }
    }
}
