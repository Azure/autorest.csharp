// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
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
        private static IDictionary<GeneratedCodeWorkspace, ISet<string>> _addedProjectFilenames = new Dictionary<GeneratedCodeWorkspace, ISet<string>>();
        private static IDictionary<GeneratedCodeWorkspace, IList<string>> _overriddenProjectFilenames = new Dictionary<GeneratedCodeWorkspace, IList<string>>();

        private static void AddGeneratedFile(GeneratedCodeWorkspace project, string filename, string text)
        {
            if (!_addedProjectFilenames.TryGetValue(project, out var addedFileNames))
            {
                addedFileNames = new HashSet<string>();
                _addedProjectFilenames.Add(project, addedFileNames);
            }
            if (addedFileNames.Contains(filename))
            {
                if (!_overriddenProjectFilenames.TryGetValue(project, out var overriddenFileNames))
                {
                    overriddenFileNames = new List<string>();
                    _overriddenProjectFilenames.Add(project, overriddenFileNames);
                }
                overriddenFileNames.Add(filename);
            }
            else
            {
                addedFileNames.Add(filename);
            }
            project.AddGeneratedFile(filename, text);
        }

        public static void Execute(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel? sourceInputModel, Configuration configuration)
        {
            var addedFilenames = new HashSet<string>();
            MgmtContext.Initialize(new BuildContext<MgmtOutputLibrary>(codeModel, configuration, sourceInputModel));
            var serializeWriter = new SerializationWriter();
            var isArmCore = MgmtContext.MgmtConfiguration.IsArmCore;

            if (!isArmCore)
            {
                var utilCodeWriter = new CodeWriter();
                var staticUtilWriter = new StaticUtilWriter(utilCodeWriter);
                staticUtilWriter.Write();
                AddGeneratedFile(project, $"ProviderConstants.cs", utilCodeWriter.ToString());
            }

            foreach (var model in MgmtContext.Library.Models)
            {
                if (ShouldSkipModelGeneration(model))
                    continue;

                var codeWriter = new CodeWriter();
                ReferenceTypeWriter.GetWriter(model).WriteModel(codeWriter, model);
                var name = model.Type.Name;
                AddGeneratedFile(project, $"Models/{name}.cs", codeWriter.ToString());

                if (model is MgmtReferenceType mgmtReferenceType)
                {
                    var extensions = mgmtReferenceType.ObjectSchema.Extensions;
                    if (extensions != null && extensions.MgmtReferenceType)
                        continue;
                }

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);
                AddGeneratedFile(project, $"Models/{name}.Serialization.cs", serializerCodeWriter.ToString());
            }

            foreach (var client in MgmtContext.Library.RestClients)
            {
                var restCodeWriter = new CodeWriter();
                new MgmtRestClientWriter().WriteClient(restCodeWriter, client);

                AddGeneratedFile(project, $"RestOperations/{client.Type.Name}.cs", restCodeWriter.ToString());
            }

            foreach (var resourceCollection in MgmtContext.Library.ResourceCollections)
            {
                var codeWriter = new CodeWriter();
                new ResourceCollectionWriter(codeWriter, resourceCollection).Write();

                AddGeneratedFile(project, $"{resourceCollection.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var model in MgmtContext.Library.ResourceData)
            {
                if (TypeReferenceTypeChooser.HasMatch(model.ObjectSchema))
                    continue;

                var codeWriter = new CodeWriter();
                ReferenceTypeWriter.GetWriter(model).WriteModel(codeWriter, model);

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);

                var name = model.Type.Name;
                AddGeneratedFile(project, $"{name}.cs", codeWriter.ToString());
                AddGeneratedFile(project, $"Models/{name}.Serialization.cs", serializerCodeWriter.ToString());
            }

            foreach (var resource in MgmtContext.Library.ArmResources)
            {
                var codeWriter = new CodeWriter();
                new ResourceWriter(codeWriter, resource).Write();

                AddGeneratedFile(project, $"{resource.Type.Name}.cs", codeWriter.ToString());
            }

            if (!isArmCore)
            {
                // we will write the ResourceGroupExtensions and SubscriptionExtensions classes even if it does not contain anything
                WriteExtensionPair(project, MgmtContext.Library.ResourceGroupExtensionsClient);
                WriteExtensionPair(project, MgmtContext.Library.SubscriptionExtensionsClient);
            }

            if (!MgmtContext.Library.ManagementGroupExtensions.IsEmpty)
            {
                WriteExtensionPair(project, MgmtContext.Library.ManagementGroupExtensionsClient);
            }

            if (!MgmtContext.Library.TenantExtensions.IsEmpty)
            {
                WriteExtensionPair(project, MgmtContext.Library.TenantExtensionsClient);
            }

            if (!MgmtContext.Library.ArmClientExtensions.IsEmpty)
            {
                var armClientExtension = MgmtContext.Library.ArmClientExtensions;
                var armClientExtensionsCodeWriter = new ArmClientExtensionsWriter(armClientExtension);
                armClientExtensionsCodeWriter.Write();
                AddGeneratedFile(project, $"Extensions/{armClientExtensionsCodeWriter.FileName}.cs", armClientExtensionsCodeWriter.ToString());
            }

            if (!MgmtContext.Library.ArmResourceExtensions.IsEmpty)
            {
                var armResourceExt = MgmtContext.Library.ArmResourceExtensions;
                var armResourceExtensionsCodeWriter = new ArmResourceExtensionsWriter(armResourceExt);
                armResourceExtensionsCodeWriter.Write();
                AddGeneratedFile(project, $"Extensions/{armResourceExtensionsCodeWriter.FileName}.cs", armResourceExtensionsCodeWriter.ToString());
            }

            var lroWriter = new MgmtLongRunningOperationWriter(true);
            lroWriter.Write();
            AddGeneratedFile(project, lroWriter.Filename, lroWriter.ToString());
            lroWriter = new MgmtLongRunningOperationWriter(false);
            lroWriter.Write();
            AddGeneratedFile(project, lroWriter.Filename, lroWriter.ToString());

            foreach (var operationSource in MgmtContext.Library.OperationSources)
            {
                var writer = new OperationSourceWriter(operationSource);
                writer.Write();
                AddGeneratedFile(project, $"LongRunningOperation/{operationSource.TypeName}.cs", writer.ToString());
            }

            if (_overriddenProjectFilenames.TryGetValue(project, out var overriddenFilenames))
                throw new InvalidOperationException($"At least one file was overridden during the generation process. Filenames are: {string.Join(", ", overriddenFilenames)}");
        }

        private static void WriteExtensionPair(GeneratedCodeWorkspace project, MgmtExtensionClient extensionClient)
        {
            WriteExtensionPiece(project, new MgmtExtensionWriter(extensionClient.Extension));
            if (!MgmtContext.MgmtConfiguration.IsArmCore)
                WriteExtensionPiece(project, new ResourceExtensionWriter(extensionClient));
        }

        private static void WriteExtensionPiece(GeneratedCodeWorkspace project, MgmtClientBaseWriter extensionWriter)
        {
            extensionWriter.Write();
            AddGeneratedFile(project, $"Extensions/{extensionWriter.FileName}.cs", extensionWriter.ToString());
        }

        private static bool ShouldSkipModelGeneration(TypeProvider model)
        {
            // TODO: A temporay fix for orphaned models in Resources SDK. These models are usually not directly used by ResourceData, but a descendant property of a PropertyReferenceType.
            // Can go way after full orphan fix https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/6000
            // The includeArmCore parameter should also be removed in FindForType() then.
            if (!MgmtContext.MgmtConfiguration.IsArmCore && MgmtContext.Context.SourceInputModel?.FindForType(model.Declaration.Namespace, model.Declaration.Name, includeArmCore: true) != null)
            {
                return true;
            }

            // do not skip generation of reference types in resource manager
            // some common types (like `PrivateEndpointConnectionData`) will inherit `Resource`
            // it will cause `Resource` not being generated since `Resource` is `usedAsInheritance`
            if (model is MgmtReferenceType)
            {
                return false;
            }

            if (model is SchemaObjectType objSchema)
            {
                //TODO: we need to add logic to replace SubResource with ResourceIdentifier where appropriate until then we won't remove these types
                if (objSchema.ObjectSchema.Name.StartsWith("SubResource"))
                    return false;

                if (TypeReferenceTypeChooser.HasMatch(objSchema.ObjectSchema))
                    return true;

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
                    if (ReferenceTypePropertyChooser.GetExactMatch(mgmtObjType) != null)
                        return true;
                }
            }
            return false;
        }
    }
}
