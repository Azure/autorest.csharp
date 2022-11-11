// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Simplification;

namespace AutoRest.CSharp.Common.Output.PostProcessing;

internal abstract class PostProcessor
{
    protected Project _project;

    public PostProcessor(Project project)
    {
        _project = project;
    }

    protected record ModelSymbols(HashSet<INamedTypeSymbol> DeclaredSymbols, Dictionary<INamedTypeSymbol, HashSet<BaseTypeDeclarationSyntax>> DeclaredNodesCache, Dictionary<Document, HashSet<INamedTypeSymbol>> DocumentCache);

    protected virtual async Task<ModelSymbols> GetModelSymbolsAsync(Compilation compilation, bool publicOnly = true)
    {
        var result = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);
        var declarationCache = new Dictionary<INamedTypeSymbol, HashSet<BaseTypeDeclarationSyntax>>(SymbolEqualityComparer.Default);
        var documentCache = new Dictionary<Document, HashSet<INamedTypeSymbol>>();
        foreach (var document in _project.Documents)
        {
            if (!GeneratedCodeWorkspace.IsSharedDocument(document))
            {
                var root = await document.GetSyntaxRootAsync();
                if (root == null)
                    continue;

                var semanticModel = compilation.GetSemanticModel(root.SyntaxTree);

                foreach (var typeDeclaration in root.DescendantNodes().OfType<BaseTypeDeclarationSyntax>())
                {
                    var symbol = semanticModel.GetDeclaredSymbol(typeDeclaration);
                    if (symbol == null)
                        continue;
                    if (publicOnly && symbol.DeclaredAccessibility != Accessibility.Public)
                        continue;
                    result.Add(symbol);
                    declarationCache.AddInList(symbol, typeDeclaration);
                    documentCache.AddInList(document, symbol, () => new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default));
                }
            }
        }

        return new ModelSymbols(result, declarationCache, documentCache);
    }

    public async Task<Project> InternalizeAsync()
    {
        var compilation = await _project.GetCompilationAsync();
        if (compilation == null)
            return _project;

        // first get all the declared symbols
        var definitions = await GetModelSymbolsAsync(compilation, true);
        // build the reference map
        var referenceMap = await new ReferenceMapBuilder(compilation, _project, HasDiscriminator).BuildPublicReferenceMapAsync(definitions.DeclaredSymbols, definitions.DeclaredNodesCache);
        // get the root symbols
        var rootSymbols = GetRootSymbols(definitions);
        // traverse all the root and recursively add all the things we met
        var publicSymbols = TraverseModelsAsync(rootSymbols, referenceMap);

        var symbolsToInternalize = definitions.DeclaredSymbols.Except(publicSymbols);

        var nodesToInternalize = new List<BaseTypeDeclarationSyntax>();
        foreach (var symbol in symbolsToInternalize)
        {
            nodesToInternalize.AddRange(definitions.DeclaredNodesCache[symbol]);
        }

        foreach (var model in nodesToInternalize)
        {
            MarkInternal(model);
        }

        return _project;
    }

    public async Task<Project> RemoveAsync()
    {
        var compilation = await _project.GetCompilationAsync();
        if (compilation == null)
            return _project;

        // find all the declarations, including non-public declared
        var definitions = await GetModelSymbolsAsync(compilation, false);
        // build reference map
        var referenceMap = await new ReferenceMapBuilder(compilation, _project, HasDiscriminator).BuildAllReferenceMapAsync(definitions.DeclaredSymbols, definitions.DocumentCache);
        // get root nodes
        var rootNodes = GetRootSymbols(definitions);
        // traverse the map to determine the declarations that we are about to remove, starting from root nodes
        var referencedSymbols = TraverseModelsAsync(rootNodes, referenceMap);

        var symbolsToRemove = definitions.DeclaredSymbols.Except(referencedSymbols);

        var nodesToRemove = new List<BaseTypeDeclarationSyntax>();
        foreach (var symbol in symbolsToRemove)
        {
            nodesToRemove.AddRange(definitions.DeclaredNodesCache[symbol]);
        }

        // remove them one by one
        await RemoveModelsAsync(nodesToRemove);

        return _project;
    }

    private static IEnumerable<INamedTypeSymbol> TraverseModelsAsync(IEnumerable<INamedTypeSymbol> rootNodes, Dictionary<INamedTypeSymbol, HashSet<INamedTypeSymbol>> referenceMap)
    {
        var queue = new Queue<INamedTypeSymbol>(rootNodes);
        var visited = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);
        while (queue.Count > 0)
        {
            var definition = queue.Dequeue();
            if (visited.Contains(definition))
                continue;
            visited.Add(definition);
            // add this definition to the result
            yield return definition;
            // add every type referenced by this node to the queue
            foreach (var child in GetReferencedTypes(definition, referenceMap))
            {
                queue.Enqueue(child);
            }
        }
    }

    private static IEnumerable<T> GetReferencedTypes<T>(T definition, Dictionary<T, HashSet<T>> referenceMap) where T : notnull
    {
        if (referenceMap.TryGetValue(definition, out var references))
        {
            foreach (var reference in references)
            {
                yield return reference;
            }
        }
    }

    private void MarkInternal(BaseTypeDeclarationSyntax declarationNode)
    {
        var newNode = ChangeModifier(declarationNode, SyntaxKind.PublicKeyword, SyntaxKind.InternalKeyword);
        var tree = declarationNode.SyntaxTree;
        var document = _project.GetDocument(tree)!;
        var newRoot = tree.GetRoot().ReplaceNode(declarationNode, newNode).WithAdditionalAnnotations(Simplifier.Annotation);
        document = document.WithSyntaxRoot(newRoot);
        _project = document.Project;
    }

    private async Task<Project> RemoveModelsAsync(IEnumerable<BaseTypeDeclarationSyntax> unusedModels)
    {
        // accumulate the definitions from the same document together
        var documents = new Dictionary<Document, HashSet<BaseTypeDeclarationSyntax>>();
        foreach (var model in unusedModels)
        {
            var document = _project.GetDocument(model.SyntaxTree);
            Debug.Assert(document != null);
            if (!documents.ContainsKey(document))
                documents.Add(document, new HashSet<BaseTypeDeclarationSyntax>());

            documents[document].Add(model);
        }

        foreach (var models in documents.Values)
        {
            _project = await RemoveModelsFromDocumentAsync(models);
        }

        return _project;
    }

    private static BaseTypeDeclarationSyntax ChangeModifier(BaseTypeDeclarationSyntax memberDeclaration, SyntaxKind from, SyntaxKind to)
    {
        var originalTokenInList = memberDeclaration.Modifiers.First(token => token.IsKind(from));
        var newToken = SyntaxFactory.Token(originalTokenInList.LeadingTrivia, to, originalTokenInList.TrailingTrivia);
        var newModifiers = memberDeclaration.Modifiers.Replace(originalTokenInList, newToken);
        return memberDeclaration.WithModifiers(newModifiers);
    }

    private async Task<Project> RemoveModelsFromDocumentAsync(IEnumerable<BaseTypeDeclarationSyntax> models)
    {
        var tree = models.First().SyntaxTree;
        var document = _project.GetDocument(tree);
        if (document == null)
            return _project;
        var root = await tree.GetRootAsync();
        root = root.RemoveNodes(models, SyntaxRemoveOptions.KeepNoTrivia);
        document = document.WithSyntaxRoot(root!);
        return document.Project;
    }

    protected virtual HashSet<INamedTypeSymbol> GetRootSymbols(ModelSymbols modelSymbols)
    {
        var result = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);
        foreach (var symbol in modelSymbols.DeclaredSymbols)
        {
            foreach (var declarationNode in modelSymbols.DeclaredNodesCache[symbol])
            {
                var tree = declarationNode.SyntaxTree;
                var document = _project.GetDocument(tree);
                if (document == null)
                    continue;
                if (IsRootDocument(document))
                {
                    result.Add(symbol);
                    break; // any of the declaring document of this symbol is root, we add it to the root list, skipping the processing of other documents of this symbol (because it is unnecessary)
                }
            }
        }

        return result;
    }

    protected abstract bool IsRootDocument(Document document);

    protected virtual bool HasDiscriminator(BaseTypeDeclarationSyntax node, [MaybeNullWhen(false)] out HashSet<string> identifiers)
    {
        identifiers = null;
        // only class models will have discriminators
        if (node is ClassDeclarationSyntax classDeclaration)
        {
            if (classDeclaration.HasLeadingTrivia)
            {
                var syntaxTriviaList = classDeclaration.GetLeadingTrivia();
                var filteredTriviaList = syntaxTriviaList.Where(syntaxTrivia => ObjectType.DiscriminatorDescFixedPart.All(syntaxTrivia.ToFullString().Contains));
                if (filteredTriviaList.Count() == 1)
                {
                    var descendantNodes = filteredTriviaList.First().GetStructure()?.DescendantNodes().ToList();
                    var filteredDescendantNodes = FilterTriviaWithDiscriminator(descendantNodes);
                    var identifierNodes = filteredDescendantNodes.SelectMany(node => node.DescendantNodes().OfType<XmlCrefAttributeSyntax>());
                    identifiers = identifierNodes.Select(identifier => identifier.Cref.ToFullString()).ToHashSet();
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
}
