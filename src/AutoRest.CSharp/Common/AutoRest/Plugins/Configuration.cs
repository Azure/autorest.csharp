﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.AutoRest.Communication;
using Azure.Core;

namespace AutoRest.CSharp.Input
{
    internal static class Configuration
    {
        internal static readonly string ProjectFolderDefault = "../";

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
            public const string ExistingProjectfolder = "existing-project-folder";
            public const string ProtocolMethodList = "protocol-method-list";
            public const string SkipSerializationFormatXml = "skip-serialization-format-xml";
            public const string DisablePaginationTopRenaming = "disable-pagination-top-renaming";
            public const string SuppressAbstractBaseClasses = "suppress-abstract-base-class";
            public const string UnreferencedTypesHandling = "unreferenced-types-handling";
            public const string UseOverloadsBetweenProtocolAndConvenience = "use-overloads-between-protocol-and-convenience";
            public const string ModelFactoryForHlc = "model-factory-for-hlc";
            public const string GenerateModelFactory = "generate-model-factory";
            public const string ModelsToTreatEmptyStringAsNull = "models-to-treat-empty-string-as-null";
            public const string AdditionalIntrinsicTypesToTreatEmptyStringAsNull = "additional-intrinsic-types-to-treat-empty-string-as-null";
            public const string PublicDiscriminatorProperty = "public-discriminator-property";
            public const string ShouldTreatBase64AsBinaryData = "should-treat-base64-as-binary-data";
        }

        public enum UnreferencedTypesHandlingOption
        {
            RemoveOrInternalize = 0,
            Internalize = 1,
            KeepAll = 2
        }

        public static void Initialize(
            string outputFolder,
            string ns,
            string libraryName,
            string[] sharedSourceFolders,
            bool saveInputs,
            bool azureArm,
            bool publicClients,
            bool modelNamespace,
            bool headAsBoolean,
            bool skipCSProjPackageReference,
            bool generation1ConvenienceClient,
            bool singleTopLevelClient,
            bool skipSerializationFormatXml,
            bool disablePaginationTopRenaming,
            bool generateModelFactory,
            bool publicDiscriminatorProperty,
            IReadOnlyList<string> modelFactoryForHlc,
            UnreferencedTypesHandlingOption unreferencedTypesHandling,
            bool useOverloadsBetweenProtocolAndConvenience,
            string? projectFolder,
            string? existingProjectFolder,
            IReadOnlyList<string> protocolMethodList,
            IReadOnlyList<string> suppressAbstractBaseClasses,
            IReadOnlyList<string> modelsToTreatEmptyStringAsNull,
            IReadOnlyList<string> additionalIntrinsicTypesToTreatEmptyStringAsNull,
            bool shouldTreatBase64AsBinaryData,
            MgmtConfiguration mgmtConfiguration,
            MgmtTestConfiguration? mgmtTestConfiguration)
        {
            _outputFolder = outputFolder;
            _namespace = ns;
            _libraryName = libraryName;
            _sharedSourceFolders = sharedSourceFolders;
            SaveInputs = saveInputs;
            AzureArm = azureArm;
            PublicClients = publicClients || AzureArm;
            ModelNamespace = azureArm || modelNamespace;
            HeadAsBoolean = headAsBoolean;
            SkipCSProjPackageReference = skipCSProjPackageReference;
            Generation1ConvenienceClient = generation1ConvenienceClient;
            SingleTopLevelClient = singleTopLevelClient;
            GenerateModelFactory = generateModelFactory;
            PublicDiscriminatorProperty = publicDiscriminatorProperty;
            UnreferencedTypesHandling = unreferencedTypesHandling;
            UseOverloadsBetweenProtocolAndConvenience = useOverloadsBetweenProtocolAndConvenience;
            ShouldTreatBase64AsBinaryData = (!azureArm && !generation1ConvenienceClient) ? shouldTreatBase64AsBinaryData : false;
            projectFolder ??= ProjectFolderDefault;
            if (Path.IsPathRooted(projectFolder))
            {
                _absoluteProjectFolder = projectFolder;
                projectFolder = Path.GetRelativePath(outputFolder, projectFolder);
            }
            else
            {
                _absoluteProjectFolder = Path.GetFullPath(Path.Combine(outputFolder, projectFolder));
            }

            ExistingProjectFolder = existingProjectFolder == null ? DownloadLatestContract(_absoluteProjectFolder) : Path.GetFullPath(Path.Combine(_absoluteProjectFolder, existingProjectFolder));
            var isAzureProject = ns.StartsWith("Azure.") || ns.StartsWith("Microsoft.Azure");
            // we only check the combination for Azure projects whose namespace starts with "Azure." or "Microsoft.Azure."
            // issue: https://github.com/Azure/autorest.csharp/issues/3179
            if (publicClients && generation1ConvenienceClient && isAzureProject)
            {
                var binaryLocation = typeof(Configuration).Assembly.Location;
                if (!binaryLocation.EndsWith(Path.Combine("artifacts", "bin", "AutoRest.CSharp", "Debug", "net6.0", "AutoRest.CSharp.dll")))
                {
                    if (_absoluteProjectFolder is not null)
                    {
                        //TODO Remove after resolving https://github.com/Azure/autorest.csharp/issues/3151
                        var absoluteProjectFolderSPlit = new HashSet<string>(_absoluteProjectFolder.Split(Path.DirectorySeparatorChar), StringComparer.Ordinal);
                        if (!absoluteProjectFolderSPlit.Contains("src") ||
                            (!absoluteProjectFolderSPlit.Contains("Azure.Analytics.Synapse.Spark") &&
                            !absoluteProjectFolderSPlit.Contains("Azure.Analytics.Synapse.Monitoring") &&
                            !absoluteProjectFolderSPlit.Contains("Azure.Analytics.Synapse.ManagedPrivateEndpoints") &&
                            !absoluteProjectFolderSPlit.Contains("Azure.Analytics.Synapse.Artifacts") &&
                            !absoluteProjectFolderSPlit.Contains("Azure.Communication.PhoneNumbers")))
                            throw new Exception($"Unsupported combination of settings both {Options.PublicClients} and {Options.Generation1ConvenienceClient} cannot be true at the same time.");
                    }
                }
            }

            _relativeProjectFolder = projectFolder;
            _protocolMethodList = protocolMethodList;
            SkipSerializationFormatXml = skipSerializationFormatXml;
            DisablePaginationTopRenaming = disablePaginationTopRenaming;
            _oldModelFactoryEntries = modelFactoryForHlc;
            _mgmtConfiguration = mgmtConfiguration;
            MgmtTestConfiguration = mgmtTestConfiguration;
            _suppressAbstractBaseClasses = suppressAbstractBaseClasses;
            _modelsToTreatEmptyStringAsNull = new HashSet<string>(modelsToTreatEmptyStringAsNull);
            _intrinsicTypesToTreatEmptyStringAsNull.UnionWith(additionalIntrinsicTypesToTreatEmptyStringAsNull);
        }

