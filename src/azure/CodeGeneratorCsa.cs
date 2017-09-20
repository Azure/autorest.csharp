// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;
using System.Globalization;
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
using static AutoRest.Core.Utilities.DependencyInjection;

namespace AutoRest.CSharp.Azure
{
    public class CodeGeneratorCsa : CodeGeneratorCs
    {
        private const string ClientRuntimePackage = "Microsoft.Rest.ClientRuntime.Azure.3.3.8";

        public override string UsageInstructions => string.Format(CultureInfo.InvariantCulture,
            Properties.Resources.UsageInformation, ClientRuntimePackage);


        /// <summary>
        ///     Generates C# code for service client.
        /// </summary>
        /// <param name="codeModel"></param>
        /// <returns></returns>
        public override async Task Generate(CodeModel cm)
        {
            var codeModel = cm as CodeModelCsa;
            if (codeModel == null)
            {
                throw new InvalidCastException("CodeModel is not a Azure c# CodeModel");
            }

            // Service client
            var serviceClientTemplate = new AzureServiceClientTemplate {Model = codeModel};
            await Write(serviceClientTemplate, $"{codeModel.Name}{ImplementationFileExtension}");

            // Service client interface
            var serviceClientInterfaceTemplate = new ServiceClientInterfaceTemplate {Model = codeModel};
            await Write(serviceClientInterfaceTemplate, "I" + codeModel.Name + ImplementationFileExtension);

            // Operations
            foreach (MethodGroupCs group in codeModel.Operations)
            {
                if (!group.IsCodeModelMethodGroup)
                {
                    // Operation
                    var operationsTemplate = new AzureMethodGroupTemplate {Model = group};
                    await Write(operationsTemplate, operationsTemplate.Model.TypeName + ImplementationFileExtension);

                    // Operation interface
                    var operationsInterfaceTemplate = new MethodGroupInterfaceTemplate {Model = group};
                    await Write(operationsInterfaceTemplate,
                        $"I{operationsInterfaceTemplate.Model.TypeName}{ImplementationFileExtension}");
                }
                var operationExtensionsTemplate = new ExtensionsTemplate {Model = group};
                await Write(operationExtensionsTemplate,
                    $"{group.ExtensionTypeName}Extensions{ImplementationFileExtension}");
            }

            // Models
            foreach (CompositeTypeCs model in codeModel.ModelTypes.Concat(codeModel.HeaderTypes))
            {
                if (model.Extensions.ContainsKey(AzureExtensions.ExternalExtension) &&
                    (bool) model.Extensions[AzureExtensions.ExternalExtension])
                {
                    continue;
                }

                var modelTemplate = new ModelTemplate {Model = model};
                await Write(modelTemplate,Path.Combine(Settings.Instance.ModelsName,
                    $"{model.Name}{ImplementationFileExtension}"));
            }

            // Enums
            foreach (EnumTypeCs enumType in codeModel.EnumTypes)
            {
                var enumTemplate = new EnumTemplate {Model = enumType};
                await Write(enumTemplate,Path.Combine(Settings.Instance.ModelsName,
                    $"{enumTemplate.Model.Name}{ImplementationFileExtension}"));
            }

            // Page class
            foreach (var pageClass in codeModel.pageClasses)
            {
                var pageTemplate = new PageTemplate
                {
                    Model = new Page(pageClass.Value, pageClass.Key.Key, pageClass.Key.Value)
                };
                await Write(pageTemplate, Path.Combine(Settings.Instance.ModelsName,
                    $"{pageTemplate.Model.TypeDefinitionName}{ImplementationFileExtension}"));
            }
            // Exceptions
            foreach (CompositeTypeCs exceptionType in codeModel.ErrorTypes)
            {
                if (exceptionType.Name == "CloudError")
                {
                    continue;
                }

                var exceptionTemplate = new ExceptionTemplate {Model = exceptionType};
                await Write(exceptionTemplate, Path.Combine(Settings.Instance.ModelsName,
                     $"{exceptionTemplate.Model.ExceptionTypeDefinitionName}{ImplementationFileExtension}"));
            }

            // Xml Serialization
            if (codeModel.ShouldGenerateXmlSerialization)
            {
                var xmlSerializationTemplate = new XmlSerializationTemplate { Model = null };
                await Write(xmlSerializationTemplate, Path.Combine(Settings.Instance.ModelsName, $"{XmlSerialization.XmlDeserializationClass}{ImplementationFileExtension}"));
            }
        }
    }
}