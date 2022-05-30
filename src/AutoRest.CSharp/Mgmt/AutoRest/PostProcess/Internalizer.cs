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

namespace AutoRest.CSharp.Mgmt.AutoRest.PostProcess
{
    internal static class Internalizer
    {
        public static async Task<Project> InternalizeAsync(Project project, ImmutableHashSet<string> modelsToKeep)
        {
            var compilation = await GetCompilationAsync(project);

            // first get all the declared models
            var definitions = await GetModels(project, true);
            // get the root nodes
            var rootNodes = await GetRootNodes(project, modelsToKeep, true);
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

        private static async IAsyncEnumerable<BaseTypeDeclarationSyntax> TraverseAllPublicModelsAsync(Compilation compilation, Project project, ImmutableHashSet<BaseTypeDeclarationSyntax> rootNodes)
        {
            var queue = new Queue<BaseTypeDeclarationSyntax>(rootNodes);
            // traverse all the models starting from the root nodes
            var visited = new HashSet<BaseTypeDeclarationSyntax>();
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

        private static async IAsyncEnumerable<BaseTypeDeclarationSyntax> GetReferencedTypes(Compilation compilation, Project project, SyntaxNode root)
        {
            var semanticModel = compilation.GetSemanticModel(root.SyntaxTree);
            var publicMemberVisitor = new MemberVisitor(true);
            publicMemberVisitor.Visit(root);
            foreach (var member in publicMemberVisitor.PublicMembers)
            {
                var symbol = semanticModel.GetDeclaredSymbol(member);
                if (symbol == null)
                    continue;
                var list = new HashSet<BaseTypeDeclarationSyntax>();
                await ProcessSymbol(project, symbol, list);
                foreach (var node in list)
                {
                    yield return node;
                }
            }
        }

        private static async Task ProcessSymbol(Project project, ISymbol? symbol, HashSet<BaseTypeDeclarationSyntax> result)
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
                        Debug.Assert(node is BaseTypeDeclarationSyntax);
                        var declaration = (BaseTypeDeclarationSyntax)node;
                        result.Add(declaration);
                        if (HasDiscriminator(declaration, out var identifierCandidates))
                        {
                            // first find all the derived types from this type
                            foreach (var derivedTypeSymbol in await Microsoft.CodeAnalysis.FindSymbols.SymbolFinder.FindDerivedClassesAsync(typeSymbol, project.Solution))
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

        private static bool HasDiscriminator(BaseTypeDeclarationSyntax node, [MaybeNullWhen(false)] out ImmutableHashSet<string> identifiers)
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

        private static Project MarkInternal(Project project, BaseTypeDeclarationSyntax declarationNode)
        {
            var newNode = ChangeModifier(declarationNode, SyntaxKind.PublicKeyword, SyntaxKind.InternalKeyword);
            var tree = declarationNode.SyntaxTree;
            var document = project.GetDocument(tree)!;
            var newRoot = tree.GetRoot().ReplaceNode(declarationNode, newNode).WithAdditionalAnnotations(Simplifier.Annotation);
            document = document.WithSyntaxRoot(newRoot);
            project = document.Project;

            return project;
        }

        private static BaseTypeDeclarationSyntax ChangeModifier(BaseTypeDeclarationSyntax memberDeclaration, SyntaxKind from, SyntaxKind to)
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

        public static async Task<ImmutableHashSet<BaseTypeDeclarationSyntax>> GetModels(Project project, bool publicOnly)
        {
            var classVisitor = new DefinitionVisitor(publicOnly);

            foreach (var document in project.Documents)
            {
                if (!GeneratedCodeWorkspace.IsSharedDocument(document))
                {
                    var root = await document.GetSyntaxRootAsync();
                    classVisitor.Visit(root);
                }
            }

            return classVisitor.ModelDeclarations;
        }

        public static async Task<ImmutableHashSet<BaseTypeDeclarationSyntax>> GetRootNodes(Project project, ImmutableHashSet<string> modelsToKeep, bool publicOnly)
        {
            var classVisitor = new DefinitionVisitor(publicOnly);
            foreach (var document in project.Documents)
            {
                var root = await document.GetSyntaxRootAsync();
                // we add a declaration as root node when
                // 1. the file is under `Generated` or `Generated/Extensions` which is handled by `IsMgmtRootDocument`
                // 2. the declaration has a ReferenceType or similar attribute on it which is handled by `IsReferenceType`
                // 3. the file is custom code (not generated and not shared) which is handled by `IsCustomDocument`
                if (IsMgmtRootDocument(document) || IsReferenceType(root) || GeneratedCodeWorkspace.IsCustomDocument(document) || ShouldKeepModel(root, modelsToKeep))
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

        private static bool ShouldKeepModel(SyntaxNode? root, ImmutableHashSet<string> modelsToKeep)
        {
            if (root is null)
                return false;

            // use `BaseTypeDeclarationSyntax` to also include enums because `EnumDeclarationSyntax` extends `BaseTypeDeclarationSyntax`
            // `ClassDeclarationSyntax` and `StructDeclarationSyntax` both inherit `TypeDeclarationSyntax`
            var typeNodes = root.DescendantNodes().OfType<BaseTypeDeclarationSyntax>();
            // there is possibility that we have multiple types defined in the same document (for instance, custom code)
            return typeNodes.Any(t => modelsToKeep.Contains(t.Identifier.Text));
        }

        private static SyntaxList<AttributeListSyntax>? GetAttributeLists(SyntaxNode node)
        {
            if (node is StructDeclarationSyntax structDeclaration)
                return structDeclaration.AttributeLists;

            if (node is ClassDeclarationSyntax classDeclaration)
                return classDeclaration.AttributeLists;

            return null;
        }
    }
}
