using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.Core.Utilities;
using Microsoft.Perks.JsonRPC;

namespace AutoRest.CSharp.V3.Common.Plugins
{
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    internal class AutoRestCommands
    {
        public Task<string> ReadFile(string filename) => _connection.Request<string>("ReadFile", _sessionId, filename);
        public Task<T> GetValue<T>(string key) => _connection.Request<T>("GetValue", _sessionId, key);
        public Task<string> GetValue(string key) => GetValue<string>(key);
        public Task<string[]> ListInputs() => _connection.Request<string[]>("ListInputs", _sessionId, null);
        public Task<string[]> ListInputs(string artifactType) => _connection.Request<string[]>("ListInputs", _sessionId, artifactType);

        public void Message(Message message) => _connection.Notify("Message", _sessionId, message);

        public void WriteFile(string filename, string content, object sourcemap) => _connection.Notify("WriteFile", _sessionId, filename, content, sourcemap);
        public void WriteFile(string filename, string content, object sourcemap, string artifactType) => _connection.Notify("Message", _sessionId, new Message
        {
            Channel = "file",
            Details = new
            {
                content,
                type = artifactType,
                uri = filename,
                sourceMap = sourcemap
            },
            Text = content,
            Key = new[] { artifactType, filename }
        });

        public async Task ProtectFiles(string path)
        {
            try
            {
                var items = await ListInputs(path);
                if (items?.Length > 0)
                {
                    foreach (var each in items)
                    {
                        try
                        {
                            var content = await ReadFile(each);
                            WriteFile(each, content, null, "preserved-files");
                        }
                        catch
                        {
                            // no good.
                        }
                    }
                    return;
                }
                var contentSingle = await ReadFile(path);
                WriteFile(path, contentSingle, null, "preserved-files");
            }
            catch
            {
                // oh well.
            }
        }

        public async Task<string> GetConfigurationFile(string filename)
        {
            var configurations = await GetValue<Dictionary<string, string>>("configurationFiles");
            var first = configurations?.Keys.FirstOrDefault();
            if (first != null)
            {
                first = first.Substring(0, first.LastIndexOf('/'));
                foreach (var configFile in configurations?.Keys)
                {
                    if (configFile == $"{first}/{filename}")
                    {
                        return configurations[configFile];
                    }
                }
            }
            return "";
        }

        public void UpdateConfigurationFile(string filename, string content)
        {
            _connection.Notify("Message", _sessionId, new Message
            {
                Channel = "configuration",
                Key = new[] { filename },
                Text = content
            });
        }

        private readonly Connection _connection;
        private string Plugin { get; }
        private readonly string _sessionId;

        protected AutoRestCommands(Connection connection, string plugin, string sessionId)
        {
            _connection = connection;
            Plugin = plugin;
            _sessionId = sessionId;
        }

        public async Task<bool> Process(Func<Task<bool>> processMethod)
        {
            if (true == await GetValue<bool?>($"{Plugin}.debugger"))
            {
                AutoRestDebugger.Await();
            }
            try
            {
                return await processMethod();
            }
            catch (Exception e)
            {
                Message(new Message { Channel = "fatal", Text = e.ToString() });
                return false;
            }
        }
    }
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
}
