﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Simplification;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class GeneratedCodeWorkspace
    {
        public static string SharedFolder = "shared";
        public static string GeneratedFolder = "Generated";

        private static readonly string[] SharedFolders = { SharedFolder };
        private static readonly string[] GeneratedFolders = { GeneratedFolder };
        private static Task<Project>? _cachedProject;

        private Project _project;

        private GeneratedCodeWorkspace(Project generatedCodeProject)
        {
            _project = generatedCodeProject;
        }

        /// <summary>
        /// Creating AdHoc workspace and project takes a while, we'd like to preload this work
        /// to the generator startup time
        /// </summary>
        public static void Initialize()
        {
            _cachedProject = Task.Run(CreateGeneratedCodeProject);
        }

        public void AddGeneratedFile(string name, string text)
        {
            var document = _project.AddDocument(name, text, GeneratedFolders);
            var root = document.GetSyntaxRootAsync().GetAwaiter().GetResult();
            Debug.Assert(root != null);

            root = root.WithAdditionalAnnotations(Simplifier.Annotation);
            document = document.WithSyntaxRoot(root);
            _project = document.Project;
        }

        public async IAsyncEnumerable<(string Name, string Text)> GetGeneratedFilesAsync()
        {
            var compilation = await _project.GetCompilationAsync();
            Debug.Assert(compilation != null);

            var suppressedTypeNames = GetSuppressedTypeNames(compilation);
            List<Task<Document>> documents = new List<Task<Document>>();
            foreach (Document document in _project.Documents)
            {
                // Skip writing shared files or originals
                if (!IsGeneratedDocument(document))
                {
                    continue;
                }

                documents.Add(Task.Run(() => ProcessDocument(compilation, document, suppressedTypeNames)));
            }

            foreach (var task in documents)
            {
                var processed = await task;
                var text = await processed.GetSyntaxTreeAsync();
                yield return (processed.Name, text!.ToString());
            }
        }

        private async Task<Document> ProcessDocument(Compilation compilation, Document document, ImmutableHashSet<string> suppressedTypeNames)
        {
            var syntaxTree = await document.GetSyntaxTreeAsync();
            if (syntaxTree != null)
            {
                var semanticModel = compilation.GetSemanticModel(syntaxTree);
                var rewriter = new MemberRemoverRewriter(_project, semanticModel, suppressedTypeNames);
                document = document.WithSyntaxRoot(rewriter.Visit(await syntaxTree.GetRootAsync()));
            }

            document = await Simplifier.ReduceAsync(document);
            document = await Formatter.FormatAsync(document);
            return document;
        }

        private static ImmutableHashSet<string> GetSuppressedTypeNames(Compilation compilation)
        {
            var suppressTypeAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenSuppressTypeAttribute).FullName!)!;
            return compilation.Assembly.GetAttributes()
                .Where(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, suppressTypeAttribute))
                .Select(a => a.ConstructorArguments[0].Value)
                .OfType<string>()
                .ToImmutableHashSet();
        }

        public static async Task<GeneratedCodeWorkspace> Create(string projectDirectory, string outputDirectory, string[] sharedSourceFolders)
        {
            var projectTask = Interlocked.Exchange(ref _cachedProject, null);
            var generatedCodeProject = projectTask != null ? await projectTask : CreateGeneratedCodeProject();

            if (Path.IsPathRooted(projectDirectory) && Path.IsPathRooted(outputDirectory))
            {
                projectDirectory = Path.GetFullPath(projectDirectory);
                outputDirectory = Path.GetFullPath(outputDirectory);

                foreach (string sourceFile in Directory.GetFiles(projectDirectory, "*.cs", SearchOption.AllDirectories))
                {
                    // Ignore existing generated code
                    if (sourceFile.StartsWith(outputDirectory))
                    {
                        continue;
                    }
                    generatedCodeProject = generatedCodeProject.AddDocument(sourceFile, File.ReadAllText(sourceFile), Array.Empty<string>(), sourceFile).Project;
                }
            }

            foreach (var sharedSourceFolder in sharedSourceFolders)
            {
                foreach (string sharedSourceFile in Directory.GetFiles(sharedSourceFolder, "*.cs", SearchOption.AllDirectories))
                {
                    generatedCodeProject = generatedCodeProject.AddDocument(sharedSourceFile, File.ReadAllText(sharedSourceFile), SharedFolders, sharedSourceFile).Project;
                }
            }

            return new GeneratedCodeWorkspace(generatedCodeProject);
        }

        private static Project CreateGeneratedCodeProject()
        {
            var workspace = new AdhocWorkspace();
            // TODO: This is not the right way to construct the workspace but it works
            Project generatedCodeProject = workspace.AddProject("GeneratedCode", LanguageNames.CSharp);

            var corlibLocation = typeof(object).Assembly.Location;
            var references = new List<MetadataReference>();

            references.Add(MetadataReference.CreateFromFile(corlibLocation));

            var trustedAssemblies = ((string?) AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") ?? "").Split(Path.PathSeparator);
            foreach (var tpl in trustedAssemblies)
            {
                references.Add(MetadataReference.CreateFromFile(tpl));
            }

            generatedCodeProject = generatedCodeProject
                .AddMetadataReferences(references)
                .WithCompilationOptions(new CSharpCompilationOptions(
                    OutputKind.DynamicallyLinkedLibrary, nullableContextOptions: NullableContextOptions.Disable));
            return generatedCodeProject;
        }

        public async Task<CSharpCompilation> GetCompilationAsync()
        {
            var compilation = await _project.GetCompilationAsync() as CSharpCompilation;
            Debug.Assert(compilation != null);
            return compilation;
        }

        public static bool IsGeneratedDocument(Document document) => document.Folders.Contains(GeneratedFolder);
    }
}
