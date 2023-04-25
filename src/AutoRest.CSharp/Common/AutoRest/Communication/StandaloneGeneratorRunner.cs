// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.AutoRest.Communication
{
    internal class StandaloneGeneratorRunner
    {
        public static async Task RunAsync(CommandLineOptions options)
        {
            string? projectPath = null;
            string outputPath;
            bool wasProjectPathPassedIn = options.ProjectPath is not null;
            if (options.Standalone is not null)
            {
                //TODO this is only here for back compat we should consider removing it
                outputPath = options.Standalone;
            }
            else
            {
                projectPath = options.ProjectPath!;
                outputPath = Path.Combine(projectPath, "Generated");
            }

            var configurationPath = options.ConfigurationPath ?? Path.Combine(outputPath, "Configuration.json");
            LoadConfiguration(projectPath, outputPath, options.ExistingProjectFolder, File.ReadAllText(configurationPath));

            var codeModelInputPath = Path.Combine(outputPath, "CodeModel.yaml");
            var cadlInputFile = Path.Combine(outputPath, "cadl.json");

            GeneratedCodeWorkspace workspace;
            if (File.Exists(cadlInputFile))
            {
                var json = await File.ReadAllTextAsync(cadlInputFile);
                var rootNamespace = CadlSerialization.Deserialize(json) ?? throw new InvalidOperationException($"Deserializing {cadlInputFile} has failed.");
                workspace = await new CSharpGen().ExecuteAsync(rootNamespace);
                if (options.IsNewProject)
                {
                    // TODO - add support for DataFactoryExpression lookup
                    new CSharpProj().Execute(Configuration.Namespace, outputPath, false);
                }
            }
            else if (File.Exists(codeModelInputPath))
            {
                var yaml = await File.ReadAllTextAsync(codeModelInputPath);
                var codeModel = CodeModelSerialization.DeserializeCodeModel(yaml);
                workspace = await new CSharpGen().ExecuteAsync(codeModel);
                if (options.IsNewProject)
                {
                    new CSharpProj().Execute(Configuration.Namespace, outputPath, (yaml.Contains("x-ms-format: dfe-", StringComparison.Ordinal)));
                }
            }
            else
            {
                throw new InvalidOperationException($"Neither CodeModel.yaml nor cadl.json exist in {outputPath} folder.");
            }

            if (options.ClearOutputFolder)
            {
                var keepFiles = new string[] { "CodeModel.yaml", "Configuration.json", "cadl.json" };
                DeleteDirectory(outputPath, keepFiles);
            }

            await foreach (var file in workspace.GetGeneratedFilesAsync())
            {
                if (string.IsNullOrEmpty(file.Text))
                {
                    continue;
                }
                var filename = Path.Combine(outputPath, file.Name);
                Console.WriteLine($"Writing {filename}");
                Directory.CreateDirectory(Path.GetDirectoryName(filename)!);
                await File.WriteAllTextAsync(filename, file.Text);
            }
        }

        private static void DeleteDirectory(string path, string[] keepFiles)
        {
            var directoryInfo = new DirectoryInfo(path);
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (keepFiles.Contains(file.Name))
                {
                    continue;
                }
                file.Delete();
            }

            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                DeleteDirectory(directory.FullName, keepFiles);
            }

            if (!directoryInfo.EnumerateFileSystemInfos().Any())
            {
                directoryInfo.Delete();
            }
        }

        private static void WriteIfNotDefault<T>(Utf8JsonWriter writer, string option, T enumValue) where T : struct, Enum
        {
            var defaultValue = Configuration.GetDefaultEnumOptionValue(option);
            if (!enumValue.Equals(defaultValue))
            {
                writer.WriteString(option, enumValue.ToString());
            }
        }

        private static void WriteIfNotDefault(Utf8JsonWriter writer, string option, bool value)
        {
            var defaultValue = Configuration.GetDefaultBoolOptionValue(option);
            if (!defaultValue.HasValue || defaultValue.Value != value)
            {
                writer.WriteBoolean(option, value);
            }
        }

        private static void WriteIfNotDefault(Utf8JsonWriter writer, string option, string? value)
        {
            if (value == null)
            {
                return;
            }

            switch (option)
            {
                case Configuration.Options.ProjectFolder:
                    if (value != Configuration.ProjectFolderDefault)
                        writer.WriteString(option, value);
                    break;
                default:
                    writer.WriteString(option, value);
                    break;
            }
        }

        internal static string SaveConfiguration()
        {
            using (var memoryStream = new MemoryStream())
            {
                JsonWriterOptions options = new JsonWriterOptions();
                options.Indented = true;
                using (Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream, options))
                {
                    writer.WriteStartObject();
                    writer.WriteString(nameof(Configuration.OutputFolder), Path.GetRelativePath(Configuration.OutputFolder, Configuration.OutputFolder));
                    writer.WriteString(nameof(Configuration.Namespace), Configuration.Namespace);
                    writer.WriteString(nameof(Configuration.LibraryName), Configuration.LibraryName);
                    writer.WriteStartArray(nameof(Configuration.SharedSourceFolders));
                    foreach (var sharedSourceFolder in Configuration.SharedSourceFolders)
                    {
                        writer.WriteStringValue(NormalizePath(sharedSourceFolder));
                    }
                    writer.WriteEndArray();
                    WriteIfNotDefault(writer, Configuration.Options.AzureArm, Configuration.AzureArm);
                    WriteIfNotDefault(writer, Configuration.Options.PublicClients, Configuration.PublicClients);
                    WriteIfNotDefault(writer, Configuration.Options.ModelNamespace, Configuration.ModelNamespace);
                    WriteIfNotDefault(writer, Configuration.Options.HeadAsBoolean, Configuration.HeadAsBoolean);
                    WriteIfNotDefault(writer, Configuration.Options.SkipCSProjPackageReference, Configuration.SkipCSProjPackageReference);
                    WriteIfNotDefault(writer, Configuration.Options.Generation1ConvenienceClient, Configuration.Generation1ConvenienceClient);
                    WriteIfNotDefault(writer, Configuration.Options.SingleTopLevelClient, Configuration.SingleTopLevelClient);
                    WriteIfNotDefault(writer, Configuration.Options.GenerateModelFactory, Configuration.GenerateModelFactory);
                    Utf8JsonWriterExtensions.WriteNonEmptyArray(writer, Configuration.Options.ModelFactoryForHlc, Configuration.ModelFactoryForHlc);
                    WriteIfNotDefault(writer, Configuration.Options.UnreferencedTypesHandling, Configuration.UnreferencedTypesHandling);
                    WriteIfNotDefault(writer, Configuration.Options.UseOverloadsBetweenProtocolAndConvenience, Configuration.UseOverloadsBetweenProtocolAndConvenience);
                    WriteIfNotDefault(writer, Configuration.Options.ProjectFolder, Configuration.RelativeProjectFolder);
                    Utf8JsonWriterExtensions.WriteNonEmptyArray(writer, nameof(Configuration.Options.ProtocolMethodList), Configuration.ProtocolMethodList);
                    Utf8JsonWriterExtensions.WriteNonEmptyArray(writer, nameof(Configuration.Options.SuppressAbstractBaseClasses), Configuration.SuppressAbstractBaseClasses);
                    Utf8JsonWriterExtensions.WriteNonEmptyArray(writer, nameof(Configuration.Options.ModelsToTreatEmptyStringAsNull), Configuration.ModelsToTreatEmptyStringAsNull.ToList<string>());
                    if (Configuration.ModelsToTreatEmptyStringAsNull.Any())
                    {
                        Utf8JsonWriterExtensions.WriteNonEmptyArray(writer, nameof(Configuration.IntrinsicTypesToTreatEmptyStringAsNull), Configuration.IntrinsicTypesToTreatEmptyStringAsNull.ToList<string>());
                    }

                    Configuration.MgmtConfiguration.SaveConfiguration(writer);

                    if (Configuration.MgmtTestConfiguration != null)
                    {
                        Configuration.MgmtTestConfiguration.SaveConfiguration(writer);
                    }

                    writer.WriteEndObject();
                }

                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        private static string NormalizePath(string sharedSourceFolder)
        {
            return Path.GetRelativePath(Configuration.OutputFolder, sharedSourceFolder);
        }

        private static bool ReadOption(JsonElement root, string option)
        {
            if (root.TryGetProperty(option, out JsonElement value))
            {
                return value.GetBoolean();
            }
            else
            {
                return Configuration.GetDefaultBoolOptionValue(option)!.Value;
            }
        }

        private static T ReadEnumOption<T>(JsonElement root, string option) where T : struct, Enum
        {
            var enumStr = ReadStringOption(root, option);
            return Configuration.GetOptionEnumValueFromString<T>(option, enumStr);
        }

        private static string? ReadStringOption(JsonElement root, string option)
        {
            if (root.TryGetProperty(option, out JsonElement value))
                return value.GetString();

            return null;
        }

        internal static void LoadConfiguration(string? projectPath, string outputPath, string? existingProjectFolder, string json)
        {
            JsonDocument document = JsonDocument.Parse(json);
            var root = document.RootElement;
            var sharedSourceFolders = new List<string>();

            foreach (var sharedSourceFolder in root.GetProperty(nameof(Configuration.SharedSourceFolders)).EnumerateArray())
            {
                sharedSourceFolders.Add(Path.Combine(outputPath, sharedSourceFolder.GetString()!));
            }

            root.TryGetProperty(nameof(Configuration.Options.ProtocolMethodList), out var protocolMethodList);
            var protocolMethods = Configuration.DeserializeArray(protocolMethodList);
            root.TryGetProperty(nameof(Configuration.Options.SuppressAbstractBaseClasses), out var suppressAbstractBaseClassesElement);
            var suppressAbstractBaseClasses = Configuration.DeserializeArray(suppressAbstractBaseClassesElement);
            root.TryGetProperty(nameof(Configuration.Options.ModelsToTreatEmptyStringAsNull), out var modelsToTreatEmptyStringAsNullElement);
            var modelsToTreatEmptyStringAsNull = Configuration.DeserializeArray(modelsToTreatEmptyStringAsNullElement);
            root.TryGetProperty(nameof(Configuration.IntrinsicTypesToTreatEmptyStringAsNull), out var intrinsicTypesToTreatEmptyStringAsNullElement);
            var intrinsicTypesToTreatEmptyStringAsNull = Configuration.DeserializeArray(intrinsicTypesToTreatEmptyStringAsNullElement);
            root.TryGetProperty(nameof(Configuration.Options.ModelFactoryForHlc), out var oldModelFactoryEntriesElement);
            var oldModelFactoryEntries = Configuration.DeserializeArray(oldModelFactoryEntriesElement);

            Configuration.Initialize(
                Path.Combine(outputPath, root.GetProperty(nameof(Configuration.OutputFolder)).GetString()!),
                root.GetProperty(nameof(Configuration.Namespace)).GetString()!,
                root.GetProperty(nameof(Configuration.LibraryName)).GetString()!,
                sharedSourceFolders.ToArray(),
                saveInputs: false,
                ReadOption(root, Configuration.Options.AzureArm),
                ReadOption(root, Configuration.Options.PublicClients),
                ReadOption(root, Configuration.Options.ModelNamespace),
                ReadOption(root, Configuration.Options.HeadAsBoolean),
                ReadOption(root, Configuration.Options.SkipCSProjPackageReference),
                ReadOption(root, Configuration.Options.Generation1ConvenienceClient),
                ReadOption(root, Configuration.Options.SingleTopLevelClient),
                ReadOption(root, Configuration.Options.SkipSerializationFormatXml),
                ReadOption(root, Configuration.Options.DisablePaginationTopRenaming),
                ReadOption(root, Configuration.Options.GenerateModelFactory),
                ReadOption(root, Configuration.Options.PublicDiscriminatorProperty),
                oldModelFactoryEntries,
                ReadEnumOption<Configuration.UnreferencedTypesHandlingOption>(root, Configuration.Options.UnreferencedTypesHandling),
                ReadOption(root, Configuration.Options.UseOverloadsBetweenProtocolAndConvenience),
                projectPath ?? ReadStringOption(root, Configuration.Options.ProjectFolder),
                existingProjectFolder,
                protocolMethods,
                suppressAbstractBaseClasses,
                modelsToTreatEmptyStringAsNull,
                intrinsicTypesToTreatEmptyStringAsNull,
                MgmtConfiguration.LoadConfiguration(root),
                MgmtTestConfiguration.LoadConfiguration(root)
            );
        }
    }
}
