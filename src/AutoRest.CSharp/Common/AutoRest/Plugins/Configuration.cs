// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection.Metadata;
using AutoRest.CSharp.AutoRest.Communication;
using System.Text.Json;
using System.Collections.Generic;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class Configuration
    {
        public Configuration(string outputFolder, string? ns, string? name, string[] sharedSourceFolders, bool saveInputs, bool azureArm, bool publicClients, bool modelNamespace, bool headAsBoolean, bool skipCSProjPackageReference, bool lowLevelClient, MgmtConfiguration mgmtConfiguration)
        {
            OutputFolder = outputFolder;
            Namespace = ns;
            LibraryName = name;
            SharedSourceFolders = sharedSourceFolders;
            SaveInputs = saveInputs;
            AzureArm = azureArm;
            PublicClients = publicClients || AzureArm;
            ModelNamespace = modelNamespace;
            HeadAsBoolean = headAsBoolean;
            SkipCSProjPackageReference = skipCSProjPackageReference;
            LowLevelClient = lowLevelClient;
            MgmtConfiguration = mgmtConfiguration;
        }

        public string OutputFolder { get; }
        public string? Namespace { get; }
        public string? LibraryName { get; }
        public string[] SharedSourceFolders { get; }
        public bool SaveInputs { get; }
        public bool AzureArm { get; }
        public bool PublicClients { get; }
        public bool ModelNamespace { get; }
        public bool HeadAsBoolean { get; }
        public bool SkipCSProjPackageReference { get; }
        public static string ProjectRelativeDirectory = "../";
        public bool LowLevelClient { get; }
        public MgmtConfiguration MgmtConfiguration { get; }

        public static Configuration GetConfiguration(IPluginCommunication autoRest)
        {
            return new Configuration(
                TrimFileSuffix(GetRequiredOption<string>(autoRest, "output-folder")),
                autoRest.GetValue<string?>("namespace").GetAwaiter().GetResult(),
                autoRest.GetValue<string?>("library-name").GetAwaiter().GetResult(),
                GetRequiredOption<string[]>(autoRest, "shared-source-folders").Select(TrimFileSuffix).ToArray(),
                GetOptionValue(autoRest, "save-inputs"),
                GetOptionValue(autoRest, "azure-arm"),
                GetOptionValue(autoRest, "public-clients"),
                GetOptionValue(autoRest, "model-namespace"),
                GetOptionValue(autoRest, "head-as-boolean"),
                GetOptionValue(autoRest, "skip-csproj-packagereference"),
                GetOptionValue(autoRest, "low-level-client"),
                MgmtConfiguration.GetConfiguration(autoRest)
            );
        }

        private static bool GetOptionValue(IPluginCommunication autoRest, string option)
        {
            return autoRest.GetValue<bool?>(option).GetAwaiter().GetResult() ?? GetDefaultOptionValue(option)!.Value;
        }

        public static bool? GetDefaultOptionValue(string option)
        {
            switch (option)
            {
                case "save-inputs":
                    return false;
                case "azure-arm":
                    return false;
                case "public-clients":
                    return false;
                case "model-namespace":
                    return true;
                case "head-as-boolean":
                    return false;
                case "skip-csproj-packagereference":
                    return false;
                case "low-level-client":
                    return false;
                default:
                    return null;
            }
        }

        private static T GetRequiredOption<T>(IPluginCommunication autoRest, string name)
        {
            return autoRest.GetValue<T>(name).GetAwaiter().GetResult() ?? throw new InvalidOperationException($"{name} configuration parameter is required");
        }

        private static string TrimFileSuffix(string path)
        {
            if (Uri.IsWellFormedUriString(path, UriKind.Absolute))
            {
                path = new Uri(path).LocalPath;
            }

            return path;
        }
    }
}
