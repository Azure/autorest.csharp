// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
{
#pragma warning disable RS1024
    internal class MemberRemoverRewriter : CSharpSyntaxRewriter
    {
        private readonly Project _project;
        private readonly SemanticModel _semanticModel;
        private readonly Dictionary<INamedTypeSymbol, List<Supression>> _suppressionCache;
        private readonly INamedTypeSymbol _suppressAttribute;

        public MemberRemoverRewriter(Project project, SemanticModel semanticModel)
        {
            _project = project;
            _semanticModel = semanticModel;
            _suppressionCache = new Dictionary<INamedTypeSymbol, List<Supression>>();
            _suppressAttribute = semanticModel.Compilation.GetTypeByMetadataName(typeof(CodeGenSuppressAttribute).FullName!)!;
        }

        public override SyntaxNode? VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
        {
            var symbol = _semanticModel.GetDeclaredSymbol(node);

            return ShouldRemove(symbol) ? null : base.VisitConstructorDeclaration(node);
        }

        public override SyntaxNode? VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            var symbol = _semanticModel.GetDeclaredSymbol(node);

            return ShouldRemove(symbol) ? null : base.VisitPropertyDeclaration(node);
        }

        public override SyntaxNode? VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var symbol = _semanticModel.GetDeclaredSymbol(node);

            return ShouldRemove(symbol) ? null : base.VisitMethodDeclaration(node);
        }

        public override SyntaxNode? VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            var symbol = _semanticModel.GetDeclaredSymbol(node);

            return ShouldRemove(symbol) ? null : base.VisitFieldDeclaration(node);
        }

        private List<Supression>? GetSupressions(INamedTypeSymbol namedTypeSymbol)
        {
            if (_suppressionCache.TryGetValue(namedTypeSymbol, out var suppressions))
            {
                return suppressions;
            }

            foreach (var attributeData in namedTypeSymbol.GetAttributes())
            {
                if (attributeData.AttributeClass?.Equals(_suppressAttribute) == true)
                {
                    suppressions ??= new List<Supression>();
                    var name = attributeData.ConstructorArguments[0].Value as string;
                    var parameterTypes = attributeData.ConstructorArguments[1].Values.Select(v => (ISymbol?)v.Value).ToArray();
                    suppressions.Add(new Supression(name, parameterTypes));
                }
            }

            if (suppressions != null)
            {
                _suppressionCache.Add(namedTypeSymbol, suppressions);
            }
            return suppressions;
        }

        private bool ShouldRemove(ISymbol? symbol)
        {
            if (symbol != null)
            {
                INamedTypeSymbol? containingType = symbol.ContainingType;
                IMethodSymbol? methodSymbol = symbol as IMethodSymbol;

                var suppressions = GetSupressions(symbol.ContainingType);
                if (suppressions != null)
                {
                    foreach (var suppression in suppressions)
                    {
                        if (suppression.Matches(symbol))
                        {
                            return true;
                        }
                    }
                }

                while (containingType != null)
                {
                    var members = containingType.GetMembers(symbol.Name);
                    foreach (var member in members)
                    {
                        if (!member.Equals(symbol) &&
                            IsDeclaredInNonGeneratedCode(member))
                        {
                            if (methodSymbol != null &&
                                member is IMethodSymbol memberMethodSymbol &&
                                !methodSymbol.Parameters.SequenceEqual(memberMethodSymbol.Parameters, (s1, s2) => s1.Type.Equals(s2.Type)))
                            {
                                continue;
                            }

                            return true;
                        }
                    }

                    // Skip traversing parents for constructors and explicit interface implementations
                    if (methodSymbol != null &&
                        (methodSymbol.MethodKind == MethodKind.Constructor ||
                         !methodSymbol.ExplicitInterfaceImplementations.IsEmpty))
                    {
                        break;
                    }
                    containingType = containingType.BaseType;
                }
            }

            return false;
        }

        private bool IsDeclaredInNonGeneratedCode(ISymbol member)
        {
            var references = member.DeclaringSyntaxReferences;

            if (references.Length == 0)
            {
                return false;
            }

            foreach (var reference in references)
            {
                Document? document = _project.GetDocument(reference.SyntaxTree);

                if (document != null && GeneratedCodeWorkspace.IsGeneratedDocument(document))
                {
                    return false;
                }
            }

            return true;
        }

        private readonly struct Supression
        {
            private readonly string? _name;
            private readonly ISymbol?[] _types;

            public Supression(string? name, ISymbol?[] types)
            {
                _name = name;
                _types = types;
            }

            public bool Matches(ISymbol symbol)
            {
                if (symbol is IMethodSymbol methodSymbol)
                {
                    string name = methodSymbol.Name;
                    // Use friendly name for ctors
                    if (methodSymbol.MethodKind == MethodKind.Constructor)
                    {
                        name = methodSymbol.ContainingType.Name;
                    }

                    return  _name == name &&
                            _types.SequenceEqual(methodSymbol.Parameters.Select(p => p.Type), SymbolEqualityComparer.Default);
                }
                else
                {
                    return symbol.Name == _name;
                }
            }
        }
    }
}