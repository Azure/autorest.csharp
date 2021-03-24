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
{0}
  <ItemGroup>
    <PackageReference Include=""Azure.Core"" Version=""1.10.0"" />
    <PackageReference Include=""Azure.ResourceManager.Core"" Version=""1.0.0-alpha.20210323.1"" />
  </ItemGroup>

</Project>
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

            string csProjContent;
            if (configuration.SkipCSProjPackageReference)
            {
                csProjContent = string.Format(_csProjContent, "");
            }
            else
            {
                var version = GetVersion();
                var csProjPackageReference = string.Format(_csProjPackageReference, version);
                csProjContent = string.Format(_csProjContent, csProjPackageReference);
            }

            await autoRest.WriteFile($"{Configuration.ProjectRelativeDirectory}{context.DefaultNamespace}.csproj", csProjContent, "source-file-csharp");

            return true;
        }
    }
}
