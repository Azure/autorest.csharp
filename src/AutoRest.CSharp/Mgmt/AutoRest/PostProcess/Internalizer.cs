// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Mgmt.Output;
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
            var definitions = await PostProcessCommon.GetModels(project, true);
            // get the root nodes
            var rootNodes = await PostProcessCommon.GetRootNodes(project, true, modelsToKeep);
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

        private static bool HasDiscriminator(BaseTypeDeclarationSyntax node, [MaybeNullWhen(false)] out ImmutableHashSet<string> identifiers)
        {
            identifiers = null;
            // only class models will have discriminators
            if (node is ClassDeclarationSyntax classDeclaration)
            {
                if (classDeclaration.HasLeadingTrivia)
                {
                    var syntaxTriviaList = classDeclaration.GetLeadingTrivia();
                    var filteredTriviaList = syntaxTriviaList.Where(syntaxTrivia => MgmtObjectType.DiscriminatorDescFixedPart.All(syntaxTrivia.ToFullString().Contains));
                    if (filteredTriviaList.Count() == 1)
                    {
                        var descendantNodes = filteredTriviaList.First().GetStructure()?.DescendantNodes().ToList();
                        var filteredDescendantNodes = FilterTriviaWithDiscriminator(descendantNodes);
                        var identifierNodes = filteredDescendantNodes.SelectMany(node => node.DescendantNodes().OfType<XmlCrefAttributeSyntax>());
                        identifiers = identifierNodes.Select(identifier => identifier.Cref.ToFullString()).ToImmutableHashSet();
                        return true;
                    }
                }
                return false;
            }

            return false;
        }

        private static IEnumerable<SyntaxNode> FilterTriviaWithDiscriminator(List<SyntaxNode>? nodes)
        {
            // If the base class has discriminator, we will add a description at the end of the original description to add the known derived types
            // Here we use the added description to filter the syntax nodes coming from xml comment to get all the derived types exactly
            var targetIndex = nodes?.FindLastIndex(node => node.ToFullString().Contains(MgmtObjectType.DiscriminatorDescFixedPart.Last()));
            return nodes.Where((val, index) => index >= targetIndex);
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
            var newModifiers = memberDeclaration.Modifiers.Replace(originalTokenInList, newToken);
            return memberDeclaration.WithModifiers(newModifiers);
        }

        private static async Task<CSharpCompilation> GetCompilationAsync(Project project)
        {
            var compilation = await project.GetCompilationAsync() as CSharpCompilation;
            Debug.Assert(compilation != null);
            return compilation;
        }
    }
}
