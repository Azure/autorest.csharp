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
using Azure.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
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

            generatedCodeProject = generatedCodeProject.WithParseOptions(new CSharpParseOptions(preprocessorSymbols: new[] { "EXPERIMENTAL" }));
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

            var trustedAssemblies = ((string?)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") ?? "").Split(Path.PathSeparator);
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
        private static bool IsMgmtRootDocument(Document document) => IsGeneratedDocument(document) && (!document.Name.Contains('/') || document.Name.Contains("Extensions/"));

        private class ClassDeclarationVisitor : CSharpSyntaxRewriter
        {
            private List<ClassDeclarationSyntax> _classes = new();
            internal IReadOnlyList<ClassDeclarationSyntax> ClassDeclarations => _classes;
            public override SyntaxNode? VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                node = (ClassDeclarationSyntax)base.VisitClassDeclaration(node)!;
                if (IsPublic(node.Modifiers))
                    _classes.Add(node);
                return node;
            }

            // TODO -- add more, like enum visitor, struct visitor
        }

        private class PublicMemberVisitor : CSharpSyntaxRewriter
        {
            private List<SyntaxNode> _models = new();

            public IEnumerable<SyntaxNode> PublicMembers => _models;

            //private Document _document;
            //private SyntaxTree _tree;
            //private SemanticModel _semanticModel;

            //internal PublicMemberVisitor(Document document)
            //{
            //    _document = document;
            //    _tree = _document.GetSyntaxTreeAsync().Result!;
            //    _semanticModel = _document.GetSemanticModelAsync().Result!;
            //}

            /// <summary>
            /// override this to add my self in, and add the base class in
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public override SyntaxNode? VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                node = (ClassDeclarationSyntax)base.VisitClassDeclaration(node)!;
                if (IsPublic(node.Modifiers))
                {
                    _models.Add(node); // add myself
                    // add base class of myself if any
                    var list = node.BaseList;
                    if (list != null)
                    {
                        foreach (var type in list.Types)
                        {
                            _models.Add(type);
                        }
                    }
                }
                return node;
            }

            /// <summary>
            /// override this to add my property in
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public override SyntaxNode? VisitPropertyDeclaration(PropertyDeclarationSyntax node)
            {
                node = (PropertyDeclarationSyntax)base.VisitPropertyDeclaration(node)!;
                if (IsPublic(node.Modifiers))
                {
                    _models.Add(node);
                }
                return node;
            }

            /// <summary>
            /// override this to add my methods in
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public override SyntaxNode? VisitMethodDeclaration(MethodDeclarationSyntax node)
            {
                node = (MethodDeclarationSyntax)base.VisitMethodDeclaration(node)!;
                if (IsPublic(node.Modifiers))
                {
                    _models.Add(node);
                }
                return node;
            }
        }

        private static bool IsPublic(SyntaxTokenList tokenList)
            => tokenList.Any(token => token.IsKind(SyntaxKind.PublicKeyword));

        private static bool IsStatic(SyntaxTokenList tokenList)
            => tokenList.Any(token => token.IsKind(SyntaxKind.StaticKeyword));

        private async Task<IEnumerable<SyntaxNode>> GetAllDeclaredModels()
        {
            var classVisitor = new ClassDeclarationVisitor();

            foreach (var document in _project.Documents)
            {
                if (IsGeneratedDocument(document))
                {
                    var root = await document.GetSyntaxRootAsync();
                    classVisitor.Visit(root);
                }
            }

            return classVisitor.ClassDeclarations;
        }

        private async IAsyncEnumerable<SyntaxNode> TraverseAllPublicModels()
        {
            var compilation = await _project.GetCompilationAsync();
            if (compilation == null)
                yield break;

            // get the root nodes
            var classVisitor = new ClassDeclarationVisitor();
            foreach (var document in _project.Documents)
            {
                // we only find the files directly under `Generated` and `Extensions`
                if (IsMgmtRootDocument(document))
                {
                    var root = await document.GetSyntaxRootAsync();
                    classVisitor.Visit(root);
                }
            }
            var queue = new Queue<SyntaxNode>(classVisitor.ClassDeclarations);
            // traverse all the models starting from the root nodes
            var visited = new HashSet<SyntaxNode>();
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (visited.Contains(node))
                    continue;
                visited.Add(node);
                // add this node to the public list
                yield return node;
                // add every type referenced by this node to the queue
                await foreach (var child in GetReferencedTypes(compilation, node))
                {
                    queue.Enqueue(child);
                }
            }
        }

        private async IAsyncEnumerable<SyntaxNode> GetReferencedTypes(Compilation compilation, SyntaxNode root)
        {
            var semanticModel = compilation.GetSemanticModel(root.SyntaxTree);
            var publicMemberVisitor = new PublicMemberVisitor();
            publicMemberVisitor.Visit(root);
            foreach (var member in publicMemberVisitor.PublicMembers)
            {
                var symbol = semanticModel.GetDeclaredSymbol(member);
                if (symbol == null)
                    continue;
                var list = new List<SyntaxNode>();
                await ProcessSymbol(symbol, list);
                foreach (var node in list)
                {
                    yield return node;
                }
            }
        }

        private async Task ProcessSymbol(ISymbol? symbol, List<SyntaxNode> result)
        {
            if (symbol == null || symbol.DeclaredAccessibility != Accessibility.Public)
                return;
            switch (symbol)
            {
                case INamedTypeSymbol typeSymbol:
                    foreach (var reference in typeSymbol.DeclaringSyntaxReferences)
                    {
                        result.Add(await reference.GetSyntaxAsync());
                    }
                    await ProcessSymbol(typeSymbol.BaseType, result);
                    foreach (var typeArgument in typeSymbol.TypeArguments)
                    {
                        await ProcessSymbol(typeArgument, result);
                    }
                    break;
                case IMethodSymbol methodSymbol:
                    await ProcessSymbol(methodSymbol.ReturnType, result);
                    foreach (var parameter in methodSymbol.Parameters)
                    {
                        await ProcessSymbol(parameter.Type, result);
                    }
                    break;
                case IPropertySymbol propertySymbol:
                    await ProcessSymbol(propertySymbol.Type, result);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        public async Task RemoveOrphanedModels()
        {
            // first get all the declared models
            var models = await GetAllDeclaredModels();
            // traverse all the root and recursively add all the things we met
            var publicModels = TraverseAllPublicModels().ToEnumerable();
            // get the models we need to mark internal
            var internalModels = models.Except(publicModels);
            foreach (var model in internalModels)
            {
                switch (model)
                {
                    case ClassDeclarationSyntax classDeclaration:
                        MarkClassInternal(classDeclaration);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        private void MarkClassInternal(ClassDeclarationSyntax classDeclaration)
        {
            var newClass = GetInternalClass(classDeclaration);
            var tree = classDeclaration.SyntaxTree;
            var document = _project.GetDocument(tree)!;
            var newRoot = tree.GetRoot().ReplaceNode(classDeclaration, newClass).WithAdditionalAnnotations(Simplifier.Annotation);
            _project = _project.RemoveDocument(document.Id);
            document = document.WithSyntaxRoot(newRoot);
            _project = document.Project;
        }

        private static ClassDeclarationSyntax GetInternalClass(ClassDeclarationSyntax classDeclaration)
        {
            var publicTokenInList = classDeclaration.Modifiers.First(token => token.IsKind(SyntaxKind.PublicKeyword));
            var internalToken = SyntaxFactory.Token(publicTokenInList.LeadingTrivia, SyntaxKind.InternalKeyword, publicTokenInList.TrailingTrivia);
            var newModifiers = classDeclaration.Modifiers.Replace(publicTokenInList, internalToken);
            return classDeclaration.WithModifiers(newModifiers);
        }

        public async void RemoveOrphanedEnums(HashSet<string> orphanedDocsToKeep)
        {
            var compilation = await _project.GetCompilationAsync();
            if (compilation == null)
                return;
            var docsToDelete = new HashSet<Document>();
            foreach (var document in _project.Documents)
            {
                if (!IsGeneratedDocument(document) || orphanedDocsToKeep.Contains(document.Name))
                {
                    continue;
                }
                var tree = await document.GetSyntaxTreeAsync();
                if (IsOrphanedEnum(compilation, document, tree!))
                {
                    docsToDelete.Add(document);
                }
            }
            var docNamesToDelete = docsToDelete.Select(d => d.Name).ToHashSet();
            var docIdsToDelete = _project.Documents.Where(d => IsGeneratedDocument(d) && IsOrphanedSerializationClass(d, docNamesToDelete)).Select(d => d.Id).Concat(docsToDelete.Select(d => d.Id)).ToImmutableArray();
            _project = _project.RemoveDocuments(docIdsToDelete);
        }

        private bool IsOrphanedSerializationClass(Document document, HashSet<string> orphanedDocNames)
        {
            if (document.Name.EndsWith(".Serialization.cs"))
            {
                var docName = string.Join(".", document.Name.Split(".").SkipLast(2).Append("cs"));
                return orphanedDocNames.Contains(docName);
            }
            return false;
        }

        private bool IsOrphanedEnum(Compilation compilation, Document document, SyntaxTree tree)
        {
            var semanticModel = compilation.GetSemanticModel(tree!);
            var root = tree!.GetRoot();
            BaseTypeDeclarationSyntax? typeSyntax = root?.DescendantNodes().OfType<StructDeclarationSyntax>().FirstOrDefault();
            if (typeSyntax == null)
            {
                typeSyntax = root?.DescendantNodes().OfType<EnumDeclarationSyntax>().FirstOrDefault();
                if (typeSyntax == null)
                    return false;
            }
            var typeSymbol = semanticModel.GetDeclaredSymbol(typeSyntax);
            if (typeSymbol == null)
            {
                return false;
            }
            var declaringFiles = typeSymbol.DeclaringSyntaxReferences.Select(reference => reference.SyntaxTree.FilePath).ToHashSet();
            var referencesToType = SymbolFinder.FindReferencesAsync(typeSymbol, _project.Solution).Result;
            var refLocations = new HashSet<String>();
            foreach (var reference in referencesToType)
            {
                foreach (var location in reference.Locations)
                {
                    if (!location.Document.Name.EndsWith($"{typeSyntax.Identifier.Value}.Serialization.cs"))
                    {
                        refLocations.Add(location.Document.Name);
                    }
                }
            }
            // If a model is only referenced by its declaring files and serialization file, it is orphaned.
            if (declaringFiles.IsSupersetOf(refLocations))
            {
                return true;
            }
            return false;
        }
    }
}
