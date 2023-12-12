// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Reflection;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class CSharpProj
    {
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

        public void Execute(IPluginCommunication autoRest, bool includeDfe, bool includeAzureKeyAuth)
            => Execute(Configuration.Namespace, includeAzureKeyAuth, async (filename, text) =>
            {
                await autoRest.WriteFile(Path.Combine(Configuration.RelativeProjectFolder, filename), text, "source-file-csharp");
            }, includeDfe);

        public void Execute(bool includeDfe, bool includeAzureKeyAuth)
            => Execute(Configuration.Namespace, includeAzureKeyAuth, async (filename, text) =>
            {
                //TODO adding to workspace makes the formatting messed up since its a raw xml document
                //somewhere it tries to parse it as a syntax tree and when it converts back to text
                //its no longer valid xml.  We should consider a "raw files" concept in the work space
                //so the file writing can still remain in one place
                await File.WriteAllTextAsync(Path.Combine(Configuration.AbsoluteProjectFolder, filename), text);
            }, includeDfe);

        private void Execute(string defaultNamespace, bool includeAzureKeyAuth, Action<string, string> writeFile, bool includeDfe)
        {
            var projectFile = defaultNamespace;
            if (Configuration.MgmtTestConfiguration is not null)
            {
                projectFile += ".Tests";
            }
            var csprojContent = Configuration.SkipCSProjPackageReference ? GetCSProj(includeDfe, includeAzureKeyAuth, defaultNamespace) : GetExternalCSProj(includeDfe, includeAzureKeyAuth, defaultNamespace);
            writeFile($"{projectFile}.csproj", csprojContent);
        }

        private string GetCSProj(bool includeDfe, bool includeAzureKeyAuth, string defaultNamespace)
        {
            var builder = new CSProjBuilder()
            {
                TargetFramework = "netstandard2.0",
                TreatWarningsAsErrors = true,
                Nullable = "annotations",
                IncludeManagementSharedCode = Configuration.AzureArm ? true : null,
                DefineConstants = !Configuration.AzureArm && !Configuration.Generation1ConvenienceClient ? new("$(DefineConstants);EXPERIMENTAL") : null
            };
            builder.PackageReferences.Add(new("Azure.Core"));
            if (includeDfe)
            {
                builder.PackageReferences.Add(new("Azure.Core.Expressions.DataFactory"));
            }

            var isMgmtTestProject = Configuration.MgmtTestConfiguration is not null;
            if (isMgmtTestProject)
            {
                builder.ProjectReferences.Add(new($"..\\src\\{defaultNamespace}.csproj"));

                builder.PackageReferences.Add(new("NUnit"));
                builder.PackageReferences.Add(new("Azure.Identity"));

                builder.CompileIncludes.Add(new("..\\..\\..\\..\\src\\assets\\TestFramework\\*.cs"));
            }

            if (Configuration.AzureArm)
            {
                builder.PackageReferences.Add(new("Azure.ResourceManager"));
            }
            else if (!Configuration.Generation1ConvenienceClient)
            {
                builder.PackageReferences.Add(new("Azure.Core.Experimental"));
            }

            if (includeAzureKeyAuth)
            {
                builder.CompileIncludes.Add(new("$(AzureCoreSharedSources)AzureKeyCredentialPolicy.cs", "Shared/Core"));
            }

            return builder.Build();
        }

        private string GetExternalCSProj(bool includeDfe, bool includeAzureKeyAuth, string defaultNamespace)
        {
            var builder = new CSProjBuilder()
            {
                TargetFramework = "netstandard2.0",
                TreatWarningsAsErrors = true,
                Nullable = "annotations",
                IncludeManagementSharedCode = Configuration.AzureArm ? true : null,
                DefineConstants = !Configuration.AzureArm && !Configuration.Generation1ConvenienceClient ? new("$(DefineConstants);EXPERIMENTAL") : null,
                LangVersion = "11.0",
                IncludeGeneratorSharedCode = true,
                RestoreAdditionalProjectSources = "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json"
            };
            builder.PackageReferences.Add(new("Azure.Core"));
            if (includeDfe)
            {
                builder.PackageReferences.Add(new("Azure.Core.Expressions.DataFactory"));
            }

            var isMgmtTestProject = Configuration.MgmtTestConfiguration is not null;
            if (isMgmtTestProject)
            {
                builder.ProjectReferences.Add(new($"..\\src\\{defaultNamespace}.csproj"));

                builder.PackageReferences.Add(new("NUnit"));
                builder.PackageReferences.Add(new("Azure.Identity"));

                builder.CompileIncludes.Add(new("..\\..\\..\\..\\src\\assets\\TestFramework\\*.cs"));
            }

            var version = GetVersion();

            builder.PrivatePackageReferences.Add(new("Microsoft.Azure.AutoRest.CSharp", version));

            return builder.Build();
        }
    }
}
