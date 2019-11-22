// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.V3.Plugins.PostGen
{
    internal class QualifiedNamesRewriter : CSharpSyntaxRewriter
    {
        private readonly HashSet<string> _leftOfNames = new HashSet<string>();
        private readonly HashSet<string> _fullNames = new HashSet<string>();

        public string[] GetNames(SyntaxNode node)
        {
            _leftOfNames.Clear();
            _fullNames.Clear();
            Visit(node);
            return _leftOfNames.Where(l => _fullNames.Contains(l)).ToArray();
        }

        public override SyntaxNode VisitQualifiedName(QualifiedNameSyntax node)
        {
            _leftOfNames.Add(node.Left.ToString());
            _fullNames.Add(node.ToString());
            return base.VisitQualifiedName(node);
        }
    }
}
