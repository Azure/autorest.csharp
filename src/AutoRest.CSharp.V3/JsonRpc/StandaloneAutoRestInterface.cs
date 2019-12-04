// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AutoRest.CSharp.V3.JsonRpc.MessageModels
{
    internal class StandaloneAutoRestInterface : IAutoRestInterface
    {
        private readonly Dictionary<string, string> _arguments;
        private readonly string _basePath;

        public StandaloneAutoRestInterface(string[] args)
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
                if (parts.Length == 1)
                {
                    _arguments[name] = "true";
                }
                else
                {
                    _arguments[name] = parts[1];
                }
            }

            _basePath = _arguments["base-path"];
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
                return Task.FromResult((T)Convert.ChangeType(stringValue, typeof(T)));
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
            filename = Path.Combine(_basePath, filename);
            Console.WriteLine($"Writing {filename} {artifactType}");
            await File.WriteAllTextAsync(filename, content);
        }

        public async Task WriteFile(string filename, string content, string artifactType, Mapping[] sourceMap)
        {
            filename = Path.Combine(_basePath, filename);
            Console.WriteLine($"Writing {filename} {artifactType}");
            await File.WriteAllTextAsync(filename, content);
        }

        public async Task Fatal(string text)
        {
            await Console.Error.WriteLineAsync("FATAL: " + text);
        }
    }
}