        private static string? DownloadLatestContract(string projectFolder)
        {
            if (AzureArm || Generation1ConvenienceClient)
            {
                return null;
            }

            int sdkFolderIndex = projectFolder.LastIndexOf("\\sdk\\", StringComparison.InvariantCultureIgnoreCase);
            if (sdkFolderIndex == -1)
            {
                return null;
            }

            string rootFolder = projectFolder.Substring(0, sdkFolderIndex);
            var scriptPath = Path.Join(rootFolder, "eng", "common", "scripts", "Download-Latest-Contract.ps1");
            if (File.Exists(scriptPath))
            {
                string projectDirectory = projectFolder.EndsWith("src") ? Path.GetFullPath(Path.Join(projectFolder, "..")) : projectFolder;
                var scriptStartInfo = new ProcessStartInfo("pwsh", $"-ExecutionPolicy ByPass {scriptPath} {projectDirectory}")
                {
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WorkingDirectory = rootFolder
                };
                var scriptProcess = Process.Start(scriptStartInfo);
                if (scriptProcess != null)
                {
                    scriptProcess.WaitForExit();

                    string projectName = new DirectoryInfo(projectDirectory).Name;
                    string relativeProject = projectFolder.Substring(sdkFolderIndex);
                    return Path.GetFullPath(Path.Join(rootFolder, "..", "sparse-spec", "sdk", projectName, relativeProject));
                }
            }

            return null;
        }

        public static bool ShouldTreatBase64AsBinaryData { get; private set; }

        private static string? _outputFolder;
        public static string OutputFolder => _outputFolder ?? throw new InvalidOperationException("Configuration has not been initialized");
        public static string? ExistingProjectFolder { get; private set; }

        private static string? _namespace;
        public static string Namespace => _namespace ?? throw new InvalidOperationException("Configuration has not been initialized");

