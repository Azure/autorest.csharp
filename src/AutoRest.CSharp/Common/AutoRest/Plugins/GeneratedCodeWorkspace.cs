// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.PostProcessing;
using AutoRest.CSharp.Input;
using Azure;
using Azure.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Simplification;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class GeneratedCodeWorkspace
    {
        public static readonly string SharedFolder = "shared";
        public static readonly string GeneratedFolder = "Generated";

        private static readonly IReadOnlyList<MetadataReference> AssemblyMetadataReferences;

        static GeneratedCodeWorkspace()
        {
            var references = new List<MetadataReference>
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Response).Assembly.Location),
            };

            var trustedAssemblies = ((string?)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") ?? "").Split(Path.PathSeparator);
            foreach (var tpl in trustedAssemblies)
            {
                references.Add(MetadataReference.CreateFromFile(tpl));
            }

            AssemblyMetadataReferences = references;
        }

        private static readonly string[] SharedFolders = { SharedFolder };
        private static readonly string[] GeneratedFolders = { GeneratedFolder };
        private static Task<Project>? _cachedProject;

        private Project _project;
        private Dictionary<string, string> _docFiles { get; init; }

        private GeneratedCodeWorkspace(Project generatedCodeProject)
        {
            _project = generatedCodeProject;
            _docFiles = new Dictionary<string, string>();
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

        /// <summary>
        /// Add generated doc file.
        /// </summary>
        /// <param name="name">Name of the doc file, including the relative path to the "Generated" folder.</param>
        /// <param name="text">Content of the doc file.</param>
        public void AddGeneratedDocFile(string name, string text)
        {
            _docFiles.Add(name, text);
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

                processed = await Simplifier.ReduceAsync(processed);
                processed = await Formatter.FormatAsync(processed);
                var text = await processed.GetSyntaxTreeAsync();
                yield return (processed.Name, text!.ToString());
            }

            foreach (var doc in _docFiles)
            {
                yield return (doc.Key, doc.Value);
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

            return document;
        }

        internal static ImmutableHashSet<string> GetSuppressedTypeNames(Compilation compilation)
        {
            var suppressTypeAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenSuppressTypeAttribute).FullName!)!;
            return compilation.Assembly.GetAttributes()
                .Where(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, suppressTypeAttribute))
                .Select(a => a.ConstructorArguments[0].Value)
                .OfType<string>()
                .ToImmutableHashSet();
        }

        /// <summary>
        /// Add some additional files into this project
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="skipPredicate"></param>
        /// <param name="folders"></param>
        public void AddDirectory(string directory, Func<string, bool>? skipPredicate = null, IEnumerable<string>? folders = null)
        {
            _project = AddDirectory(_project, directory, skipPredicate, folders);
        }

        /// <summary>
        /// Add the files in the directory to a project per a given predicate with the folders specified
        /// </summary>
        /// <param name="project"></param>
        /// <param name="directory"></param>
        /// <param name="skipPredicate"></param>
        /// <param name="folders"></param>
        /// <returns></returns>
        internal static Project AddDirectory(Project project, string directory, Func<string, bool>? skipPredicate = null, IEnumerable<string>? folders = null)
        {
            foreach (string sourceFile in Directory.GetFiles(directory, "*.cs", SearchOption.AllDirectories))
            {
                if (skipPredicate != null && skipPredicate(sourceFile))
                    continue;

                project = project.AddDocument(sourceFile, File.ReadAllText(sourceFile), folders ?? Array.Empty<string>(), sourceFile).Project;
            }

            return project;
        }

        public static async Task<GeneratedCodeWorkspace> Create(string projectDirectory, string outputDirectory, string[] sharedSourceFolders)
        {
            var projectTask = Interlocked.Exchange(ref _cachedProject, null);
            var generatedCodeProject = projectTask != null ? await projectTask : CreateGeneratedCodeProject();

            if (Path.IsPathRooted(projectDirectory) && Path.IsPathRooted(outputDirectory))
            {
                projectDirectory = Path.GetFullPath(projectDirectory);
                outputDirectory = Path.GetFullPath(outputDirectory);

                generatedCodeProject = AddDirectory(generatedCodeProject, projectDirectory, skipPredicate: sourceFile => sourceFile.StartsWith(outputDirectory));
            }

            foreach (var sharedSourceFolder in sharedSourceFolders)
            {
                generatedCodeProject = AddDirectory(generatedCodeProject, sharedSourceFolder, folders: SharedFolders);
            }

            generatedCodeProject = generatedCodeProject.WithParseOptions(new CSharpParseOptions(preprocessorSymbols: new[] { "EXPERIMENTAL" }));
            return new GeneratedCodeWorkspace(generatedCodeProject);
        }

        // TODO: Currently the outputDirectory is expected to be generated folder. We will handle the customization folder if there is a case.
        public static GeneratedCodeWorkspace CreateExistingCodeProject(string outputDirectory)
        {
            var workspace = new AdhocWorkspace();
            Project project = workspace.AddProject("ExistingCode", LanguageNames.CSharp);

            if (Path.IsPathRooted(outputDirectory))
            {
                outputDirectory = Path.GetFullPath(outputDirectory);
                project = AddDirectory(project, outputDirectory, null);
            }

            project = project
                .AddMetadataReferences(AssemblyMetadataReferences)
                .WithCompilationOptions(new CSharpCompilationOptions(
                    OutputKind.DynamicallyLinkedLibrary, nullableContextOptions: NullableContextOptions.Disable));

            return new GeneratedCodeWorkspace(project);
        }

        private static Project CreateGeneratedCodeProject()
        {
            var workspace = new AdhocWorkspace();
            // TODO: This is not the right way to construct the workspace but it works
            Project generatedCodeProject = workspace.AddProject("GeneratedCode", LanguageNames.CSharp);

            generatedCodeProject = generatedCodeProject
                .AddMetadataReferences(AssemblyMetadataReferences)
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

        public static bool IsCustomDocument(Document document) => !IsGeneratedDocument(document) && !IsSharedDocument(document);
        public static bool IsSharedDocument(Document document) => document.Folders.Contains(SharedFolder);
        public static bool IsGeneratedDocument(Document document) => document.Folders.Contains(GeneratedFolder);

        /// <summary>
        /// This method delegates the caller to do something on the generated code project
        /// </summary>
        /// <param name="processor"></param>
        /// <returns></returns>
        public async Task PostProcess(Func<Project, Task<Project>> processor)
        {
            _project = await processor(_project);
        }

        /// <summary>
        /// This method invokes the postProcessor to do some post processing work
        /// Depending on the configuration, it will either remove + internalize, just internalize or do nothing
        /// </summary>
        /// <param name="postProcessor"></param>
        /// <returns></returns>
        public async Task PostProcessAsync(PostProcessor? postProcessor = null)
        {
            postProcessor ??= new PostProcessor();
            switch (Configuration.UnreferencedTypesHandling)
            {
                case Configuration.UnreferencedTypesHandlingOption.KeepAll:
                    break;
                case Configuration.UnreferencedTypesHandlingOption.Internalize:
                    _project = await postProcessor.InternalizeAsync(_project);
                    break;
                case Configuration.UnreferencedTypesHandlingOption.RemoveOrInternalize:
                    _project = await postProcessor.InternalizeAsync(_project);
                    _project = await postProcessor.RemoveAsync(_project);
                    break;
            }
        }
    }
}
