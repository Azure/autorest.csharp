// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using AutoRest.CSharp.V3.AutoRest.Communication.Serialization.Models;
using AutoRest.CSharp.V3.AutoRest.Plugins;

namespace AutoRest.CSharp.V3.AutoRest.Communication
{
    internal interface IPluginCommunication
    {
        string PluginName { get; }
        Configuration Configuration { get; }
        Task<string> GetCodeModel();
        Task WriteFile(string filename, string content, string artifactType, RawSourceMap? sourceMap = null);
        Task Fatal(string text);
    }
}