        private static string? _libraryName;
        public static string LibraryName => _libraryName ?? throw new InvalidOperationException("Configuration has not been initialized");

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
        public static bool SkipSerializationFormatXml { get; private set; }
        public static bool DisablePaginationTopRenaming { get; private set; }

        /// <summary>
        /// Whether we will generate model factory for this library.
        /// If true (default), the model factory will be generated. If false, the model factory will not be generated.
        /// </summary>
        public static bool GenerateModelFactory { get; private set; }

        /// <summary>
        /// Whether we will generate the discriminator property as public or internal.
        /// If true, the discriminator property will be public. If false (default), the discriminator property will be internal.
        /// </summary>
        public static bool PublicDiscriminatorProperty { get; private set; }
        public static bool UseOverloadsBetweenProtocolAndConvenience { get; private set; }

        private static IReadOnlyList<string>? _oldModelFactoryEntries;
        /// <summary>
        /// This is a shim flag that keeps the old behavior of model factory generation. This configuration should be only used on HLC packages.
        /// </summary>
        public static IReadOnlyList<string> ModelFactoryForHlc => _oldModelFactoryEntries ?? throw new InvalidOperationException("Configuration has not been initialized");
        public static UnreferencedTypesHandlingOption UnreferencedTypesHandling { get; private set; }
        private static IReadOnlyList<string>? _suppressAbstractBaseClasses;
        public static IReadOnlyList<string> SuppressAbstractBaseClasses => _suppressAbstractBaseClasses ?? throw new InvalidOperationException("Configuration has not been initialized");

        private static IReadOnlyList<string>? _protocolMethodList;
        public static IReadOnlyList<string> ProtocolMethodList => _protocolMethodList ?? throw new InvalidOperationException("Configuration has not been initialized");

        private static HashSet<string>? _modelsToTreatEmptyStringAsNull;
        public static HashSet<string> ModelsToTreatEmptyStringAsNull => _modelsToTreatEmptyStringAsNull ?? throw new InvalidOperationException("Configuration has not been initialized");

        private static HashSet<string> _intrinsicTypesToTreatEmptyStringAsNull = new HashSet<string>() { nameof(Uri), nameof(Guid), nameof(ResourceIdentifier), nameof(DateTimeOffset) };
        public static HashSet<string> IntrinsicTypesToTreatEmptyStringAsNull => _intrinsicTypesToTreatEmptyStringAsNull;

        private static MgmtConfiguration? _mgmtConfiguration;
        public static MgmtConfiguration MgmtConfiguration => _mgmtConfiguration ?? throw new InvalidOperationException("Configuration has not been initialized");

        public static MgmtTestConfiguration? MgmtTestConfiguration { get; private set; }

        private static string? _relativeProjectFolder;
        public static string RelativeProjectFolder => _relativeProjectFolder ?? throw new InvalidOperationException("Configuration has not been initialized");
        private static string? _absoluteProjectFolder;
        public static string AbsoluteProjectFolder => _absoluteProjectFolder ?? throw new InvalidOperationException("Configuration has not been initialized");

