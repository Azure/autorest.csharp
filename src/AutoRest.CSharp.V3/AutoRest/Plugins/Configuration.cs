// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using AutoRest.CSharp.V3.AutoRest.Communication;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
{
    internal class Configuration
    {
        public Configuration(string outputFolder, string ns, string? title, string sharedSourceFolder, bool saveInputs, bool azureArm)
        {
            OutputFolder = outputFolder;
            Namespace = ns;
            Title = title;
            SharedSourceFolder = sharedSourceFolder;
            SaveInputs = saveInputs;
            AzureArm = azureArm;
        }

        public string OutputFolder { get; }
        public string Namespace { get; }
        public string? Title { get; }
        public string SharedSourceFolder { get; }
        public bool SaveInputs { get; }
        public bool AzureArm { get; }
    }
}
