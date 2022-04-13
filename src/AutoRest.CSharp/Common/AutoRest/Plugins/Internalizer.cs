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
            // traverse all the root and recursively add all the things we met
            var publicModels = TraverseAllPublicModelsAsync(compilation, project, rootNodes);
            await foreach (var model in publicModels)
            {
                definitions = definitions.Remove(model);
            }
            // get the models we need to mark internal
            foreach (var model in definitions)
            {
                project = MarkInternal(project, model);
            }

            return project;
        }

        private static async IAsyncEnumerable<SyntaxNode> TraverseAllPublicModelsAsync(Compilation compilation, Project project, ImmutableHashSet<SyntaxNode> rootNodes)
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
                await foreach (var child in GetReferencedTypes(compilation, project, node))
                {
                    queue.Enqueue(child);
                }
            }
        }

        private static async IAsyncEnumerable<SyntaxNode> GetReferencedTypes(Compilation compilation, Project project, SyntaxNode root)
        {
            var semanticModel = compilation.GetSemanticModel(root.SyntaxTree);
            var publicMemberVisitor = new MemberVisitor(IsPublic);
            publicMemberVisitor.Visit(root);
            foreach (var member in publicMemberVisitor.PublicMembers)
            {
                var symbol = semanticModel.GetDeclaredSymbol(member);
                if (symbol == null)
                    continue;
                var list = new HashSet<SyntaxNode>();
                await ProcessSymbol(project, symbol, list);
                foreach (var node in list)
                {
                    yield return node;
                }
            }
        }

        private static async Task ProcessSymbol(Project project, ISymbol? symbol, HashSet<SyntaxNode> result)
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
                            foreach (var derivedTypeSymbol in await SymbolFinder.FindDerivedClassesAsync(typeSymbol, project.Solution))
                            {
                                if (identifierCandidates.Contains(derivedTypeSymbol.Name))
                                {
                                    await ProcessSymbol(project, derivedTypeSymbol, result);
                                }
                            }
                        }
                    }
                    await ProcessSymbol(project, typeSymbol.BaseType, result);
                    foreach (var typeArgument in typeSymbol.TypeArguments)
                    {
                        await ProcessSymbol(project, typeArgument, result);
                    }
                    break;
                case IMethodSymbol methodSymbol:
                    await ProcessSymbol(project, methodSymbol.ReturnType, result);
                    foreach (var parameter in methodSymbol.Parameters)
                    {
                        await ProcessSymbol(project, parameter.Type, result);
                    }
                    break;
                case IPropertySymbol propertySymbol:
                    await ProcessSymbol(project, propertySymbol.Type, result);
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

        private static Project MarkInternal(Project project, SyntaxNode declarationNode)
        {
            var newNode = declarationNode switch
            {
                MemberDeclarationSyntax declaration => ChangeModifier(declaration, SyntaxKind.PublicKeyword, SyntaxKind.InternalKeyword),
                _ => throw new InvalidOperationException()
            };
            var tree = declarationNode.SyntaxTree;
            var document = project.GetDocument(tree)!;
            var newRoot = tree.GetRoot().ReplaceNode(declarationNode, newNode).WithAdditionalAnnotations(Simplifier.Annotation);
            //project = project.RemoveDocument(document.Id);
            document = document.WithSyntaxRoot(newRoot);
            project = document.Project;

            return project;
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

            public IEnumerable<SyntaxNode> PublicMembers => _members;

            private Func<SyntaxTokenList, bool> _predicate;

            public MemberVisitor(Func<SyntaxTokenList, bool> accessibility)
            {
                _predicate = accessibility;
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

        private static bool IsPublic(SyntaxTokenList tokenList)
            => tokenList.Any(token => token.IsKind(SyntaxKind.PublicKeyword));
    }
}
