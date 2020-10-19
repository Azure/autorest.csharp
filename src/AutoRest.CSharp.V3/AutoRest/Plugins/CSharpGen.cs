// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.AutoRest.Communication;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Generation.Writers;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Input.Source;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Responses;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Simplification;
using Microsoft.CodeAnalysis.Text;
using Diagnostic = Microsoft.CodeAnalysis.Diagnostic;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
{
    [PluginName("csharpgen")]
    internal class CSharpGen : IPlugin
    {
        public async Task<GeneratedCodeWorkspace> ExecuteAsync(Task<CodeModel> codeModelTask, Configuration configuration)
        {
            Directory.CreateDirectory(configuration.OutputFolder);
            var project = await GeneratedCodeWorkspace.Create(configuration.OutputFolder, configuration.SharedSourceFolders);
            var sourceInputModel = new SourceInputModel(await project.GetCompilationAsync());

            var context = new BuildContext(await codeModelTask, configuration, sourceInputModel);

            var modelWriter = new ModelWriter();
            var clientWriter = new ClientWriter();
            var restClientWriter = new RestClientWriter();
            var serializeWriter = new SerializationWriter();
            var headerModelModelWriter = new ResponseHeaderGroupWriter();

            foreach (var model in context.Library.Models)
            {
                var codeWriter = new CodeWriter();
                modelWriter.WriteModel(codeWriter, model);

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);

                var name = model.Type.Name;
                project.AddGeneratedFile($"Models/{name}.cs", codeWriter.ToString());
                project.AddGeneratedFile($"Models/{name}.Serialization.cs", serializerCodeWriter.ToString());
            }

            foreach (var client in context.Library.RestClients)
            {
                var restCodeWriter = new CodeWriter();
                restClientWriter.WriteClient(restCodeWriter, client);

                project.AddGeneratedFile($"{client.Type.Name}.cs", restCodeWriter.ToString());
            }

            foreach (ResponseHeaderGroupType responseHeaderModel in context.Library.HeaderModels)
            {
                var headerModelCodeWriter = new CodeWriter();
                headerModelModelWriter.WriteHeaderModel(headerModelCodeWriter, responseHeaderModel);

                project.AddGeneratedFile($"{responseHeaderModel.Type.Name}.cs", headerModelCodeWriter.ToString());
            }

            foreach (var client in context.Library.Clients)
            {
                var codeWriter = new CodeWriter();
                clientWriter.WriteClient(codeWriter, client, context.Configuration);

                project.AddGeneratedFile($"{client.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var operation in context.Library.LongRunningOperations)
            {
                var codeWriter = new CodeWriter();
                LongRunningOperationWriter.Write(codeWriter, operation);

                project.AddGeneratedFile($"{operation.Type.Name}.cs", codeWriter.ToString());
            }

            if (context.Configuration.AzureArm)
            {
                var codeWriter = new CodeWriter();
                ManagementClientWriter.WriteClientOptions(codeWriter, context);
                project.AddGeneratedFile($"{context.Configuration.LibraryName}ManagementClientOptions.cs", codeWriter.ToString());

                var clientCodeWriter = new CodeWriter();
                ManagementClientWriter.WriteAggregateClient(clientCodeWriter, context);
                project.AddGeneratedFile($"{context.Configuration.LibraryName}ManagementClient.cs", clientCodeWriter.ToString());

            }

            return project;
        }

        public async Task<bool> Execute(IPluginCommunication autoRest)
        {
            string codeModelFileName = (await autoRest.ListInputs()).FirstOrDefault();
            if (string.IsNullOrEmpty(codeModelFileName)) throw new Exception("Generator did not receive the code model file.");

            var configuration = new Configuration(
                    TrimFileSuffix(GetRequiredOption<string>(autoRest, "output-folder")),
                GetRequiredOption<string>(autoRest, "namespace"),
                autoRest.GetValue<string?>("library-name").GetAwaiter().GetResult(),
                GetRequiredOption<string[]>(autoRest, "shared-source-folders").Select(TrimFileSuffix).ToArray(),
                autoRest.GetValue<bool?>("save-inputs").GetAwaiter().GetResult() ?? false,
                autoRest.GetValue<bool?>("azure-arm").GetAwaiter().GetResult() ?? false,
                autoRest.GetValue<bool?>("public-clients").GetAwaiter().GetResult() ?? false,
                autoRest.GetValue<bool?>("model-namespace").GetAwaiter().GetResult() ?? true,
                autoRest.GetValue<bool?>("head-as-boolean").GetAwaiter().GetResult() ?? false
            );

            string codeModelYaml = string.Empty;

            Task<CodeModel> codeModelTask = Task.Run(async () =>
            {
                codeModelYaml = await autoRest.ReadFile(codeModelFileName);
                return CodeModelSerialization.DeserializeCodeModel(codeModelYaml);
            });

            if (configuration.SaveInputs)
            {
                await autoRest.WriteFile("Configuration.json", StandaloneGeneratorRunner.SaveConfiguration(configuration), "source-file-csharp");
                await autoRest.WriteFile("CodeModel.yaml", codeModelYaml, "source-file-csharp");
            }

            var project = await ExecuteAsync(codeModelTask, configuration);
            await foreach (var file in project.GetGeneratedFilesAsync())
            {
                await autoRest.WriteFile(file.Name, file.Text, "source-file-csharp");
            }

            return true;
        }

        private T GetRequiredOption<T>(IPluginCommunication autoRest, string name)
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
