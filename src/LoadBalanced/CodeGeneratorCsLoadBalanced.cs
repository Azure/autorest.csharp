using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Model;
using AutoRest.CSharp.LoadBalanced.Templates.Rest.Client;
using VanillaTemplates = AutoRest.CSharp.vanilla.Templates.Rest.Client;
using System.Linq;

namespace AutoRest.CSharp.LoadBalanced
{
    public class CodeGeneratorCsLoadBalanced : CodeGeneratorCs
    {
        protected override async Task GenerateClientSideCode(CodeModelCs codeModel)
        {
            await GenerateServiceClient<ServiceClientTemplate>(codeModel);
            await GenerateOperations<VanillaTemplates.MethodGroupTemplate>(codeModel.Operations);
            await GenerateModels(codeModel.ModelTypes.Union(codeModel.HeaderTypes));
            await GenerateEnums(codeModel.EnumTypes);
            await GenerateExceptions(codeModel.ErrorTypes);
            if (codeModel.ShouldGenerateXmlSerialization)
            {
                await GenerateXmlSerialization();
            }

            await Write(new ExtendedServiceClientTemplate { Model = codeModel }, $"{GeneratedSourcesBaseFolder}LoadBalanced{codeModel.Name}{ImplementationFileExtension}");
            await Write(new ConfigTemplate { Model = codeModel }, $"{GeneratedSourcesBaseFolder}LoadBalancingConfigBase{ImplementationFileExtension}");
            await Write(new ConfigInterfaceTemplate { Model = codeModel }, $"{GeneratedSourcesBaseFolder}ILoadBalancingConfig{ImplementationFileExtension}");
        }
    }
}
