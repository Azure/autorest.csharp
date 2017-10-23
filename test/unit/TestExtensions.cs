// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using AutoRest.Core;
using AutoRest.Core.Extensibility;
using AutoRest.Core.Utilities;
using static AutoRest.Core.Utilities.DependencyInjection;
using AutoRest.Swagger;
using AutoRest.Modeler;

using IAnyPlugin = AutoRest.Core.Extensibility.IPlugin<AutoRest.Core.Extensibility.IGeneratorSettings, AutoRest.Core.IModelSerializer<AutoRest.Core.Model.CodeModel>, AutoRest.Core.ITransformer<AutoRest.Core.Model.CodeModel>, AutoRest.Core.CodeGenerator, AutoRest.Core.CodeNamer, AutoRest.Core.Model.CodeModel>;

namespace AutoRest.CSharp.Unit.Tests
{
    internal static class TestExtensions
    {
        public static dynamic ToDynamic(this object anonymousObject)
        {
            return new AutoDynamic(anonymousObject);
        }

        public static bool IsAnonymousType(this Type type)
        {
            var name = type.Name;
            if (name.Length < 3)
            {
                return false;
            }
            return name[0] == '<' && name[1] == '>' && name.IndexOf("AnonymousType", StringComparison.Ordinal) > 0;
        }

        internal static void CopyFile(this MemoryFileSystem fileSystem, string source, string destination)
        {
            destination = destination.Replace("._", ".");
            fileSystem.WriteAllText(destination, File.ReadAllText(source));
        }

        internal static void CopyFolder(this MemoryFileSystem fileSystem, string basePath, string source, string destination)
        {
            fileSystem.CreateDirectory(destination);
        
            // Copy dirs recursively
            foreach (var child in Directory.EnumerateDirectories(Path.Combine(Core.Utilities.Extensions.CodeBaseDirectory(typeof(TestExtensions)), basePath, source)).Select(Path.GetFileName))
            {
                fileSystem.CopyFolder(basePath, Path.Combine(source, child), Path.Combine(destination, child));
            }

            // Copy files
            foreach (var childFile in Directory.EnumerateFiles(Path.Combine(Core.Utilities.Extensions.CodeBaseDirectory(typeof(TestExtensions)), basePath, source)).Select(Path.GetFileName))
            {
                fileSystem.CopyFile(Path.Combine(Core.Utilities.Extensions.CodeBaseDirectory(typeof(TestExtensions)), basePath, source,childFile), Path.Combine(destination, childFile));
            }
        }

        internal static string[] GetFilesByExtension(this MemoryFileSystem fileSystem, string path, SearchOption s, params string[] fileExts)
        {
            return fileSystem.GetFiles(path, "*.*", s).Where(f => fileExts.Contains(f.Substring(f.LastIndexOf(".")+1))).ToArray();
        }

        internal static MemoryFileSystem GenerateCodeInto(this string testName,  MemoryFileSystem inputFileSystem, IAnyPlugin plugin = null)
        {
            using (NewContext)
            {
                var settings = new Settings
                {
                    FileSystemInput = inputFileSystem,
                    OutputDirectory = "",
                    Namespace = "Test",
                    CodeGenerationMode = "rest-client"
                };

                return testName.GenerateCodeInto(inputFileSystem, settings, plugin);
            }
        }

        internal static MemoryFileSystem GenerateCodeInto(this string testName, MemoryFileSystem inputFileSystem, Settings settings, IAnyPlugin plugin = null)
        {
            plugin = plugin ?? new PluginCs();
            Settings.Instance.FileSystemInput = inputFileSystem;
            // copy the whole input directory into the memoryfilesystem.
            inputFileSystem.CopyFolder("Resource", testName,"");

            // find the appropriately named .yaml or .json file for the swagger. 
            foreach (var ext in new[] {".yaml", ".json", ".md"}) {
                var name = testName + ext;
                if (inputFileSystem.FileExists(name)) {
                    settings.Input = name;
                }
            }

            if (string.IsNullOrWhiteSpace(settings.Input)) {
                throw new Exception($"Can't find swagger file ${testName} [.yaml] [.json] [.md]");
            }

            var modeler = new SwaggerModeler(Settings.Instance);
            var swagger = Singleton<AutoRest.Modeler.Model.ServiceDefinition>.Instance = SwaggerParser.Parse(inputFileSystem.ReadAllText(Settings.Instance.Input));
            var codeModel = modeler.Build(swagger);

            using (plugin.Activate())
            {
                // load model into language-specific code model
                codeModel = plugin.Serializer.Load(codeModel);

                // apply language-specific tranformation (more than just language-specific types)
                // used to be called "NormalizeClientModel" . 
                codeModel = plugin.Transformer.TransformCodeModel(codeModel);

                // Generate code from CodeModel.
                plugin.CodeGenerator.Generate(codeModel).GetAwaiter().GetResult();

                return settings.FileSystemOutput;
            }
        }

        internal static string SaveFilesToTemp(this MemoryFileSystem fileSystem, string folderName = null)
        {
            folderName = string.IsNullOrWhiteSpace(folderName) ? Guid.NewGuid().ToString() : folderName;
            var outputFolder = Path.Combine(Path.GetTempPath(), folderName);
            if (Directory.Exists(outputFolder))
            {
                try
                {
                    Directory.Delete(outputFolder, true);
                }
                catch
                {
                    // who cares...
                }
            }

            Directory.CreateDirectory(outputFolder);
            foreach (var file in fileSystem.GetFiles("", "*", SearchOption.AllDirectories))
            {
                var target = Path.Combine(outputFolder, file.Substring(file.IndexOf(":", StringComparison.Ordinal) + 1));
                Directory.CreateDirectory(Path.GetDirectoryName(target));
                File.WriteAllText(target, fileSystem.ReadAllText(file));
            }

            return outputFolder;
        }

        internal static bool IsNullableValueType(this Type type) => type.IsGenericType() && type.GetGenericTypeDefinition() == typeof(Nullable<>);
    }
}