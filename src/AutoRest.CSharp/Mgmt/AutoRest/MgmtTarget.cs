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

            foreach (var model in context.Library.Models)
            {
                if (ShouldSkipModelGeneration(model, context))
                    continue;

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
                containerWriter.Write();

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
                armResourceWriter.Write();

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

            var resourceGroupExtensionsCodeWriter = new CodeWriter();
            new ResourceGroupExtensionsWriter(resourceGroupExtensionsCodeWriter, context.Library.ResourceGroupExtensions, context).WriteExtension();
            //new ResourceGroupExtensionsWriter(resourceGroupExtensionsCodeWriter, context).WriteExtension();
            project.AddGeneratedFile($"Extensions/{context.Library.ResourceGroupExtensions.Type.Name}.cs", resourceGroupExtensionsCodeWriter.ToString());

            var subscriptionExtensionsCodeWriter = new CodeWriter();
            new SubscriptionExtensionsWriter(subscriptionExtensionsCodeWriter, context.Library.SubscriptionExtensions, context).WriteExtension();
            project.AddGeneratedFile($"Extensions/{context.Library.SubscriptionExtensions.Type.Name}.cs", subscriptionExtensionsCodeWriter.ToString());

            var managementGroupExtensionsCodeWriter = new CodeWriter();
            new ManagementGroupExtensionsWriter(managementGroupExtensionsCodeWriter, context.Library.ManagementGroupExtensions, context).WriteExtension();
            project.AddGeneratedFile($"Extensions/{context.Library.ManagementGroupExtensions.Type.Name}.cs", managementGroupExtensionsCodeWriter.ToString());

            var tenantExtensionsCodeWriter = new CodeWriter();
            new TenantExtensionsWriter(tenantExtensionsCodeWriter, context.Library.TenantExtensions, context).WriteExtension();
            project.AddGeneratedFile($"Extensions/{context.Library.TenantExtensions.Type.Name}.cs", tenantExtensionsCodeWriter.ToString());

            var armClientExtensionsCodeWriter = new CodeWriter();
            new ArmClientExtensionsWriter(armClientExtensionsCodeWriter, context.Library.ArmClientExtensions, context).WriteExtension();
            project.AddGeneratedFile($"Extensions/{context.Library.ArmClientExtensions.Type.Name}.cs", armClientExtensionsCodeWriter.ToString());
        }

        private static bool ShouldSkipModelGeneration(TypeProvider model, BuildContext<MgmtOutputLibrary> context)
        {
            // TODO: A temporay fix for orphaned models in Resources SDK. These models are usually not directly used by ResourceData, but a descendant property of a PropertyReferenceType.
            // Can go way after full orphan fix https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/6000
            // The includeArmCore parameter should also be removed in FindForType() then.
            if (!context.Configuration.MgmtConfiguration.IsArmCore && context.SourceInputModel?.FindForType(model.Declaration.Namespace, model.Declaration.Name, includeArmCore: true) != null)
            {
                return true;
            }
            if (model is SchemaObjectType objSchema)
            {
                //TODO: we need to add logic to replace SubResource with ResourceIdentifier where appropriate until then we won't remove these types
                if (objSchema.ObjectSchema.Name.StartsWith("SubResource"))
                    return false;
                //skip things that had exact match replacements
                //TODO: Can go away after full orphan fix https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/6000
                //Since we forced the evaluation of inheritance and property match for all models before, here we can use the fully loaded cache to
                //get the information that whether the model has been used as a base class for inheritance and as a property.
                var usedAsInheritance = InheritanceChooser.TryGetCachedExactMatch(objSchema.ObjectSchema, out var inheritanceResult);
                var usedAsProperty = ReferenceTypePropertyChooser.TryGetCachedExactMatch(objSchema.ObjectSchema, out var propertyResult);
                if (usedAsInheritance && usedAsProperty)
                {
                    //If the model is used both as a base class for inheritance and a property, we only remove the model when it has matches in both cases.
                    if (inheritanceResult != null && propertyResult != null)
                        return true;
                }
                else if (inheritanceResult != null || propertyResult != null)
                    return true;
                else if (model is MgmtObjectType mgmtObjType && model.GetType() != typeof(MgmtReferenceType))
                {
                    //In the cache of ReferenceTypePropertyChooser, only models used as a direct property of another model is stored.
                    //There could be orphaned models that are not a direct property of another model and is not tracked by cache.
                    //TODO: Can go away after full orphan fix https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/6000
                    if (ReferenceTypePropertyChooser.GetExactMatch(mgmtObjType, context) != null)
                        return true;
                }
            }
            return false;
        }
    }
}
