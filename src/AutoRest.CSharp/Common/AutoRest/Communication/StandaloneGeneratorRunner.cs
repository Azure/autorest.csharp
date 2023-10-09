﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.AutoRest.Plugins;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.AutoRest.Communication
{
    internal class StandaloneGeneratorRunner
    {
        public static async Task RunAsync(CommandLineOptions options)
        {
            string? projectPath = null;
            string outputPath;
            string sampleOutputPath;
            bool wasProjectPathPassedIn = options.ProjectPath is not null;
            if (options.Standalone is not null)
            {
                //TODO this is only here for back compat we should consider removing it
                outputPath = options.Standalone;
            }
            else
            {
                projectPath = options.ProjectPath!;
                outputPath = Path.Combine(projectPath, "Generated");
            }
            sampleOutputPath = Path.Combine(outputPath, "..", "..", "tests", "Generated", "Samples");

            var configurationPath = options.ConfigurationPath ?? Path.Combine(outputPath, "Configuration.json");
            LoadConfiguration(projectPath, outputPath, options.ExistingProjectFolder, File.ReadAllText(configurationPath));

            var codeModelInputPath = Path.Combine(outputPath, "CodeModel.yaml");
            var tspInputFile = Path.Combine(outputPath, "tspCodeModel.json");

            GeneratedCodeWorkspace workspace;
            if (File.Exists(tspInputFile))
            {
                var json = await File.ReadAllTextAsync(tspInputFile);
                var rootNamespace = TypeSpecSerialization.Deserialize(json) ?? throw new InvalidOperationException($"Deserializing {tspInputFile} has failed.");
                workspace = await new CSharpGen().ExecuteAsync(rootNamespace);
                if (options.IsNewProject)
                {
                    // TODO - add support for DataFactoryElement lookup
                    await new NewProjectScaffolding().Execute();
                }
            }
            else if (File.Exists(codeModelInputPath))
            {
                var yaml = await File.ReadAllTextAsync(codeModelInputPath);
                var codeModel = CodeModelSerialization.DeserializeCodeModel(yaml);
                workspace = await new CSharpGen().ExecuteAsync(codeModel);
                if (options.IsNewProject)
                {
                    new CSharpProj().Execute(Configuration.Namespace, outputPath, (yaml.Contains("x-ms-format: dfe-", StringComparison.Ordinal)), Configuration.ToCSharpProjConfiguration());
                }
            }
            else
            {
                throw new InvalidOperationException($"Neither CodeModel.yaml nor tspCodeModel.json exist in {outputPath} folder.");
            }

            if (options.ClearOutputFolder)
            {
                var keepFiles = new string[] { "CodeModel.yaml", "Configuration.json", "tspCodeModel.json" };
                DeleteDirectory(outputPath, keepFiles);
                DeleteDirectory(sampleOutputPath, keepFiles);
            }

            await foreach (var file in workspace.GetGeneratedFilesAsync())
            {
                if (string.IsNullOrEmpty(file.Text))
                {
                    continue;
                }
                var filename = Path.Combine(outputPath, file.Name);
                Console.WriteLine($"Writing {filename}");
                Directory.CreateDirectory(Path.GetDirectoryName(filename)!);
                await File.WriteAllTextAsync(filename, file.Text);
            }
        }

        private static void DeleteDirectory(string path, string[] keepFiles)
        {
            var directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                return;
            }
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (keepFiles.Contains(file.Name))
                {
                    continue;
                }
                file.Delete();
            }

            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                DeleteDirectory(directory.FullName, keepFiles);
            }

            if (!directoryInfo.EnumerateFileSystemInfos().Any())
            {
                directoryInfo.Delete();
            }
        }

        internal static void LoadConfiguration(string? projectPath, string outputPath, string? existingProjectFolder, string json)
        {
            var root = JsonDocument.Parse(json).RootElement;
            Configuration.LoadConfiguration(root, projectPath, outputPath, existingProjectFolder);
        }
    }
}
