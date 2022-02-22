// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using Azure.Core;

namespace AutoRest.CSharp.AutoRest.Communication
{
    internal class StandaloneGeneratorRunner
    {
        public static async Task RunAsync(string[] args)
        {
            var basePath = args.Single(a => !a.StartsWith("--"));

            LoadConfiguration(basePath, File.ReadAllText(Path.Combine(basePath, "Configuration.json")));
            var codeModelTask = Task.Run(() => CodeModelSerialization.DeserializeCodeModel(File.ReadAllText(Path.Combine(basePath, "CodeModel.yaml"))));
            var workspace = await new CSharpGen().ExecuteAsync(codeModelTask);

            await foreach (var file in workspace.GetGeneratedFilesAsync())
            {
                if (string.IsNullOrEmpty(file.Text))
                {
                    continue;
                }
                var filename = Path.Combine(basePath, file.Name);
                Console.WriteLine($"Writing {filename}");
                Directory.CreateDirectory(Path.GetDirectoryName(filename));
                await File.WriteAllTextAsync(filename, file.Text);
            }
        }

        private static void WriteIfNotDefault(Utf8JsonWriter writer, string option, bool value)
        {
            var defaultValue = Configuration.GetDefaultOptionValue (option);
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
            var defaultValue = Configuration.GetDefaultOptionStringValue(option);
            if (defaultValue == null || defaultValue != value)
            {
                writer.WriteString(option, value);
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
                    WriteIfNotDefault(writer, Configuration.Options.DataPlane, Configuration.DataPlane);
                    WriteIfNotDefault(writer, Configuration.Options.SingleTopLevelClient, Configuration.SingleTopLevelClient);
                    WriteIfNotDefault(writer, Configuration.Options.ProjectFolder, Configuration.ProjectFolder);
                    Utf8JsonWriterExtensions.WriteNonEmptyArray(writer, nameof(Configuration.ProtocolMethodList), Configuration.ProtocolMethodList);

                    Configuration.MgmtConfiguration.SaveConfiguration(writer);

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
                return Configuration.GetDefaultOptionValue(option)!.Value;
            }
        }

        private static string ReadStringOption(JsonElement root, string option)
        {
            if (root.TryGetProperty(option, out JsonElement value))
            {
                return value.GetString();
            }
            else
            {
                return Configuration.GetDefaultOptionStringValue(option)!;
            }
        }

        internal static void LoadConfiguration(string basePath, string json)
        {
            JsonDocument document = JsonDocument.Parse(json);
            var root = document.RootElement;
            var sharedSourceFolders = new List<string>();

            foreach (var sharedSourceFolder in root.GetProperty(nameof(Configuration.SharedSourceFolders)).EnumerateArray())
            {
                sharedSourceFolders.Add(Path.Combine(basePath, sharedSourceFolder.GetString()));
            }

            root.TryGetProperty(nameof(Configuration.Options.ProtocolMethodList), out var protocolMethodList);
            var protocolMethods = protocolMethodList.ValueKind == JsonValueKind.Array
                ? protocolMethodList.EnumerateArray().Select(t => t.ToString()).ToArray()
                : Array.Empty<string>();

            Configuration.Initialize(
                Path.Combine(basePath, root.GetProperty(nameof(Configuration.OutputFolder)).GetString()),
                root.GetProperty(nameof(Configuration.Namespace)).GetString(),
                root.GetProperty(nameof(Configuration.LibraryName)).GetString(),
                sharedSourceFolders.ToArray(),
                saveInputs: false,
                ReadOption(root, Configuration.Options.AzureArm),
                ReadOption(root, Configuration.Options.PublicClients),
                ReadOption(root, Configuration.Options.ModelNamespace),
                ReadOption(root, Configuration.Options.HeadAsBoolean),
                ReadOption(root, Configuration.Options.SkipCSProjPackageReference),
                ReadOption(root, Configuration.Options.DataPlane),
                ReadOption(root, Configuration.Options.SingleTopLevelClient),
                ReadStringOption(root, Configuration.Options.ProjectFolder),
                protocolMethods,
                MgmtConfiguration.LoadConfiguration(root)
            );
        }
    }
}
