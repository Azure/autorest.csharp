// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.Generation.Writers
{
    public class SamplesFormattingSyntaxRewriter : CSharpSyntaxRewriter
    {
        private static readonly SyntaxAnnotation HasLeadingLineBreak = new(nameof(HasLeadingLineBreak));
        private static readonly CSharpSyntaxRewriter Instance = new SamplesFormattingSyntaxRewriter();
        private static readonly CSharpSyntaxRewriter AnnotatingVisitor = new AnnotatingSyntaxVisitor();

        public static string FormatFile(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = Instance.Visit(syntaxTree.GetRoot());
            return root.GetText().ToString();
        }

        public static string FormatCodeBlock(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code, options: CSharpParseOptions.Default.WithKind(SourceCodeKind.Script));
            var root = Instance.Visit(AnnotatingVisitor.Visit(syntaxTree.GetRoot()));
            return root.GetText().ToString();
        }

        private class AnnotatingSyntaxVisitor : CSharpSyntaxRewriter
        {
            public override SyntaxNode? Visit(SyntaxNode? node)
            {
                if (node is not null && node.GetLeadingTrivia().Any(SyntaxKind.EndOfLineTrivia))
                {
                    node = node.WithAdditionalAnnotations(HasLeadingLineBreak);
                }

                return base.Visit(node);
            }
        }

        public override SyntaxNode? Visit(SyntaxNode? node)
        {
            node = base.Visit(node);
            if (node is not null && node.GetAnnotations(nameof(HasLeadingLineBreak)).Any() && !node.GetLeadingTrivia().Any(SyntaxKind.EndOfLineTrivia))
            {
                return node.WithLeadingTrivia(SyntaxFactory.CarriageReturnLineFeed);
            }
            return node;
        }

        public override SyntaxNode? VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            var parentLeadingTrivia = GetParentLeadingTrivia(node);

            node = node
                .WithInitializers(SyntaxFactory.SeparatedList<AnonymousObjectMemberDeclaratorSyntax>(FixInitializerTrivia(node.Initializers.GetWithSeparators(), parentLeadingTrivia)))
                .WithOpenBraceToken(FixOpenBraceTrivia(node.OpenBraceToken, node.Initializers.Any()))
                .WithCloseBraceToken(FixCloseBraceTrivia(node.CloseBraceToken, parentLeadingTrivia));

            return base.VisitAnonymousObjectCreationExpression(node);
        }

        public override SyntaxNode? VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            var parentLeadingTrivia = GetParentLeadingTrivia(node);
            var initializer = node.Initializer;

            node = node
                .WithNewKeyword(node.NewKeyword.WithTrailingTrivia(SyntaxTriviaList.Empty))
                .WithCloseBracketToken(node.CloseBracketToken.WithTrailingTrivia(SyntaxTriviaList.Empty))
                .WithInitializer(initializer
                    .WithExpressions(SyntaxFactory.SeparatedList<ExpressionSyntax>(FixInitializerTrivia(initializer.Expressions.GetWithSeparators(), parentLeadingTrivia)))
                    .WithOpenBraceToken(FixOpenBraceTrivia(initializer.OpenBraceToken, initializer.Expressions.Any()))
                    .WithCloseBraceToken(FixCloseBraceTrivia(initializer.CloseBraceToken, parentLeadingTrivia)));

            return base.VisitImplicitArrayCreationExpression(node);
        }

        private static SyntaxTriviaList GetParentLeadingTrivia(SyntaxNode node)
        {
            while (node.Parent != null)
            {
                node = node.Parent;
                switch (node) {
                    case AnonymousObjectCreationExpressionSyntax objectCreation when objectCreation.Initializers.Any():
                        return objectCreation.Initializers.First().GetLeadingTrivia();
                    case ImplicitArrayCreationExpressionSyntax arrayCreation when arrayCreation.Initializer.Expressions.Any():
                        return arrayCreation.Initializer.Expressions.First().GetLeadingTrivia();
                }
            }

            return SyntaxTriviaList.Empty;
        }

        private static IEnumerable<SyntaxNodeOrToken> FixInitializerTrivia(SyntaxNodeOrTokenList nodesOrToken, SyntaxTriviaList leadingTrivia)
        {
            for (int i = 0; i < nodesOrToken.Count; i++)
            {
                var nodeOrToken = nodesOrToken[i];
                if (nodeOrToken.IsNode)
                {
                    nodeOrToken = nodeOrToken.WithLeadingTrivia(nodeOrToken.GetLeadingTrivia().AddRange(leadingTrivia).Add(SyntaxFactory.Whitespace("    ")));
                }

                if (!nodeOrToken.IsNode || i == nodesOrToken.Count - 1)
                {
                    nodeOrToken = nodeOrToken.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed);
                }

                yield return nodeOrToken;
            }
        }

        private static SyntaxToken FixOpenBraceTrivia(SyntaxToken openBraceToken, bool hasInnerTokens)
        {
            openBraceToken = openBraceToken
                .WithoutAnnotations(HasLeadingLineBreak)
                .WithLeadingTrivia(SyntaxFactory.Space);
            return hasInnerTokens
                ? openBraceToken.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed)
                : openBraceToken.WithTrailingTrivia(SyntaxTriviaList.Empty);
        }

        private static SyntaxToken FixCloseBraceTrivia(SyntaxToken closeBraceToken, SyntaxTriviaList leadingTrivia)
            => closeBraceToken.WithLeadingTrivia(leadingTrivia).WithTrailingTrivia(SyntaxTriviaList.Empty);
    }
}
