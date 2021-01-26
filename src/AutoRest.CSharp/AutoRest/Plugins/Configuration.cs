// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class Configuration
    {
        public Configuration(string outputFolder, string? ns, string? name, string[] sharedSourceFolders, bool saveInputs, bool azureArm, bool publicClients, bool modelNamespace, bool headAsBoolean, string defaultLibraryName)
        {
            OutputFolder = outputFolder;
            Namespace = ns ?? defaultLibraryName;
            LibraryName = name ?? defaultLibraryName;
            SharedSourceFolders = sharedSourceFolders;
            SaveInputs = saveInputs;
            AzureArm = azureArm;
            PublicClients = publicClients || AzureArm;
            ModelNamespace = modelNamespace;
            HeadAsBoolean = headAsBoolean;
        }


        public string OutputFolder { get; }
        public string Namespace { get; }
        public string LibraryName { get; }
        public string[] SharedSourceFolders { get; }
        public bool SaveInputs { get; }
        public bool AzureArm { get; }
        public bool PublicClients { get; }
        public bool ModelNamespace { get; }
        public bool HeadAsBoolean { get; }
        public static string ProjectRelativeDirectory = "../";
    }
}
