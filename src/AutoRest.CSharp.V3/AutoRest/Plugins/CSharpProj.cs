// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using AutoRest.CSharp.V3.AutoRest.Communication;
using AutoRest.CSharp.V3.Input;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
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

  <ItemGroup>
    <PackageReference Include=""Azure.Core"" Version=""1.1.0"" />
    <PackageReference Include=""System.Text.Json"" Version=""4.6.0"" />
  </ItemGroup>

</Project>

";
        public async Task<bool> Execute(IPluginCommunication autoRest, CodeModel codeModel, Configuration configuration)
        {
                await autoRest.WriteFile($"{configuration.Title}.csproj", _csProjContent, "source-file-csharp");

            return true;
        }
    }
}
