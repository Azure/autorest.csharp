// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.AutoRest.Communication.Serialization.Models;
using AutoRest.CSharp.V3.AutoRest.Plugins;

namespace AutoRest.CSharp.V3.AutoRest.Communication
{
    internal class HostCommunication : IPluginCommunication
    {
        private readonly string _basePath;

        public HostCommunication(string[] args)
        {
            var arguments = new Dictionary<string, string>();
            foreach (string s in args)
            {
                var parts = s.Split("=");
                string name = parts[0];
                if (name.StartsWith("--"))
                {
                    name = name.Substring(2);
                }
                arguments[name] = parts.Length == 1 ? "true" : parts[1];
            }

            _basePath = arguments["output-folder"];
            PluginName = arguments["plugin"];
            Configuration = LoadConfiguration(File.ReadAllText(Path.Combine(_basePath, "Configuration.json")));
        }

        public string PluginName { get; }
        public Configuration Configuration { get; }

        public Task<string> GetCodeModel()
        {
            var filename = Path.Combine(_basePath, "CodeModel.yaml");
            return File.ReadAllTextAsync(filename);
        }

        public async Task WriteFile(string filename, string content, string artifactType, RawSourceMap? sourceMap = null)
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }
            filename = Path.Combine(_basePath, filename);
            Console.WriteLine($"Writing {filename} {artifactType}");
            Directory.CreateDirectory(Path.GetDirectoryName(filename));
            await File.WriteAllTextAsync(filename, content);
        }

        public async Task Fatal(string text)
        {
            await Console.Error.WriteLineAsync("FATAL: " + text);
        }

        internal static string SaveConfiguration(Configuration configuration)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream))
                {
                    writer.WriteStartObject();
                    writer.WriteString(nameof(Plugins.Configuration.OutputFolder), Path.GetRelativePath(configuration.OutputFolder, configuration.OutputFolder));
                    writer.WriteString(nameof(Plugins.Configuration.Namespace), configuration.Namespace);
                    writer.WriteString(nameof(Plugins.Configuration.Title), configuration.Title);
                    writer.WriteString(nameof(Plugins.Configuration.SharedSourceFolder), Path.GetRelativePath(configuration.OutputFolder,configuration.SharedSourceFolder));
                    writer.WriteBoolean(nameof(Plugins.Configuration.AzureArm), configuration.AzureArm);
                    writer.WriteEndObject();
                }

                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        private Configuration LoadConfiguration(string json)
        {
            JsonDocument document = JsonDocument.Parse(json);
            var root = document.RootElement;
            return new Configuration(
                Path.Combine(_basePath, root.GetProperty(nameof(Plugins.Configuration.OutputFolder)).GetString()),
                root.GetProperty(nameof(Plugins.Configuration.Namespace)).GetString(),
                root.GetProperty(nameof(Plugins.Configuration.Title)).GetString(),
                Path.Combine(_basePath, root.GetProperty(nameof(Plugins.Configuration.SharedSourceFolder)).GetString()),
                saveInputs: false,
                root.GetProperty(nameof(Plugins.Configuration.AzureArm)).GetBoolean()
            );
        }
    }
}
