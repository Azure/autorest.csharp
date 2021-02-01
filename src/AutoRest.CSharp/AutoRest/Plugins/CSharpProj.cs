// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    // ReSharper disable once StringLiteralTypo
    [PluginName("csharpproj")]
    // ReSharper disable once IdentifierTypo
    internal class CSharpProj : IPlugin
    {
        private string _csProjContent = @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <Nullable>annotations</Nullable>
  </PropertyGroup>

  <PropertyGroup>
	<RestoreAdditionalProjectSources>https://azuresdkartifacts.blob.core.windows.net/azure-sdk-tools/index.json</RestoreAdditionalProjectSources>
  </PropertyGroup>
	
  <ItemGroup>
	<PackageReference Include=""Microsoft.Azure.AutoRest.CSharp"" Version=""3.0.0-beta.20210129.2"" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include=""Azure.Core"" Version=""1.6.0"" />
  </ItemGroup>

</Project>

";
        public async Task<bool> Execute(IPluginCommunication autoRest)
        {
            string codeModelFileName = (await autoRest.ListInputs()).FirstOrDefault();
            if (string.IsNullOrEmpty(codeModelFileName))
                throw new Exception("Generator did not receive the code model file.");

            var codeModelYaml = await autoRest.ReadFile(codeModelFileName);
            var codeModel = CodeModelSerialization.DeserializeCodeModel(codeModelYaml);

            var configuration = Configuration.GetConfiguration(autoRest);

            var context = new BuildContext(codeModel, configuration, null);

            await autoRest.WriteFile($"{Configuration.ProjectRelativeDirectory}{context.DefaultNamespace}.csproj", _csProjContent, "source-file-csharp");

            return true;
        }
    }
}