        public static void Initialize(IPluginCommunication autoRest, string defaultNamespace, string defaultLibraryName)
        {
            Initialize(
                outputFolder: TrimFileSuffix(GetRequiredOption<string>(autoRest, Options.OutputFolder)),
                ns: autoRest.GetValue<string?>(Options.Namespace).GetAwaiter().GetResult() ?? defaultNamespace,
                libraryName: autoRest.GetValue<string?>(Options.LibraryName).GetAwaiter().GetResult() ?? defaultLibraryName,
                sharedSourceFolders: GetRequiredOption<string[]>(autoRest, Options.SharedSourceFolders).Select(TrimFileSuffix).ToArray(),
                saveInputs: GetOptionBoolValue(autoRest, Options.SaveInputs),
                azureArm: GetOptionBoolValue(autoRest, Options.AzureArm),
                publicClients: GetOptionBoolValue(autoRest, Options.PublicClients),
                modelNamespace: GetOptionBoolValue(autoRest, Options.ModelNamespace),
                headAsBoolean: GetOptionBoolValue(autoRest, Options.HeadAsBoolean),
                skipCSProjPackageReference: GetOptionBoolValue(autoRest, Options.SkipCSProjPackageReference),
                generation1ConvenienceClient: GetOptionBoolValue(autoRest, Options.Generation1ConvenienceClient),
                singleTopLevelClient: GetOptionBoolValue(autoRest, Options.SingleTopLevelClient),
                skipSerializationFormatXml: GetOptionBoolValue(autoRest, Options.SkipSerializationFormatXml),
                disablePaginationTopRenaming: GetOptionBoolValue(autoRest, Options.DisablePaginationTopRenaming),
                generateModelFactory: GetOptionBoolValue(autoRest, Options.GenerateModelFactory),
                publicDiscriminatorProperty: GetOptionBoolValue(autoRest, Options.PublicDiscriminatorProperty),
                modelFactoryForHlc: autoRest.GetValue<string[]?>(Options.ModelFactoryForHlc).GetAwaiter().GetResult() ?? Array.Empty<string>(),
                unreferencedTypesHandling: GetOptionEnumValue<UnreferencedTypesHandlingOption>(autoRest, Options.UnreferencedTypesHandling),
                useOverloadsBetweenProtocolAndConvenience: GetOptionBoolValue(autoRest, Options.UseOverloadsBetweenProtocolAndConvenience),
                projectFolder: autoRest.GetValue<string?>(Options.ProjectFolder).GetAwaiter().GetResult(),
                existingProjectFolder: autoRest.GetValue<string?>(Options.ExistingProjectfolder).GetAwaiter().GetResult(),
                protocolMethodList: autoRest.GetValue<string[]?>(Options.ProtocolMethodList).GetAwaiter().GetResult() ?? Array.Empty<string>(),
                suppressAbstractBaseClasses: autoRest.GetValue<string[]?>(Options.SuppressAbstractBaseClasses).GetAwaiter().GetResult() ?? Array.Empty<string>(),
                modelsToTreatEmptyStringAsNull: autoRest.GetValue<string[]?>(Options.ModelsToTreatEmptyStringAsNull).GetAwaiter().GetResult() ?? Array.Empty<string>(),
                additionalIntrinsicTypesToTreatEmptyStringAsNull: autoRest.GetValue<string[]?>(Options.AdditionalIntrinsicTypesToTreatEmptyStringAsNull).GetAwaiter().GetResult() ?? Array.Empty<string>(),
                shouldTreatBase64AsBinaryData: GetOptionBoolValue(autoRest, Options.ShouldTreatBase64AsBinaryData),
                mgmtConfiguration: MgmtConfiguration.GetConfiguration(autoRest),
                mgmtTestConfiguration: MgmtTestConfiguration.GetConfiguration(autoRest)
            );
        }

        private static T GetOptionEnumValue<T>(IPluginCommunication autoRest, string option) where T : struct, Enum
        {
            var enumStr = autoRest.GetValue<string?>(option).GetAwaiter().GetResult();
            return GetOptionEnumValueFromString<T>(option, enumStr);
        }

        internal static T GetOptionEnumValueFromString<T>(string option, string? enumStrValue) where T : struct, Enum
        {
            if (Enum.TryParse<T>(enumStrValue, true, out var enumValue))
            {
                return enumValue;
            }

            return (T)GetDefaultEnumOptionValue(option)!;
        }

        public static Enum? GetDefaultEnumOptionValue(string option) => option switch
        {
            Options.UnreferencedTypesHandling => UnreferencedTypesHandlingOption.RemoveOrInternalize,
            _ => null
        };

        private static bool GetOptionBoolValue(IPluginCommunication autoRest, string option)
        {
            return autoRest.GetValue<bool?>(option).GetAwaiter().GetResult() ?? GetDefaultBoolOptionValue(option)!.Value;
        }

        public static bool? GetDefaultBoolOptionValue(string option)
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
                case Options.SkipSerializationFormatXml:
                    return false;
                case Options.DisablePaginationTopRenaming:
                    return false;
                case Options.GenerateModelFactory:
                    return true;
                case Options.PublicDiscriminatorProperty:
                    return false;
                case Options.UseOverloadsBetweenProtocolAndConvenience:
                    return true;
                case Options.ShouldTreatBase64AsBinaryData:
                    return true;
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

        internal static bool IsValidJsonElement(JsonElement? element)
        {
            return element != null && element?.ValueKind != JsonValueKind.Null && element?.ValueKind != JsonValueKind.Undefined;
        }

        public static bool DeserializeBoolean(JsonElement? jsonElement, bool defaultValue = false)
            => jsonElement == null || !Configuration.IsValidJsonElement(jsonElement) ? defaultValue : Convert.ToBoolean(jsonElement.ToString());

        public static IReadOnlyList<string> DeserializeArray(JsonElement jsonElement)
            => jsonElement.ValueKind != JsonValueKind.Array ? Array.Empty<string>() : jsonElement.EnumerateArray().Select(t => t.ToString()).ToArray();
    }
}
