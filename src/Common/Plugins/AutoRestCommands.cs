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
    internal class AutoRestCommands
    {
        public Task<string> ReadFile(string filename) => ProcessRequest<string>(requestId => AutoRestRequests.ReadFile(requestId, _sessionId, filename));
        public Task<T> GetValue<T>(string key) => ProcessRequest<T>(requestId => AutoRestRequests.GetValue(requestId, _sessionId, key));
        public Task<string[]> ListInputs(string artifactType = null) => ProcessRequest<string[]>(requestId => AutoRestRequests.ListInputs(requestId, _sessionId, artifactType));
        public Task<string> ProtectFiles(string path) => ProcessRequest<string>(requestId => AutoRestRequests.ProtectFiles(requestId, _sessionId, path));
        public Task Message(IMessage message) => _connection.Send(AutoRestRequests.Message(_sessionId, message));

        public Task WriteFile(string filename, string content, string artifactType, RawSourceMap sourceMap = null) =>
            _connection.Send(AutoRestRequests.WriteFile(_sessionId, filename, content, artifactType, sourceMap));
        public Task WriteFile(string filename, string content, string artifactType, Mapping[] sourceMap) =>
            _connection.Send(AutoRestRequests.WriteFile(_sessionId, filename, content, artifactType, sourceMap));

        private Task<T> ProcessRequest<T>(Func<string, string> requestMethod)
        {
            var requestId = Guid.NewGuid().ToString();
            return _connection.Request5<T>(requestId, requestMethod(requestId));
        }

        private readonly Connection _connection;
        private readonly string _pluginName;
        private readonly string _sessionId;

        public AutoRestCommands(Connection connection, string pluginName, string sessionId)
        {
            _connection = connection;
            _pluginName = pluginName;
            _sessionId = sessionId;
        }

        public async Task<bool> Process(Func<Task<bool>> processMethod)
        {
            // AutoRest sends and empty Object as 'true' value. When the configuration item is not present, it is a Null value.
            if ((await GetValue<JsonElement?>($"{_pluginName}.debugger")).IsObject())
            {
                AutoRestDebugger.Await();
            }
            try
            {
                return await processMethod();
            }
            catch (Exception e)
            {
                //Message(new Message { Channel = "fatal", Text = e.ToString() });
                Message(new Message { Channel = Channel.Fatal, Text = e.ToString() });
                return false;
            }
        }
    }
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
}
