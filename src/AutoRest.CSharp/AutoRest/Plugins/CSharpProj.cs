// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
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
    <LangVersion>8.0</LangVersion>
    <IncludeGeneratorSharedCode>true</IncludeGeneratorSharedCode>
	<RestoreAdditionalProjectSources>https://azuresdkartifacts.blob.core.windows.net/azure-sdk-tools/index.json</RestoreAdditionalProjectSources>
  </PropertyGroup>
	
  <ItemGroup>
	<PackageReference Include=""Microsoft.Azure.AutoRest.CSharp"" Version=""{0}"" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include=""Azure.Core"" Version=""1.6.0"" />
  </ItemGroup>

</Project>

";
        internal static string GetVersion()
        {
            const string PackagePrefix = "AutoRest.CSharp";

            Assembly clientAssembly = Assembly.GetExecutingAssembly();

            AssemblyInformationalVersionAttribute? versionAttribute = clientAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (versionAttribute == null)
            {
                throw new InvalidOperationException($"{nameof(AssemblyInformationalVersionAttribute)} is required on client SDK assembly '{clientAssembly.FullName}'");
            }

            string version = versionAttribute.InformationalVersion;

            string assemblyName = clientAssembly.GetName().Name!;
            if (assemblyName.StartsWith(PackagePrefix, StringComparison.Ordinal))
            {
                assemblyName = assemblyName.Substring(PackagePrefix.Length);
            }

            int hashSeparator = version.IndexOf('+');
            version = version.Substring(0, hashSeparator);

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

            var version = GetVersion();
            var csProjContent = string.Format(_csProjContent, version);

            await autoRest.WriteFile($"{Configuration.ProjectRelativeDirectory}{context.DefaultNamespace}.csproj", csProjContent, "source-file-csharp");

            return true;
        }
    }
}
