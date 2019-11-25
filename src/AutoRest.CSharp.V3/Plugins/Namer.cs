// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    // ReSharper disable once StringLiteralTypo
    [PluginName("cs-namer")]
    // ReSharper disable once IdentifierTypo
    internal class Namer : IPlugin
    {
        public Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            return Task.FromResult(true);
        }
    }
}
