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
        private readonly SemanticModel _semanticModel;
        private readonly Dictionary<INamedTypeSymbol, HashSet<string>> _suppressionCache;
        private readonly INamedTypeSymbol _suppressAttribute;

        private static readonly SymbolDisplayFormat SymbolDisplayFormat = new SymbolDisplayFormat(
            SymbolDisplayGlobalNamespaceStyle.Omitted,
            SymbolDisplayTypeQualificationStyle.NameOnly,
            SymbolDisplayGenericsOptions.None,
            SymbolDisplayMemberOptions.IncludeParameters,
            SymbolDisplayDelegateStyle.NameOnly,
            SymbolDisplayExtensionMethodStyle.StaticMethod,
            SymbolDisplayParameterOptions.IncludeType);

        public MemberRemoverRewriter(SemanticModel semanticModel)
        {
            _semanticModel = semanticModel;
            _suppressionCache = new Dictionary<INamedTypeSymbol, HashSet<string>>();
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

        private HashSet<string>? GetSupressions(INamedTypeSymbol namedTypeSymbol)
        {
            if (_suppressionCache.TryGetValue(namedTypeSymbol, out var suppressions))
            {
                return suppressions;
            }

            foreach (var attributeData in namedTypeSymbol.GetAttributes())
            {
                if (attributeData.AttributeClass.Equals(_suppressAttribute))
                {
                    suppressions ??= new HashSet<string>();
                    var name = attributeData.ConstructorArguments.Single().Value as string;
                    suppressions.Add(name!);
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

                var suppressions = GetSupressions(symbol.ContainingType);

                if (suppressions != null)
                {
                    var name = symbol is IMethodSymbol ? symbol.ToDisplayString(SymbolDisplayFormat) : symbol.Name;
                    if (suppressions.Contains(name))
                    {
                        return true;
                    }
                }

                while (containingType != null)
                {
                    var members = containingType.GetMembers(symbol.Name);
                    foreach (var member in members)
                    {
                        if (!member.Equals(symbol) &&
                            member.DeclaringSyntaxReferences.Any())
                        {
                            if (symbol is IMethodSymbol methodSymbol &&
                                member is IMethodSymbol memberMethodSymbol &&
                                !methodSymbol.Parameters.SequenceEqual(memberMethodSymbol.Parameters, (s1, s2) => s1.Type.Equals(s2.Type)))
                            {
                                continue;
                            }

                            return true;
                        }
                    }

                    containingType = containingType.BaseType;
                }
            }

            return false;
        }
    }
}