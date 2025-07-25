// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class DataPlaneTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, InputNamespace inputNamespace, SourceInputModel? sourceInputModel)
        {
            var library = new DataPlaneOutputLibrary(inputNamespace, sourceInputModel);
            var modelWriter = new ModelWriter();
            var clientWriter = new DataPlaneClientWriter();
            var restClientWriter = new RestClientWriter();
            var serializeWriter = new SerializationWriter();
            var headerModelModelWriter = new DataPlaneResponseHeaderGroupWriter();
            var longRunningOperationWriter = new LongRunningOperationWriter();

            foreach (var helper in ExpressionTypeProvider.GetHelperProviders())
            {
                var helperWriter = new CodeWriter();
                new ExpressionTypeProviderWriter(helperWriter, helper).Write();
                project.AddGeneratedFile($"Internal/{helper.Type.Name}.cs", helperWriter.ToString());
            }

            foreach (var model in library.Models)
            {
                var codeWriter = new CodeWriter();
                modelWriter.WriteModel(codeWriter, model);

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);

                var name = model.Type.Name;
                project.AddGeneratedFile($"Models/{name}.cs", codeWriter.ToString());
                project.AddGeneratedFile($"Models/{name}.Serialization.cs", serializerCodeWriter.ToString());
            }

            var modelFactoryType = library.ModelFactory;
            if (modelFactoryType != default)
            {
                var modelFactoryWriter = new ModelFactoryWriter(modelFactoryType);
                modelFactoryWriter.Write();
                project.AddGeneratedFile($"{modelFactoryType.Type.Name}.cs", modelFactoryWriter.ToString());
            }

            foreach (var client in library.RestClients)
            {
                var restCodeWriter = new CodeWriter();
                restClientWriter.WriteClient(restCodeWriter, client);

                project.AddGeneratedFile($"{client.Type.Name}.cs", restCodeWriter.ToString());
            }

            foreach (DataPlaneResponseHeaderGroupType responseHeaderModel in library.HeaderModels)
            {
                var headerModelCodeWriter = new CodeWriter();
                headerModelModelWriter.WriteHeaderModel(headerModelCodeWriter, responseHeaderModel);

                project.AddGeneratedFile($"{responseHeaderModel.Type.Name}.cs", headerModelCodeWriter.ToString());
            }

            if (library.ClientOptions is not null)
            {
                var codeWriter = new CodeWriter();
                ClientOptionsWriter.WriteClientOptions(codeWriter, library.ClientOptions);
                project.AddGeneratedFile($"{library.ClientOptions.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var client in library.Clients)
            {
                var codeWriter = new CodeWriter();
                clientWriter.WriteClient(codeWriter, client, library);
                project.AddGeneratedFile($"{client.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var operation in library.LongRunningOperations)
            {
                var codeWriter = new CodeWriter();
                longRunningOperationWriter.Write(codeWriter, operation);

                project.AddGeneratedFile($"{operation.Type.Name}.cs", codeWriter.ToString());
            }

            if (Configuration.UseModelReaderWriter)
            {
                var contextWriter = new CodeWriter();
                var contextWriterInstance = new ModelReaderWriterContextWriter();
                contextWriterInstance.Write(contextWriter, library.Models);
                project.AddGeneratedFile($"Models/{ModelReaderWriterContextWriter.Name}.cs", contextWriter.ToString());
            }
        }
    }
}
