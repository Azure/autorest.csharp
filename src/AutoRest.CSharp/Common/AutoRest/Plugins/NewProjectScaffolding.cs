// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using static AutoRest.CSharp.Generation.Writers.CSProjWriter;

namespace AutoRest.CSharp.Common.AutoRest.Plugins
{
    internal class NewProjectScaffolding
    {
        private string _serviceDirectoryName;
        private string _projectDirectory;
        private string _testDirectory;
        private string _serviceDirectory;
        private string _samplesDirectory;
        private bool _isAzureSdk;
        private bool _needAzureKeyAuth;
        private bool _includeDfe;

        public NewProjectScaffolding(bool needAzureKeyAuth, bool includeDfe)
        {
            _serviceDirectoryName = Path.GetFileName(Path.GetFullPath(Path.Combine(Configuration.AbsoluteProjectFolder, "..", "..")));
            _projectDirectory = Path.Combine(Configuration.AbsoluteProjectFolder, "..");
            _testDirectory = Path.Combine(Configuration.AbsoluteProjectFolder, "..", "tests");
            _samplesDirectory = Path.Combine(Configuration.AbsoluteProjectFolder, "..", "samples");
            _serviceDirectory = Path.Combine(Configuration.AbsoluteProjectFolder, "..", "..");
            _isAzureSdk = Configuration.Namespace.StartsWith("Azure.");
            _needAzureKeyAuth = needAzureKeyAuth;
            _includeDfe = includeDfe;
        }

        public async Task<bool> Execute()
        {
            if (!_isAzureSdk)
            {
                //clean up old sln and csproj files
                foreach (var file in Directory.GetFiles(_projectDirectory, "*.csproj", SearchOption.AllDirectories))
                {
                    File.Delete(file);
                }
                foreach (var file in Directory.GetFiles(_projectDirectory, "*.sln", SearchOption.AllDirectories))
                {
                    File.Delete(file);
                }
            }

            if (_isAzureSdk)
                await WriteServiceDirectoryFiles();

            await WriteSolutionFiles();

            await WriteProjectFiles();

            await WriteTestFiles();

            if (Configuration.AzureArm)
            {
                await WriteAssetJson();
                await WriteSamplesProject();
            }

            return true;
        }

        private async Task WriteAssetJson()
        {
            await File.WriteAllBytesAsync(Path.Combine(_projectDirectory, "assets.json"), Encoding.ASCII.GetBytes(GetAssetContent("AssetJson.txt", Configuration.Namespace.Split('.').Last().ToLower(), Configuration.Namespace)));
        }

        private async Task WriteServiceDirectoryFiles()
        {
            //TODO handle existing ci where multiple projects are in the same service directory
            string ciYmlFile = Path.Combine(_serviceDirectory, "ci.yml");
            if (!File.Exists(ciYmlFile))
                await File.WriteAllBytesAsync(ciYmlFile, Encoding.ASCII.GetBytes(GetCiYml()));
        }

        private async Task WriteTestFiles()
        {
            if (!Configuration.GenerateTestProject && !Configuration.GenerateSampleProject)
                return;

            if (!Directory.Exists(_testDirectory))
                Directory.CreateDirectory(_testDirectory);

            await File.WriteAllBytesAsync(Path.Combine(_testDirectory, $"{Configuration.Namespace}.Tests.csproj"), Encoding.ASCII.GetBytes(GetTestCSProj()));
            if (Configuration.AzureArm)
            {
                await File.WriteAllBytesAsync(Path.Combine(_testDirectory, $"{Configuration.Namespace.Split('.').Last()}ManagementTestBase.cs"), Encoding.ASCII.GetBytes(GetAssetContent("TestBase_Mgmt.cs", Configuration.Namespace, Configuration.Namespace.Split('.').Last())));
                await File.WriteAllBytesAsync(Path.Combine(_testDirectory, $"{Configuration.Namespace.Split('.').Last()}ManagementTestEnvironment.cs"), Encoding.ASCII.GetBytes(GetAssetContent("TestEnvironment_Mgmt.cs", Configuration.Namespace, Configuration.Namespace.Split('.').Last())));
            }
        }

