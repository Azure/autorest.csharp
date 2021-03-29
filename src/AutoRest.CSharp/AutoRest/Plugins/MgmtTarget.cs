// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MgmtTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel? sourceInputModel, Configuration configuration)
        {
            BuildContext<MgmtOutputLibrary> context = new BuildContext<MgmtOutputLibrary>(codeModel, configuration, sourceInputModel);
            var modelWriter = new ModelWriter();
            var clientWriter = new MgmtClientWriter();
            var restClientWriter = new MgmtRestClientWriter();
            var serializeWriter = new SerializationWriter();
            var headerModelModelWriter = new MgmtResponseHeaderGroupWriter();
            var resourceOperationWriter = new ResourceOperationWriter();
            var resourceContainerWriter = new ResourceContainerWriter();
            var resourceDataWriter = new ResourceDataWriter();
            var armResourceWriter = new ArmResourceWriter();
            var resourceDataSerializeWriter = new ResourceDataSerializationWriter();

            new InheritanceChoser().RebuildModelInheritance(context.Library.SchemaMap, context.Library.ResourceSchemaMap);

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

            foreach (MgmtResponseHeaderGroupType responseHeaderModel in context.Library.HeaderModels)
            {
                var headerModelCodeWriter = new CodeWriter();
                headerModelModelWriter.WriteHeaderModel(headerModelCodeWriter, responseHeaderModel);

                project.AddGeneratedFile($"{responseHeaderModel.Type.Name}.cs", headerModelCodeWriter.ToString());
            }

            foreach (var operation in context.Library.LongRunningOperations)
            {
                var codeWriter = new CodeWriter();
                MgmtLongRunningOperationWriter.Write(codeWriter, operation);

                project.AddGeneratedFile($"{operation.Type.Name}.cs", codeWriter.ToString());
            }


            foreach (var resourceOperation in context.Library.ResourceOperations)
            {
                var codeWriter = new CodeWriter();
                resourceOperationWriter.WriteClient(codeWriter, resourceOperation);

                project.AddGeneratedFile($"{resourceOperation.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var resourceContainer in context.Library.ResourceContainers)
            {
                var codeWriter = new CodeWriter();
                resourceContainerWriter.WriteClient(codeWriter, resourceContainer);

                project.AddGeneratedFile($"{resourceContainer.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var model in context.Library.ResourceData)
            {
                var codeWriter = new CodeWriter();
                resourceDataWriter.WriteResourceData(codeWriter, model);

                var serializerCodeWriter = new CodeWriter();
                resourceDataSerializeWriter.WriteSerialization(serializerCodeWriter, model);

                var name = model.Type.Name;
                project.AddGeneratedFile($"Models/{name}.cs", codeWriter.ToString());
                project.AddGeneratedFile($"Models/{name}.Serialization.cs", serializerCodeWriter.ToString());
            }

            foreach (var model in context.Library.ArmResource)
            {
                var codeWriter = new CodeWriter();
                armResourceWriter.WriteResource(codeWriter, model);

                var name = model.Type.Name;
                project.AddGeneratedFile($"{name}.cs", codeWriter.ToString());
            }
        }
    }
}
