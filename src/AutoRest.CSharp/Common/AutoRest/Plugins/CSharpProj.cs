﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;
using System.Text.Json;

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
{0}{1}

</Project>
";
        private string _coreCsProjContent = @"
  <ItemGroup>
    <PackageReference Include=""Azure.Core"" Version=""1.22.0-alpha.20211207.1"" />
  </ItemGroup>";

        private string _armCsProjContent = @"
  <PropertyGroup>
    <IncludeManagementSharedCode>true</IncludeManagementSharedCode>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Azure.ResourceManager"" Version=""1.0.0-beta.7"" />
  </ItemGroup>
";

        private string _csProjPackageReference = @"
  <PropertyGroup>
    <LangVersion>8.0</LangVersion>
    <IncludeGeneratorSharedCode>true</IncludeGeneratorSharedCode>
    <RestoreAdditionalProjectSources>https://azuresdkartifacts.blob.core.windows.net/azure-sdk-tools/index.json</RestoreAdditionalProjectSources>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.Azure.AutoRest.CSharp"" Version=""{0}"" PrivateAssets=""All"" />
  </ItemGroup>
";

        private string _llcProjectContent = @"
  <PropertyGroup>
    <DefineConstants>$(DefineConstants);EXPERIMENTAL</DefineConstants>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include=""Azure.Core.Experimental"" Version=""0.1.0-preview.18"" />
  </ItemGroup>
";

        internal static string GetVersion()
        {
            Assembly clientAssembly = Assembly.GetExecutingAssembly();

            AssemblyInformationalVersionAttribute? versionAttribute = clientAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (versionAttribute == null)
            {
                throw new InvalidOperationException($"{nameof(AssemblyInformationalVersionAttribute)} is required on client SDK assembly '{clientAssembly.FullName}'");
            }

            string version = versionAttribute.InformationalVersion;

            int hashSeparator = version.IndexOf('+');
            if (hashSeparator != -1)
            {
                return version.Substring(0, hashSeparator);
            }

            return version;
        }

        public async Task<bool> Execute(IPluginCommunication autoRest)
        {
            string codeModelFileName = (await autoRest.ListInputs()).FirstOrDefault();
            if (string.IsNullOrEmpty(codeModelFileName))
                throw new Exception("Generator did not receive the code model file.");

            var codeModelYaml = await autoRest.ReadFile(codeModelFileName);
            var codeModel = CodeModelSerialization.DeserializeCodeModel(codeModelYaml);

            var configuration = Configuration.GetConfiguration(autoRest);

            var context = new BuildContext(codeModel, configuration, null);

            var isTestProject = configuration.MgmtConfiguration.TestModeler is not null;
            if (isTestProject)
            {
                _coreCsProjContent += string.Format(@"

  <ItemGroup>
    <ProjectReference Include=""..\src\{0}.csproj"" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include = ""NUnit"" Version = ""3.12.0"" />
  </ItemGroup>

  <ItemGroup>
    <Compile Include = ""..\..\..\..\src\assets\TestFramework\*.cs"" />
  </ItemGroup>", context.DefaultNamespace);
            }

            string csProjContent;
            if (configuration.SkipCSProjPackageReference)
            {
                string additionalContent = string.Empty;
                if (configuration.AzureArm)
                {
                  additionalContent += _armCsProjContent;
                }
                if (configuration.DataPlane)
                {
                  additionalContent += _llcProjectContent;
                }

                csProjContent = string.Format(_csProjContent, additionalContent, _coreCsProjContent);
            }
            else
            {
                var version = GetVersion();
                var csProjPackageReference = string.Format(_csProjPackageReference, version);
                csProjContent = string.Format(_csProjContent, csProjPackageReference, _coreCsProjContent);
            }

            var projectFile = $"{configuration.ProjectFolder}{context.DefaultNamespace}";
            if (isTestProject)
            {
                projectFile += "Test";
            }
            await autoRest.WriteFile($"{projectFile}.csproj", csProjContent, "source-file-csharp");

            return true;
        }
    }
}
