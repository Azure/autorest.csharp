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
        private static readonly SyntaxTrivia Indentation = SyntaxFactory.Whitespace("    ");

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

        public override SyntaxNode? VisitForEachStatement(ForEachStatementSyntax node)
        {
            if (node.Statement is BlockSyntax block)
            {
                block = block.WithStatements(new SyntaxList<StatementSyntax>(block.Statements.Select(s => s.WithLeadingTrivia(Indentation))));
                node = node.WithStatement(block);
            }

            return base.VisitForEachStatement(node);
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
                .WithInitializers(SyntaxFactory.SeparatedList<AnonymousObjectMemberDeclaratorSyntax>(FixInitializerTrailingTrivia(newNode.Initializers.GetWithSeparators())))
                .WithCloseBraceToken(FixCloseBraceTrivia(newNode.CloseBraceToken, newNode.Initializers.Any() ? parentLeadingTrivia : SyntaxTriviaList.Empty));
        }

        public override SyntaxNode? VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            var parentLeadingTrivia = GetParentLeadingTrivia(node);

            if (node.Initializer is { } initializer)
            {
                node = node.WithInitializer(FixInitializerBeforeVisit(initializer, parentLeadingTrivia));
            }

            if (base.VisitObjectCreationExpression(node) is not ObjectCreationExpressionSyntax newNode)
            {
                return null;
            }

            if (newNode.Initializer is { } newInitializer)
            {
                newNode = newNode.WithInitializer(FixInitializerAfterVisit(newInitializer, parentLeadingTrivia));
            }

            return newNode;
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
                .WithExpressions(SyntaxFactory.SeparatedList<ExpressionSyntax>(FixInitializerTrailingTrivia(initializer.Expressions.GetWithSeparators())))
                .WithCloseBraceToken(FixCloseBraceTrivia(initializer.CloseBraceToken, initializer.Expressions.Any() ? parentLeadingTrivia : SyntaxTriviaList.Empty)));
        }

        public override SyntaxNode? VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            var parentLeadingTrivia = GetParentLeadingTrivia(node);

            if (node.Initializer is { } initializer)
            {
                node = node.WithInitializer(FixInitializerBeforeVisit(initializer, parentLeadingTrivia));
            }

            if (base.VisitArrayCreationExpression(node) is not ArrayCreationExpressionSyntax newNode)
            {
                return null;
            }

            if (newNode.Initializer is { } newInitializer)
            {
                newNode = newNode.WithInitializer(FixInitializerAfterVisit(newInitializer, parentLeadingTrivia));
            }

            return newNode;
        }

        private static InitializerExpressionSyntax FixInitializerBeforeVisit(InitializerExpressionSyntax initializer, SyntaxTriviaList parentLeadingTrivia)
            => initializer
                .WithOpenBraceToken(initializer.OpenBraceToken.WithLeadingTrivia(parentLeadingTrivia))
                .WithExpressions(SyntaxFactory.SeparatedList<ExpressionSyntax>(FixInitializerLeadingTrivia(initializer.Expressions.GetWithSeparators(), parentLeadingTrivia)));

        private static InitializerExpressionSyntax FixInitializerAfterVisit(InitializerExpressionSyntax newInitializer, SyntaxTriviaList parentLeadingTrivia)
            => newInitializer
                .WithExpressions(SyntaxFactory.SeparatedList<ExpressionSyntax>(FixInitializerTrailingTrivia(newInitializer.Expressions.GetWithSeparators())))
                .WithCloseBraceToken(FixCloseBraceTrivia(newInitializer.CloseBraceToken, newInitializer.Expressions.Any() ? parentLeadingTrivia : SyntaxTriviaList.Empty));

        private static SyntaxTriviaList GetParentLeadingTrivia(SyntaxNode node)
        {
            while (node.Parent != null)
            {
                node = node.Parent;
                switch (node) {
                    case AnonymousObjectCreationExpressionSyntax { Initializers.Count: > 0 } objectCreation:
                        return objectCreation.Initializers.First().GetLeadingTrivia();
                    case InitializerExpressionSyntax { Expressions.Count: > 0 } initializer:
                        return initializer.Expressions.First().GetLeadingTrivia();
                }
            }

            return SyntaxTriviaList.Empty;
        }

        private static IEnumerable<SyntaxNodeOrToken> FixInitializerLeadingTrivia(SyntaxNodeOrTokenList nodesOrToken, SyntaxTriviaList leadingTrivia)
            => nodesOrToken.Select(nodeOrToken => nodeOrToken.IsNode
                ? nodeOrToken.WithLeadingTrivia(nodeOrToken.GetLeadingTrivia().AddRange(leadingTrivia).Add(Indentation))
                : nodeOrToken);

        private static IEnumerable<SyntaxNodeOrToken> FixInitializerTrailingTrivia(SyntaxNodeOrTokenList nodesOrToken)
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
