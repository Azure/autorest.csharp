// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;

namespace AutoRest.CSharp.Common.Output.PostProcessing
{
    internal class ReferenceMapBuilder
    {
        internal delegate bool HasDiscriminatorDelegate(BaseTypeDeclarationSyntax node, [MaybeNullWhen(false)] out HashSet<string> identifiers);

        private static readonly Func<HashSet<INamedTypeSymbol>> _symbolSetInitializer = () => new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);
        private readonly Compilation _compilation;
        private readonly Project _project;
        private readonly HasDiscriminatorDelegate _hasDiscriminatorFunc;

        public ReferenceMapBuilder(Compilation compilation, Project project, HasDiscriminatorDelegate hasDiscriminatorFunc)
        {
            _compilation = compilation;
            _project = project;
            _hasDiscriminatorFunc = hasDiscriminatorFunc;
        }

        public async Task<ReferenceMap> BuildPublicReferenceMapAsync(IEnumerable<INamedTypeSymbol> definitions, IReadOnlyDictionary<INamedTypeSymbol, ImmutableHashSet<BaseTypeDeclarationSyntax>> nodeCache)
        {
            var referenceMap = new ReferenceMap();
            foreach (var definition in definitions)
            {
                await ProcessPublicSymbolAsync(definition, referenceMap, nodeCache);
            }

            return referenceMap;
        }

        public async Task<ReferenceMap> BuildAllReferenceMapAsync(IEnumerable<INamedTypeSymbol> definitions, IReadOnlyDictionary<Document, ImmutableHashSet<INamedTypeSymbol>> documentCache)
        {
            var referenceMap = new ReferenceMap();
            foreach (var definition in definitions)
            {
                await ProcessSymbolAsync(definition, referenceMap, documentCache);
            }

            return referenceMap;
        }

        private async Task ProcessPublicSymbolAsync(INamedTypeSymbol symbol, ReferenceMap referenceMap, IReadOnlyDictionary<INamedTypeSymbol, ImmutableHashSet<BaseTypeDeclarationSyntax>> cache)
        {
            // process myself, adding base and generic arguments
            AddTypeSymbol(symbol, symbol, referenceMap);

            // add my sibling classes
            foreach (var declaration in cache[symbol])
            {
                if (_hasDiscriminatorFunc(declaration, out var identifierCandidates))
                {
                    // first find all the derived types from this type
                    foreach (var derivedTypeSymbol in await SymbolFinder.FindDerivedClassesAsync(symbol, _project.Solution))
                    {
                        if (identifierCandidates.Contains(derivedTypeSymbol.Name))
                        {
                            AddTypeSymbol(symbol, derivedTypeSymbol, referenceMap);
                        }
                    }
                }
            }

            // go over all the members
            foreach (var member in symbol.GetMembers())
            {
                // only go through the public members
                if (member.DeclaredAccessibility != Accessibility.Public)
                    continue;

                switch (member)
                {
                    case IMethodSymbol methodSymbol:
                        ProcessMethodSymbol(symbol, methodSymbol, referenceMap);
                        break;
                    case IPropertySymbol propertySymbol:
                        ProcessPropertySymbol(symbol, propertySymbol, referenceMap);
                        break;
                    case IFieldSymbol fieldSymbol:
                        ProcessFieldSymbol(symbol, fieldSymbol, referenceMap);
                        break;
                    case IEventSymbol eventSymbol:
                        ProcessEventSymbol(symbol, eventSymbol, referenceMap);
                        break;
                    case INamedTypeSymbol innerTypeSymbol:
                        break; // do nothing for the inner types
                    default:
                        throw new InvalidOperationException($"This case has not been covered {member.GetType()}");
                }
            }
        }

        private async Task ProcessSymbolAsync(INamedTypeSymbol symbol, ReferenceMap referenceMap, IReadOnlyDictionary<Document, ImmutableHashSet<INamedTypeSymbol>> documentCache)
        {
            foreach (var reference in await SymbolFinder.FindReferencesAsync(symbol, _project.Solution))
            {
                await AddReferenceToReferenceMapAsync(symbol, reference, referenceMap, documentCache);
            }

            // static class can have direct references, like ClassName.Method, but the extension methods might not have direct reference to the class itself
            // therefore here we find the references of all its members and add them to the reference map
            await ProcessExtensionSymbol(symbol, referenceMap, documentCache);
        }

        private async Task ProcessExtensionSymbol(INamedTypeSymbol extensionClassSymbol, ReferenceMap referenceMap, IReadOnlyDictionary<Document, ImmutableHashSet<INamedTypeSymbol>> documentCache)
        {
            if (!extensionClassSymbol.IsStatic)
                return;

            foreach (var member in extensionClassSymbol.GetMembers())
            {
                if (member is not IMethodSymbol methodSymbol)
                    continue;

                if (!methodSymbol.IsExtensionMethod)
                    continue;

                // find which document is using this extension method, and add it to the map
                foreach (var reference in await SymbolFinder.FindReferencesAsync(methodSymbol, _project.Solution))
                {
                    await AddReferenceToReferenceMapAsync(extensionClassSymbol, reference, referenceMap, documentCache);
                }
            }
        }

