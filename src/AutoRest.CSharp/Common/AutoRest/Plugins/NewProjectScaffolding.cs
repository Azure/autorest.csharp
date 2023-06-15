﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;
using static System.Net.Mime.MediaTypeNames;

namespace AutoRest.CSharp.Common.AutoRest.Plugins
{
    [PluginName("newproject")]
    internal class NewProjectScaffolding : IPlugin
    {
        public async Task<bool> Execute(IPluginCommunication autoRest)
        {
            WriteServiceDirectoryFiles(autoRest);

            await WriteSolutionFiles(autoRest);

            WriteProjectFiles(autoRest);

            WriteTestFiles(autoRest);

            return true;
        }

        private void WriteServiceDirectoryFiles(IPluginCommunication autoRest)
        {
            //WriteCiYml(autoRest);
        }

        private void WriteTestFiles(IPluginCommunication autoRest)
        {
            //WriteTestCsproj(autoRest);
            //WriteTestReadme(autoRest);
            //WriteTestBaseClass(autoRest);
            //WriteTestEnvironment(autoRest);
        }

        private void WriteProjectFiles(IPluginCommunication autoRest)
        {
            //WriteSrcCsproj(autoRest);
            //WriteSrcReadme(autoRest);
            //WriteChangeLog(autoRest);
            //WriteAzureIconPng(autoRest);
            //WriteAssemblyInfo(autoRest)
        }

        private async Task WriteSolutionFiles(IPluginCommunication autoRest)
        {
            await autoRest.WriteFile(Path.Combine(Configuration.AbsoluteProjectFolder, "..", $"{Configuration.Namespace}.sln"), GetSln(), "source-file-csharp");
            //WriteDirectoryBuildProps(autoRest);
        }

        private string GetSln()
        {
            const string slnContent = @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.29709.97
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{9A19103F-16F7-4668-BE54-9A1E7A4F7556}"") = ""Azure.Core.TestFramework"", ""..\..\core\Azure.Core.TestFramework\src\Azure.Core.TestFramework.csproj"", ""{ECC730C1-4AEA-420C-916A-66B19B79E4DC}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""{0}"", ""src\{0}.csproj"", ""{28FF4005-4467-4E36-92E7-DEA27DEB1519}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""{0}.Perf"", ""perf\{0}.Perf.csproj"", ""{30C5FF85-655A-49FC-A324-16438130FF3F}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""{0}.Tests"", ""tests\{0}.Tests.csproj"", ""{1F1CD1D4-9932-4B73-99D8-C252A67D4B46}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{B0C276D1-2930-4887-B29A-D1A33E7009A2}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{B0C276D1-2930-4887-B29A-D1A33E7009A2}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{B0C276D1-2930-4887-B29A-D1A33E7009A2}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{B0C276D1-2930-4887-B29A-D1A33E7009A2}.Release|Any CPU.Build.0 = Release|Any CPU
		{8E9A77AC-792A-4432-8320-ACFD46730401}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{8E9A77AC-792A-4432-8320-ACFD46730401}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{8E9A77AC-792A-4432-8320-ACFD46730401}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{8E9A77AC-792A-4432-8320-ACFD46730401}.Release|Any CPU.Build.0 = Release|Any CPU
		{ECC730C1-4AEA-420C-916A-66B19B79E4DC}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{ECC730C1-4AEA-420C-916A-66B19B79E4DC}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{ECC730C1-4AEA-420C-916A-66B19B79E4DC}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{ECC730C1-4AEA-420C-916A-66B19B79E4DC}.Release|Any CPU.Build.0 = Release|Any CPU
		{A4241C1F-A53D-474C-9E4E-075054407E74}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{A4241C1F-A53D-474C-9E4E-075054407E74}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{A4241C1F-A53D-474C-9E4E-075054407E74}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{A4241C1F-A53D-474C-9E4E-075054407E74}.Release|Any CPU.Build.0 = Release|Any CPU
		{FA8BD3F1-8616-47B6-974C-7576CDF4717E}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{FA8BD3F1-8616-47B6-974C-7576CDF4717E}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{FA8BD3F1-8616-47B6-974C-7576CDF4717E}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{FA8BD3F1-8616-47B6-974C-7576CDF4717E}.Release|Any CPU.Build.0 = Release|Any CPU
		{85677AD3-C214-42FA-AE6E-49B956CAC8DC}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{85677AD3-C214-42FA-AE6E-49B956CAC8DC}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{85677AD3-C214-42FA-AE6E-49B956CAC8DC}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{85677AD3-C214-42FA-AE6E-49B956CAC8DC}.Release|Any CPU.Build.0 = Release|Any CPU
		{28FF4005-4467-4E36-92E7-DEA27DEB1519}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{28FF4005-4467-4E36-92E7-DEA27DEB1519}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{28FF4005-4467-4E36-92E7-DEA27DEB1519}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{28FF4005-4467-4E36-92E7-DEA27DEB1519}.Release|Any CPU.Build.0 = Release|Any CPU
		{30C5FF85-655A-49FC-A324-16438130FF3F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{30C5FF85-655A-49FC-A324-16438130FF3F}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{30C5FF85-655A-49FC-A324-16438130FF3F}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{30C5FF85-655A-49FC-A324-16438130FF3F}.Release|Any CPU.Build.0 = Release|Any CPU
		{1F1CD1D4-9932-4B73-99D8-C252A67D4B46}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{1F1CD1D4-9932-4B73-99D8-C252A67D4B46}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{1F1CD1D4-9932-4B73-99D8-C252A67D4B46}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{1F1CD1D4-9932-4B73-99D8-C252A67D4B46}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {A97F4B90-2591-4689-B1F8-5F21FE6D6CAE}
	EndGlobalSection
EndGlobal
            ";
            return String.Format(slnContent, Environment.NewLine);
        }
    }
}
