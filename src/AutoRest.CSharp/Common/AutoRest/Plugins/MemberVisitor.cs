// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.Common.AutoRest.Plugins
{
    internal class MemberVisitor : CSharpSyntaxRewriter
    {
        private List<SyntaxNode> _members = new();

        public IEnumerable<SyntaxNode> PublicMembers => _members;

        private Func<SyntaxTokenList, bool> _predicate;

        public MemberVisitor(bool publicOnly)
        {
            _predicate = publicOnly ? IsPublic : _ => true;
        }

        public override SyntaxNode? VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            node = (ClassDeclarationSyntax)base.VisitClassDeclaration(node)!;
            if (_predicate(node.Modifiers))
            {
                _members.Add(node);
            }
            return node;
        }

        public override SyntaxNode? VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            node = (PropertyDeclarationSyntax)base.VisitPropertyDeclaration(node)!;
            if (_predicate(node.Modifiers))
            {
                _members.Add(node);
            }
            return node;
        }

        public override SyntaxNode? VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            node = (MethodDeclarationSyntax)base.VisitMethodDeclaration(node)!;
            if (_predicate(node.Modifiers))
                _members.Add(node);
            return node;
        }

        public override SyntaxNode? VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
        {
            node = (ConstructorDeclarationSyntax)base.VisitConstructorDeclaration(node)!;
            if (_predicate(node.Modifiers))
                _members.Add(node);
            return node;
        }

        private static bool IsPublic(SyntaxTokenList tokenList)
            => tokenList.Any(token => token.IsKind(SyntaxKind.PublicKeyword));
    }
}
