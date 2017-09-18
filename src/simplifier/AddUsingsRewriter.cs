// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using AutoRest.Core.Utilities;
#pragma warning disable CS3009 // Base type is not CLS-compliant
#pragma warning disable CS3001
#pragma warning disable CS3002
#pragma warning disable CS3008

namespace AutoRest.Simplify
{
    public class AddUsingsRewriter : CSharpSyntaxRewriter
    {
        private static readonly SyntaxTrivia _leadingTrivia = SyntaxFactory.SyntaxTrivia(SyntaxKind.WhitespaceTrivia, "    ");
        private static readonly SyntaxTrivia _trailingTrivia = SyntaxFactory.SyntaxTrivia(SyntaxKind.WhitespaceTrivia, "\r\n");

        public IEnumerable<string> _namespaces;

        public AddUsingsRewriter(IEnumerable<string> namespaces)
        {
            _namespaces = namespaces;
        }

        /// <summary>Called when the visitor visits a NamespaceDeclarationSyntax node.</summary>
        public override SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            var u = _namespaces.Select(each => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName($" {each}"))
                .WithLeadingTrivia(_leadingTrivia)
                .WithTrailingTrivia(_trailingTrivia)
            );
            

            if(node.Name!=null)
            {
                var currUsings = new List<string>();
                var currNode = ((QualifiedNameSyntax)node.Name);
                
                while(true)
                {
                    currUsings.Add(currNode.ToString());
                    if(currNode.Left ==null || currNode.Left.GetType().Name!="QualifiedNameSyntax")
                    {
                        break;
                    }
                    currNode = (QualifiedNameSyntax)currNode.Left;
                }
                u = u.Where(uName =>!currUsings.Contains(uName.Name.ToString()));
            }
            node = node.AddUsings(u.ToArray());
            node = node.WithUsings(Sort(node.Usings));
            return base.VisitNamespaceDeclaration(node);
        }


        internal static SyntaxList<UsingDirectiveSyntax> Sort(SyntaxList<UsingDirectiveSyntax> directives) =>
            SyntaxFactory.List(
                directives.
                    OrderBy(x => x.StaticKeyword.IsKind(SyntaxKind.StaticKeyword) ? 1 : x.Alias == null ? 0 : 2).
                    ThenBy(x => x.Alias?.ToString()).
                    ThenBy(x => x.Name.ToString())
                    .Distinct(new AutoRest.Core.Utilities.EqualityComparer<UsingDirectiveSyntax>((a, b) => a.Name.ToString() == b.Name.ToString(), a=> 0 )));
    }
}