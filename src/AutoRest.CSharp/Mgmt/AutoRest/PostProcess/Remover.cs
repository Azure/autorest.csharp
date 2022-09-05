﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.CodeAnalysis.Simplification;

namespace AutoRest.CSharp.Mgmt.AutoRest.PostProcess
{
    internal static class Remover
    {
        public static async Task<Project> RemoveUnusedAsync(Project project, ImmutableHashSet<string> modelsToKeep)
        {
            var compilation = await project.GetCompilationAsync();
            if (compilation == null)
                return project;

            // find all the declarations, including non-public declared
            var definitions = await PostProcessCommon.GetModels(project, false);
            // build reference map
            var referenceMap = await BuildReferenceMap(compilation, project, definitions);
            // get root nodes
            var rootNodes = await PostProcessCommon.GetRootNodes(project, false, modelsToKeep);
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

        public static async Task<Project> RemoveUnusedFieldsAsync(Project project)
        {
            var compilation = await project.GetCompilationAsync();
            if (compilation == null)
                return project;

            // find all the resources and resource collections
            var definitions = await PostProcessCommon.GetClients(project);

            // get them inside a big dictionary
            var result = new List<IEnumerable<FieldDeclarationSyntax>>();
            foreach (var definition in definitions)
            {
                var semanticModel = compilation.GetSemanticModel(definition.SyntaxTree);
                var symbol = semanticModel.GetDeclaredSymbol(definition);
                if (symbol == null || symbol is not INamedTypeSymbol typeSymbol)
                    continue;

                var unusedFields = await FindUnusedFields(project, typeSymbol);

                if (unusedFields.Any())
                    result.Add(unusedFields);
            }

            // remove all of them
            project = await RemoveUnusedFieldsFromClientsAsync(project, result);

            return project;
        }

        private static async Task<IEnumerable<FieldDeclarationSyntax>> FindUnusedFields(Project project, INamedTypeSymbol typeSymbol)
        {
            var fieldsWithoutReferences = new List<FieldDeclarationSyntax>();
            // iterate over the field symbols
            foreach (var field in typeSymbol.GetMembers().OfType<IFieldSymbol>())
            {
                var references = await SymbolFinder.FindReferencesAsync(field, project.Solution);
                // we cannot simply assert the array references is empty because this is never empty. Only when the Locations inside is empty indicates this symbol is not used
                var allOcurrences = references.Sum(reference => reference.Locations.Count());
                if (allOcurrences == 0)
                {
                    foreach (var declaration in field.DeclaringSyntaxReferences)
                    {
                        // we have this layer because a field can define multiple variables hence multiple VariableDeclarators here, like
                        // private string a, b;
                        // but we never use it in our SDK. Therefore here we just iterate over all the field declarations and find which one is containing this
                        var node = await declaration.GetSyntaxAsync();
                        if (node is VariableDeclaratorSyntax variableDeclarator)
                            fieldsWithoutReferences.Add(await FindFieldDeclaration(variableDeclarator));
                    }
                }
            }

            return fieldsWithoutReferences;
        }

        private static async Task<FieldDeclarationSyntax> FindFieldDeclaration(VariableDeclaratorSyntax variableDeclaration)
        {
            var root = await variableDeclaration.SyntaxTree.GetRootAsync();
            var allFields = root.DescendantNodes().OfType<FieldDeclarationSyntax>();

            return allFields.First(field => field.Declaration.Variables.Contains(variableDeclaration));
        }

        private static async Task<Project> RemoveUnusedFieldsFromClientsAsync(Project project, List<IEnumerable<FieldDeclarationSyntax>> unusedFields)
        {
            var documents = new Dictionary<Document, HashSet<FieldDeclarationSyntax>>();
            foreach (var fields in unusedFields)
            {
                var document = project.GetDocument(fields.First().SyntaxTree);
                Debug.Assert(document != null);
                if (!documents.ContainsKey(document))
                    documents.Add(document, new HashSet<FieldDeclarationSyntax>());

                foreach (var field in fields)
                    documents[document].Add(field);
            }

            foreach (var fields in documents.Values)
            {
                project = await RemoveNodesFromDocumentAsync(project, fields);
            }

            return project;
        }

        private static async Task<Project> RemoveModels(Project project, IEnumerable<BaseTypeDeclarationSyntax> unusedModels)
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
                project = await RemoveNodesFromDocumentAsync(project, models);
            }

            return project;
        }

        private static async Task<Project> RemoveNodesFromDocumentAsync<T>(Project project, IEnumerable<T> nodes) where T : SyntaxNode
        {
            var tree = nodes.First().SyntaxTree;
            var document = project.GetDocument(tree);
            if (document == null)
                return project;
            var root = await tree.GetRootAsync();
            root = root.RemoveNodes(nodes, SyntaxRemoveOptions.KeepNoTrivia);
            document = document.WithSyntaxRoot(root!);

            return document.Project;
        }

        // TODO -- unify this method and Internalizer.TraverseAllPublicModelsAsync
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
            var visited = new HashSet<ISymbol>(SymbolEqualityComparer.Default);
            foreach (var definition in definitions)
            {
                var semanticModel = compilation.GetSemanticModel(definition.SyntaxTree);
                var symbol = semanticModel.GetDeclaredSymbol(definition);
                if (symbol == null)
                    continue;

                // add the class and all its partial classes to the map
                // this will make all the partial classes are referencing each other in the reference map
                // when we make the travesal over the reference map, we will not only remove one of the partial class, instead we will either keep all the partial classes (if at least one of them has references), or remove all of them (if none of them has references)
                foreach (var reference in symbol.DeclaringSyntaxReferences)
                {
                    var node = await reference.GetSyntaxAsync();
                    AddToReferenceMap(definition, node as BaseTypeDeclarationSyntax, references);
                }
                await ProcessSymbol(project, symbol, definition, references, visited);
            }

            return references;
        }

        private static void AddToReferenceMap(BaseTypeDeclarationSyntax key, BaseTypeDeclarationSyntax? value, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> references)
        {
            if (value == null)
                return;

            if (!references.ContainsKey(key))
                references.Add(key, new HashSet<BaseTypeDeclarationSyntax>());

            references[key].Add(value);
        }

        private static async Task ProcessSymbol(Project project, ISymbol symbol, BaseTypeDeclarationSyntax definition, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> references, HashSet<ISymbol> visited)
        {
            if (visited.Contains(symbol))
                return;

            visited.Add(symbol);

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

            // static class can have direct references, like ClassName.Method, but the extension methods might not have direct reference to the class itself
            // therefore here we find the references of all its members and add them to the reference map
            if (symbol is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.IsStatic)
            {
                var members = namedTypeSymbol.GetMembers();
                foreach (var member in members)
                {
                    await ProcessSymbol(project, member, definition, references, visited);
                }
            }
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
    }
}