        private async Task WriteProjectFiles()
        {
            await File.WriteAllBytesAsync(Path.Combine(Configuration.AbsoluteProjectFolder, $"{Configuration.Namespace}.csproj"), Encoding.ASCII.GetBytes(GetSrcCSProj()));
            Directory.CreateDirectory(Path.Combine(Configuration.AbsoluteProjectFolder, "Properties"));
            await File.WriteAllBytesAsync(Path.Combine(Configuration.AbsoluteProjectFolder, "Properties", "AssemblyInfo.cs"), Encoding.ASCII.GetBytes(GetAssemblyInfo()));
        }

        private async Task WriteSolutionFiles()
        {
            await File.WriteAllBytesAsync(Path.Combine(_projectDirectory, $"{Configuration.Namespace}.sln"), Encoding.ASCII.GetBytes(GetSln()));
            if (_isAzureSdk)
            {
                await File.WriteAllBytesAsync(Path.Combine(_projectDirectory, "Directory.Build.props"), Encoding.ASCII.GetBytes(GetAssetContent("Directory.Build.props")));
                await File.WriteAllBytesAsync(Path.Combine(_projectDirectory, "README.md"), Encoding.ASCII.GetBytes(!Configuration.AzureArm ? GetReadme() : GetAssetContent("Readme_Mgmt.md", Configuration.Namespace.Split('.').Last(), Configuration.Namespace)));
                await File.WriteAllBytesAsync(Path.Combine(_projectDirectory, "CHANGELOG.md"), Encoding.ASCII.GetBytes(GetAssetContent("CHANGELOG.md")));
            }
        }

        private string GetAssemblyInfo()
        {
            const string publicKey = StaticStrings.publicKeyAssemblyInfo;
            const string assemblyInfoContent = StaticStrings.assemblyInfoContentAssemblyInfo;
            string azureResourceProvider = string.Format(StaticStrings.resourceProviderAssemblyIfno, !Configuration.AzureArm ? "Microsoft.Template" : Configuration.Namespace.Split('.').Last());
            return string.Format(assemblyInfoContent, Configuration.Namespace, Configuration.IsBranded ? publicKey : string.Empty, _isAzureSdk ? azureResourceProvider : string.Empty);
        }

        private string GetReadme()
        {
            string multipleApiVersionContent = GetAssetContent("Readme_multipleApiVersionContent_DataPlane.md");
            string readmeContent = GetAssetContent("Readme_readmeContent_DataPlane.md", Configuration.Namespace, _serviceDirectoryName, (Configuration.AzureArm || Configuration.Generation1ConvenienceClient) ? "" : multipleApiVersionContent);
            return readmeContent;
        }

        private string GetCiYml()
        {
            string safeName = Configuration.Namespace.Replace(".", "");
            string ciYmlContent = GetAssetContent("ci.yml", _serviceDirectoryName, Configuration.Namespace, safeName);
            return ciYmlContent;
        }

