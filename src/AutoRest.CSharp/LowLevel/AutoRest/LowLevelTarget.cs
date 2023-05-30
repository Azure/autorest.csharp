// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.PostProcessing;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.LowLevel.Generation;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class LowLevelTarget
    {
        public static async Task ExecuteAsync(GeneratedCodeWorkspace project, InputNamespace inputNamespace, SourceInputModel? sourceInputModel, bool typespecInput)
        {
            var library = new DpgOutputLibraryBuilder(inputNamespace, sourceInputModel).Build(typespecInput);

            foreach (var model in library.AllModels)
            {
                var codeWriter = new CodeWriter();
                var modelWriter = new ModelWriter();
                modelWriter.WriteModel(codeWriter, model);
                var folderPath = Configuration.ModelNamespace ? "Models/" : "";
                project.AddGeneratedFile($"{folderPath}{model.Type.Name}.cs", codeWriter.ToString());

                var serializationCodeWriter = new CodeWriter();
                var serializationWriter = new SerializationWriter();
                serializationWriter.WriteSerialization(serializationCodeWriter, model);
                project.AddGeneratedFile($"{folderPath}{model.Type.Name}.Serialization.cs", serializationCodeWriter.ToString());
            }

            foreach (var client in library.RestClients)
            {
                var codeWriter = new CodeWriter();
                var xmlDocWriter = new XmlDocWriter();
                var lowLevelClientWriter = new LowLevelClientWriter(codeWriter, xmlDocWriter, client);
                lowLevelClientWriter.WriteClient();
                project.AddGeneratedFile($"{client.Type.Name}.cs", codeWriter.ToString());
                project.AddGeneratedDocFile($"Docs/{client.Type.Name}.xml", xmlDocWriter.ToString());

                var exampleCompileCheckWriter = new ExampleCompileCheckWriter(client);
                exampleCompileCheckWriter.Write();
                project.AddGeneratedFile($"../../tests/Generated/Samples/Samples_{client.Type.Name}.cs", exampleCompileCheckWriter.ToString());
            }

            var optionsWriter = new CodeWriter();
            ClientOptionsWriter.WriteClientOptions(optionsWriter, library.ClientOptions);
            project.AddGeneratedFile($"{library.ClientOptions.Type.Name}.cs", optionsWriter.ToString());

            var extensionWriter = new AspDotNetExtensionWriter(library.AspDotNetExtension);
            extensionWriter.Write();
            project.AddGeneratedFile($"{library.AspDotNetExtension.Type.Name}.cs", extensionWriter.ToString());

            await project.PostProcessAsync(new PostProcessor(
                modelFactoryFullName: null,
                aspExtensionClassName: library.AspDotNetExtension.FullName));
        }
    }
}
