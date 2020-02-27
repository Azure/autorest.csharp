// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using AutoRest.CSharp.V3.AutoRest.Communication.Serialization.Models;

namespace AutoRest.CSharp.V3.AutoRest.Communication
{
    internal interface IPluginCommunication
    {
        string PluginName { get; }
        Task<string> ReadFile(string filename);
        Task<T> GetValue<T>(string key);
        Task<string[]> ListInputs(string? artifactType = null);
        Task WriteFile(string filename, string content, string artifactType, RawSourceMap? sourceMap = null);
        Task Fatal(string text);
        Task Message(string text);
    }
}
