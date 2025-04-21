// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MicrosoftTypeSpecGeneratorTarget
    {
        public static async Task ExecuteAsync(GeneratedCodeWorkspace project, InputNamespace inputNamespace)
        {
            // normalize the output folder
            var outputFolder = NormalizeOutputFolder(Configuration.OutputFolder);
            // write the configuration.json
            var configurationFilepath = Path.Combine(outputFolder, "Configuration.json");
            await File.WriteAllTextAsync(configurationFilepath, Configuration.SaveConfiguration());
            // serialize inputNamespace to tspCodeModel.json
            var tspCodeModel = TypeSpecSerialization.Serialize(inputNamespace);
            var codeModelFilepath = Path.Combine(outputFolder, "tspCodeModel.json");
            await File.WriteAllTextAsync(codeModelFilepath, tspCodeModel);
            // TODO: spawn a child process to invoke MTG or Azure plugin
        }

        private static string NormalizeOutputFolder(string outputFolder)
        {
            var fullpath = Path.GetFullPath(outputFolder);
            var index = fullpath.LastIndexOf(Path.DirectorySeparatorChar);
            if (index < 0)
            {
                return outputFolder;
            }
            if (fullpath[(index + 1)..] == "Generated")
            {
                return fullpath[..index];
            }
            return outputFolder;
        }
    }
}
