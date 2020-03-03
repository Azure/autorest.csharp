// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Simplification;
using Microsoft.CodeAnalysis.Text;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
{
    internal class GeneratedCodeWorkspace
    {
        public static string SharedFolder = "shared";
        public static string GeneratedFolder = "Generated";

        private static readonly string[] SharedFolders = { SharedFolder };
        private static readonly string[] GeneratedFolders = { GeneratedFolder };

        private Project _project;

        private GeneratedCodeWorkspace(Project generatedCodeProject)
        {
            _project = generatedCodeProject;
        }

        public void AddGeneratedFile(string name, string text)
        {
            _project = _project.AddDocument(GeneratedFolder + "/" + name, text, GeneratedFolders).Project;
        }

        public async IAsyncEnumerable<(string Name, string Text)> GetGeneratedFilesAsync()
        {
            foreach (Document document in _project.Documents)
            {
                // Skip writing shared files or originals
                if (!document.Folders.Contains(GeneratedFolder))
                {
                    continue;
                }

                var root = await document.GetSyntaxRootAsync()!;

                Debug.Assert(root != null);

                root = root.WithAdditionalAnnotations(Simplifier.Annotation);
                var simplified = document.WithSyntaxRoot(root);
                simplified = await Simplifier.ReduceAsync(simplified);
                simplified = await Formatter.FormatAsync(simplified);

                SourceText text = await simplified.GetTextAsync();
                yield return (document.Name, text.ToString());
            }
        }

        public static GeneratedCodeWorkspace Create(string projectDirectory, string sharedSourceFolder)
        {
            var workspace = new AdhocWorkspace();
            // TODO: This is not the right way to construct the workspace but it works
            Project generatedCodeProject = workspace.AddProject("GeneratedCode", LanguageNames.CSharp);

            var corlibLocation = typeof(object).Assembly.Location;

            generatedCodeProject = generatedCodeProject.AddMetadataReference(MetadataReference.CreateFromFile(corlibLocation));

            var trustedAssemblies = ((string?)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") ?? "").Split(Path.PathSeparator);
            foreach (var tpl in trustedAssemblies)
            {
                generatedCodeProject = generatedCodeProject.AddMetadataReference(MetadataReference.CreateFromFile(tpl));
            }

            generatedCodeProject = generatedCodeProject.WithCompilationOptions(new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary, nullableContextOptions: NullableContextOptions.Annotations));

            foreach (string sharedSourceFile in Directory.GetFiles(projectDirectory, "*.cs"))
            {
                generatedCodeProject = generatedCodeProject.AddDocument(sharedSourceFile, File.ReadAllText(sharedSourceFile), Array.Empty<string>(), sharedSourceFile).Project;
            }

            foreach (string sharedSourceFile in Directory.GetFiles(sharedSourceFolder, "*.cs", SearchOption.AllDirectories))
            {
                generatedCodeProject = generatedCodeProject.AddDocument(sharedSourceFile, File.ReadAllText(sharedSourceFile), SharedFolders, sharedSourceFile).Project;
            }

            return new GeneratedCodeWorkspace(generatedCodeProject);
        }

        public async Task<CSharpCompilation> GetCompilationAsync()
        {
            var compilation = await _project.GetCompilationAsync() as CSharpCompilation;
            Debug.Assert(compilation != null);
            return compilation;
        }
    }
}
