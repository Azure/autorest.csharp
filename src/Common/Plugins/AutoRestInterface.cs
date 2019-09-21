using System;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.V3.Common.JsonRpc;
using AutoRest.CSharp.V3.Common.Utilities;
using Microsoft.Perks.JsonRPC;

namespace AutoRest.CSharp.V3.Common.Plugins
{
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    internal class AutoRestInterface
    {
        public Task<string> ReadFile(string filename) => ProcessRequest<string>(requestId => OutgoingMessages.ReadFile(requestId, _sessionId, filename));
        public Task<T> GetValue<T>(string key) => ProcessRequest<T>(requestId => OutgoingMessages.GetValue(requestId, _sessionId, key));
        public Task<string[]> ListInputs(string artifactType = null) => ProcessRequest<string[]>(requestId => OutgoingMessages.ListInputs(requestId, _sessionId, artifactType));
        public Task<string> ProtectFiles(string path) => ProcessRequest<string>(requestId => OutgoingMessages.ProtectFiles(requestId, _sessionId, path));
        public Task Message(IMessage message) => _connection.Send(OutgoingMessages.Message(_sessionId, message));

        public Task WriteFile(string filename, string content, string artifactType, RawSourceMap sourceMap = null) =>
            _connection.Send(OutgoingMessages.WriteFile(_sessionId, filename, content, artifactType, sourceMap));
        public Task WriteFile(string filename, string content, string artifactType, Mapping[] sourceMap) =>
            _connection.Send(OutgoingMessages.WriteFile(_sessionId, filename, content, artifactType, sourceMap));

        private Task<T> ProcessRequest<T>(Func<string, string> requestMethod)
        {
            var requestId = Guid.NewGuid().ToString();
            return _connection.Request5<T>(requestId, requestMethod(requestId));
        }

        private readonly Connection _connection;
        private readonly string _sessionId;
        public string PluginName { get; }

        public AutoRestInterface(Connection connection, string pluginName, string sessionId)
        {
            _connection = connection;
            PluginName = pluginName;
            _sessionId = sessionId;
        }

        public async Task<bool> Process(Func<Task<bool>> processMethod)
        {
            // AutoRest sends an empty Object as a 'true' value. When the configuration item is not present, it sends a Null value.
            if ((await GetValue<JsonElement?>($"{PluginName}.debugger")).IsObject())
            {
                AutoRestDebugger.Await();
            }
            try
            {
                return await processMethod();
            }
            catch (Exception e)
            {
                Message(new Message { Channel = Channel.Fatal, Text = e.ToString() });
                return false;
            }
        }
    }
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
}
