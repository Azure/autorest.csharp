// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.V3.AutoRest.Communication;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
{
    internal class Configuration
    {
        public string OutputFolder { get; }
        public string Namespace { get; }
        public string Title { get; }
        public string SharedSourceFolder { get; }
        public bool SaveCodeModel { get; }

        public Configuration(IPluginCommunication autoRest)
        {
            OutputFolder = new Uri(GetRequiredOption(autoRest, "output-folder")).LocalPath;
            SharedSourceFolder = new Uri(GetRequiredOption(autoRest, "shared-source-folder")).LocalPath;
            Namespace = autoRest.GetValue<string?>("namespace").GetAwaiter().GetResult() ?? "Sample";
            Title = autoRest.GetValue<string?>("title").GetAwaiter().GetResult() ?? "Sample";
            SaveCodeModel = autoRest.GetValue<bool?>("save-code-model").GetAwaiter().GetResult() ?? false;
        }

        private static string GetRequiredOption(IPluginCommunication autoRest, string name)
        {
            return autoRest.GetValue<string?>(name).GetAwaiter().GetResult() ?? throw new InvalidOperationException($"{name} configuration parameter is required");
        }
    }
}