        private string GetBrandedSrcCSProj()
        {
            var builder = new CSProjWriter()
            {
                Description = !Configuration.AzureArm ? $"This is the {Configuration.Namespace} client library for developing .NET applications with rich experience." : $"Azure Resource Manager client SDK for Azure resource provider {Configuration.Namespace.Split('.').Last()}.",
                AssemblyTitle = !Configuration.AzureArm ? new CSProjProperty($"Azure SDK Code Generation {Configuration.Namespace} for Azure Data Plane") : null,
                Version = "1.0.0-beta.1",
                PackageTags = !Configuration.AzureArm ? Configuration.Namespace : $"azure;management;arm;resource manager;{Configuration.Namespace.Split('.').Last().ToLower()}",
                TargetFrameworks = !Configuration.AzureArm ? new CSProjProperty("$(RequiredTargetFrameworks)") : null,
                IncludeOperationsSharedSource = !Configuration.AzureArm ? new CSProjProperty("true") : null,
            };
            if (Configuration.AzureArm)
            {
                builder.PackageId = Configuration.Namespace;
            }
            if (_needAzureKeyAuth)
                builder.CompileIncludes.Add(new("$(AzureCoreSharedSources)AzureKeyCredentialPolicy.cs", "Shared/Core"));
            if (!Configuration.AzureArm)
            {
                // only branded library will add these shared code compilation lines
                builder.CompileIncludes.Add(new("$(AzureCoreSharedSources)AzureResourceProviderNamespaceAttribute.cs", "Shared/Core"));
                foreach (var packages in _brandedDependencyPackages)
                {
                    builder.PackageReferences.Add(packages);
                }
            }

            if (_includeDfe)
            {
                builder.PackageReferences.Add(new("Azure.Core.Expressions.DataFactory"));
            }

            return builder.Write();
        }

        private string GetUnbrandedSrcCSProj()
        {
            var builder = new CSProjWriter()
            {
                Description = $"This is the {Configuration.Namespace} client library for developing .NET applications with rich experience.",
                AssemblyTitle = $"SDK Code Generation {Configuration.Namespace}",
                Version = "1.0.0-beta.1",
                PackageTags = Configuration.Namespace,
                TargetFramework = "netstandard2.0",
                LangVersion = "latest",
                GenerateDocumentationFile = true,
            };
            foreach (var packages in _unbrandedDependencyPackages)
            {
                builder.PackageReferences.Add(packages);
            }

            return builder.Write();
        }

        private string GetSrcCSProj() => Configuration.IsBranded ? GetBrandedSrcCSProj() : GetUnbrandedSrcCSProj();

        private static readonly IReadOnlyList<CSProjWriter.CSProjDependencyPackage> _brandedDependencyPackages = new CSProjWriter.CSProjDependencyPackage[]
        {
            new("Azure.Core"),
            new("System.Text.Json")
        };

        private static readonly IReadOnlyList<CSProjWriter.CSProjDependencyPackage> _unbrandedDependencyPackages = new CSProjWriter.CSProjDependencyPackage[]
        {
            new("System.ClientModel", "1.1.0-beta.3"),
            new("System.Text.Json", "4.7.2")
        };

        private static readonly IReadOnlyList<CSProjWriter.CSProjDependencyPackage> _brandedTestDependencyPackages = new CSProjWriter.CSProjDependencyPackage[]
        {
            new("Azure.Identity"),
            new("NUnit"),
            new("NUnit3TestAdapter"),
            new("Microsoft.NET.Test.Sdk"),
            new("Moq")
        };

        private static readonly IReadOnlyList<CSProjWriter.CSProjDependencyPackage> _brandedSampleDependencyPackagesMgmtVersion = new CSProjWriter.CSProjDependencyPackage[]
        {
            new("Azure.Identity","1.11.4"),
            new("NUnit","3.13.2"),
            new("NUnit3TestAdapter","4.4.2"),
        };

        private static readonly IReadOnlyList<CSProjWriter.CSProjDependencyPackage> _brandedSampleDependencyPackagesMgmt = new CSProjWriter.CSProjDependencyPackage[]
        {
            new("Azure.Identity"),
            new("NUnit"),
            new("NUnit3TestAdapter"),
        };

        private static readonly IReadOnlyList<CSProjWriter.CSProjDependencyPackage> _unbrandedTestDependencyPackages = new CSProjWriter.CSProjDependencyPackage[]
        {
            new("NUnit", "3.13.2"),
            new("NUnit3TestAdapter", "4.4.2"),
            new("Microsoft.NET.Test.Sdk", "17.0.0"),
            new("Moq", "[4.18.2]")
        };

