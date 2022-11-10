// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Simplification;

namespace AutoRest.CSharp.Common.Output.PostProcessing;

internal abstract class PostProcessor
{
    protected Project project;

    public PostProcessor(Project project)
    {
        this.project = project;
    }

    protected virtual async Task<HashSet<BaseTypeDeclarationSyntax>> GetModels(bool publicOnly = true)
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

    public async Task<Project> InternalizeAsync()
    {
        // first get all the declared models
        var definitions = await GetModels(true);
        // build the reference map
        var referenceMapBuilder = new ReferenceMapBuilder(project, HasDiscriminator);
        var referenceMap = await referenceMapBuilder.BuildPublicReferenceMapAsync(definitions);
        // get the root nodes
        var rootNodes = await GetRootNodes(true);
        // traverse all the root and recursively add all the things we met
        var publicModels = TraverseModelsAsync(rootNodes, referenceMap);

        foreach (var model in publicModels)
        {
            definitions.Remove(model);
        }

        // get the models we need to mark internal
        foreach (var model in definitions)
        {
            MarkInternal(model);
        }

        return project;
    }

    public async Task<Project> RemoveAsync()
    {
        // find all the declarations, including non-public declared
        var definitions = await GetModels(false);
        // build reference map
        var referenceMapBuilder = new ReferenceMapBuilder(project, HasDiscriminator);
        var referenceMap = await referenceMapBuilder.BuildAllReferenceMapAsync(definitions);
        // get root nodes
        var rootNodes = await GetRootNodes(false);
        // traverse the map to determine the declarations that we are about to remove, starting from root nodes
        var referencedDefinitions = TraverseModelsAsync(rootNodes, referenceMap);
        // remove those declarations one by one
        foreach (var model in referencedDefinitions)
        {
            definitions.Remove(model);
        }
        // remove them one by one
        await RemoveModelsAsync(definitions);

        return project;
    }

    private static IEnumerable<BaseTypeDeclarationSyntax> TraverseModelsAsync(IEnumerable<BaseTypeDeclarationSyntax> rootNodes, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> referenceMap)
    {
        var queue = new Queue<BaseTypeDeclarationSyntax>(rootNodes);
        var visited = new HashSet<BaseTypeDeclarationSyntax>();
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

    private static IEnumerable<BaseTypeDeclarationSyntax> GetReferencedTypes(BaseTypeDeclarationSyntax definition, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> referenceMap)
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
        var document = project.GetDocument(tree)!;
        var newRoot = tree.GetRoot().ReplaceNode(declarationNode, newNode).WithAdditionalAnnotations(Simplifier.Annotation);
        document = document.WithSyntaxRoot(newRoot);
        project = document.Project;
    }

    private async Task<Project> RemoveModelsAsync(IEnumerable<BaseTypeDeclarationSyntax> unusedModels)
    {
        // accumulate the definitions from the same document together
        var documents = new Dictionary<Document, HashSet<BaseTypeDeclarationSyntax>>();
        foreach (var model in unusedModels)
        {
            var document = project.GetDocument(model.SyntaxTree);
            Debug.Assert(document != null);
            if (!documents.ContainsKey(document))
                documents.Add(document, new HashSet<BaseTypeDeclarationSyntax>());

            documents[document].Add(model);
        }

        foreach (var models in documents.Values)
        {
            project = await RemoveModelsFromDocumentAsync(models);
        }

        return project;
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
        var document = project.GetDocument(tree);
        if (document == null)
            return project;
        var root = await tree.GetRootAsync();
        root = root.RemoveNodes(models, SyntaxRemoveOptions.KeepNoTrivia);
        document = document.WithSyntaxRoot(root!);
        return document.Project;
    }

    protected abstract Task<HashSet<BaseTypeDeclarationSyntax>> GetRootNodes(bool publicOnly = true);

    protected abstract bool HasDiscriminator(BaseTypeDeclarationSyntax node, [MaybeNullWhen(false)] out HashSet<string> identifiers);
}
