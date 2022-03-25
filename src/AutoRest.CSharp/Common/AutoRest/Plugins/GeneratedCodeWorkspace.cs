// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Mgmt.AutoRest;
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
        private static bool IsMgmtRootDocument(Document document) => IsGeneratedDocument(document) && Path.GetDirectoryName(document.Name) is "Extensions" or "";

        private class PublicDefinitionVisitor : CSharpSyntaxRewriter
        {
            public ImmutableHashSet<SyntaxNode> ModelDeclarations { get; private set; }
            private readonly ImmutableHashSet<string> _modelsToKeep;

            public PublicDefinitionVisitor(ImmutableHashSet<string> modelsToKeep)
            {
                _modelsToKeep = modelsToKeep;
                ModelDeclarations = ImmutableHashSet<SyntaxNode>.Empty;
            }

            public PublicDefinitionVisitor()
            {
                _modelsToKeep = ImmutableHashSet<string>.Empty;
                ModelDeclarations = ImmutableHashSet<SyntaxNode>.Empty;
            }

            public override SyntaxNode? VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                node = (ClassDeclarationSyntax)base.VisitClassDeclaration(node)!;
                if (IsPublic(node.Modifiers) && !_modelsToKeep.Contains(node.Identifier.ToString()))
                {
                    ModelDeclarations = ModelDeclarations.Add(node);
                }

                return node;
            }

            public override SyntaxNode? VisitStructDeclaration(StructDeclarationSyntax node)
            {
                node = (StructDeclarationSyntax)base.VisitStructDeclaration(node)!;

                if (IsPublic(node.Modifiers) && !_modelsToKeep.Contains(node.Identifier.ToString()))
                {
                    ModelDeclarations = ModelDeclarations.Add(node);
                }
                return node;
            }

            public override SyntaxNode? VisitEnumDeclaration(EnumDeclarationSyntax node)
            {
                node = (EnumDeclarationSyntax)base.VisitEnumDeclaration(node)!;
                if (IsPublic(node.Modifiers) && !_modelsToKeep.Contains(node.Identifier.ToString()))
                {
                    ModelDeclarations = ModelDeclarations.Add(node);
                }
                return node;
            }
        }

        private class PublicMemberVisitor : CSharpSyntaxRewriter
        {
            private List<SyntaxNode> _members = new();

            public IEnumerable<SyntaxNode> PublicMembers => _members;

            public override SyntaxNode? VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                node = (ClassDeclarationSyntax)base.VisitClassDeclaration(node)!;
                if (IsPublic(node.Modifiers))
                {
                    _members.Add(node);
                }
                return node;
            }

            public override SyntaxNode? VisitPropertyDeclaration(PropertyDeclarationSyntax node)
            {
                node = (PropertyDeclarationSyntax)base.VisitPropertyDeclaration(node)!;
                if (IsPublic(node.Modifiers))
                {
                    _members.Add(node);
                }
                return node;
            }

            public override SyntaxNode? VisitMethodDeclaration(MethodDeclarationSyntax node)
            {
                node = (MethodDeclarationSyntax)base.VisitMethodDeclaration(node)!;
                if (IsPublic(node.Modifiers))
                    _members.Add(node);
                return node;
            }

            public override SyntaxNode? VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
            {
                node = (ConstructorDeclarationSyntax)base.VisitConstructorDeclaration(node)!;
                if (IsPublic(node.Modifiers))
                    _members.Add(node);
                return node;
            }
        }

        private static bool IsPublic(SyntaxTokenList tokenList)
            => tokenList.Any(token => token.IsKind(SyntaxKind.PublicKeyword));

        private static bool IsStatic(SyntaxTokenList tokenList)
            => tokenList.Any(token => token.IsKind(SyntaxKind.StaticKeyword));

        private async Task<ImmutableHashSet<SyntaxNode>> GetAllDeclaredModels(ImmutableHashSet<string> modelsToKeep)
        {
            var classVisitor = new PublicDefinitionVisitor(modelsToKeep);

            foreach (var document in _project.Documents)
            {
                if (IsGeneratedDocument(document))
                {
                    var root = await document.GetSyntaxRootAsync();
                    classVisitor.Visit(root);
                }
            }

            return classVisitor.ModelDeclarations;
        }

        private async Task<ClassDeclarationSyntax> GetModelFactoryClass()
        {
            var fileName = $"{MgmtContext.RpName}ModelFactory.cs";
            var root = await _project.Documents.First(d => d.Name.EndsWith(fileName)).GetSyntaxRootAsync();
            return root!.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
        }

        private async IAsyncEnumerable<SyntaxNode> TraverseAllPublicModelsAsync()
        {
            var compilation = await _project.GetCompilationAsync();
            if (compilation == null)
                yield break;

            // get the root nodes
            var classVisitor = new PublicDefinitionVisitor();
            foreach (var document in _project.Documents)
            {
                // we only find the files directly under `Generated` and `Extensions`
                if (IsMgmtRootDocument(document))
                {
                    var root = await document.GetSyntaxRootAsync();
                    classVisitor.Visit(root);
                }
            }
            var queue = new Queue<SyntaxNode>(classVisitor.ModelDeclarations);
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
                var list = new HashSet<SyntaxNode>();
                await ProcessSymbol(symbol, list);
                foreach (var node in list)
                {
                    yield return node;
                }
            }
        }

        private async Task ProcessSymbol(ISymbol? symbol, HashSet<SyntaxNode> result)
        {
            if (symbol == null || symbol.DeclaredAccessibility != Accessibility.Public)
                return;
            switch (symbol)
            {
                case INamedTypeSymbol typeSymbol:
                    foreach (var reference in typeSymbol.DeclaringSyntaxReferences)
                    {
                        var node = await reference.GetSyntaxAsync();
                        // short cut the recursive execution if this has already been in the result
                        if (result.Contains(node))
                            return;
                        result.Add(node);
                        if (HasDiscriminator(node, out var identifierCandidates))
                        {
                            // first find all the derived types from this type
                            foreach (var derivedTypeSymbol in await SymbolFinder.FindDerivedClassesAsync(typeSymbol, _project.Solution))
                            {
                                if (identifierCandidates.Contains(derivedTypeSymbol.Name))
                                {
                                    await ProcessSymbol(derivedTypeSymbol, result);
                                }
                            }
                        }
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
                    throw new InvalidOperationException($"Not implemented for symbol {symbol.GetType()}");
            }
        }

        private static bool HasDiscriminator(SyntaxNode node, [MaybeNullWhen(false)] out ImmutableHashSet<string> identifiers)
        {
            identifiers = null;
            // only class models will have discriminators
            if (node is ClassDeclarationSyntax classDeclaration)
            {
                var methodName = $"Deserialize{classDeclaration.Identifier.Text}";
                var deserializeMethod = classDeclaration.Members.OfType<MethodDeclarationSyntax>().FirstOrDefault(method => method.Identifier.Text.Equals(methodName));
                if (deserializeMethod != null && deserializeMethod.Body != null)
                {
                    var switchStatementNode = deserializeMethod.Body.DescendantNodes().OfType<SwitchStatementSyntax>();
                    foreach (var switchNode in switchStatementNode)
                    {
                        if (switchNode.Expression.ToFullString().Contains("discriminator.GetString"))
                        {
                            // get the identifiers in the switch statements, some of them are class names of the derived classes
                            // but since we do not have the full semantic model here, we cannot directly get which of them is
                            // therefore here we just return all of them, and see if the derived type name shows in this list
                            var identifierNodes = switchNode.Sections.SelectMany(section => section.DescendantNodes().OfType<IdentifierNameSyntax>());
                            identifiers = identifierNodes.Select(identifier => identifier.Identifier.ToFullString()).ToImmutableHashSet();
                            return true;
                        }
                    }
                }
                return false;
            }

            return false;
        }

        public async Task InternalizeOrphanedModels(ImmutableHashSet<string> modelsToKeep)
        {
            // first get all the declared models
            var definitions = await GetAllDeclaredModels(modelsToKeep);
            // traverse all the root and recursively add all the things we met
            var publicModels = TraverseAllPublicModelsAsync();

            var modelFactoryNode = await GetModelFactoryClass();
            var tree = modelFactoryNode.SyntaxTree;
            var document = _project.GetDocument(tree)!;
            var newModelFactoryNode = modelFactoryNode;
            await foreach (var model in publicModels)
            {
                definitions = definitions.Remove(model);
            }
            // get the models we need to mark internal
            foreach (var model in definitions)
            {
                MarkInternal(model, ref newModelFactoryNode);
            }

            var newRoot = tree.GetRoot().ReplaceNode(modelFactoryNode, newModelFactoryNode).WithAdditionalAnnotations(Simplifier.Annotation);
            _project = _project.RemoveDocument(document.Id);
            document = document.WithSyntaxRoot(newRoot);
            _project = document.Project;
        }

        private void MarkInternal(SyntaxNode declarationNode, ref ClassDeclarationSyntax modelFactoryNode)
        {
            var newNode = declarationNode switch
            {
                MemberDeclarationSyntax declaration => MarkInternal(declaration, ref modelFactoryNode),
                _ => throw new InvalidOperationException()
            };
            var tree = declarationNode.SyntaxTree;
            var document = _project.GetDocument(tree)!;
            var newRoot = tree.GetRoot().ReplaceNode(declarationNode, newNode).WithAdditionalAnnotations(Simplifier.Annotation);
            _project = _project.RemoveDocument(document.Id);
            document = document.WithSyntaxRoot(newRoot);
            _project = document.Project;
        }

        private static MemberDeclarationSyntax MarkInternal(MemberDeclarationSyntax memberDeclaration, ref ClassDeclarationSyntax modelFactoryNode)
        {
            string? name = memberDeclaration switch
            {
                ClassDeclarationSyntax classDeclaration => classDeclaration.Identifier.Text,
                StructDeclarationSyntax structDeclaration => structDeclaration.Identifier.Text,
                _ => null
            };

            if (name is not null)
            {
                var methodToRemove = modelFactoryNode.DescendantNodes(node => node is MethodDeclarationSyntax method && method.Identifier.Text == name);
                modelFactoryNode = modelFactoryNode.RemoveNodes(methodToRemove, SyntaxRemoveOptions.KeepNoTrivia)!;
            }

            var publicTokenInList = memberDeclaration.Modifiers.First(token => token.IsKind(SyntaxKind.PublicKeyword));
            var internalToken = SyntaxFactory.Token(publicTokenInList.LeadingTrivia, SyntaxKind.InternalKeyword, publicTokenInList.TrailingTrivia);
            var newModifiers = memberDeclaration.Modifiers.Replace(publicTokenInList, internalToken);
            return memberDeclaration.WithModifiers(newModifiers);
        }
    }
}
