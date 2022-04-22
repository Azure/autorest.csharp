// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;

namespace AutoRest.CSharp.Common.AutoRest.Plugins
{
    internal static class Remover
    {
        public static async Task<Project> RemoveUnusedAsync(Project project)
        {
            var compilation = await project.GetCompilationAsync();
            if (compilation == null)
                return project;

            // find all the declarations, including non-public declared
            var definitions = await Internalizer.GetModels(project, false);
            // build reference map
            var referenceMap = await BuildReferenceMap(compilation, project, definitions);
            // traverse the map to determine the declarations that we are about to remove
            // TODO
            // remove those declarations one by one
            // TODO

            return project;
        }

        private static async Task<Dictionary<BaseTypeDeclarationSyntax, List<Document>>> BuildReferenceMap(Compilation compilation, Project project, IEnumerable<BaseTypeDeclarationSyntax> definitions)
        {
            var references = new Dictionary<BaseTypeDeclarationSyntax, List<Document>>();
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
                        if (!references.ContainsKey(definition))
                            references.Add(definition, new List<Document>());
                        references[definition].Add(location.Document);
                    }
                }
            }

            // TODO -- we need to reverse this dictionary to make things easier to travese
            return references;
        }
    }
}
