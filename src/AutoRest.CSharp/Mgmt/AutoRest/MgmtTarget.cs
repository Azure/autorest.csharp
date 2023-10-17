// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.AutoRest.PostProcess;
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

        public static async Task ExecuteAsync(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel? sourceInputModel)
        {
            var addedFilenames = new HashSet<string>();
            MgmtContext.Initialize(new BuildContext<MgmtOutputLibrary>(codeModel, sourceInputModel));
            var serializeWriter = new SerializationWriter();
            var isArmCore = Configuration.MgmtConfiguration.IsArmCore;

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

                var name = model.Type.Name;
                WriteArmModel(project, model, serializeWriter, $"Models/{name}.cs", $"Models/{name}.Serialization.cs");
            }

            foreach (var client in MgmtContext.Library.RestClients)
            {
                var restCodeWriter = new CodeWriter();
                new MgmtRestClientWriter().WriteClient(restCodeWriter, client);

                AddGeneratedFile(project, $"RestOperations/{client.Type.Name}.cs", restCodeWriter.ToString());
            }

            foreach (var resourceCollection in MgmtContext.Library.ResourceCollections)
            {
                var writer = new ResourceCollectionWriter(resourceCollection);
                writer.Write();

                AddGeneratedFile(project, $"{resourceCollection.Type.Name}.cs", writer.ToString());
            }

            foreach (var model in MgmtContext.Library.ResourceData)
            {
                if (model is EmptyResourceData)
                    continue;

                var name = model.Type.Name;
                WriteArmModel(project, model, serializeWriter, $"{name}.cs", $"Models/{name}.Serialization.cs");
            }

            foreach (var resource in MgmtContext.Library.ArmResources)
            {
                var writer = ResourceWriter.GetWriter(resource);
                writer.Write();

                AddGeneratedFile(project, $"{resource.Type.Name}.cs", writer.ToString());
            }

            // write extension class
            WriteExtensions(project, isArmCore, MgmtContext.Library.ExtensionWrapper, MgmtContext.Library.Extensions, MgmtContext.Library.ExtensionClients);

            var lroWriter = new MgmtLongRunningOperationWriter(true);
            lroWriter.Write();
            AddGeneratedFile(project, lroWriter.Filename, lroWriter.ToString());
            lroWriter = new MgmtLongRunningOperationWriter(false);
            lroWriter.Write();
            AddGeneratedFile(project, lroWriter.Filename, lroWriter.ToString());

            foreach (var interimOperation in MgmtContext.Library.InterimOperations.Distinct(LongRunningInterimOperation.LongRunningInterimOperationComparer))
            {
                var writer = new MgmtLongRunningInterimOperationWriter(interimOperation);
                writer.Write();
                AddGeneratedFile(project, $"LongRunningOperation/{interimOperation.TypeName}.cs", writer.ToString());
            }

            foreach (var operationSource in MgmtContext.Library.OperationSources)
            {
                var writer = new OperationSourceWriter(operationSource);
                writer.Write();
                AddGeneratedFile(project, $"LongRunningOperation/{operationSource.Type.Name}.cs", writer.ToString());
            }

            foreach (var model in MgmtContext.Library.PropertyBagModels)
            {
                var name = model.Type.Name;
                WriteArmModel(project, model, serializeWriter, $"Models/{name}.cs", $"Models/{name}.Serialization.cs");
            }

            var modelFactoryProvider = MgmtContext.Library.ModelFactory;
            if (modelFactoryProvider != null)
            {
                var modelFactoryWriter = new ModelFactoryWriter(modelFactoryProvider);
                modelFactoryWriter.Write();
                AddGeneratedFile(project, $"{modelFactoryProvider.Type.Name}.cs", modelFactoryWriter.ToString());
            }

            if (_overriddenProjectFilenames.TryGetValue(project, out var overriddenFilenames))
                throw new InvalidOperationException($"At least one file was overridden during the generation process. Filenames are: {string.Join(", ", overriddenFilenames)}");

            var modelsToKeep = Configuration.MgmtConfiguration.KeepOrphanedModels.ToImmutableHashSet();
            await project.PostProcessAsync(new MgmtPostProcessor(modelsToKeep, modelFactoryProvider?.FullName));
        }

        private static void WriteExtensions(GeneratedCodeWorkspace project, bool isArmCore, MgmtExtensionWrapper extensionWrapper, IEnumerable<MgmtExtension> extensions, IEnumerable<MgmtExtensionClient> extensionClients)
        {
            if (isArmCore)
            {
                // for Azure.ResourceManager (ArmCore), we write the individual extension type providers into their individual files
                foreach (var extension in extensions)
                {
                    if (!extension.IsEmpty)
                        WriteExtensionFile(project, MgmtExtensionWriter.GetWriter(extension));
                }
            }
            else
            {
                // for other packages (not ArmCore), we write extension wrapper (a big class that contains all the extension methods) and do not write the individual extension classes
                if (!extensionWrapper.IsEmpty)
                    WriteExtensionFile(project, new MgmtExtensionWrapperWriter(extensionWrapper));

                // and we write ExtensionClients
                foreach (var extensionClient in extensionClients)
                {
                    if (!extensionClient.IsEmpty)
                        WriteExtensionFile(project, new MgmtExtensionClientWriter(extensionClient));
                }
            }
        }

        private static void WriteExtensionFile(GeneratedCodeWorkspace project, MgmtClientBaseWriter extensionWriter)
        {
            extensionWriter.Write();
            AddGeneratedFile(project, $"Extensions/{extensionWriter.FileName}.cs", extensionWriter.ToString());
        }

        private static bool ShouldSkipModelGeneration(TypeProvider model)
        {
            // since MgmtReferenceType inherits from MgmtObjectType which inherits from SchemaObjectType, we definitely do not want to exclude any generation of ReferenceTypes
            if (model is SchemaObjectType objSchema && model is not MgmtReferenceType)
            {
                if (TypeReferenceTypeChooser.HasMatch(objSchema.ObjectSchema))
                    return true;
            }

            return false;
        }

        private static void WriteArmModel(GeneratedCodeWorkspace project, TypeProvider model, SerializationWriter serializeWriter, string modelFileName, string serializationFileName)
        {
            var codeWriter = new CodeWriter();

            ReferenceTypeWriter.GetWriter(model).WriteModel(codeWriter, model);

            AddGeneratedFile(project, modelFileName, codeWriter.ToString());

            if (model is MgmtReferenceType mgmtReferenceType)
            {
                var extensions = mgmtReferenceType.ObjectSchema.Extensions;
                if (extensions != null && extensions.MgmtReferenceType)
                    return;
            }

            var serializerCodeWriter = new CodeWriter();
            serializeWriter.WriteSerialization(serializerCodeWriter, model);
            AddGeneratedFile(project, serializationFileName, serializerCodeWriter.ToString());
        }
    }
}
