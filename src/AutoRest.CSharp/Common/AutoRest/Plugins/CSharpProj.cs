﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static System.Net.Mime.MediaTypeNames;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class CSharpProj
    {
        private string _csProjContent = @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <Nullable>annotations</Nullable>
  </PropertyGroup>
{0}{1}{2}

</Project>
";
        private string _coreCsProjContent = @"
  <ItemGroup>
    <PackageReference Include=""Azure.Core"" />
  </ItemGroup>";

        private string _armCsProjContent = @"
  <PropertyGroup>
    <IncludeManagementSharedCode>true</IncludeManagementSharedCode>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Azure.ResourceManager"" />
  </ItemGroup>
";

        private string _csProjPackageReference = @"
  <PropertyGroup>
    <LangVersion>11.0</LangVersion>
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
    <PackageReference Include=""Azure.Core.Experimental"" />
  </ItemGroup>
";
        private string _llcAzureKeyAuth = @"
  <ItemGroup>
    <Compile Include=""$(AzureCoreSharedSources)AzureKeyCredentialPolicy.cs"" LinkBase=""Shared/Core"" />
  </ItemGroup>";

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

        public void Execute(string defaultNamespace, IPluginCommunication autoRest, bool includeDfe, bool includeAzureKeyAuth)
            => Execute(defaultNamespace, includeAzureKeyAuth, async (filename, text) =>
            {
                await autoRest.WriteFile(Path.Combine(Configuration.RelativeProjectFolder, filename), text, "source-file-csharp");
            }, includeDfe);

        public void Execute(string defaultNamespace, bool includeDfe, bool includeAzureKeyAuth)
            => Execute(defaultNamespace, includeAzureKeyAuth, async (filename, text) =>
            {
                //TODO adding to workspace makes the formatting messed up since its a raw xml document
                //somewhere it tries to parse it as a syntax tree and when it converts back to text
                //its no longer valid xml.  We should consider a "raw files" concept in the work space
                //so the file writing can still remain in one place
                await File.WriteAllTextAsync(Path.Combine(Configuration.AbsoluteProjectFolder, filename), text);
            }, includeDfe);

        private void Execute(string defaultNamespace, bool includeAzureKeyAuth, Action<string, string> writeFile, bool includeDfe)
        {
            if (includeDfe)
            {
                _coreCsProjContent += @"
  <ItemGroup>
    <PackageReference Include=""Azure.Core.Expressions.DataFactory"" />
  </ItemGroup>";
            }

            var isMgmtTestProject = Configuration.MgmtTestConfiguration is not null;
            if (isMgmtTestProject)
            {
                _coreCsProjContent += string.Format(@"

  <ItemGroup>
    <ProjectReference Include=""..\src\{0}.csproj"" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include=""NUnit"" />
    <PackageReference Include=""Azure.Identity"" />
  </ItemGroup>

  <ItemGroup>
    <Compile Include = ""..\..\..\..\src\assets\TestFramework\*.cs"" />
  </ItemGroup>", defaultNamespace);
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

                csProjContent = string.Format(_csProjContent, additionalContent, _coreCsProjContent, includeAzureKeyAuth ? _llcAzureKeyAuth : "");
            }
            else
            {
                var version = GetVersion();
                var csProjPackageReference = string.Format(_csProjPackageReference, version);
                csProjContent = string.Format(_csProjContent, csProjPackageReference, _coreCsProjContent, includeAzureKeyAuth ? _llcAzureKeyAuth : "");
            }

            var projectFile = defaultNamespace;
            if (isMgmtTestProject)
            {
                projectFile += ".Tests";
            }
            writeFile($"{projectFile}.csproj", csProjContent);
        }
    }
}
