// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
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

        private readonly Func<HashSet<INamedTypeSymbol>> _symbolSetInitializer = () => new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);
        private readonly Compilation _compilation;
        private readonly Project _project;
        private readonly HasDiscriminatorDelegate _hasDiscriminatorFunc;

        public ReferenceMapBuilder(Compilation compilation, Project project, HasDiscriminatorDelegate hasDiscriminatorFunc)
        {
            _compilation = compilation;
            _project = project;
            _hasDiscriminatorFunc = hasDiscriminatorFunc;
        }

        public async Task<Dictionary<INamedTypeSymbol, HashSet<INamedTypeSymbol>>> BuildPublicReferenceMapAsync(IEnumerable<INamedTypeSymbol> definitions, Dictionary<INamedTypeSymbol, HashSet<BaseTypeDeclarationSyntax>> nodeCache)
        {
            var references = new Dictionary<INamedTypeSymbol, HashSet<INamedTypeSymbol>>(SymbolEqualityComparer.Default);
            foreach (var definition in definitions)
            {
                await ProcessPublicSymbolAsync(definition, references, nodeCache);
            }

            return references;
        }

        public async Task<Dictionary<INamedTypeSymbol, HashSet<INamedTypeSymbol>>> BuildAllReferenceMapAsync(IEnumerable<INamedTypeSymbol> definitions, Dictionary<Document, HashSet<INamedTypeSymbol>> documentCache)
        {
            var references = new Dictionary<INamedTypeSymbol, HashSet<INamedTypeSymbol>>(SymbolEqualityComparer.Default);
            foreach (var definition in definitions)
            {
                await ProcessSymbolAsync(definition, references, documentCache);
            }

            return references;
        }

        private async Task ProcessPublicSymbolAsync(INamedTypeSymbol symbol, Dictionary<INamedTypeSymbol, HashSet<INamedTypeSymbol>> references, Dictionary<INamedTypeSymbol, HashSet<BaseTypeDeclarationSyntax>> cache)
        {
            // process myself, adding base and generic arguments
            AddTypeSymbol(symbol, symbol, references);

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
                            AddTypeSymbol(symbol, derivedTypeSymbol, references);
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
                        AddMethodSymbol(symbol, methodSymbol, references);
                        break;
                    case IPropertySymbol propertySymbol:
                        AddTypeSymbol(symbol, propertySymbol.Type, references);
                        break;
                    case IFieldSymbol fieldSymbol:
                        AddTypeSymbol(symbol, fieldSymbol.Type, references);
                        break;
                    default:
                        throw new InvalidOperationException("This should never happen");
                }
            }
        }

        private async Task ProcessSymbolAsync(INamedTypeSymbol symbol, Dictionary<INamedTypeSymbol, HashSet<INamedTypeSymbol>> references, Dictionary<Document, HashSet<INamedTypeSymbol>> documentCache)
        {
            foreach (var reference in await SymbolFinder.FindReferencesAsync(symbol, _project.Solution))
            {
                foreach (var location in reference.Locations)
                {
                    var document = location.Document;
                    var candicateReferenceeSymbols = documentCache[document];
                    if (candicateReferenceeSymbols.Count == 1)
                    {
                        references.AddInList(candicateReferenceeSymbols.Single(), symbol, _symbolSetInitializer);
                    }
                    else
                    {
                        // fallback to calculate the symbol when the document contains multiple type symbols
                        // this should never happen in the generated code
                        // customized code might have this issue
                        var root = await document.GetSyntaxRootAsync();
                        if (root == null)
                            continue;
                        // TODO -- this needs simplification
                        // get the node of this reference
                        var node = root.FindNode(location.Location.SourceSpan);
                        var owner = GetOwner(root, node);
                        var semanticModel = _compilation.GetSemanticModel(owner.SyntaxTree);
                        var ownerSymbol = semanticModel.GetDeclaredSymbol(owner);

                        if (ownerSymbol == null)
                            continue;
                        // add it to the map
                        references.AddInList(ownerSymbol, symbol, _symbolSetInitializer);
                    }
                }
            }

            // static class can have direct references, like ClassName.Method, but the extension methods might not have direct reference to the class itself
            // therefore here we find the references of all its members and add them to the reference map
            ProcessExtensionSymbol(symbol, references);
        }

        private void ProcessExtensionSymbol(INamedTypeSymbol extensionClassSymbol, Dictionary<INamedTypeSymbol, HashSet<INamedTypeSymbol>> references)
        {
            if (!extensionClassSymbol.IsStatic)
                return;

            foreach (var member in extensionClassSymbol.GetMembers())
            {
                if (member is not IMethodSymbol methodSymbol)
                    continue;

                if (!methodSymbol.IsExtensionMethod)
                    continue;

                // we only find the methods and find if it has "this" parameter
                var firstParameter = methodSymbol.Parameters.FirstOrDefault();
                if (firstParameter == null)
                    continue;

                AddTypeSymbol(firstParameter.Type, extensionClassSymbol, references);
            }
        }

        private void AddTypeSymbol(ITypeSymbol keySymbol, ITypeSymbol typeSymbol, Dictionary<INamedTypeSymbol, HashSet<INamedTypeSymbol>> references)
        {
            if (keySymbol is not INamedTypeSymbol keyTypeSymbol)
                return;
            // add the class and all its partial classes to the map
            // this will make all the partial classes are referencing each other in the reference map
            // when we make the travesal over the reference map, we will not only remove one of the partial class, instead we will either keep all the partial classes (if at least one of them has references), or remove all of them (if none of them has references)
            AddToReferenceMap(keyTypeSymbol, typeSymbol, references);
            // add the base type
            AddToReferenceMap(keyTypeSymbol, typeSymbol.BaseType, references);
            if (typeSymbol is INamedTypeSymbol namedType)
            {
                // add the generic type arguments
                foreach (var typeArgument in namedType.TypeArguments)
                {
                    AddToReferenceMap(keyTypeSymbol, typeArgument, references);
                }
            }
        }

        private void AddMethodSymbol(INamedTypeSymbol keySymbol, IMethodSymbol methodSymbol, Dictionary<INamedTypeSymbol, HashSet<INamedTypeSymbol>> references)
        {
            // add the return type
            AddTypeSymbol(keySymbol, methodSymbol.ReturnType, references);
            // add the parameters
            foreach (var parameter in methodSymbol.Parameters)
            {
                AddTypeSymbol(keySymbol, parameter.Type, references);
            }
        }

        private void AddToReferenceMap(INamedTypeSymbol keySymbol, ISymbol? valueSymbol, Dictionary<INamedTypeSymbol, HashSet<INamedTypeSymbol>> references)
        {
            if (valueSymbol is not INamedTypeSymbol valueTypeSymbol)
                return;

            references.AddInList(keySymbol, valueTypeSymbol, _symbolSetInitializer);
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
