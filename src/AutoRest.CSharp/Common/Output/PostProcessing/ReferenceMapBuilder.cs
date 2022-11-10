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

        private readonly Project _project;
        private readonly HasDiscriminatorDelegate _hasDiscriminatorFunc;

        public ReferenceMapBuilder(Project project, HasDiscriminatorDelegate hasDiscriminatorFunc)
        {
            _project = project;
            _hasDiscriminatorFunc = hasDiscriminatorFunc;
        }

        private readonly Dictionary<ISymbol, HashSet<BaseTypeDeclarationSyntax>> _symbolMap = new(SymbolEqualityComparer.Default);

        public async Task<Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>>> BuildPublicReferenceMapAsync(IEnumerable<BaseTypeDeclarationSyntax> definitions)
        {
            var references = new Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>>();
            var compilation = await _project.GetCompilationAsync();
            if (compilation == null)
                return references;

            var visited = new HashSet<ISymbol>(SymbolEqualityComparer.Default);

            foreach (var definition in definitions)
            {
                var semanticModel = compilation.GetSemanticModel(definition.SyntaxTree);
                var typeSymbol = semanticModel.GetDeclaredSymbol(definition);
                if (typeSymbol == null || visited.Contains(typeSymbol))
                    continue;

                visited.Add(typeSymbol);

                // go through all the element in this type and add them into the map
                await ProcessPublicSymbolAsync(typeSymbol, references);
            }

            return references;
        }

        public async Task<Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>>> BuildAllReferenceMapAsync(IEnumerable<BaseTypeDeclarationSyntax> definitions)
        {
            var references = new Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>>();
            var compilation = await _project.GetCompilationAsync();
            if (compilation == null)
                return references;

            var visited = new HashSet<ISymbol>(SymbolEqualityComparer.Default);

            foreach (var definition in definitions)
            {
                var semanticModel = compilation.GetSemanticModel(definition.SyntaxTree);
                var typeSymbol = semanticModel.GetDeclaredSymbol(definition);
                if (typeSymbol == null || visited.Contains(typeSymbol))
                    continue;

                visited.Add(typeSymbol);

                await ProcessSymbolAsync(typeSymbol, references);
            }

            return references;
        }

        private async Task ProcessPublicSymbolAsync(INamedTypeSymbol symbol, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> references)
        {
            // process myself, adding base and generic arguments
            AddTypeSymbol(symbol, symbol, references);

            // add my sibling classes
            foreach (var declaration in GetAllDeclarations(symbol))
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

        private async Task ProcessSymbolAsync(ISymbol symbol, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> references)
        {
            foreach (var reference in await SymbolFinder.FindReferencesAsync(symbol, _project.Solution))
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
                    // put all the definition of this symbol into the reference of this "owner"
                    foreach (var declaration in GetAllDeclarations(symbol))
                        references.AddInList(owner, declaration);
                }
            }

            // static class can have direct references, like ClassName.Method, but the extension methods might not have direct reference to the class itself
            // therefore here we find the references of all its members and add them to the reference map
            ProcessExtensionSymbol(symbol, references);
        }

        private void ProcessExtensionSymbol(ISymbol symbol, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> references)
        {
            if (symbol is not INamedTypeSymbol extensionClassSymbol || !extensionClassSymbol.IsStatic)
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

        private void AddTypeSymbol(ISymbol keySymbol, ITypeSymbol typeSymbol, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> references)
        {
            // add the class and all its partial classes to the map
            // this will make all the partial classes are referencing each other in the reference map
            // when we make the travesal over the reference map, we will not only remove one of the partial class, instead we will either keep all the partial classes (if at least one of them has references), or remove all of them (if none of them has references)
            AddToReferenceMap(keySymbol, typeSymbol, references);
            // add the base type
            AddToReferenceMap(keySymbol, typeSymbol.BaseType, references);
            if (typeSymbol is INamedTypeSymbol namedType)
            {
                // add the generic type arguments
                foreach (var typeArgument in namedType.TypeArguments)
                {
                    AddToReferenceMap(keySymbol, typeArgument, references);
                }
            }
        }

        private void AddMethodSymbol(ISymbol keySymbol, IMethodSymbol methodSymbol, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> references)
        {
            // add the return type
            AddTypeSymbol(keySymbol, methodSymbol.ReturnType, references);
            // add the parameters
            foreach (var parameter in methodSymbol.Parameters)
            {
                AddTypeSymbol(keySymbol, parameter.Type, references);
            }
        }

        private void AddToReferenceMap(ISymbol keySymbol, ISymbol? valueSymbol, Dictionary<BaseTypeDeclarationSyntax, HashSet<BaseTypeDeclarationSyntax>> references)
        {
            if (valueSymbol == null)
                return;

            foreach (var keyDeclaration in GetAllDeclarations(keySymbol))
            {
                foreach (var valueDeclaration in GetAllDeclarations(valueSymbol))
                {
                    references.AddInList(keyDeclaration, valueDeclaration);
                }
            }
        }

        private HashSet<BaseTypeDeclarationSyntax> GetAllDeclarations(ISymbol symbol)
        {
            if (!_symbolMap.TryGetValue(symbol, out var result))
            {
                result = new HashSet<BaseTypeDeclarationSyntax>();
                foreach (var reference in symbol.DeclaringSyntaxReferences)
                {
                    if (reference.GetSyntax() is BaseTypeDeclarationSyntax node)
                        result.Add(node);
                }
            }

            return result;
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
