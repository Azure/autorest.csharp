﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using AutoRest.CSharp.AutoRest.Communication;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class Configuration
    {
        public static class Options
        {
            public const string OutputFolder = "output-folder";
            public const string Namespace = "namespace";
            public const string LibraryName = "library-name";
            public const string SharedSourceFolders = "shared-source-folders";
            public const string SaveInputs = "save-inputs";
            public const string AzureArm = "azure-arm";
            public const string PublicClients = "public-clients";
            public const string ModelNamespace = "model-namespace";
            public const string HeadAsBoolean = "head-as-boolean";
            public const string SkipCSProjPackageReference = "skip-csproj-packagereference";
            public const string DataPlane = "data-plane";
            public const string SingleTopLevelClient = "single-top-level-client";
            public const string AttachDebuggerFormat = "{0}.attach";
            public const string ProjectFolder = "project-folder";
        }

        public Configuration(string outputFolder, string? ns, string? name, string[] sharedSourceFolders, bool saveInputs, bool azureArm, bool publicClients, bool modelNamespace, bool headAsBoolean, bool skipCSProjPackageReference, bool dataplane, bool singleTopLevelClient, string projectFolder, MgmtConfiguration mgmtConfiguration)
        {
            OutputFolder = outputFolder;
            Namespace = ns;
            LibraryName = name;
            SharedSourceFolders = sharedSourceFolders;
            SaveInputs = saveInputs;
            AzureArm = azureArm;
            PublicClients = publicClients || AzureArm;
            ModelNamespace = azureArm || modelNamespace;
            HeadAsBoolean = headAsBoolean;
            SkipCSProjPackageReference = skipCSProjPackageReference;
            DataPlane = dataplane;
            SingleTopLevelClient = singleTopLevelClient;
            ProjectFolder = Path.IsPathRooted(projectFolder) ? Path.GetRelativePath(outputFolder, projectFolder) : projectFolder;
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
        public bool DataPlane { get; }
        public bool SingleTopLevelClient { get; }
        public MgmtConfiguration MgmtConfiguration { get; }

        public string ProjectFolder { get; }

        public static Configuration GetConfiguration(IPluginCommunication autoRest)
        {
            return new Configuration(
                outputFolder: TrimFileSuffix(GetRequiredOption<string>(autoRest, Options.OutputFolder)),
                ns: autoRest.GetValue<string?>(Options.Namespace).GetAwaiter().GetResult(),
                name: autoRest.GetValue<string?>(Options.LibraryName).GetAwaiter().GetResult(),
                sharedSourceFolders: GetRequiredOption<string[]>(autoRest, Options.SharedSourceFolders).Select(TrimFileSuffix).ToArray(),
                saveInputs: GetOptionValue(autoRest, Options.SaveInputs),
                azureArm: GetOptionValue(autoRest, Options.AzureArm),
                publicClients: GetOptionValue(autoRest, Options.PublicClients),
                modelNamespace: GetOptionValue(autoRest, Options.ModelNamespace),
                headAsBoolean: GetOptionValue(autoRest, Options.HeadAsBoolean),
                skipCSProjPackageReference: GetOptionValue(autoRest, Options.SkipCSProjPackageReference),
                dataplane: GetOptionValue(autoRest, Options.DataPlane),
                singleTopLevelClient: GetOptionValue(autoRest, Options.SingleTopLevelClient),
                projectFolder: GetOptionStringValue(autoRest, Options.ProjectFolder, TrimFileSuffix),
                mgmtConfiguration: MgmtConfiguration.GetConfiguration(autoRest)
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
                case Options.SaveInputs:
                    return false;
                case Options.AzureArm:
                    return false;
                case Options.PublicClients:
                    return false;
                case Options.ModelNamespace:
                    return true;
                case Options.HeadAsBoolean:
                    return false;
                case Options.SkipCSProjPackageReference:
                    return false;
                case Options.DataPlane:
                    return false;
                case Options.SingleTopLevelClient:
                    return false;
                default:
                    return null;
            }
        }

        private static string GetOptionStringValue(IPluginCommunication autoRest, string option, Func<string, string>? func)
        {
            var projectFolder = autoRest.GetValue<string?>(Options.ProjectFolder).GetAwaiter().GetResult();
            return projectFolder == null ? GetDefaultOptionStringValue(option)! : (func == null ? projectFolder : func(projectFolder));
        }

        public static string? GetDefaultOptionStringValue(string option)
        {
            switch (option)
            {
                case Options.ProjectFolder:
                    return "../";
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
