// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
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
{0}{1}

</Project>
";
        private string _coreCsProjContent = @"
  <ItemGroup>
    <PackageReference Include=""Azure.Core"" Version=""1.25.0-alpha.20220504.1"" />
  </ItemGroup>";

        private string _armCsProjContent = @"
  <PropertyGroup>
    <IncludeManagementSharedCode>true</IncludeManagementSharedCode>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Azure.ResourceManager"" Version=""1.0.0"" />
  </ItemGroup>
";

        private string _csProjPackageReference = @"
  <PropertyGroup>
    <LangVersion>9.0</LangVersion>
    <IncludeGeneratorSharedCode>true</IncludeGeneratorSharedCode>
    <RestoreAdditionalProjectSources>https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json</RestoreAdditionalProjectSources>
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

            Configuration.Initialize(autoRest);

            var context = new BuildContext(codeModel, null);

            var isTestProject = Configuration.MgmtConfiguration.TestModeler is not null;
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
    <PackageReference Include=""Azure.ResourceManager.Resources"" Version=""1.1.0""/>
  </ItemGroup>", context.DefaultNamespace);
            }

            string csProjContent;
            if (Configuration.SkipCSProjPackageReference)
            {
                string additionalContent = string.Empty;
                if (Configuration.AzureArm)
                {
                  additionalContent += _armCsProjContent;
                }
                else if (!Configuration.Generation1ConvenienceClient)
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

            var projectFile = $"{Configuration.ProjectFolder}{context.DefaultNamespace}";
            if (isTestProject)
            {
                projectFile += "Test";
            }
            await autoRest.WriteFile($"{projectFile}.csproj", csProjContent, "source-file-csharp");

            return true;
        }
    }
}
