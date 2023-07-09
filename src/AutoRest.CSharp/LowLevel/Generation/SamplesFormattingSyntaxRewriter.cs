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
        private static readonly CSharpSyntaxRewriter Instance = new SamplesFormattingSyntaxRewriter();

        public static string FormatFile(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = Instance.Visit(syntaxTree.GetRoot());
            return root.GetText().ToString();
        }

        public static string FormatCodeBlock(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code, options: CSharpParseOptions.Default.WithKind(SourceCodeKind.Script));
            var root = Instance.Visit(syntaxTree.GetRoot());
            return root.GetText().ToString();
        }

        public override SyntaxNode? VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            var parentLeadingTrivia = GetParentLeadingTrivia(node);

            node = node
                .WithNewKeyword(node.NewKeyword.WithTrailingTrivia(SyntaxTriviaList.Empty))
                .WithOpenBraceToken(FixOpenBraceTrivia(node.OpenBraceToken, node.Initializers.Any()))
                .WithInitializers(SyntaxFactory.SeparatedList<AnonymousObjectMemberDeclaratorSyntax>(FixInitializerLeadingTrivia(node.Initializers.GetWithSeparators(), parentLeadingTrivia)));

            if (base.VisitAnonymousObjectCreationExpression(node) is not AnonymousObjectCreationExpressionSyntax newNode)
            {
                return null;
            }

            return newNode
                .WithInitializers(SyntaxFactory.SeparatedList<AnonymousObjectMemberDeclaratorSyntax>(FixInitializerTrailingTrivia(newNode.Initializers.GetWithSeparators(), parentLeadingTrivia)))
                .WithCloseBraceToken(FixCloseBraceTrivia(newNode.CloseBraceToken, newNode.Initializers.Any() ? parentLeadingTrivia : SyntaxTriviaList.Empty));
        }

        public override SyntaxNode? VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            var parentLeadingTrivia = GetParentLeadingTrivia(node);
            var initializer = node.Initializer;

            node = node
                .WithNewKeyword(node.NewKeyword.WithTrailingTrivia(SyntaxTriviaList.Empty))
                .WithCloseBracketToken(node.CloseBracketToken.WithTrailingTrivia(SyntaxTriviaList.Empty))
                .WithInitializer(initializer
                    .WithOpenBraceToken(FixOpenBraceTrivia(initializer.OpenBraceToken, initializer.Expressions.Any()))
                    .WithExpressions(SyntaxFactory.SeparatedList<ExpressionSyntax>(FixInitializerLeadingTrivia(initializer.Expressions.GetWithSeparators(), parentLeadingTrivia))));

            if (base.VisitImplicitArrayCreationExpression(node) is not ImplicitArrayCreationExpressionSyntax newNode)
            {
                return null;
            }

            initializer = newNode.Initializer;
            return newNode.WithInitializer(initializer
                .WithExpressions(SyntaxFactory.SeparatedList<ExpressionSyntax>(FixInitializerTrailingTrivia(initializer.Expressions.GetWithSeparators(), parentLeadingTrivia)))
                .WithCloseBraceToken(FixCloseBraceTrivia(initializer.CloseBraceToken, initializer.Expressions.Any() ? parentLeadingTrivia : SyntaxTriviaList.Empty)));
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

        private static IEnumerable<SyntaxNodeOrToken> FixInitializerLeadingTrivia(SyntaxNodeOrTokenList nodesOrToken, SyntaxTriviaList leadingTrivia)
            => nodesOrToken.Select(nodeOrToken => nodeOrToken.IsNode
                ? nodeOrToken.WithLeadingTrivia(nodeOrToken.GetLeadingTrivia().AddRange(leadingTrivia).Add(SyntaxFactory.Whitespace("    ")))
                : nodeOrToken);

        private static IEnumerable<SyntaxNodeOrToken> FixInitializerTrailingTrivia(SyntaxNodeOrTokenList nodesOrToken, SyntaxTriviaList leadingTrivia)
        {
            for (int i = 0; i < nodesOrToken.Count; i++)
            {
                var nodeOrToken = nodesOrToken[i];
                if (!nodeOrToken.IsNode || i == nodesOrToken.Count - 1)
                {
                    nodeOrToken = nodeOrToken.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed);
                }

                yield return nodeOrToken;
            }
        }

        private static SyntaxToken FixOpenBraceTrivia(SyntaxToken openBraceToken, bool hasInnerTokens)
        {
            openBraceToken = openBraceToken.WithLeadingTrivia(SyntaxFactory.Space);
            return hasInnerTokens
                ? openBraceToken.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed)
                : openBraceToken.WithTrailingTrivia(SyntaxTriviaList.Empty);
        }

        private static SyntaxToken FixCloseBraceTrivia(SyntaxToken closeBraceToken, SyntaxTriviaList leadingTrivia)
            => closeBraceToken.WithLeadingTrivia(leadingTrivia).WithTrailingTrivia(SyntaxTriviaList.Empty);
    }
}
