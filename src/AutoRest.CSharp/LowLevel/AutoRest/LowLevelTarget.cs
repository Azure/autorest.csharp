// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.PostProcessing;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.LowLevel.Generation.SampleGeneration;
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
                var dpgClientWriter = new DpgClientWriter(library, client);
                dpgClientWriter.WriteClient();
                project.AddGeneratedFile($"{client.Type.Name}.cs", dpgClientWriter.ToString());

                var sampleProvider = library.GetSampleForClient(client);
                if (Configuration.IsBranded)
                {
                    // write samples
                    if (sampleProvider != null)
                    {
                        var clientExampleFilename = $"../../tests/Generated/Samples/{sampleProvider.Type.Name}.cs";
                        var clientSampleWriter = new DpgClientSampleWriter(sampleProvider);
                        clientSampleWriter.Write();
                        project.AddGeneratedTestFile(clientExampleFilename, clientSampleWriter.ToString());
                        project.AddGeneratedDocFile(dpgClientWriter.XmlDocWriter.Filename, new XmlDocumentFile(clientExampleFilename, dpgClientWriter.XmlDocWriter));
                    }
                }
                else
                {
                    if (Configuration.GenerateTestProject && sampleProvider is not null)
                    {
                        var smokeTestWriter = new SmokeTestWriter(client, sampleProvider);
                        smokeTestWriter.Write();
                        project.AddGeneratedTestFile($"../../tests/Generated/{client.Type.Name}Tests.cs", smokeTestWriter.ToString());
                    }
                }
            }

            var optionsWriter = new CodeWriter();
            ClientOptionsWriter.WriteClientOptions(optionsWriter, library.ClientOptions);
            project.AddGeneratedFile($"{library.ClientOptions.Type.Name}.cs", optionsWriter.ToString());

            if (Configuration.IsBranded)
            {
                var extensionWriter = new AspDotNetExtensionWriter(library.AspDotNetExtension);
                extensionWriter.Write();
                project.AddGeneratedFile($"{library.AspDotNetExtension.Type.Name}.cs", extensionWriter.ToString());
            }

            var modelFactoryProvider = library.ModelFactory;
            if (modelFactoryProvider != null)
            {
                var modelFactoryWriter = new ModelFactoryWriter(modelFactoryProvider);
                modelFactoryWriter.Write();
                project.AddGeneratedFile($"{modelFactoryProvider.Type.Name}.cs", modelFactoryWriter.ToString());
            }

            await project.PostProcessAsync(new PostProcessor(
                modelsToKeep: library.AccessOverriddenModels.ToImmutableHashSet(),
                modelFactoryFullName: modelFactoryProvider?.FullName,
                aspExtensionClassName: library.AspDotNetExtension.FullName));
        }
    }
}
