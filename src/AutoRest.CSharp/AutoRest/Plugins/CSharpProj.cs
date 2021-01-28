// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Input;

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

  <ItemGroup>
    <PackageReference Include=""Azure.Core"" Version=""1.1.0"" />
    <PackageReference Include=""System.Text.Json"" Version=""4.6.0"" />
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

            var defaultLibraryName = codeModel.Language.Default.Name;
            var ns = await autoRest.GetValue<string>("namespace");

            await autoRest.WriteFile($"{Configuration.ProjectRelativeDirectory}{ns ?? defaultLibraryName}.csproj", _csProjContent, "source-file-csharp");

            return true;
        }
    }
}
