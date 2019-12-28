// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline.Generated;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Simplification;
using Microsoft.CodeAnalysis.Text;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("cs-modeler")]
    internal class Modeler : IPlugin
    {
        public async Task<bool> Execute(IAutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            var schemas = (codeModel.Schemas.Choices ?? Enumerable.Empty<ChoiceSchema>()).Cast<Schema>()
                .Concat(codeModel.Schemas.SealedChoices ?? Enumerable.Empty<SealedChoiceSchema>())
                .Concat(codeModel.Schemas.Objects ?? Enumerable.Empty<ObjectSchema>());

            var modelBuilder = new ModelBuilder(HasXmlOperations(codeModel));
            var models = schemas.Select(modelBuilder.BuildModel).ToArray();
            var clients = codeModel.OperationGroups.Select(ClientBuilder.BuildClient).ToArray();

            var typeProviders = models.OfType<ISchemaTypeProvider>().ToArray();
            var typeFactory = new TypeFactory(configuration.Namespace, typeProviders);

            var modelWriter = new ModelWriter(typeFactory);
            var writer = new ClientWriter(typeFactory);
            var serializeWriter = new SerializationWriter(typeFactory);
            var headerModelModelWriter = new ResponseHeaderModelModelWriter(typeFactory);

            var project = WorkspaceFactory.CreateGeneratedCodeProject();

            foreach (var model in models)
            {
                var codeWriter = new CodeWriter();
                modelWriter.WriteModel(codeWriter, model);

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);

                var name = model.Name;
                project = project.AddDocument($"Generated/Models/{name}.cs", codeWriter.ToFormattedCode()).Project;
                project = project.AddDocument($"Generated/Models/{name}.Serialization.cs", serializerCodeWriter.ToFormattedCode()).Project;
            }

            foreach (var client in clients)
            {
                var codeWriter = new CodeWriter();
                writer.WriteClient(codeWriter, client);

                project = project.AddDocument($"Generated/Operations/{client.Name}.cs", codeWriter.ToFormattedCode()).Project;

                foreach (ClientMethod clientMethod in client.Methods)
                {
                    ResponseHeaderModel? responseHeaderModel = clientMethod.Response.HeaderModel;
                    if (responseHeaderModel == null)
                        continue;

                    var headerModelCodeWriter = new CodeWriter();
                    headerModelModelWriter.WriteHeaderModel(headerModelCodeWriter, responseHeaderModel);

                    project = project.AddDocument($"Generated/Operations/{responseHeaderModel.Name}.cs", headerModelCodeWriter.ToFormattedCode()).Project;
                }
            }

            Compilation? compilation = await project.GetCompilationAsync();

            Debug.Assert(compilation != null);

            foreach (Diagnostic diagnostic in compilation.GetDiagnostics())
            {
                if (diagnostic.Severity == DiagnosticSeverity.Error)
                {
                    await autoRest.Fatal(diagnostic.ToString());
                }
            }

            foreach (Document document in project.Documents)
            {
                // Skip writing shared files
                if (document.Folders.Contains(WorkspaceFactory.SharedFolder))
                {
                    continue;
                }

                var root = await document.GetSyntaxRootAsync()!;

                Debug.Assert(root != null);

                root = root.WithAdditionalAnnotations(Simplifier.Annotation);
                var simplified = document.WithSyntaxRoot(root);

                try
                {
                    simplified = await Simplifier.ReduceAsync(simplified);
                }
                catch (InvalidOperationException)
                {
                    // Workaround for https://github.com/dotnet/roslyn/issues/40592
                }

                simplified = await Formatter.FormatAsync(simplified);

                SourceText text = await simplified.GetTextAsync();
                await autoRest.WriteFile(document.Name, text.ToString(), "source-file-csharp");
            }

            return true;
        }

        private bool HasXmlOperations(CodeModel codeModel)
        {
            return codeModel.OperationGroups.Any(og =>
                og.Operations.Any(op =>
                    (op.Request.Protocol.Http is HttpWithBodyRequest bodyRequest && bodyRequest.KnownMediaType == KnownMediaType.Xml) ||
                    op.Responses.Any(r => r.Protocol.Http is HttpResponse response && response.KnownMediaType == KnownMediaType.Xml)
                ));
        }
    }
}