        private string GetBrandedTestCSProj()
        {
            var writer = !Configuration.AzureArm ? new CSProjWriter()
            {
                TargetFrameworks = "$(RequiredTargetFrameworks)",
                NoWarn = new("$(NoWarn);CS1591", "We don't care about XML doc comments on test types and members")
            } : new CSProjWriter();

            // add the project references
            if (_isAzureSdk)
            {
                writer.ProjectReferences.Add(new("$(AzureCoreTestFramework)"));
            }
            writer.ProjectReferences.Add(new($"..\\src\\{Configuration.Namespace}.csproj"));
            // add the package references
            if (!Configuration.AzureArm)
            {
                foreach (var package in _brandedTestDependencyPackages)
                {
                    writer.PackageReferences.Add(package);
                }
            }

            return writer.Write();
        }

        private string GetUnbrandedTestCSProj()
        {
            var writer = new CSProjWriter()
            {
                TargetFramework = "net8.0",
                NoWarn = new("$(NoWarn);CS1591", "Ignore XML doc comments on test types and members")
            };

            // add the project references
            writer.ProjectReferences.Add(new($"..\\src\\{Configuration.Namespace}.csproj"));
            // add the package references
            foreach (var package in _unbrandedTestDependencyPackages)
            {
                writer.PackageReferences.Add(package);
            }

            return writer.Write();
        }

        private string GetTestCSProj() => Configuration.IsBranded ? GetBrandedTestCSProj() : GetUnbrandedTestCSProj();

        private string GetSln()
        {
            string slnContent = @"Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.29709.97
MinimumVisualStudioVersion = 10.0.40219.1
";

            string testFrameworkConfig = @"Project(""{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}"") = ""Azure.Core.TestFramework"", ""..\..\core\Azure.Core.TestFramework\src\Azure.Core.TestFramework.csproj"", ""{{ECC730C1-4AEA-420C-916A-66B19B79E4DC}}""
EndProject
";

            string sampleProjectConfig = @"Project(""{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}"") = ""{0}.Samples"", ""samples\{0}.Samples.csproj"", ""{{7A2DFF15-5746-49F4-BD0F-C6C35337088A}}""
EndProject
";
            slnContent += Configuration.AzureArm ? sampleProjectConfig : testFrameworkConfig;

            slnContent += @"Project(""{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}"") = ""{0}"", ""src\{0}.csproj"", ""{{28FF4005-4467-4E36-92E7-DEA27DEB1519}}""
EndProject
";
            if (Configuration.GenerateTestProject || Configuration.GenerateSampleProject)
            {
                slnContent += @"Project(""{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}"") = ""{0}.Tests"", ""tests\{0}.Tests.csproj"", ""{{1F1CD1D4-9932-4B73-99D8-C252A67D4B46}}""
EndProject
";
            }
            slnContent += @"Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{{B0C276D1-2930-4887-B29A-D1A33E7009A2}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{B0C276D1-2930-4887-B29A-D1A33E7009A2}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{B0C276D1-2930-4887-B29A-D1A33E7009A2}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{B0C276D1-2930-4887-B29A-D1A33E7009A2}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{8E9A77AC-792A-4432-8320-ACFD46730401}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{8E9A77AC-792A-4432-8320-ACFD46730401}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{8E9A77AC-792A-4432-8320-ACFD46730401}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{8E9A77AC-792A-4432-8320-ACFD46730401}}.Release|Any CPU.Build.0 = Release|Any CPU
";
            string testFrameworkConfigProfile = @"		{{ECC730C1-4AEA-420C-916A-66B19B79E4DC}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{ECC730C1-4AEA-420C-916A-66B19B79E4DC}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{ECC730C1-4AEA-420C-916A-66B19B79E4DC}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{ECC730C1-4AEA-420C-916A-66B19B79E4DC}}.Release|Any CPU.Build.0 = Release|Any CPU
";
            string sampleProjectConfigProfile = @"		{{7A2DFF15-5746-49F4-BD0F-C6C35337088A}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{7A2DFF15-5746-49F4-BD0F-C6C35337088A}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{7A2DFF15-5746-49F4-BD0F-C6C35337088A}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{7A2DFF15-5746-49F4-BD0F-C6C35337088A}}.Release|Any CPU.Build.0 = Release|Any CPU
";
            slnContent += Configuration.AzureArm ? sampleProjectConfigProfile : testFrameworkConfigProfile;
            slnContent += @"		{{A4241C1F-A53D-474C-9E4E-075054407E74}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{A4241C1F-A53D-474C-9E4E-075054407E74}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{A4241C1F-A53D-474C-9E4E-075054407E74}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{A4241C1F-A53D-474C-9E4E-075054407E74}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{FA8BD3F1-8616-47B6-974C-7576CDF4717E}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{FA8BD3F1-8616-47B6-974C-7576CDF4717E}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{FA8BD3F1-8616-47B6-974C-7576CDF4717E}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{FA8BD3F1-8616-47B6-974C-7576CDF4717E}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{85677AD3-C214-42FA-AE6E-49B956CAC8DC}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{85677AD3-C214-42FA-AE6E-49B956CAC8DC}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{85677AD3-C214-42FA-AE6E-49B956CAC8DC}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{85677AD3-C214-42FA-AE6E-49B956CAC8DC}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{28FF4005-4467-4E36-92E7-DEA27DEB1519}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{28FF4005-4467-4E36-92E7-DEA27DEB1519}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{28FF4005-4467-4E36-92E7-DEA27DEB1519}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{28FF4005-4467-4E36-92E7-DEA27DEB1519}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{1F1CD1D4-9932-4B73-99D8-C252A67D4B46}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{1F1CD1D4-9932-4B73-99D8-C252A67D4B46}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{1F1CD1D4-9932-4B73-99D8-C252A67D4B46}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{1F1CD1D4-9932-4B73-99D8-C252A67D4B46}}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {{A97F4B90-2591-4689-B1F8-5F21FE6D6CAE}}
	EndGlobalSection
EndGlobal
";
            return string.Format(slnContent, Configuration.Namespace);
        }

