﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public Configuration(string outputFolder, string? ns, string? name, string[] sharedSourceFolders, bool saveInputs, bool azureArm, bool publicClients, bool modelNamespace, bool headAsBoolean, bool skipCSProjPackageReference, string[] credentialTypes, string[] credentialScopes, string credentialHeaderName, bool lowLevelClient, JsonElement? operationGroupToResourceType = default, JsonElement? operationGroupToResource = default, JsonElement? resourceRename = default, JsonElement? operationGroupToParent = default)
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
            CredentialTypes = credentialTypes;
            CredentialScopes = credentialScopes;
            CredentialHeaderName = credentialHeaderName;
            OperationGroupToResourceType = operationGroupToResourceType?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResourceType.ToString());
            OperationGroupToResource = operationGroupToResource?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResource.ToString());
            ResourceRename = resourceRename?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(resourceRename.ToString());
            OperationGroupToParent = operationGroupToParent?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToParent.ToString());
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
        public string[] CredentialTypes { get; }
        public string[] CredentialScopes { get; }
        public string CredentialHeaderName { get; }

        public static string ProjectRelativeDirectory = "../";
        public Dictionary<string, string> OperationGroupToResourceType;
        public Dictionary<string, string> OperationGroupToResource;
        public Dictionary<string, string> ResourceRename;
        public bool LowLevelClient { get; }
        public Dictionary<string, string> OperationGroupToParent;

        public static Configuration GetConfiguration(IPluginCommunication autoRest)
        {
            return new Configuration(
                    TrimFileSuffix(GetRequiredOption<string>(autoRest, "output-folder")),
                autoRest.GetValue<string?>("namespace").GetAwaiter().GetResult(),
                autoRest.GetValue<string?>("library-name").GetAwaiter().GetResult(),
                GetRequiredOption<string[]>(autoRest, "shared-source-folders").Select(TrimFileSuffix).ToArray(),
                autoRest.GetValue<bool?>("save-inputs").GetAwaiter().GetResult() ?? false,
                autoRest.GetValue<bool?>("azure-arm").GetAwaiter().GetResult() ?? false,
                autoRest.GetValue<bool?>("public-clients").GetAwaiter().GetResult() ?? false,
                autoRest.GetValue<bool?>("model-namespace").GetAwaiter().GetResult() ?? true,
                autoRest.GetValue<bool?>("head-as-boolean").GetAwaiter().GetResult() ?? false,
                autoRest.GetValue<bool?>("skip-csproj-packagereference").GetAwaiter().GetResult() ?? false,
                autoRest.GetValue<string[]?>("credential-types").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<string[]?>("credential-scopes").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<string?>("credential-header-name").GetAwaiter().GetResult() ?? "api-key",
                autoRest.GetValue<bool?>("low-level-client").GetAwaiter().GetResult() ?? false,
                autoRest.GetValue<JsonElement?>("operation-group-to-resource-type").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-resource").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("resource-rename").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-parent").GetAwaiter().GetResult()
            );
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
