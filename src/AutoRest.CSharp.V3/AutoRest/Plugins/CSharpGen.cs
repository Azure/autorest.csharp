// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.AutoRest.Communication;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Generation.Writers;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Input.Source;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Responses;
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
        public async Task<bool> Execute(IPluginCommunication autoRest, CodeModel codeModel, Configuration configuration)
        {
            var schemas = (codeModel.Schemas.Choices ?? Enumerable.Empty<ChoiceSchema>()).Cast<Schema>()
                .Concat(codeModel.Schemas.SealedChoices ?? Enumerable.Empty<SealedChoiceSchema>())
                .Concat(codeModel.Schemas.Objects ?? Enumerable.Empty<ObjectSchema>());

            var project = GeneratedCodeWorkspace.Create(configuration.OutputFolder);
            var sourceInputModel = SourceInputModelBuilder.Build(await project.GetCompilationAsync());

            var modelBuilder = new ModelBuilder(configuration.Namespace, GetMediaTypes(codeModel), sourceInputModel);
            var clientBuilder = new ClientBuilder(configuration.Namespace, sourceInputModel);
            var models = schemas.Select(modelBuilder.BuildModel).ToArray();
            var clients = codeModel.OperationGroups.Select(clientBuilder.BuildClient).ToArray();
            var typeFactory = new TypeFactory(models);

            var modelWriter = new ModelWriter(typeFactory);
            var writer = new ClientWriter(typeFactory);
            var serializeWriter = new SerializationWriter(typeFactory);
            var headerModelModelWriter = new ResponseHeaderGroupWriter(typeFactory);

            foreach (var model in models)
            {
                var codeWriter = new CodeWriter();
                modelWriter.WriteModel(codeWriter, model);

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);

                var name = model.Type.Name;
                project.AddGeneratedFile($"Models/{name}.cs", codeWriter.ToFormattedCode());
                project.AddGeneratedFile($"Models/{name}.Serialization.cs", serializerCodeWriter.ToFormattedCode());
            }

            foreach (var client in clients)
            {
                var codeWriter = new CodeWriter();
                writer.WriteClient(codeWriter, client);

                project.AddGeneratedFile($"Operations/{client.Type.Name}.cs", codeWriter.ToFormattedCode());

                var headerModels = client.Methods.Select(m => m.Response.HeaderModel).OfType<ResponseHeaderGroupType>().Distinct();
                foreach (ResponseHeaderGroupType responseHeaderModel in headerModels)
                {
                    var headerModelCodeWriter = new CodeWriter();
                    headerModelModelWriter.WriteHeaderModel(headerModelCodeWriter, responseHeaderModel);

                    project.AddGeneratedFile($"Operations/{responseHeaderModel.Type.Name}.cs", headerModelCodeWriter.ToFormattedCode());
                }
            }

            await foreach (var file in project.GetGeneratedFilesAsync())
            {
                await autoRest.WriteFile(file.Name, file.Text, "source-file-csharp");
            }

            return true;
        }

        // TODO: remove if https://github.com/Azure/autorest.modelerfour/issues/103 is implemented
        private KnownMediaType[] GetMediaTypes(CodeModel codeModel)
        {
            HashSet<KnownMediaType> types = new HashSet<KnownMediaType>();
            foreach (OperationGroup operationGroup in codeModel.OperationGroups)
            {
                foreach (Operation operation in operationGroup.Operations)
                {
                    if (operation.Request.Protocol.Http is HttpWithBodyRequest bodyRequest)
                    {
                        types.Add(bodyRequest.KnownMediaType);
                    }

                    foreach (var response in operation.Responses!)
                    {
                        if (response is SchemaResponse _ &&
                            response.Protocol.Http is HttpResponse httpResponse)
                        {
                            types.Add(httpResponse.KnownMediaType);
                        }
                    }
                }
            }

            // Order so JSON always goes first
            return types.OrderBy(t => t).ToArray();
        }
    }
}
