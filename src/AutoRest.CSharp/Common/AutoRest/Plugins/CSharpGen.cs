// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    [PluginName("csharpgen")]
    internal class CSharpGen : IPlugin
    {
        public async Task<GeneratedCodeWorkspace> ExecuteAsync(Task<CodeModel> codeModelTask)
        {
            ValidateConfiguration();

            Directory.CreateDirectory(Configuration.OutputFolder);
            var project = await GeneratedCodeWorkspace.Create(Configuration.AbsoluteProjectFolder, Configuration.OutputFolder, Configuration.SharedSourceFolders);
            var sourceInputModel = new SourceInputModel(await project.GetCompilationAsync());

            var codeModel = await codeModelTask;

            if (Configuration.Generation1ConvenienceClient)
            {
                DataPlaneTarget.Execute(project, codeModel, sourceInputModel);
            }
            else if (Configuration.AzureArm)
            {
                if (Configuration.MgmtConfiguration.TestGen is not null)
                {
                    // we currently do not need this sourceInputModel when generating the test code because it only has information about the "non-generated" test code.
                    await MgmtTestTarget.ExecuteAsync(project, codeModel);
                }
                else
                {
                    await MgmtTarget.ExecuteAsync(project, codeModel, sourceInputModel);
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
            var sourceInputModel = new SourceInputModel(await project.GetCompilationAsync());
            await LowLevelTarget.ExecuteAsync(project, rootNamespace, sourceInputModel, true);
            return project;
        }

        private static void ValidateConfiguration ()
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

            Configuration.Initialize(autoRest);

            string codeModelYaml = await autoRest.ReadFile(codeModelFileName);
            Task<CodeModel> codeModelTask = Task.Run(() => CodeModelSerialization.DeserializeCodeModel(codeModelYaml));

            if (!Path.IsPathRooted(Configuration.OutputFolder))
            {
                await autoRest.Warning("output-folder path should be an absolute path");
            }
            if (Configuration.SaveInputs)
            {
                await autoRest.WriteFile("Configuration.json", StandaloneGeneratorRunner.SaveConfiguration(), "source-file-csharp");
                await autoRest.WriteFile("CodeModel.yaml", codeModelYaml, "source-file-csharp");
            }

            try
            {
                var project = await ExecuteAsync(codeModelTask);
                await foreach (var file in project.GetGeneratedFilesAsync())
                {
                    await autoRest.WriteFile(file.Name, file.Text, "source-file-csharp");
                }
            }
            catch (ErrorHelpers.ErrorException e)
            {
                await autoRest.Fatal(e.ErrorText);
                return false;
            }
            catch (Exception e)
            {
                try
                {
                    if (Configuration.SaveInputs)
                    {
                        // We are unsuspectingly crashing, so output anything that might help us reproduce the issue
                        File.WriteAllText(Path.Combine(Configuration.OutputFolder, "Configuration.json"), StandaloneGeneratorRunner.SaveConfiguration());
                        File.WriteAllText(Path.Combine(Configuration.OutputFolder, "CodeModel.yaml"), codeModelYaml);
                    }
                }
                catch
                {
                    // Ignore any errors while trying to output crash information
                }
                await autoRest.Fatal($"Internal error in AutoRest.CSharp{ErrorHelpers.FileIssueText}\nException: {e.Message}\n{e.StackTrace}");
                return false;
            }

            return true;
        }
    }
}
