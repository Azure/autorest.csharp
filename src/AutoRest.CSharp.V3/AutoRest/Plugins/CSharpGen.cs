﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using AutoRest.CSharp.V3.Output.Models.Types;
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
            var project = GeneratedCodeWorkspace.Create(configuration.OutputFolder);
            var sourceInputModel = SourceInputModelBuilder.Build(await project.GetCompilationAsync());

            var context = new BuildContext(codeModel, configuration.Namespace, sourceInputModel);

            var modelWriter = new ModelWriter();
            var writer = new ClientWriter();
            var serializeWriter = new SerializationWriter();
            var headerModelModelWriter = new ResponseHeaderGroupWriter();

            foreach (var model in context.Library.Models)
            {
                var codeWriter = new CodeWriter();
                modelWriter.WriteModel(codeWriter, model);

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);

                var name = model.Type.Name;
                project.AddGeneratedFile($"Models/{name}.cs", codeWriter.ToFormattedCode());
                project.AddGeneratedFile($"Models/{name}.Serialization.cs", serializerCodeWriter.ToFormattedCode());
            }

            foreach (var client in context.Library.Clients)
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
    }
}