        private async Task AddReferenceToReferenceMapAsync(INamedTypeSymbol symbol, ReferencedSymbol reference, ReferenceMap referenceMap, IReadOnlyDictionary<Document, ImmutableHashSet<INamedTypeSymbol>> documentCache)
        {
            foreach (var location in reference.Locations)
            {
                var document = location.Document;
                if (!documentCache.TryGetValue(document, out var candidateReferenceSymbols))
                    continue;

                if (candidateReferenceSymbols.Count == 1)
                {
                    referenceMap.AddInList(candidateReferenceSymbols.Single(), symbol);
                }
                else
                {
                    // fallback to calculate the symbol when the document contains multiple type symbols
                    // this should never happen in the generated code
                    // customized code might have this issue
                    var root = await document.GetSyntaxRootAsync();
                    if (root == null)
                        continue;
                    // get the node of this reference
                    var node = root.FindNode(location.Location.SourceSpan);
                    var owner = GetOwner(node);
                    if (owner == null)
                    {
                        referenceMap.AddGlobal(symbol);
                    }
                    else
                    {
                        var semanticModel = _compilation.GetSemanticModel(owner.SyntaxTree);
                        var ownerSymbol = semanticModel.GetDeclaredSymbol(owner);

                        if (ownerSymbol == null)
                            continue;
                        // add it to the map
                        referenceMap.AddInList(ownerSymbol, symbol);
                    }
                }
            }
        }

        /// <summary>
        /// This method recusively adds all related types in <paramref name="valueSymbol"/> to the reference map as the value of key <paramref name="keySymbol"/>
        /// </summary>
        /// <param name="keySymbol"></param>
        /// <param name="valueSymbol"></param>
        /// <param name="references"></param>
        private void AddTypeSymbol(ITypeSymbol keySymbol, ITypeSymbol? valueSymbol, ReferenceMap references)
        {
            if (keySymbol is not INamedTypeSymbol keyTypeSymbol)
                return;
            if (valueSymbol is not INamedTypeSymbol valueTypeSymbol)
                return;
            // add the class and all its partial classes to the map
            // this will make all the partial classes are referencing each other in the reference map
            // when we make the travesal over the reference map, we will not only remove one of the partial class, instead we will either keep all the partial classes (if at least one of them has references), or remove all of them (if none of them has references)
            references.AddInList(keyTypeSymbol, valueTypeSymbol);
            // add the base type
            AddTypeSymbol(keyTypeSymbol, valueSymbol.BaseType, references);
            if (valueSymbol is INamedTypeSymbol namedType)
            {
                // add the generic type arguments
                foreach (var typeArgument in namedType.TypeArguments)
                {
                    AddTypeSymbol(keyTypeSymbol, typeArgument, references);
                }
            }
        }

        private void ProcessMethodSymbol(INamedTypeSymbol keySymbol, IMethodSymbol methodSymbol, ReferenceMap referenceMap)
        {
            // add the return type
            AddTypeSymbol(keySymbol, methodSymbol.ReturnType, referenceMap);
            // add the parameters
            foreach (var parameter in methodSymbol.Parameters)
            {
                AddTypeSymbol(keySymbol, parameter.Type, referenceMap);
            }
        }

        private void ProcessPropertySymbol(INamedTypeSymbol keySymbol, IPropertySymbol propertySymbol, ReferenceMap references) => AddTypeSymbol(keySymbol, propertySymbol.Type, references);

        private void ProcessFieldSymbol(INamedTypeSymbol keySymbol, IFieldSymbol fieldSymbol, ReferenceMap references) => AddTypeSymbol(keySymbol, fieldSymbol.Type, references);

        private void ProcessEventSymbol(INamedTypeSymbol keySymbol, IEventSymbol eventSymbol, ReferenceMap references) => AddTypeSymbol(keySymbol, eventSymbol.Type, references);

        /// <summary>
        /// Returns the node that defines <paramref name="node"/> inside the document, which should be a <see cref="BaseTypeDeclarationSyntax"/> or null if not found
        /// There is possibility that it is used on an assembly attribute which is not enclosed by a type declaration
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static BaseTypeDeclarationSyntax? GetOwner(SyntaxNode node)
        {
            SyntaxNode? current = node;
            while (current != null)
            {
                if (current is BaseTypeDeclarationSyntax declarationNode)
                    return declarationNode;

                current = current.Parent;
            }

            return null;
        }
    }
}
