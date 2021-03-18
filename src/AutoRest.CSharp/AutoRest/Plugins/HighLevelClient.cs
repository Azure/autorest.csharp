// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class HighLevelClient
    {
        public static void ExecuteAsync(GeneratedCodeWorkspace project, BuildContext context, Configuration configuration)
        {
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

            if (configuration.PublicClients && !configuration.AzureArm && context.Library.Clients.Count() > 0)
            {
                var codeWriter = new CodeWriter();
                ClientOptionsWriter.WriteClientOptions(codeWriter, context);

                var clientOptionsName = ClientBase.GetClientPrefix(context.DefaultLibraryName, context);
                project.AddGeneratedFile($"{clientOptionsName}ClientOptions.cs", codeWriter.ToString());
            }

            foreach (var client in context.Library.Clients)
            {
                var codeWriter = new CodeWriter();
                clientWriter.WriteClient(codeWriter, client, context);

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
                var libraryName = ManagementClientWriter.GetManagementClientPrefix(context.DefaultLibraryName);
                project.AddGeneratedFile($"{libraryName}ManagementClientOptions.cs", codeWriter.ToString());

                var clientCodeWriter = new CodeWriter();
                ManagementClientWriter.WriteAggregateClient(clientCodeWriter, context);
                project.AddGeneratedFile($"{libraryName}ManagementClient.cs", clientCodeWriter.ToString());

            }
        }
    }
}
