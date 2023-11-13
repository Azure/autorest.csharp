// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Utilities;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.AutoRest.PostProcess;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MgmtTarget
    {
        private static IDictionary<GeneratedCodeWorkspace, ISet<string>> _addedProjectFilenames = new Dictionary<GeneratedCodeWorkspace, ISet<string>>();
        private static IDictionary<GeneratedCodeWorkspace, IList<string>> _overriddenProjectFilenames = new Dictionary<GeneratedCodeWorkspace, IList<string>>();

        private static bool _reportOnlyModeWarningLogged = false;
        private static void AddGeneratedFile(GeneratedCodeWorkspace project, string filename, string text)
        {
            if (Configuration.MgmtConfiguration.MgmtDebug.ReportOnly)
            {
                if (!_reportOnlyModeWarningLogged)
                {
                    AutoRestLogger.Warning("codegen-report-only is set to true. Skip adding source code file to output.").Wait();
                    _reportOnlyModeWarningLogged = true;
                }
                return;
            }

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

                if (model is MgmtObjectType mot)
                {
                    ObjectModelItem mi = new ObjectModelItem(mot.Declaration.Namespace, mot.Declaration.Name, mot.InputModel.Name, MgmtReport.Instance.TransformSection);
                    mi.Properties = mot.Properties.ToDictionary(p => p.Declaration.Name, p =>
                    {
                        if (p.InputModelProperty != null)
                        {
                            return new PropertyItem(p.Declaration.Name, p.Declaration.Type.GetNameForReport(), mot.GetFullSerializedName(p.InputModelProperty), MgmtReport.Instance.TransformSection);
                        }
                        else
                        {
                            AutoRestLogger.Warning($"Ignore Property '{mi.FullName}.{p.Declaration.Name}' without schema (i.e. AdditionalProperties)").Wait();
                            return new PropertyItem(p.Declaration.Name, p.Declaration.Type.GetNameForReport(), "<NoPropertySchemaFound>", MgmtReport.Instance.TransformSection);
                        }
                    });
                    MgmtReport.Instance.ObjectModelSection.Add(mi.FullName, mi);
                }
                else if (model is EnumType et)
                {
                    var inputType = MgmtContext.Library.InputTypeMap.First(map => map.Value == model).Key;
                    var choices = inputType switch
                    {
                        InputEnumType sc => sc.AllowedValues,
                        _ => throw new InvalidOperationException("Unexpected Schema type for EnumType: " + inputType.GetType())
                    };

                    EnumModelItem mi = new EnumModelItem(et.Declaration.Namespace, et.Declaration.Name, inputType.Name, MgmtReport.Instance.TransformSection);
                    mi.Values = et.Values.ToDictionary(v => v.Declaration.Name, v =>
                    {
                        var found = choices.FirstOrDefault(c => c.Value.ToString() == v.Value.Value?.ToString());
                        if (found == null)
                        {
                            var allValues = string.Join(",", choices.Select(c => c.Value ?? "<null>"));
                            AutoRestLogger.Warning($"Can't find matching enumvalue '{v.Value}' in '{allValues}'").Wait();
                            return new EnumValueItem(v.Declaration.Name, "<no matching enum value found>", MgmtReport.Instance.TransformSection);
                        }
                        return new EnumValueItem(v.Declaration.Name, inputType.GetFullSerializedName(found), MgmtReport.Instance.TransformSection);
                    });
                    MgmtReport.Instance.EnumModelSection.Add(mi.FullName, mi);
                }
                else
                {
                    AutoRestLogger.Warning("Model found which is not MgmtObjectType: " + name).Wait();
                }

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

                var ri = new ResourceItem(resourceCollection, MgmtReport.Instance.TransformSection);
                MgmtReport.Instance.ResourceCollectionSection.Add(ri.Name, ri);

                AddGeneratedFile(project, $"{resourceCollection.Type.Name}.cs", writer.ToString());
            }

            foreach (var model in MgmtContext.Library.ResourceData)
            {
                if (model is EmptyResourceData)
                    continue;

                var name = model.Type.Name;

                ObjectModelItem mi = new ObjectModelItem(model.Declaration.Namespace, model.Declaration.Name, model.InputModel.Name, MgmtReport.Instance.TransformSection);
                mi.Properties = model.Properties.ToDictionary(p => p.Declaration.Name, p =>
                {
                    if (p.InputModelProperty != null)
                    {
                        return new PropertyItem(p.Declaration.Name, p.Declaration.Type.GetNameForReport(), model.GetFullSerializedName(p.InputModelProperty), MgmtReport.Instance.TransformSection);
                    }
                    else
                    {
                        AutoRestLogger.Warning($"Ignore Resource Property '{mi.FullName}.{p.Declaration.Name}' without schema (i.e. AdditionalProperties)").Wait();
                        return new PropertyItem(p.Declaration.Name, p.Declaration.Type.GetNameForReport(), "<NoPropertySchemaFound>", MgmtReport.Instance.TransformSection);
                    }
                });
                MgmtReport.Instance.ObjectModelSection.Add(mi.FullName, mi);

                WriteArmModel(project, model, serializeWriter, $"{name}.cs", $"Models/{name}.Serialization.cs");
            }

            foreach (var resource in MgmtContext.Library.ArmResources)
            {
                var writer = ResourceWriter.GetWriter(resource);
                writer.Write();

                var ri = new ResourceItem(resource, MgmtReport.Instance.TransformSection);
                MgmtReport.Instance.ResourceSection.Add(ri.Name, ri);

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
                    {
                        MgmtReport.Instance.ExtensionSection.Add(extension.ResourceName, new ExtensionItem(extension, MgmtReport.Instance.TransformSection));
                        WriteExtensionFile(project, MgmtExtensionWriter.GetWriter(extension));
                    }
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
                    {
                        MgmtReport.Instance.ExtensionSection.Add(extensionClient.ResourceName, new ExtensionItem(extensionClient, MgmtReport.Instance.TransformSection));
                        WriteExtensionFile(project, new MgmtExtensionClientWriter(extensionClient));
                    }
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
                if (TypeReferenceTypeChooser.HasMatch(objSchema.InputModel))
                    return true;
            }

            return false;
        }

        private static void WriteArmModel(GeneratedCodeWorkspace project, TypeProvider model, SerializationWriter serializeWriter, string modelFileName, string serializationFileName)
        {
            var codeWriter = new CodeWriter();

            ReferenceTypeWriter.GetWriter(model).WriteModel(codeWriter, model);

            AddGeneratedFile(project, modelFileName, codeWriter.ToString());

            // TODO: Handle this while regen resource manager
            //if (model is MgmtReferenceType mgmtReferenceType)
            //{
            //    var extensions = mgmtReferenceType.InputModel.Extensions;
            //    if (extensions != null && extensions.MgmtReferenceType)
            //        return;
            //}

            var serializerCodeWriter = new CodeWriter();
            serializeWriter.WriteSerialization(serializerCodeWriter, model);
            AddGeneratedFile(project, serializationFileName, serializerCodeWriter.ToString());
        }
    }
}
