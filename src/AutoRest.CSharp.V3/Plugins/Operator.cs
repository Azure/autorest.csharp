// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("cs-operator")]
    internal class Operator : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                var writer = new OperationWriter();
                writer.WriteOperationGroup(operationGroup);
                await autoRest.WriteFile($"Generated/Operations/{operationGroup.CSharpName()}.cs", writer.ToFormattedCode(), "source-file-csharp");
            }

            return true;
        }

        public bool ReserializeCodeModel => false;
    }
}
