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
            var restClientWriter = new MgmtRestClientWriter();
            var serializeWriter = new SerializationWriter();
            var mgmtLongRunningOperationWriter = new MgmtLongRunningOperationWriter();

            foreach (var resource in context.Library.ArmResourcesOfRequestPath)
            {
                foreach (var childResource in resource.ChildResources)
                {
                    var name = childResource.Type.Name;
                }

                foreach (var operationSet in resource.ChildOperations)
                {
                    var name = operationSet.ToString();
                }
            }

            foreach (var resourceData in context.Library.ResourceDataForRequestPath)
            {
                var name = resourceData.Type.Name;
            }

            foreach (var model in context.Library.Models)
            {
                // TODO: A temporay fix for orphaned models in Resources SDK. These models are usually not directly used by ResourceData, but a descendant property of a PropertyReferenceType.
                // Can go way after full orphan fix https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/6000
                // The includeArmCore parameter should also be removed in FindForType() then.
                if (!context.Configuration.MgmtConfiguration.IsArmCore && context.SourceInputModel?.FindForType(model.Declaration.Namespace, model.Declaration.Name, includeArmCore: true) != null)
                {
                    continue;
                }
                if (model is SchemaObjectType objSchema)
                {
                    //skip things that had exact match replacements
                    //TODO: Can go away after full orphan fix https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/6000
                    if (SchemaMatchTracker.TryGetExactMatch(objSchema.ObjectSchema, out var result))
                    {
                        if (result != null)
                            continue;
                    }
                    else if (model is MgmtObjectType mgmtObjType && model.GetType() != typeof(MgmtReferenceType))
                    {
                        //There could be orphaned models that are not a direct property of another model and SchemaMatchTracker haven't tracked them.
                        //TODO: Can go away after full orphan fix https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/6000
                        if (ReferenceTypePropertyChooser.GetExactMatch(mgmtObjType, context) != null)
                            continue;
                    }
                }

                var codeWriter = new CodeWriter();
                ReferenceTypeWriter.GetWriter(model).WriteModel(codeWriter, model);
                var name = model.Type.Name;
                project.AddGeneratedFile($"Models/{name}.cs", codeWriter.ToString());

                if (model is MgmtReferenceType mgmtReferenceType)
                {
                    var extensions = mgmtReferenceType.ObjectSchema.Extensions;
                    if (extensions != null && extensions.MgmtReferenceType)
                        continue;
                }

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);
                project.AddGeneratedFile($"Models/{name}.Serialization.cs", serializerCodeWriter.ToString());
            }

            foreach (var client in context.Library.RestClients)
            {
                var restCodeWriter = new CodeWriter();
                restClientWriter.WriteClient(restCodeWriter, client);

                project.AddGeneratedFile($"RestOperations/{client.Type.Name}.cs", restCodeWriter.ToString());
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
                ReferenceTypeWriter.GetWriter(model).WriteModel(codeWriter, model);

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);

                var name = model.Type.Name;
                project.AddGeneratedFile($"{name}.cs", codeWriter.ToString());
                project.AddGeneratedFile($"Models/{name}.Serialization.cs", serializerCodeWriter.ToString());
            }

            foreach (var resource in context.Library.ArmResources)
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

            foreach (var tupleResource in context.Library.TupleResources)
            {
                var codeWriter = new CodeWriter();
                var resourceWriter = new TupleResourceWriter(codeWriter, tupleResource, context);
                resourceWriter.WriteResource();

                project.AddGeneratedFile($"{tupleResource.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var tupleResourceContainer in context.Library.TupleResourceContainers)
            {
                var codeWriter = new CodeWriter();
                new TupleResourceContainerWriter(codeWriter, tupleResourceContainer, context).WriteContainer();

                project.AddGeneratedFile($"{tupleResourceContainer.Type.Name}.cs", codeWriter.ToString());
            }

            var resourceGroupExtensionsCodeWriter = new CodeWriter();
            new ResourceGroupExtensionsWriter(resourceGroupExtensionsCodeWriter, context).WriteExtension();
            project.AddGeneratedFile($"Extensions/{ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.ResourceGroups]}.cs", resourceGroupExtensionsCodeWriter.ToString());

            var subscriptionExtensionsCodeWriter = new CodeWriter();
            new SubscriptionExtensionsWriter(subscriptionExtensionsCodeWriter, context).WriteExtension();
            project.AddGeneratedFile($"Extensions/{ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.Subscriptions]}.cs", subscriptionExtensionsCodeWriter.ToString());

            if (context.Library.ManagementGroupChildResources.Count() > 0)
            {
                var managementGroupExtensionsCodeWriter = new CodeWriter();
                new ManagementGroupExtensionsWriter(managementGroupExtensionsCodeWriter, context).WriteExtension();
                project.AddGeneratedFile($"Extensions/{ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.ManagementGroups]}.cs", managementGroupExtensionsCodeWriter.ToString());
            }
        }
    }
}
