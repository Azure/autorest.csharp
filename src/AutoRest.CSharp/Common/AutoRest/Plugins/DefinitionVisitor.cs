// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class DefinitionVisitor : CSharpSyntaxRewriter
    {
        public ImmutableHashSet<BaseTypeDeclarationSyntax> ModelDeclarations { get; private set; }
        private readonly Func<SyntaxTokenList, bool> _predicate;

        public DefinitionVisitor(bool publicOnly)
        {
            ModelDeclarations = ImmutableHashSet<BaseTypeDeclarationSyntax>.Empty;
            _predicate = publicOnly ? IsPublic : _ => true;
        }

        public override SyntaxNode? VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            node = (ClassDeclarationSyntax)base.VisitClassDeclaration(node)!;
            if (_predicate(node.Modifiers))
            {
                ModelDeclarations = ModelDeclarations.Add(node);
            }

            return node;
        }

        public override SyntaxNode? VisitStructDeclaration(StructDeclarationSyntax node)
        {
            node = (StructDeclarationSyntax)base.VisitStructDeclaration(node)!;

            if (_predicate(node.Modifiers))
            {
                ModelDeclarations = ModelDeclarations.Add(node);
            }
            return node;
        }

        public override SyntaxNode? VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            node = (EnumDeclarationSyntax)base.VisitEnumDeclaration(node)!;
            if (_predicate(node.Modifiers))
            {
                ModelDeclarations = ModelDeclarations.Add(node);
            }
            return node;
        }

        private static bool IsPublic(SyntaxTokenList tokenList)
            => tokenList.Any(token => token.IsKind(SyntaxKind.PublicKeyword));
    }
}
