// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.PostProcessing;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.LowLevel.Generation;
using AutoRest.CSharp.LowLevel.Generation.SampleGeneration;
using AutoRest.CSharp.LowLevel.Generation.TestGeneration;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class LowLevelTarget
    {
        public static async Task ExecuteAsync(GeneratedCodeWorkspace project, InputNamespace inputNamespace, SourceInputModel? sourceInputModel, bool isTspInput)
        {
            var library = new DpgOutputLibraryBuilder(inputNamespace, sourceInputModel).Build(isTspInput);

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

                // write samples
                var sampleProvider = library.GetSampleForClient(client);
                if (sampleProvider != null)
                {
                    var exampleFileCheckFilename = $"../../tests/Generated/Samples/{sampleProvider.Type.Name}.cs";
                    var clientSampleWriter = new DpgClientSampleWriter(sampleProvider);
                    clientSampleWriter.Write();
                    project.AddGeneratedTestFile(exampleFileCheckFilename, clientSampleWriter.ToString());
                    project.AddGeneratedDocFile($"Docs/{client.Type.Name}.xml", new XmlDocumentFile(exampleFileCheckFilename, xmlDocWriter));
                }

                // write test cases
                var clientTestProvider = library.GetTestForClient(client);
                if (clientTestProvider != null)
                {
                    var clientTestFilename = $"../../tests/Generated/Tests/{clientTestProvider.Type.Name}.cs";
                    var clientTestWriter = new DpgClientTestWriter(clientTestProvider);
                }
            }

            var optionsWriter = new CodeWriter();
            ClientOptionsWriter.WriteClientOptions(optionsWriter, library.ClientOptions);
            project.AddGeneratedFile($"{library.ClientOptions.Type.Name}.cs", optionsWriter.ToString());

            var extensionWriter = new AspDotNetExtensionWriter(library.AspDotNetExtension);
            extensionWriter.Write();
            project.AddGeneratedFile($"{library.AspDotNetExtension.Type.Name}.cs", extensionWriter.ToString());

            var modelFactoryProvider = library.ModelFactory;
            if (modelFactoryProvider != null)
            {
                var modelFactoryWriter = new ModelFactoryWriter(modelFactoryProvider);
                modelFactoryWriter.Write();
                project.AddGeneratedFile($"{modelFactoryProvider.Type.Name}.cs", modelFactoryWriter.ToString());
            }

            var testBaseWriter = new DpgTestBaseWriter(library.DpgTestBase);
            testBaseWriter.Write();
            project.AddGeneratedTestFile($"../../tests/Generated/Tests/{library.DpgTestBase.Type.Name}.cs", testBaseWriter.ToString());

            var testEnvWriter = new DpgTestEnvironmentWriter(library.DpgTestEnvironment);
            testEnvWriter.Write();
            project.AddGeneratedTestFile($"../../tests/Generated/Tests/{library.DpgTestEnvironment.Type.Name}.cs", testEnvWriter.ToString());

            await project.PostProcessAsync(new PostProcessor(
                modelFactoryFullName: modelFactoryProvider?.FullName,
                aspExtensionClassName: library.AspDotNetExtension.FullName));
        }
    }
}
