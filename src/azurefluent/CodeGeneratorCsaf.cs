// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.CSharp.Azure.Model;

using AutoRest.CSharp.azure.Templates;
using AutoRest.CSharp.Model;

using AutoRest.CSharp.vanilla.Templates.Rest.Client;
using AutoRest.CSharp.vanilla.Templates.Rest.Common;
using AutoRest.Extensions.Azure;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.azurefluent.Templates;

namespace AutoRest.CSharp.Azure.Fluent
{
    public class CodeGeneratorCsaf : CodeGeneratorCsa
    {
        private const string ClientRuntimePackage = "Microsoft.Rest.ClientRuntime.Azure.3.2.0";

        /// <summary>
        /// Generates C# code for service client.
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public override async Task Generate(CodeModel cm)
        {
            var codeModel = cm as CodeModelCsa;
            if (codeModel == null)
            {
                throw new InvalidCastException("CodeModel is not a Azure c# CodeModel");
            }

            // Service client
            var serviceClientTemplate = new AzureServiceClientTemplate { Model = codeModel };
            await Write(serviceClientTemplate, $"Generated/{codeModel.Name}{ImplementationFileExtension}");

            // Service client interface
            var serviceClientInterfaceTemplate = new ServiceClientInterfaceTemplate { Model = codeModel };
            await Write(serviceClientInterfaceTemplate, $"Generated/I{codeModel.Name}{ImplementationFileExtension}");

            // Operations
            foreach (MethodGroupCs group in codeModel.Operations)
            {
                if (!group.IsCodeModelMethodGroup)
                {
                    // Operation
                    var operationsTemplate = new AzureMethodGroupTemplate { Model = group };
                    await Write(operationsTemplate, $"Generated/{operationsTemplate.Model.TypeName}{ImplementationFileExtension}");

                    // Operation interface
                    var operationsInterfaceTemplate = new MethodGroupInterfaceTemplate { Model = group };
                    await Write(operationsInterfaceTemplate,
                        $"Generated/I{operationsInterfaceTemplate.Model.TypeName}{ImplementationFileExtension}");
                }
                var operationExtensionsTemplate = new ExtensionsTemplate { Model = group };
                await Write(operationExtensionsTemplate,
                    $"Generated/{group.ExtensionTypeName}Extensions{ImplementationFileExtension}");
            }

            // Models
            foreach (CompositeTypeCs model in codeModel.ModelTypes.Concat(codeModel.HeaderTypes))
            {
                if (true == model.Extensions.Get<bool>(AzureExtensions.ExternalExtension))
                {
                    continue;
                }
                if (model.IsResource())
                {
                    continue;
                }
                var modelTemplate = new ModelTemplate { Model = model };
                await Write(modelTemplate, Path.Combine("Generated", Settings.Instance.ModelsName,
                    $"{model.Name}{ImplementationFileExtension}"));
            }

            // Enums
            foreach (EnumTypeCs enumType in codeModel.EnumTypes)
            {
                var enumTemplate = new EnumTemplate { Model = enumType };
                await Write(enumTemplate, Path.Combine("Generated", Settings.Instance.ModelsName,
                    $"{enumTemplate.Model.Name}{ImplementationFileExtension}"));
            }

            // Page class
            foreach (var pageClass in codeModel.pageClasses)
            {
                var pageTemplate = new PageTemplate
                {
                    Model = new Page(pageClass.Value, pageClass.Key.Key, pageClass.Key.Value)
                };
                await Write(pageTemplate, Path.Combine("Generated", Settings.Instance.ModelsName,
                    $"{pageTemplate.Model.TypeDefinitionName}{ImplementationFileExtension}"));
            }
            // Exceptions
            foreach (CompositeTypeCs exceptionType in codeModel.ErrorTypes)
            {
                if (exceptionType.Name == "CloudError")
                {
                    continue;
                }

                var exceptionTemplate = new ExceptionTemplate { Model = exceptionType };
                await Write(exceptionTemplate, Path.Combine("Generated", Settings.Instance.ModelsName,
                     $"{exceptionTemplate.Model.ExceptionTypeDefinitionName}{ImplementationFileExtension}"));
            }

            // Xml Serialization
            if (codeModel.ShouldGenerateXmlSerialization)
            {
                var xmlSerializationTemplate = new XmlSerializationTemplate { Model = null };
                await Write(xmlSerializationTemplate, Path.Combine("Generated", Settings.Instance.ModelsName, $"{XmlSerialization.XmlDeserializationClass}{ImplementationFileExtension}"));
            }

            if (Settings.Instance.Host?.GetValue<bool?>("regenerate-manager").Result == true)
            {
                await Write(
                    new AzureServiceManagerTemplate { Model = codeModel },
                    codeModel.ServiceName + "Manager" + ImplementationFileExtension);
                
                await Write(
                    new AzureCsprojTemplate { Model = codeModel },
                    $"Microsoft.Azure.Management.{codeModel.ServiceName}.Fluent.csproj");

                await Write(
                    new AzureAssemblyInfoTemplate { Model = codeModel },
                    "Properties/AssemblyInfo.cs");
            }
        }
    }
}
