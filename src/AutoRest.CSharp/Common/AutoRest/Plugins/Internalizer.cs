// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.CodeAnalysis.Simplification;

namespace AutoRest.CSharp.Common.AutoRest.Plugins
{
    internal static class Internalizer
    {
        public static async Task<Project> InternalizeAsync(Project project, ImmutableHashSet<string> modelsToKeep)
        {
            var compilation = await GetCompilationAsync(project);

            // first get all the declared models
            var definitions = await GetAllPublicDeclaredModels(project, modelsToKeep);

            // get the root nodes
            var rootNodes = await GetRootNodes(project);
            // traverse all the models from the roots and recursively add all the things we met (including non-public things)
            var referencedModels = TraverseAllModelsAsync(compilation, project, rootNodes, false);
            var unreferencedModels = new HashSet<SyntaxNode>(definitions);
            await foreach (var model in referencedModels)
            {
                unreferencedModels.Remove(model);
            }
            foreach (var model in unreferencedModels)
            {
                project = await RemoveNode(compilation, project, model);
            }
            // traverse all the models from the roots and recursively add all the public things we met
            var publicModels = TraverseAllModelsAsync(compilation, project, rootNodes, true);
            var internalModels = new HashSet<SyntaxNode>(definitions);
            await foreach (var model in publicModels)
            {
                internalModels.Remove(model);
            }
            // get the models we need to mark internal
            foreach (var model in internalModels)
            {
                project = await MarkInternal(project, model);
            }

            return project;
        }

        private static async IAsyncEnumerable<SyntaxNode> TraverseAllModelsAsync(Compilation compilation, Project project, ImmutableHashSet<SyntaxNode> rootNodes, bool publicOnly)
        {
            var queue = new Queue<SyntaxNode>(rootNodes);
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
                await foreach (var child in GetReferencedTypes(compilation, project, node, publicOnly))
                {
                    queue.Enqueue(child);
                }
            }
        }

        private static async IAsyncEnumerable<SyntaxNode> GetReferencedTypes(Compilation compilation, Project project, SyntaxNode root, bool publicOnly)
        {
            var semanticModel = compilation.GetSemanticModel(root.SyntaxTree);
            var memberVisitor = new MemberVisitor(publicOnly);
            memberVisitor.Visit(root);
            foreach (var member in memberVisitor.Members)
            {
                var symbol = semanticModel.GetDeclaredSymbol(member);
                if (symbol == null)
                    continue;
                var referencedNodes = new HashSet<SyntaxNode>();
                await ProcessSymbol(project, symbol, publicOnly, referencedNodes);
                foreach (var node in referencedNodes)
                {
                    yield return node;
                }
            }
        }

