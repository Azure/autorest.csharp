// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MgmtTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel? sourceInputModel, Configuration configuration)
        {
            BuildContext<MgmtOutputLibrary> context = new BuildContext<MgmtOutputLibrary>(codeModel, configuration, sourceInputModel);
            var modelWriter = new ModelWriter();
            var restClientWriter = new RestClientWriter();
            var serializeWriter = new SerializationWriter();
            var resourceOperationWriter = new ResourceOperationWriter();
            var resourceContainerWriter = new ResourceContainerWriter();
            var armResourceWriter = new ResourceWriter();
            var resourceGroupExtensionsWriter = new ResourceGroupExtensionsWriter(); 
            var subscriptionExtensionsWriter = new SubscriptionExtensionsWriter();

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

            foreach (var resourceOperation in context.Library.ResourceOperations)
            {
                var codeWriter = new CodeWriter();
                resourceOperationWriter.WriteClient(codeWriter, resourceOperation);

                project.AddGeneratedFile($"{resourceOperation.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var resourceContainer in context.Library.ResourceContainers)
            {
                var codeWriter = new CodeWriter();
                resourceContainerWriter.WriteContainer(codeWriter, resourceContainer);

                project.AddGeneratedFile($"{resourceContainer.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var model in context.Library.ResourceData)
            {
                var codeWriter = new CodeWriter();
                modelWriter.WriteModel(codeWriter, model);

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);

                var name = model.Type.Name;
                project.AddGeneratedFile($"Models/{name}.cs", codeWriter.ToString());
                project.AddGeneratedFile($"Models/{name}.Serialization.cs", serializerCodeWriter.ToString());
            }

            foreach (var model in context.Library.ArmResource)
            {
                var codeWriter = new CodeWriter();
                armResourceWriter.WriteResource(codeWriter, context, model);

                var name = model.Type.Name;
                project.AddGeneratedFile($"{name}.cs", codeWriter.ToString());
            }

            var extensionsWriter = new CodeWriter();
            resourceGroupExtensionsWriter.WriteExtension(context, extensionsWriter);
            project.AddGeneratedFile("Extensions/ResourceGroupExtensions.cs", extensionsWriter.ToString());

            var subscriptionExtensionsCodeWriter = new CodeWriter();
            var resources = context.Library.ArmResource;
            subscriptionExtensionsWriter.WriteExtension(subscriptionExtensionsCodeWriter, context, resources);
            project.AddGeneratedFile($"Extensions/SubscriptionExtensions.cs", subscriptionExtensionsCodeWriter.ToString());
        }
    }
}
