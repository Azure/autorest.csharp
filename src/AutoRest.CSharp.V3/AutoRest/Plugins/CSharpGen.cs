// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            Directory.CreateDirectory(configuration.OutputFolder);
            var project = GeneratedCodeWorkspace.Create(configuration.OutputFolder, configuration.SharedSourceFolder);
            var sourceInputModel = new SourceInputModel(await project.GetCompilationAsync());

            var context = new BuildContext(codeModel, configuration, sourceInputModel);

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

                project.AddGeneratedFile($"Operations/{client.Type.Name}.cs", restCodeWriter.ToString());

                var headerModels = client.Methods.Select(m => m.HeaderModel).OfType<ResponseHeaderGroupType>().Distinct();
                foreach (ResponseHeaderGroupType responseHeaderModel in headerModels)
                {
                    var headerModelCodeWriter = new CodeWriter();
                    headerModelModelWriter.WriteHeaderModel(headerModelCodeWriter, responseHeaderModel);

                    project.AddGeneratedFile($"Operations/{responseHeaderModel.Type.Name}.cs", headerModelCodeWriter.ToString());
                }
            }

            foreach (var client in context.Library.Clients)
            {
                var codeWriter = new CodeWriter();
                clientWriter.WriteClient(codeWriter, client, context.Configuration);

                project.AddGeneratedFile($"Operations/{client.Type.Name}.cs", codeWriter.ToString());
            }

            if (context.Configuration.AzureArm)
            {
                var title = context.Configuration.Title;

                var codeWriter = new CodeWriter();
                ClientOptionsWriter.WriteClientOptions(codeWriter, context);

                project.AddGeneratedFile($"Operations/{title}ManagementClientOptions.cs", codeWriter.ToString());
            }

            await foreach (var file in project.GetGeneratedFilesAsync())
            {
                await autoRest.WriteFile(file.Name, file.Text, "source-file-csharp");
            }

            return true;
        }
    }
}
