// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal static class Remover
    {
        public static async Task<Project> RemoveUnusedAsync(Project project)
        {
            var compilation = await project.GetCompilationAsync();
            if (compilation == null)
                return project;

            // find all the declarations, including non-public declared
            var definitions = await GetModels(project, false);
            // build reference map
            var referenceMap = await BuildReferenceMap(compilation, project, definitions);
            // get root nodes
            // TODO
            // traverse the map to determine the declarations that we are about to remove, starting from root nodes
            // TODO
            // remove those declarations one by one
            // TODO

            return project;
        }

        private static async Task<Dictionary<Document, HashSet<BaseTypeDeclarationSyntax>>> BuildReferenceMap(Compilation compilation, Project project, IEnumerable<BaseTypeDeclarationSyntax> definitions)
        {
            var references = new Dictionary<Document, HashSet<BaseTypeDeclarationSyntax>>();
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
                        if (!references.ContainsKey(document))
                            references.Add(document, new HashSet<BaseTypeDeclarationSyntax>());
                        references[document].Add(definition);
                    }
                }
            }

            return references;
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
