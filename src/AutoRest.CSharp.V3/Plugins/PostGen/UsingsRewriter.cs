// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.V3.Plugins.PostGen
{
    //TODO: INCOMPLETE
    internal class UsingsRewriter : CSharpSyntaxRewriter
    {
        private static readonly SyntaxTrivia LeadingTrivia = SyntaxFactory.SyntaxTrivia(SyntaxKind.WhitespaceTrivia, "    ");
        private static readonly SyntaxTrivia TrailingTrivia = SyntaxFactory.SyntaxTrivia(SyntaxKind.WhitespaceTrivia, "\r\n");

        private readonly IEnumerable<string> _namespaces;

        public UsingsRewriter(IEnumerable<string> namespaces)
        {
            _namespaces = namespaces;
        }

        public override SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            var usings = _namespaces.Select(ns => SyntaxFactory
                .UsingDirective(SyntaxFactory.ParseName($" {ns}"))
                .WithLeadingTrivia(LeadingTrivia)
                .WithTrailingTrivia(TrailingTrivia));

            //if(node.Name is QualifiedNameSyntax name)
            //{
            //    var currentUsings = new List<string>();
            //    var currentNode = name;
            //    while(true)
            //    {
            //        currentUsings.Add(name.ToString());
            //        if(!(name?.Left is QualifiedNameSyntax left)) break;
            //        currentNode = left;
            //    }
            //    usings = usings.Where(uName => !currentUsings.Contains(uName.Name.ToString()));
            //}

            var currentUsings = new List<string>();
            var currentNode = node.Name;
            while (currentNode is QualifiedNameSyntax name)
            {
                currentUsings.Add(name.ToString());
                currentNode = name.Left;
            }
            return base.VisitNamespaceDeclaration(node
                .AddUsings(usings.Where(u => !currentUsings.Contains(u.Name.ToString())).ToArray())
                .WithUsings(Sort(node.Usings)));
        }

        private static readonly IEqualityComparer<UsingDirectiveSyntax> UsingDirectiveSyntaxComparer =
            EqualityComparerFactory.Create<UsingDirectiveSyntax>(uds => uds.Name.ToString().GetHashCode(), (uds1, uds2) => uds1.Name.ToString().Equals(uds2.Name.ToString()));
        public static SyntaxList<UsingDirectiveSyntax> Sort(SyntaxList<UsingDirectiveSyntax> directives) =>
            SyntaxFactory.List(
                directives.
                    OrderBy(x => x.StaticKeyword.IsKind(SyntaxKind.StaticKeyword) ? 1 : x.Alias == null ? 0 : 2).
                    ThenBy(x => x.Alias?.ToString()).
                    ThenBy(x => x.Name.ToString())
                    .Distinct(UsingDirectiveSyntaxComparer));
    }
}