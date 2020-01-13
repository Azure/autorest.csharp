// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    // ReSharper disable once StringLiteralTypo
    [PluginName("csharpassets")]
    // ReSharper disable once IdentifierTypo
    internal class CSharpAssets : IPlugin
    {
        private string _csProjContent = @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <Nullable>annotations</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Azure.Core"" Version=""1.0.0"" />
    <PackageReference Include=""System.Text.Json"" Version=""4.6.0"" />
  </ItemGroup>

</Project>

";
        public async Task<bool> Execute(IPluginCommunication autoRest, CodeModel codeModel, Configuration configuration)
        {
            if (configuration.IncludeCsProj)
            {
                await autoRest.WriteFile($"{configuration.Title}.csproj", _csProjContent, "source-file-csharp");
            }

            return true;
        }
    }
}
