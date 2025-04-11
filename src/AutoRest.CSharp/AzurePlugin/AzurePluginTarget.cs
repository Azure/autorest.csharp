// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using System.IO;
using System.Threading.Tasks;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class AzurePluginTarget
    {
        public static async Task ExecuteAsync(GeneratedCodeWorkspace project, InputNamespace inputNamespace)
        {
            // write the configuration.json
            var configurationFilepath = Path.Combine(Configuration.OutputFolder, "Configuration.json");
            await File.WriteAllTextAsync(configurationFilepath, Configuration.SaveConfiguration());
            // serialize inputNamespace to tspCodeModel.json
            var tspCodeModel = TypeSpecSerialization.Serialize(inputNamespace);
            var codeModelFilepath = Path.Combine(Configuration.OutputFolder, "tspCodeModel.json");
            await File.WriteAllTextAsync(codeModelFilepath, tspCodeModel);
            // TODO: spawn a child process to invoke MTG or Azure plugin
            await Task.CompletedTask;
        }
    }
}
