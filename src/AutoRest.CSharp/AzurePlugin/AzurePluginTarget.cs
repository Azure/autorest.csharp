// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.Input;
using System.Threading.Tasks;

namespace AutoRest.CSharp.AzurePlugin
{
    internal class AzurePluginTarget
    {
        public static async Task ExecuteAsync(GeneratedCodeWorkspace project, InputNamespace inputNamespace)
        {
            // TODO: serialize configuration.json and serialize inputNamespace to tspCodeModel.json
            // TODO: spawn a chile process to invoke MTG or Azure plugin
            await Task.CompletedTask;
        }
    }
}
