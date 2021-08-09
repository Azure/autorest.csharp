// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Output;
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
            var resourceGroupExtensionsWriter = new ResourceGroupExtensionsWriter();
            var subscriptionExtensionsWriter = new SubscriptionExtensionsWriter();
            var mgmtLongRunningOperationWriter = new MgmtLongRunningOperationWriter();

            foreach (var model in context.Library.Models)
            {
                // For the shared models in Core and Resources/Management, we should generate them in Core package and skip in Resources/Management package.
                if (context.Configuration.LibraryName != "Core")
                {
                    if (context.SourceInputModel?.FindForType($"{model.Declaration.Namespace}", model.Declaration.Name) != null)
                    {
                        continue;
                    }
                    var mgmtObj = model as MgmtObjectType;
                    if (mgmtObj != null && ReferenceTypePropertyChooser.GetExactMatch(mgmtObj) != null)
                    {
                        continue;
                    }
                }
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

                project.AddGeneratedFile($"RestOperations/{client.Type.Name}.cs", restCodeWriter.ToString());
            }

            foreach (var resourceOperation in context.Library.ResourceOperations)
            {
                var codeWriter = new CodeWriter();
                var operationWriter = new ResourceOperationWriter(codeWriter, resourceOperation, context);
                operationWriter.WriteClient();

                project.AddGeneratedFile($"{resourceOperation.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var resourceContainer in context.Library.ResourceContainers)
            {
                var codeWriter = new CodeWriter();
                var containerWriter = new ResourceContainerWriter(codeWriter, resourceContainer, context);
                containerWriter.WriteContainer();

                project.AddGeneratedFile($"{resourceContainer.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var model in context.Library.ResourceData)
            {
                var codeWriter = new CodeWriter();
                modelWriter.WriteModel(codeWriter, model);

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);

                var name = model.Type.Name;
                project.AddGeneratedFile($"{name}.cs", codeWriter.ToString());
                project.AddGeneratedFile($"Models/{name}.Serialization.cs", serializerCodeWriter.ToString());
            }

            foreach (var resource in context.Library.ArmResource)
            {
                var codeWriter = new CodeWriter();
                var armResourceWriter = new ResourceWriter(codeWriter, resource, context);
                armResourceWriter.WriteResource();

                project.AddGeneratedFile($"{resource.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var operation in context.Library.LongRunningOperations)
            {
                var codeWriter = new CodeWriter();
                mgmtLongRunningOperationWriter.Write(codeWriter, operation);

                project.AddGeneratedFile($"LongRunningOperation/{operation.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var operation in context.Library.NonLongRunningOperations)
            {
                var codeWriter = new CodeWriter();
                NonLongRunningOperationWriter.Write(codeWriter, operation);

                project.AddGeneratedFile($"LongRunningOperation/{operation.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var tupleResourceOperation in context.Library.TupleResourceOperations)
            {
                var codeWriter = new CodeWriter();
                var resourceOperationWriter = new TupleResourceOperationWriter(codeWriter, tupleResourceOperation, context);
                resourceOperationWriter.WriteClient();

                project.AddGeneratedFile($"{tupleResourceOperation.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var tupleResourceContainer in context.Library.TupleResourceContainers)
            {
                var codeWriter = new CodeWriter();
                new TupleResourceContainerWriter(codeWriter, tupleResourceContainer, context).WriteContainer();

                project.AddGeneratedFile($"{tupleResourceContainer.Type.Name}.cs", codeWriter.ToString());
            }

            var extensionsWriter = new CodeWriter();
            resourceGroupExtensionsWriter.WriteExtension(extensionsWriter, context);
            project.AddGeneratedFile($"Extensions/{ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.ResourceGroups]}.cs", extensionsWriter.ToString());

            var subscriptionExtensionsCodeWriter = new CodeWriter();
            subscriptionExtensionsWriter.WriteExtension(subscriptionExtensionsCodeWriter, context);
            project.AddGeneratedFile($"Extensions/{ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.Subscriptions]}.cs", subscriptionExtensionsCodeWriter.ToString());

            if (context.Library.ManagementGroupChildResources.Count() > 0)
            {
                var managementGroupExtensionsWriter = new ManagementGroupExtensionsWriter();
                var managementGroupExtensionsCodeWriter = new CodeWriter();
                managementGroupExtensionsWriter.WriteExtension(managementGroupExtensionsCodeWriter, context);
                project.AddGeneratedFile($"Extensions/{ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.ManagementGroups]}.cs", managementGroupExtensionsCodeWriter.ToString());
            }
        }
    }
}
