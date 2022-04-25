﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.CodeAnalysis.Simplification;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal static class Remover
    {
        public static async Task<Project> RemoveUnusedAsync(Project project, ImmutableHashSet<string> modelsToKeep)
        {
            var compilation = await project.GetCompilationAsync();
            if (compilation == null)
                return project;

            // find all the declarations, including non-public declared
            var definitions = await GetModels(project, false);
            // build reference map
            var referenceMap = await BuildReferenceMap(compilation, project, definitions);
            // get root nodes
            var rootNodes = await Internalizer.GetRootNodes(project, modelsToKeep, false);
            // traverse the map to determine the declarations that we are about to remove, starting from root nodes
            var referencedDefinitions = TraverseAllModelsAsync(rootNodes, referenceMap);
            // remove those declarations one by one
            var unusedModels = new HashSet<BaseTypeDeclarationSyntax>(definitions);
            foreach (var model in referencedDefinitions)
            {
                unusedModels.Remove(model);
            }
            // remove them one by one
            project = await RemoveModels(project, unusedModels);

            return project;
        }

        private static async Task<Project> RemoveModels(Project project, IEnumerable<BaseTypeDeclarationSyntax> unusedModels)
        {
            var documents = new Dictionary<Document, HashSet<BaseTypeDeclarationSyntax>>();
            foreach (var model in unusedModels)
            {
                var document = project.GetDocument(model.SyntaxTree);
                Debug.Assert(document != null);
                if (!documents.ContainsKey(document))
                    documents.Add(document, new HashSet<BaseTypeDeclarationSyntax>());

                documents[document].Add(model);
            }

            // TODO -- remove the models by document one by one
            // TODO -- fix, two removals are not taking effect
            foreach ((var document, var models) in documents)
            {
                var root = await document.GetSyntaxRootAsync();
                Debug.Assert(root != null);
                var newRoot = root.RemoveNodes(models, SyntaxRemoveOptions.KeepNoTrivia);
                if (newRoot != null)
                    project = document.WithSyntaxRoot(newRoot!).Project;
                else
                    project = project.RemoveDocument(document.Id);
            }

            return project;
        }

        private static IEnumerable<BaseTypeDeclarationSyntax> TraverseAllModelsAsync(IEnumerable<BaseTypeDeclarationSyntax> rootNodes, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> referenceMap)
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

        /// <summary>
        /// This method returns a dictionary from a declaration of class, struct and enum, to the declarations that are referenced in this declaration
        /// </summary>
        /// <param name="compilation"></param>
        /// <param name="project"></param>
        /// <param name="definitions"></param>
        /// <returns></returns>
        private static async Task<Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>>> BuildReferenceMap(Compilation compilation, Project project, IEnumerable<BaseTypeDeclarationSyntax> definitions)
        {
            var references = new Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>>();
            foreach (var definition in definitions)
            {
                var semanticModel = compilation.GetSemanticModel(definition.SyntaxTree);
                var symbol = semanticModel.GetDeclaredSymbol(definition);
                if (symbol == null)
                    continue;

                foreach (var reference in await SymbolFinder.FindReferencesAsync(symbol, project.Solution))
                {
                    foreach (var location in reference.Locations)
                    {
                        var document = location.Document;
                        var root = await document.GetSyntaxRootAsync();
                        if (root == null)
                            continue;
                        // get the node of this reference
                        var node = root.FindNode(location.Location.SourceSpan);
                        var owner = GetOwner(root, node);
                        if (!references.ContainsKey(owner))
                            references.Add(owner, new HashSet<BaseTypeDeclarationSyntax>());
                        references[owner].Add(definition);
                    }
                }
            }

            return references;
        }

        /// <summary>
        /// Returns the node that defines <paramref name="node"/> inside the document under the syntax root of <paramref name="root"/>, which should be <see cref="ClassDeclarationSyntax"/>, <see cref="StructDeclarationSyntax"/> or <see cref="EnumDeclarationSyntax"/>
        /// The <paramref name="node"/> here should come from the result of <see cref="SymbolFinder"/>, therefore a result is guaranteed
        /// </summary>
        /// <param name="root"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private static BaseTypeDeclarationSyntax GetOwner(SyntaxNode root, SyntaxNode node)
        {
            var candidates = root.DescendantNodes().OfType<BaseTypeDeclarationSyntax>();
            var result = candidates.First(candidate => candidate.DescendantNodesAndSelf().Contains(node));
            return result;
        }

        private static async Task<ImmutableHashSet<BaseTypeDeclarationSyntax>> GetModels(Project project, bool publicOnly)
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
    }
}
