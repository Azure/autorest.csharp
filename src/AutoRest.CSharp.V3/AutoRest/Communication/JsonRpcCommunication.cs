// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.AutoRest.Communication.MessageHandling;
using AutoRest.CSharp.V3.AutoRest.Communication.Serialization;
using AutoRest.CSharp.V3.AutoRest.Communication.Serialization.Models;
using AutoRest.CSharp.V3.AutoRest.Plugins;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.AutoRest.Communication
{
    internal class JsonRpcCommunication : IPluginCommunication
    {
        private readonly JsonRpcConnection _connection;
        private readonly string _sessionId;
        public string PluginName { get; }

        public Configuration Configuration
        {
            get
            {
                return new Configuration(
                    new Uri(GetRequiredOption("output-folder")).LocalPath,
                    GetRequiredOption("namespace"),
                    GetValue<string?>("title").GetAwaiter().GetResult(),
                    new Uri(GetRequiredOption("shared-source-folder")).LocalPath,
                    GetValue<bool?>("save-inputs").GetAwaiter().GetResult() ?? false,
                    GetValue<bool?>("azure-arm").GetAwaiter().GetResult() ?? false
                );
            }
        }

        public JsonRpcCommunication(JsonRpcConnection connection, string pluginName, string sessionId)
        {
            _connection = connection;
            PluginName = pluginName;
            _sessionId = sessionId;

            // AutoRest sends an empty Object as a 'true' value. When the configuration item is not present, it sends a Null value.
            if (GetValue<JsonElement?>($"{pluginName}.attach").GetAwaiter().GetResult().IsObject())
            {
             //   DebuggerAwaiter.AwaitAttach();
            }
        }

        // Basic Interfaces
        public Task<string> ReadFile(string filename) => ProcessRequest<string>(requestId => OutgoingMessageSerializer.ReadFile(requestId, _sessionId, filename));
        public Task<T> GetValue<T>(string key) => ProcessRequest<T>(requestId => OutgoingMessageSerializer.GetValue(requestId, _sessionId, key));
        public Task<string[]> ListInputs(string? artifactType = null) => ProcessRequest<string[]>(requestId => OutgoingMessageSerializer.ListInputs(requestId, _sessionId, artifactType));
        public Task<string> ProtectFiles(string path) => ProcessRequest<string>(requestId => OutgoingMessageSerializer.ProtectFiles(requestId, _sessionId, path));
        public Task Message(IMessage message) => _connection.Notification(OutgoingMessageSerializer.Message(_sessionId, message));

        public async Task<string> GetCodeModel()
        {
            string codeModelFileName = (await ListInputs()).FirstOrDefault();
            if (string.IsNullOrEmpty(codeModelFileName)) throw new Exception("Generator did not receive the code model file.");

            return await ReadFile(codeModelFileName);
        }

        public Task WriteFile(string filename, string content, string artifactType, RawSourceMap? sourceMap = null) =>
            _connection.Notification(OutgoingMessageSerializer.WriteFile(_sessionId, filename, content, artifactType, sourceMap));

        public Task Fatal(string text)
        {
            return Message(text, Channel.Fatal);
        }

        // Convenience Interfaces
        public Task Message(string text, Channel channel = Channel.Warning) => Message(new Message { Channel = channel, Text = text });

        private Task<T> ProcessRequest<T>(Func<string, string> requestMethod)
        {
            var requestId = Guid.NewGuid().ToString();
            return _connection.Request<T>(requestId, requestMethod(requestId));
        }

        private string GetRequiredOption(string name)
        {
            return GetValue<string?>(name).GetAwaiter().GetResult() ?? throw new InvalidOperationException($"{name} configuration parameter is required");
        }
    }
}
