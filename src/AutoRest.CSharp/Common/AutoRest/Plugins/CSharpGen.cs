﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Utilities;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    [PluginName("csharpgen")]
    internal class CSharpGen : IPlugin
    {
        public async Task<GeneratedCodeWorkspace> ExecuteAsync(CodeModel codeModel)
        {
            ValidateConfiguration();
            Directory.CreateDirectory(Configuration.OutputFolder);
            var project = await GeneratedCodeWorkspace.Create(Configuration.AbsoluteProjectFolder, Configuration.OutputFolder, Configuration.SharedSourceFolders);
            // TODO: get previous contract path from configuration
            var previousContractPath = Path.GetFullPath(Path.Combine(Configuration.AbsoluteProjectFolder, "..", "..", "PreviousContract", Configuration.Namespace));
            var sourceInputModel = Directory.Exists(previousContractPath)
                ? new SourceInputModel(await project.GetCompilationAsync(), previousContract: await GeneratedCodeWorkspace.CreateExistingCodeProject(previousContractPath).GetCompilationAsync())
                : new SourceInputModel(await project.GetCompilationAsync());

            if (Configuration.Generation1ConvenienceClient)
            {
                DataPlaneTarget.Execute(project, codeModel, sourceInputModel);
            }
            else if (Configuration.AzureArm)
            {
                if (Configuration.MgmtConfiguration.MgmtDebug.SkipCodeGen)
                {
                    await AutoRestLogger.Warning("skip generating sdk code because 'mgmt-debug.skip-codegen' is true.");
                    if (Configuration.MgmtTestConfiguration is not null)
                        await MgmtTestTarget.ExecuteAsync(project, codeModel, null);
                }
                else
                {
                    await MgmtTarget.ExecuteAsync(project, codeModel, sourceInputModel);
                    if (Configuration.MgmtTestConfiguration is not null)
                        await MgmtTestTarget.ExecuteAsync(project, codeModel, sourceInputModel);
                }
            }
            else
            {
                await LowLevelTarget.ExecuteAsync(project, new CodeModelConverter().CreateNamespace(codeModel, new SchemaUsageProvider(codeModel)), sourceInputModel, false);
            }
            return project;
        }

        public async Task<GeneratedCodeWorkspace> ExecuteAsync(InputNamespace rootNamespace)
        {
            ValidateConfiguration();

            Directory.CreateDirectory(Configuration.OutputFolder);
            var project = await GeneratedCodeWorkspace.Create(Configuration.AbsoluteProjectFolder, Configuration.OutputFolder, Configuration.SharedSourceFolders);
            var sourceInputModel = new SourceInputModel(await project.GetCompilationAsync(), await ProtocolCompilationInput.TryCreate());
            await LowLevelTarget.ExecuteAsync(project, rootNamespace, sourceInputModel, true);
            return project;
        }

        private static void ValidateConfiguration()
        {
            if (Configuration.Generation1ConvenienceClient && Configuration.AzureArm)
            {
                throw new Exception("Enabling both 'generation1-convenience-client' and 'azure-arm' at the same time is not supported.");
            }
        }

        public async Task<bool> Execute(IPluginCommunication autoRest)
        {
            Console.SetOut(Console.Error); //if you send anything to stdout there is an autorest error so this protects us against that happening
            string? codeModelFileName = (await autoRest.ListInputs()).FirstOrDefault();
            if (string.IsNullOrEmpty(codeModelFileName))
                throw new Exception("Generator did not receive the code model file.");

            string codeModelYaml = await autoRest.ReadFile(codeModelFileName);
            CodeModel codeModel = CodeModelSerialization.DeserializeCodeModel(codeModelYaml);

            Configuration.Initialize(autoRest, codeModel.Language.Default.Name, codeModel.Language.Default.Name);

            if (!Path.IsPathRooted(Configuration.OutputFolder))
            {
                await AutoRestLogger.Warning("output-folder path should be an absolute path");
            }
            if (Configuration.SaveInputs)
            {
                await autoRest.WriteFile("Configuration.json", Configuration.SaveConfiguration(), "source-file-csharp");
                await autoRest.WriteFile("CodeModel.yaml", codeModelYaml, "source-file-csharp");
            }

            try
            {
                var project = await ExecuteAsync(codeModel);
                await foreach (var file in project.GetGeneratedFilesAsync())
                {
                    // format all \ to / in filename, otherwise they will be treated as escape char when sending to autorest service
                    var filename = file.Name.Replace('\\', '/');
                    await autoRest.WriteFile(filename, file.Text, "source-file-csharp");
                }
            }
            catch (ErrorHelpers.ErrorException e)
            {
                await AutoRestLogger.Fatal(e.ErrorText);
                return false;
            }
            catch (Exception e)
            {
                try
                {
                    if (Configuration.SaveInputs)
                    {
                        // We are unsuspectingly crashing, so output anything that might help us reproduce the issue
                        File.WriteAllText(Path.Combine(Configuration.OutputFolder, "Configuration.json"), Configuration.SaveConfiguration());
                        File.WriteAllText(Path.Combine(Configuration.OutputFolder, "CodeModel.yaml"), codeModelYaml);
                    }
                }
                catch
                {
                    // Ignore any errors while trying to output crash information
                }
                await AutoRestLogger.Fatal($"Internal error in AutoRest.CSharp{ErrorHelpers.FileIssueText}\nException: {e.Message}\n{e.StackTrace}");
                return false;
            }

            return true;
        }
    }
}
