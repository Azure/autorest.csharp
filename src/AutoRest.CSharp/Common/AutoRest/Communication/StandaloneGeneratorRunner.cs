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
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.AutoRest.Communication
{
    internal class StandaloneGeneratorRunner
    {
        public static async Task RunAsync(string[] args)
        {
            var basePath = args.Single(a => !a.StartsWith("--"));

            var configuration = LoadConfiguration(basePath, File.ReadAllText(Path.Combine(basePath, "Configuration.json")));
            var codeModelTask = Task.Run(() => CodeModelSerialization.DeserializeCodeModel(File.ReadAllText(Path.Combine(basePath, "CodeModel.yaml"))));
            var workspace = await new CSharpGen().ExecuteAsync(codeModelTask, configuration);

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

        private static void WriteIfNotDefault (Utf8JsonWriter writer, string option, bool value)
        {
            var defaultValue = Configuration.GetDefault (option);
            if (!defaultValue.HasValue || defaultValue.Value != value)
            {
                writer.WriteBoolean(option, value);
            }
        }

        internal static string SaveConfiguration(Configuration configuration)
        {
            using (var memoryStream = new MemoryStream())
            {
                JsonWriterOptions options = new JsonWriterOptions();
                options.Indented = true;
                using (Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream, options))
                {
                    writer.WriteStartObject();
                    writer.WriteString(nameof(Configuration.OutputFolder), Path.GetRelativePath(configuration.OutputFolder, configuration.OutputFolder));
                    writer.WriteString(nameof(Configuration.Namespace), configuration.Namespace);
                    writer.WriteString(nameof(Configuration.LibraryName), configuration.LibraryName);
                    writer.WriteStartArray(nameof(Configuration.SharedSourceFolders));
                    foreach (var sharedSourceFolder in configuration.SharedSourceFolders)
                    {
                        writer.WriteStringValue(NormalizePath(configuration, sharedSourceFolder));
                    }
                    writer.WriteEndArray();
                    WriteIfNotDefault(writer, "azure-arm", configuration.AzureArm);
                    WriteIfNotDefault(writer, "public-clients", configuration.PublicClients);
                    WriteIfNotDefault(writer, "model-namespace", configuration.ModelNamespace);
                    WriteIfNotDefault(writer, "head-as-boolean", configuration.HeadAsBoolean);
                    WriteIfNotDefault(writer, "skip-csproj-packagereference", configuration.SkipCSProjPackageReference);
                    WriteIfNotDefault(writer, "low-level-client", configuration.LowLevelClient);

                    configuration.MgmtConfiguration.SaveConfiguration(writer);

                    writer.WriteEndObject();
                }

                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        private static string NormalizePath(Configuration configuration, string sharedSourceFolder)
        {
            return Path.GetRelativePath(configuration.OutputFolder, sharedSourceFolder);
        }

        private static bool ReadOrDefault (JsonElement root, string option)
        {
            if (root.TryGetProperty (option, out JsonElement value))
            {
                return value.GetBoolean ();
            }
            else
            {
                return Configuration.GetDefault (option)!.Value;
            }
        }

        internal static Configuration LoadConfiguration(string basePath, string json)
        {
            JsonDocument document = JsonDocument.Parse(json);
            var root = document.RootElement;
            var sharedSourceFolders = new List<string>();

            foreach (var sharedSourceFolder in root.GetProperty(nameof(Configuration.SharedSourceFolders)).EnumerateArray())
            {
                sharedSourceFolders.Add(Path.Combine(basePath, sharedSourceFolder.GetString()));
            }

            return new Configuration(
                Path.Combine(basePath, root.GetProperty(nameof(Configuration.OutputFolder)).GetString()),
                root.GetProperty(nameof(Configuration.Namespace)).GetString(),
                root.GetProperty(nameof(Configuration.LibraryName)).GetString(),
                sharedSourceFolders.ToArray(),
                saveInputs: false,
                ReadOrDefault(root, "azure-arm"),
                ReadOrDefault(root, "public-clients"),
                ReadOrDefault(root, "model-namespace"),
                ReadOrDefault(root, "head-as-boolean"),
                ReadOrDefault(root, "skip-csproj-packagereference"),
                ReadOrDefault(root, "low-level-client"),
                MgmtConfiguration.LoadConfiguration(root)
            );
        }
    }
}
