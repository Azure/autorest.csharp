// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
{
    internal class Configuration
    {
        public Configuration(string outputFolder, string ns, string? name, string[] sharedSourceFolders, bool saveInputs, bool azureArm, bool publicClients)
        {
            OutputFolder = outputFolder;
            Namespace = ns;
            var namespaceParts = ns.Split('.');
            LibraryName = name ?? namespaceParts.Last();
            SharedSourceFolders = sharedSourceFolders;
            SaveInputs = saveInputs;
            AzureArm = azureArm;
            PublicClients = publicClients || AzureArm;
        }


        public string OutputFolder { get; }
        public string Namespace { get; }
        public string LibraryName { get; }
        public string[] SharedSourceFolders { get; }
        public bool SaveInputs { get; }
        public bool AzureArm { get; }
        public bool PublicClients { get; }
    }
}
