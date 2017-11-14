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
using System.Collections.Generic;

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
            var codeModel = cm as CodeModelCsa ?? throw new InvalidCastException("CodeModel is not a Azure c# CodeModel");

            await GenerateServiceClient<AzureServiceClientTemplate>(codeModel);
            await GenerateOperations<AzureMethodGroupTemplate>(codeModel.Operations);
            await GenerateModels(codeModel.ModelTypes.Union(codeModel.HeaderTypes));
            await GenerateEnums(codeModel.EnumTypes);
            await GeneratePageClasses(codeModel.pageClasses);
            await GenerateExceptions(codeModel.ErrorTypes);
            if (codeModel.ShouldGenerateXmlSerialization)
            {
                await GenerateXmlSerialization();
            }
        }

        protected virtual async Task GeneratePageClasses(IEnumerable<KeyValuePair<KeyValuePair<string, string>, string>> pageClasses)
        {
            foreach (var pageClass in pageClasses)
            {
<<<<<<< HEAD
                if(enumType.ModelAsExtensible)
                {
                    var extensibleEnumTemplate = new ExtensibleEnumTemplate {Model = enumType};
                        await Write(extensibleEnumTemplate,Path.Combine(Settings.Instance.ModelsName,
                    $"{extensibleEnumTemplate.Model.Name}{ImplementationFileExtension}"));

                    var extensibleEnumConverterTemplate = new ExtensibleEnumConverterTemplate {Model = enumType};
                        await Write(extensibleEnumConverterTemplate,Path.Combine(Settings.Instance.ModelsName,
                    $"{extensibleEnumConverterTemplate.Model.Name+"Converter"}{ImplementationFileExtension}"));
                }
                else 
                {
                    var enumTemplate = new EnumTemplate {Model = enumType};
                    await Write(enumTemplate,Path.Combine(Settings.Instance.ModelsName,
                        $"{enumTemplate.Model.Name}{ImplementationFileExtension}"));
                }
=======
                var page = new Page(pageClass.Value, pageClass.Key.Key, pageClass.Key.Value);
                await Write(new PageTemplate { Model = page }, $"{GeneratedSourcesBaseFolder}{FolderModels}/{page.TypeDefinitionName}{ImplementationFileExtension}");
>>>>>>> b0015e3aea89b6e5af53dd2068b2266e5a628faf
            }
        }

        protected override async Task GenerateExceptions(IEnumerable<CompositeType> errorTypes)
        {
            foreach (CompositeTypeCs exceptionType in errorTypes)
            {
                if (exceptionType.Name == "CloudError")
                {
                    continue;
                }

                var exceptionTemplate = new ExceptionTemplate {Model = exceptionType};
                await Write(exceptionTemplate,
                     $"{GeneratedSourcesBaseFolder}{FolderModels}/{exceptionTemplate.Model.ExceptionTypeDefinitionName}{ImplementationFileExtension}");
            }
        }
    }
}