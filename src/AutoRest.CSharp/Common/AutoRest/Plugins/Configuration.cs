// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using AutoRest.CSharp.AutoRest.Communication;

namespace AutoRest.CSharp.Input
{
    internal static class Configuration
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
            public const string Generation1ConvenienceClient = "generation1-convenience-client";
            public const string SingleTopLevelClient = "single-top-level-client";
            public const string AttachDebuggerFormat = "{0}.attach";
            public const string ProjectFolder = "project-folder";
            public const string ProtocolMethodList = "protocol-method-list";
        }

        public static void Initialize(string outputFolder, string? ns, string? name, string[] sharedSourceFolders, bool saveInputs, bool azureArm, bool publicClients, bool modelNamespace, bool headAsBoolean, bool skipCSProjPackageReference, bool generation1ConvenienceClient, bool singleTopLevelClient, string projectFolder, string[] protocolMethodList, MgmtConfiguration mgmtConfiguration)
        {
            _outputFolder = outputFolder;
            Namespace = ns;
            LibraryName = name;
            _sharedSourceFolders = sharedSourceFolders;
            SaveInputs = saveInputs;
            AzureArm = azureArm;
            PublicClients = publicClients || AzureArm;
            ModelNamespace = azureArm || modelNamespace;
            HeadAsBoolean = headAsBoolean;
            SkipCSProjPackageReference = skipCSProjPackageReference;
            Generation1ConvenienceClient = generation1ConvenienceClient;
            SingleTopLevelClient = singleTopLevelClient;
            _projectFolder = Path.IsPathRooted(projectFolder) ? Path.GetRelativePath(outputFolder, projectFolder) : projectFolder;
            _protocolMethodList = protocolMethodList;
            _mgmtConfiguration = mgmtConfiguration;
        }

        private static string? _outputFolder;
        public static string OutputFolder => _outputFolder ?? throw new InvalidOperationException("Configuration has not been initialized");
        public static string? Namespace { get; private set; }
        public static string? LibraryName { get; private set; }

        private static string[]? _sharedSourceFolders;
        public static string[] SharedSourceFolders => _sharedSourceFolders ?? throw new InvalidOperationException("Configuration has not been initialized");
        public static bool SaveInputs { get; private set; }
        public static bool AzureArm { get; private set; }
        public static bool PublicClients { get; private set; }
        public static bool ModelNamespace { get; private set; }
        public static bool HeadAsBoolean { get; private set; }
        public static bool SkipCSProjPackageReference { get; private set; }
        public static bool Generation1ConvenienceClient { get; private set; }
        public static bool SingleTopLevelClient { get; private set; }

        private static string[]? _protocolMethodList;
        public static string[] ProtocolMethodList => _protocolMethodList ?? throw new InvalidOperationException("Configuration has not been initialized");

        private static MgmtConfiguration? _mgmtConfiguration;
        public static MgmtConfiguration MgmtConfiguration => _mgmtConfiguration ?? throw new InvalidOperationException("Configuration has not been initialized");

        private static string? _projectFolder;
        public static string ProjectFolder => _projectFolder ?? throw new InvalidOperationException("Configuration has not been initialized");

        public static void Initialize(IPluginCommunication autoRest)
        {
            Initialize(
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
                generation1ConvenienceClient: GetOptionValue(autoRest, Options.Generation1ConvenienceClient),
                singleTopLevelClient: GetOptionValue(autoRest, Options.SingleTopLevelClient),
                projectFolder: GetOptionStringValue(autoRest, Options.ProjectFolder, TrimFileSuffix),
                protocolMethodList: autoRest.GetValue<string[]?>(Options.ProtocolMethodList).GetAwaiter().GetResult() ?? Array.Empty<string>(),
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
                case Options.Generation1ConvenienceClient:
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