        private string GetSamplesProject()
        {
            var writer = new CSProjWriter();
            writer.ProjectReferences.Add(new($"..\\src\\{Configuration.Namespace}.csproj"));
            IReadOnlyList<CSProjWriter.CSProjDependencyPackage> packages;
            if (Configuration.Namespace.StartsWith("Azure.ResourceManager"))
            {
                packages = _brandedSampleDependencyPackagesMgmt;
            }
            else
            {
                packages = _brandedSampleDependencyPackagesMgmtVersion;
            }
            foreach (var package in packages)
            {
                writer.PackageReferences.Add(package);
            }
            return writer.Write();
        }
        private async Task WriteSamplesProject()
        {
            if (!Directory.Exists(_samplesDirectory))
                Directory.CreateDirectory(_samplesDirectory);
            await File.WriteAllBytesAsync(Path.Combine(_samplesDirectory, $"{Configuration.Namespace}.Samples.csproj"), Encoding.ASCII.GetBytes(GetSamplesProject()));
        }

        private string GetAssetContent(string assetFileName, params object?[] args)
        {
            string content = GetAssetContentCore(assetFileName);
            if (args is null || args.Length == 0)
            {
                return content;
            }
            return string.Format(content, args);

            string GetAssetContentCore(string assetName)
            {
                string val = "";
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(currentDirectory, "Assets", assetName);
                if (File.Exists(filePath))
                {
                    val = File.ReadAllText(filePath);
                }
                else
                {
                    throw new Exception($"Assets/{assetName} file not found");
                }
                return val;
            }
        }
    }
}