        private static async Task ProcessSymbol(Project project, ISymbol? symbol, bool publicOnly, HashSet<SyntaxNode> referencedNodes)
        {
            if (symbol == null)
                return;
            if (publicOnly && symbol.DeclaredAccessibility != Accessibility.Public)
                return;
            switch (symbol)
            {
                case INamedTypeSymbol typeSymbol:
                    foreach (var reference in typeSymbol.DeclaringSyntaxReferences)
                    {
                        var node = await reference.GetSyntaxAsync();
                        // short cut the recursive execution if this has already been in the result
                        if (referencedNodes.Contains(node))
                            return;
                        referencedNodes.Add(node);
                        if (HasDiscriminator(node, out var identifierCandidates))
                        {
                            // first find all the derived types from this type
                            foreach (var derivedTypeSymbol in await SymbolFinder.FindDerivedClassesAsync(typeSymbol, project.Solution))
                            {
                                if (identifierCandidates.Contains(derivedTypeSymbol.Name))
                                {
                                    await ProcessSymbol(project, derivedTypeSymbol, publicOnly, referencedNodes);
                                }
                            }
                        }
                    }
                    await ProcessSymbol(project, typeSymbol.BaseType, publicOnly, referencedNodes);
                    foreach (var typeArgument in typeSymbol.TypeArguments)
                    {
                        await ProcessSymbol(project, typeArgument, publicOnly, referencedNodes);
                    }
                    break;
                case IMethodSymbol methodSymbol:
                    await ProcessSymbol(project, methodSymbol.ReturnType, publicOnly, referencedNodes);
                    foreach (var parameter in methodSymbol.Parameters)
                    {
                        await ProcessSymbol(project, parameter.Type, publicOnly, referencedNodes);
                    }
                    break;
                case IPropertySymbol propertySymbol:
                    await ProcessSymbol(project, propertySymbol.Type, publicOnly, referencedNodes);
                    break;
                case IFieldSymbol fieldSymbol:
                    await ProcessSymbol(project, fieldSymbol.Type, publicOnly, referencedNodes);
                    break;
                case IArrayTypeSymbol arrayTypeSymbol:
                    await ProcessSymbol(project, arrayTypeSymbol.ElementType, publicOnly, referencedNodes);
                    break;
                case ITypeParameterSymbol:
                    // This is the type parameter place holder (such like a `T`), do nothing
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

        private static async Task<Project> MarkInternal(Project project, SyntaxNode declarationNode)
        {
            var newNode = declarationNode switch
            {
                MemberDeclarationSyntax declaration => ChangeModifier(declaration, SyntaxKind.PublicKeyword, SyntaxKind.InternalKeyword),
                _ => throw new InvalidOperationException()
            };
            var tree = declarationNode.SyntaxTree;
            var document = project.GetDocument(tree);
            if (document == null)
                return project;
            var root = await tree.GetRootAsync();
            root = root.ReplaceNode(declarationNode, newNode).WithAdditionalAnnotations(Simplifier.Annotation);
            document = document.WithSyntaxRoot(root);
            project = document.Project;

            return project;
        }

        private static async Task<Project> RemoveNode(Compilation compilation, Project project, SyntaxNode declarationNode)
        {
            var tree = declarationNode.SyntaxTree;
            var document = project.GetDocument(tree);
            if (document == null)
                return project;
            var root = await tree.GetRootAsync();
            root = root.RemoveNode(declarationNode, SyntaxRemoveOptions.KeepNoTrivia);
            document = document.WithSyntaxRoot(root!);
            project = document.Project;

            await foreach (var nodes in GetExtensionNodes(compilation, project, declarationNode))
            {
                project = await RemoveNodes(project, nodes);
            }

            return project;
        }

        private static async Task<Project> RemoveNodes(Project project, IEnumerable<SyntaxNode> nodes)
        {
            var tree = nodes.First().SyntaxTree;
            var document = project.GetDocument(tree);
            if (document == null)
                return project;
            var root = await tree.GetRootAsync();
            root = root.RemoveNodes(nodes, SyntaxRemoveOptions.KeepNoTrivia);
            document = document.WithSyntaxRoot(root!);
            project = document.Project;

            return project;
        }

        private static async IAsyncEnumerable<IEnumerable<SyntaxNode>> GetExtensionNodes(Compilation compilation, Project project, SyntaxNode declarationNode)
        {
            // in our generation, only enum declarations have extension classes as serialization method which is internal by default. We need to remove it as well if we remove its corresponding enum definition
            if (declarationNode is not EnumDeclarationSyntax enumDeclaration)
            {
                yield break;
            }

            foreach (var document in project.Documents)
            {
                if (GeneratedCodeWorkspace.IsGeneratedDocument(document))
                {
                    var root = await document.GetSyntaxRootAsync();
                    if (root == null)
                        continue;
                    var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
                    var classes = classDeclarations
                        .Where(delcaration => IsExtensionClass(delcaration, enumDeclaration));

                    if (classes.Any())
                        yield return classes;
                }
            }
        }

        private static bool IsExtensionClass(ClassDeclarationSyntax classDeclaration, BaseTypeDeclarationSyntax baseTypeDeclaration)
        {
            if (!ContainsToken(classDeclaration.Modifiers, SyntaxKind.StaticKeyword))
                return false;

            return classDeclaration.Identifier.Text.Equals($"{baseTypeDeclaration.Identifier.Text}Extensions");
        }

        private static MemberDeclarationSyntax ChangeModifier(MemberDeclarationSyntax memberDeclaration, SyntaxKind from, SyntaxKind to)
        {
            var originalTokenInList = memberDeclaration.Modifiers.First(token => token.IsKind(from));
            var newToken = SyntaxFactory.Token(originalTokenInList.LeadingTrivia, to, originalTokenInList.TrailingTrivia);
            var newModidiers = memberDeclaration.Modifiers.Replace(originalTokenInList, newToken);
            return memberDeclaration.WithModifiers(newModidiers);
        }

        private static async Task<CSharpCompilation> GetCompilationAsync(Project project)
        {
            var compilation = await project.GetCompilationAsync() as CSharpCompilation;
            Debug.Assert(compilation != null);
            return compilation;
        }

        private static async Task<ImmutableHashSet<SyntaxNode>> GetAllPublicDeclaredModels(Project project, ImmutableHashSet<string> modelsToKeep)
        {
            var classVisitor = new PublicDefinitionVisitor(modelsToKeep);

            foreach (var document in project.Documents)
            {
                if (GeneratedCodeWorkspace.IsGeneratedDocument(document))
                {
                    var root = await document.GetSyntaxRootAsync();
                    classVisitor.Visit(root);
                }
            }

            return classVisitor.ModelDeclarations;
        }

        private static async Task<ImmutableHashSet<SyntaxNode>> GetRootNodes(Project project)
        {
            var classVisitor = new PublicDefinitionVisitor();
            foreach (var document in project.Documents)
            {
                var root = await document.GetSyntaxRootAsync();
                // we add a declaration as root node when
                // 1. the file is under `Generated` or `Generated/Extensions` which is handled by `IsMgmtRootDocument`
                // 2. the declaration has a ReferenceType or similar attribute on it which is handled by `IsReferenceType`
                // 3. the file is custom code (not generated and not shared) which is handled by `IsCustomDocument`
                if (IsMgmtRootDocument(document) || IsReferenceType(root) || GeneratedCodeWorkspace.IsCustomDocument(document))
                {
                    classVisitor.Visit(root);
                }
            }

            return classVisitor.ModelDeclarations;
        }

        private static bool IsMgmtRootDocument(Document document) => GeneratedCodeWorkspace.IsGeneratedDocument(document) && Path.GetDirectoryName(document.Name) is "Extensions" or "";

        private static HashSet<string> _referenceAttributes = new HashSet<string> { "ReferenceType", "PropertyReferenceType", "TypeReferenceType" };

        private static bool IsReferenceType(SyntaxNode? root)
        {
            if (root is null)
                return false;

            var childNodes = root.DescendantNodes();
            var typeNode = childNodes.OfType<TypeDeclarationSyntax>().FirstOrDefault();
            if (typeNode is null)
            {
                return false;
            }

            var attributeLists = GetAttributeLists(typeNode);
            if (attributeLists is null || attributeLists.Value.Count == 0)
                return false;

            foreach (var attributeList in attributeLists.Value)
            {
                if (_referenceAttributes.Contains(attributeList.Attributes[0].Name.ToString()))
                    return true;
            }

            return false;
        }

        private static SyntaxList<AttributeListSyntax>? GetAttributeLists(SyntaxNode node)
        {
            if (node is StructDeclarationSyntax structDeclaration)
                return structDeclaration.AttributeLists;

            if (node is ClassDeclarationSyntax classDeclaration)
                return classDeclaration.AttributeLists;

            return null;
        }

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

        private class MemberVisitor : CSharpSyntaxRewriter
        {
            private List<SyntaxNode> _members = new();

            public IEnumerable<SyntaxNode> Members => _members;

            private Func<SyntaxTokenList, bool> _predicate;

            public MemberVisitor(bool publicOnly)
            {
                if (publicOnly)
                    _predicate = IsPublic;
                else
                    _predicate = _ => true;
            }

            public override SyntaxNode? VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                node = (ClassDeclarationSyntax)base.VisitClassDeclaration(node)!;
                if (_predicate(node.Modifiers))
                {
                    _members.Add(node);
                }
                return node;
            }

            public override SyntaxNode? VisitPropertyDeclaration(PropertyDeclarationSyntax node)
            {
                node = (PropertyDeclarationSyntax)base.VisitPropertyDeclaration(node)!;
                if (_predicate(node.Modifiers))
                {
                    _members.Add(node);
                }
                return node;
            }

            public override SyntaxNode? VisitFieldDeclaration(FieldDeclarationSyntax node)
            {
                node = (FieldDeclarationSyntax)base.VisitFieldDeclaration(node)!;
                if (_predicate(node.Modifiers))
                {
                    // a field declaration can declare multiple fields, therefore we need to add them one by one
                    foreach (var variable in node.Declaration.Variables)
                        _members.Add(variable);
                }
                return node;
            }

            public override SyntaxNode? VisitMethodDeclaration(MethodDeclarationSyntax node)
            {
                node = (MethodDeclarationSyntax)base.VisitMethodDeclaration(node)!;
                if (_predicate(node.Modifiers))
                    _members.Add(node);
                return node;
            }

            public override SyntaxNode? VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
            {
                node = (ConstructorDeclarationSyntax)base.VisitConstructorDeclaration(node)!;
                if (_predicate(node.Modifiers))
                    _members.Add(node);
                return node;
            }
        }

        private static bool ContainsToken(SyntaxTokenList tokenList, SyntaxKind kind)
            => tokenList.Any(token => token.IsKind(kind));
        private static bool IsPublic(SyntaxTokenList tokenList) => ContainsToken(tokenList, SyntaxKind.PublicKeyword);
        private static bool IsStatic(SyntaxTokenList tokenList) => ContainsToken(tokenList, SyntaxKind.StaticKeyword);
    }
}
