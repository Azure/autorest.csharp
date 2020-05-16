// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
{
    internal class Configuration
    {
        public Configuration(string outputFolder, string ns, string? name, string sharedSourceFolder, bool saveInputs, bool azureArm)
        {
            OutputFolder = outputFolder;
            Namespace = ns;
            var namespaceParts = ns.Split('.');
            LibraryName = name ?? namespaceParts.Last();
            SharedSourceFolder = sharedSourceFolder;
            SaveInputs = saveInputs;
            AzureArm = azureArm;
        }

        public string OutputFolder { get; }
        public string Namespace { get; }
        public string LibraryName { get; }
        public string SharedSourceFolder { get; }
        public bool SaveInputs { get; }
        public bool AzureArm { get; }
    }
}
