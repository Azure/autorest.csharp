// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.LowLevel.AutoRest.PostProcessing;
using AutoRest.CSharp.Output.Models;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class LowLevelTarget
    {
        public static async Task ExecuteAsync(GeneratedCodeWorkspace project, InputNamespace inputNamespace, SourceInputModel? sourceInputModel, bool cadlInput)
        {
            var library = new DpgOutputLibraryBuilder(inputNamespace, sourceInputModel).Build(cadlInput);

            foreach (var model in library.AllModels)
            {
                var codeWriter = new CodeWriter();
                var modelWriter = new ModelWriter();
                modelWriter.WriteModel(codeWriter, model);
                project.AddGeneratedFile($"{model.Type.Name}.cs", codeWriter.ToString());

                var serializationCodeWriter = new CodeWriter();
                var serializationWriter = new SerializationWriter();
                serializationWriter.WriteSerialization(serializationCodeWriter, model);
                project.AddGeneratedFile($"{model.Type.Name}.Serialization.cs", serializationCodeWriter.ToString());
            }

            foreach (var client in library.RestClients)
            {
                var codeWriter = new CodeWriter();
                var xmlDocWriter = new XmlDocWriter();
                var lowLevelClientWriter = new LowLevelClientWriter(codeWriter, xmlDocWriter, client);
                lowLevelClientWriter.WriteClient();
                project.AddGeneratedFile($"{client.Type.Name}.cs", codeWriter.ToString());
                project.AddGeneratedDocFile($"Docs/{client.Type.Name}.xml", xmlDocWriter.ToString());
            }

            var optionsWriter = new CodeWriter();
            ClientOptionsWriter.WriteClientOptions(optionsWriter, library.ClientOptions);
            project.AddGeneratedFile($"{library.ClientOptions.Type.Name}.cs", optionsWriter.ToString());

            await project.PostProcess(PostProcess);
        }

        private static async Task<Project> PostProcess(Project project)
        {
            if (Configuration.KeepUnusedModels)
                return project;

            var postProcessor = new DpgPostProcessor();
            project = await postProcessor.InternalizeAsync(project);

            project = await postProcessor.RemoveAsync(project);

            return project;
        }
    }
}
