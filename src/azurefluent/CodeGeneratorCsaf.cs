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

        protected override string GeneratedSourcesBaseFolder => "Generated/";

        /// <summary>
        /// Generates C# code for service client.
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public override async Task Generate(CodeModel cm)
        {
            var codeModel = cm as CodeModelCsa ?? throw new InvalidCastException("CodeModel is not a Azure c# CodeModel");

            await GenerateServiceClient<AzureServiceClientTemplate>(codeModel);
            await GenerateOperations<AzureMethodGroupTemplate>(codeModel.Operations);
            await GenerateModels(codeModel.ModelTypes.Union(codeModel.HeaderTypes).Where(m => !m.IsResource()));
            await GenerateEnums(codeModel.EnumTypes);
            await GeneratePageClasses(codeModel.pageClasses);
            await GenerateExceptions(codeModel.ErrorTypes, codeModel.ModelTypes.Union(codeModel.HeaderTypes).Where(m => !m.IsResource()));
            if (codeModel.ShouldGenerateXmlSerialization)
            {
                await GenerateXmlSerialization();
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
