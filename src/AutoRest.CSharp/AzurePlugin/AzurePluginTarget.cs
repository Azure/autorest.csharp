// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using System.Threading.Tasks;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class AzurePluginTarget
    {
        public static async Task ExecuteAsync(GeneratedCodeWorkspace project, InputNamespace inputNamespace)
        {
            // TODO: serialize inputNamespace to tspCodeModel.json
            // TODO: spawn a child process to invoke MTG or Azure plugin
            await Task.CompletedTask;
        }
    }
}
