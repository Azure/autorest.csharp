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

        internal static string SaveConfiguration(Configuration configuration)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream))
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
                    writer.WriteBoolean(nameof(Configuration.AzureArm), configuration.AzureArm);
                    writer.WriteBoolean(nameof(Configuration.PublicClients), configuration.PublicClients);
                    writer.WriteBoolean(nameof(Configuration.ModelNamespace), configuration.ModelNamespace);
                    writer.WriteBoolean(nameof(Configuration.HeadAsBoolean), configuration.HeadAsBoolean);
                    writer.WriteBoolean(nameof(Configuration.SkipCSProjPackageReference), configuration.SkipCSProjPackageReference);
                    writer.WriteBoolean(nameof(Configuration.LowLevelClient), configuration.LowLevelClient);
                    writer.WriteStartArray(nameof(Configuration.CredentialTypes));
                    foreach (var credentialTypes in configuration.CredentialTypes)
                    {
                        writer.WriteStringValue(credentialTypes);
                    }
                    writer.WriteEndArray();

                    writer.WriteStartArray(nameof(Configuration.CredentialScopes));
                    foreach (var credentialTypes in configuration.CredentialScopes)
                    {
                        writer.WriteStringValue(credentialTypes);
                    }
                    writer.WriteEndArray();

                    writer.WriteString(nameof(Configuration.CredentialHeaderName), configuration.CredentialHeaderName);

                    writer.WriteStartObject(nameof(Configuration.OperationGroupToResourceType));
                    foreach (var keyval in configuration.OperationGroupToResourceType)
                    {
                        writer.WriteString(keyval.Key, keyval.Value);
                    }
                    writer.WriteEndObject();

                    writer.WriteStartObject(nameof(Configuration.OperationGroupToResource));
                    foreach (var keyval in configuration.OperationGroupToResource)
                    {
                        writer.WriteString(keyval.Key, keyval.Value);
                    }
                    writer.WriteEndObject();

                    writer.WriteStartObject(nameof(Configuration.ModelToResource));
                    foreach (var keyval in configuration.ModelToResource)
                    {
                        writer.WriteString(keyval.Key, keyval.Value);
                    }
                    writer.WriteEndObject();

                    writer.WriteStartObject(nameof(Configuration.ModelRename));
                    foreach (var keyval in configuration.ModelRename)
                    {
                        writer.WriteString(keyval.Key, keyval.Value);
                    }
                    writer.WriteEndObject();

                    writer.WriteEndObject();
                }

                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        private static string NormalizePath(Configuration configuration, string sharedSourceFolder)
        {
            return Path.GetRelativePath(configuration.OutputFolder, sharedSourceFolder);
        }

        private static Configuration LoadConfiguration(string basePath, string json)
        {
            JsonDocument document = JsonDocument.Parse(json);
            var root = document.RootElement;
            var sharedSourceFolders = new List<string>();
            var credentialTypes = new List<string>();
            var credentialScopes = new List<string>();

            foreach (var sharedSourceFolder in root.GetProperty(nameof(Configuration.SharedSourceFolders)).EnumerateArray())
            {
                sharedSourceFolders.Add(Path.Combine(basePath, sharedSourceFolder.GetString()));
            }

            foreach (var credentialType in root.GetProperty(nameof(Configuration.CredentialTypes)).EnumerateArray())
            {
                credentialTypes.Add(credentialType.ToString());
            }

            foreach (var credentialScope in root.GetProperty(nameof(Configuration.CredentialScopes)).EnumerateArray())
            {
                credentialScopes.Add(credentialScope.ToString());
            }

            return new Configuration(
                Path.Combine(basePath, root.GetProperty(nameof(Configuration.OutputFolder)).GetString()),
                root.GetProperty(nameof(Configuration.Namespace)).GetString(),
                root.GetProperty(nameof(Configuration.LibraryName)).GetString(),
                sharedSourceFolders.ToArray(),
                saveInputs: false,
                root.GetProperty(nameof(Configuration.AzureArm)).GetBoolean(),
                root.GetProperty(nameof(Configuration.PublicClients)).GetBoolean(),
                root.GetProperty(nameof(Configuration.ModelNamespace)).GetBoolean(),
                root.GetProperty(nameof(Configuration.HeadAsBoolean)).GetBoolean(),
                root.GetProperty(nameof(Configuration.SkipCSProjPackageReference)).GetBoolean(),
                credentialTypes.ToArray(),
                credentialScopes.ToArray(),
                root.GetProperty(nameof(Configuration.CredentialHeaderName)).GetString(),
                root.GetProperty(nameof(Configuration.LowLevelClient)).GetBoolean(),
                root.GetProperty(nameof(Configuration.OperationGroupToResourceType)),
                root.GetProperty(nameof(Configuration.OperationGroupToResource)),
                root.GetProperty(nameof(Configuration.ModelToResource)),
                root.GetProperty(nameof(Configuration.ModelRename))
            );
        }
    }
}
