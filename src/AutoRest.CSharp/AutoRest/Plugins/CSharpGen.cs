// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Simplification;
using Microsoft.CodeAnalysis.Text;
using Diagnostic = Microsoft.CodeAnalysis.Diagnostic;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    [PluginName("csharpgen")]
    internal class CSharpGen : IPlugin
    {
        public async Task<GeneratedCodeWorkspace> ExecuteAsync(Task<CodeModel> codeModelTask, Configuration configuration)
        {
            Directory.CreateDirectory(configuration.OutputFolder);
            var projectDirectory = Path.Combine(configuration.OutputFolder, Configuration.ProjectRelativeDirectory);
            var project = await GeneratedCodeWorkspace.Create(projectDirectory, configuration.OutputFolder, configuration.SharedSourceFolders);
            var sourceInputModel = new SourceInputModel(await project.GetCompilationAsync());

            var codeModel = await codeModelTask;

            if (configuration.LowLevelClient)
            {
                LowLevelTarget.Execute (project, codeModel, sourceInputModel, configuration);
            }
            else
            {
                DataPlaneTarget.Execute (project, codeModel, sourceInputModel, configuration);
            }
            return project;
        }

        public async Task<bool> Execute(IPluginCommunication autoRest)
        {
            string codeModelFileName = (await autoRest.ListInputs()).FirstOrDefault();
            if (string.IsNullOrEmpty(codeModelFileName))
                throw new Exception("Generator did not receive the code model file.");

            var configuration = Configuration.GetConfiguration(autoRest);

            string codeModelYaml = string.Empty;

            Task<CodeModel> codeModelTask = Task.Run(async () =>
            {
                codeModelYaml = await autoRest.ReadFile(codeModelFileName);
                return CodeModelSerialization.DeserializeCodeModel(codeModelYaml);
            });

            if (configuration.CredentialTypes.Contains("TokenCredential", StringComparer.OrdinalIgnoreCase) &&
                configuration.CredentialScopes.Length < 1)
            {
                await autoRest.Fatal("You are using TokenCredential wihtout passing in any credential-scopes.");
                return false;
            }

            if (!Path.IsPathRooted(configuration.OutputFolder))
            {
                await autoRest.Warning("output-folder path should be an absolute path");
            }
            if (configuration.SaveInputs)
            {
                await codeModelTask;
                await autoRest.WriteFile("Configuration.json", StandaloneGeneratorRunner.SaveConfiguration(configuration), "source-file-csharp");
                await autoRest.WriteFile("CodeModel.yaml", codeModelYaml, "source-file-csharp");
            }

            try
            {
                var project = await ExecuteAsync(codeModelTask, configuration);
                await foreach (var file in project.GetGeneratedFilesAsync())
                {
                    await autoRest.WriteFile(file.Name, file.Text, "source-file-csharp");
                }
            }
            catch (Exception e)
            {
                await autoRest.Fatal($"Internal error in AutoRest.CSharp - Please file an issue at https://github.com/Azure/autorest.csharp/issues/new with a swagger that reproduces.\nException: {e.Message}\n{e.StackTrace}");
                return false;
            }

            return true;
        }
    }
}
