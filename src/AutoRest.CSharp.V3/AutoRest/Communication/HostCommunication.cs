// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.AutoRest.Communication.Serialization.Models;

namespace AutoRest.CSharp.V3.AutoRest.Communication
{
    internal class HostCommunication : IPluginCommunication
    {
        private readonly Dictionary<string, string> _arguments;
        private readonly string _basePath;

        public HostCommunication(string[] args)
        {
            _arguments = new Dictionary<string, string>();
            foreach (string s in args)
            {
                var parts = s.Split("=");
                string name = parts[0];
                if (name.StartsWith("--"))
                {
                    name = name.Substring(2);
                }
                _arguments[name] = parts.Length == 1 ? "true" : parts[1];
            }

            _basePath = _arguments["output-folder"];
            PluginName = _arguments["plugin"];
        }

        public string PluginName { get; }

        public Task<string> ReadFile(string filename)
        {
            filename = Path.Combine(_basePath, filename);
            return File.ReadAllTextAsync(filename);
        }

        public Task<T> GetValue<T>(string key)
        {
            if (_arguments.TryGetValue(key, out var stringValue))
            {
                var conversionType = typeof(T);
                // Handle nullable
                if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    conversionType = conversionType.GetGenericArguments()[0];
                }

                var value = (T) Convert.ChangeType(stringValue, conversionType);

                return Task.FromResult(value);
            }

            return Task.FromResult(default(T)!);
        }

        public Task<string[]> ListInputs(string? artifactType = null)
        {
            List<string> inputs = new List<string>();
            foreach (string argumentsKey in _arguments.Keys)
            {
                string inputPrefix = "input-";
                if (argumentsKey.StartsWith(inputPrefix))
                {
                    inputs.Add(_arguments[argumentsKey]);
                }
            }

            return Task.FromResult(inputs.ToArray());
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

        public Task Information(string text)
        {
            return Task.Run(() => Console.WriteLine(text));
        }
    }
}
