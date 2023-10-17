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

        public override SyntaxNode? VisitIfStatement(IfStatementSyntax node)
        {
            if (node.Statement is BlockSyntax block)
            {
                block = block.WithStatements(new SyntaxList<StatementSyntax>(block.Statements.Select(s => s.WithLeadingTrivia(Indentation))));
                node = node.WithStatement(block);
            }

            return base.VisitIfStatement(node);
        }

        public override SyntaxNode? VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            if (IsSingleLine(node))
            {
                return base.VisitObjectCreationExpression(node);
            }

            if (base.VisitObjectCreationExpression(node) is not ObjectCreationExpressionSyntax newNode)
            {
                return null;
            }

            if (newNode.Initializer is {Expressions.Count: > 0})
            {
                return newNode.ArgumentList is {} argumentList
                    ? newNode.WithArgumentList(argumentList.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed))
                    : newNode.WithType(newNode.Type.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed));
            }

            return newNode;
        }

        public override SyntaxNode? VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            var parentLeadingTrivia = GetPreviousLevelTrivia(node);

            node = node
                .WithNewKeyword(node.NewKeyword.WithTrailingTrivia(SyntaxTriviaList.Empty))
                .WithOpenBraceToken(FixOpenBraceTrivia(node.OpenBraceToken, parentLeadingTrivia, node.Initializers.Any()))
                .WithInitializers(SyntaxFactory.SeparatedList<AnonymousObjectMemberDeclaratorSyntax>(FixInitializerLeadingTrivia(node.Initializers.GetWithSeparators(), parentLeadingTrivia)));

            if (base.VisitAnonymousObjectCreationExpression(node) is not AnonymousObjectCreationExpressionSyntax newNode)
            {
                return null;
            }

            return newNode
                .WithInitializers(SyntaxFactory.SeparatedList<AnonymousObjectMemberDeclaratorSyntax>(FixInitializerTrailingTrivia(newNode.Initializers.GetWithSeparators())))
                .WithCloseBraceToken(FixCloseBraceTrivia(newNode.CloseBraceToken, newNode.Initializers.Any() ? parentLeadingTrivia : SyntaxTriviaList.Empty));
        }

        public override SyntaxNode? VisitInitializerExpression(InitializerExpressionSyntax node)
        {
            if (IsSingleLine(node))
            {
                return node.Parent switch
                {
                    ArrayCreationExpressionSyntax => node
                        .WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(SyntaxFactory.Space).WithTrailingTrivia(SyntaxFactory.Space))
                        .WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(SyntaxFactory.Space)),

                    _ => node
                        .WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(SyntaxTriviaList.Empty).WithTrailingTrivia(SyntaxFactory.Space))
                        .WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(SyntaxFactory.Space))
                };
            }

            var parentLeadingTrivia = GetPreviousLevelTrivia(node);
            node = FixInitializerBeforeVisit(node, parentLeadingTrivia);

            return base.VisitInitializerExpression(node) is InitializerExpressionSyntax newNode
                ? FixInitializerAfterVisit(newNode, parentLeadingTrivia)
                : null;
        }

        public override SyntaxNode? VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            return base.VisitImplicitArrayCreationExpression(node) is ImplicitArrayCreationExpressionSyntax newNode
                ? newNode
                    .WithNewKeyword(newNode.NewKeyword.WithTrailingTrivia(SyntaxTriviaList.Empty))
                    .WithCloseBracketToken(newNode.CloseBracketToken.WithTrailingTrivia(SyntaxTriviaList.Empty))
                : null;
        }

        private static InitializerExpressionSyntax FixInitializerBeforeVisit(InitializerExpressionSyntax initializer, SyntaxTriviaList parentLeadingTrivia)
        {
            var openBraceToken = initializer.OpenBraceToken;
            openBraceToken = initializer.Parent switch
            {
                AssignmentExpressionSyntax assignment when !assignment.OperatorToken.TrailingTrivia.Any(SyntaxKind.EndOfLineTrivia) => openBraceToken
                    .WithLeadingTrivia(parentLeadingTrivia.Insert(0, SyntaxFactory.CarriageReturnLineFeed))
                    .WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed),
                ImplicitArrayCreationExpressionSyntax => openBraceToken
                    .WithLeadingTrivia(SyntaxFactory.Space)
                    .WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed),
                _ => openBraceToken.WithLeadingTrivia(parentLeadingTrivia)
            };

            return initializer
                .WithOpenBraceToken(openBraceToken)
                .WithExpressions(SyntaxFactory.SeparatedList<ExpressionSyntax>(FixInitializerLeadingTrivia(initializer.Expressions.GetWithSeparators(), parentLeadingTrivia)));
        }

        private static InitializerExpressionSyntax FixInitializerAfterVisit(InitializerExpressionSyntax newInitializer, SyntaxTriviaList parentLeadingTrivia)
            => newInitializer
                .WithExpressions(SyntaxFactory.SeparatedList<ExpressionSyntax>(FixInitializerTrailingTrivia(newInitializer.Expressions.GetWithSeparators())))
                .WithCloseBraceToken(FixCloseBraceTrivia(newInitializer.CloseBraceToken, newInitializer.Expressions.Any() ? parentLeadingTrivia : SyntaxTriviaList.Empty));

        private static bool IsSingleLine(SyntaxNode node)
        {
            var lines = node.SyntaxTree.GetText().Lines;
            var fullSpan = node.FullSpan;
            return lines.GetLinePosition(fullSpan.Start).Line == lines.GetLinePosition(fullSpan.End).Line;
        }

        private static SyntaxTriviaList GetPreviousLevelTrivia(SyntaxNode node)
        {
            while (node.Parent != null)
            {
                node = node.Parent;
                switch (node) {
                    case MethodDeclarationSyntax {Body.Statements.Count: > 0 } methodDeclaration:
                        return methodDeclaration.Body.Statements.First().GetLeadingTrivia();
                    case AnonymousObjectCreationExpressionSyntax { Initializers.Count: > 0 } objectCreation:
                        return objectCreation.Initializers.First().GetLeadingTrivia();
                    case InitializerExpressionSyntax { Expressions.Count: > 0 } initializer:
                        return initializer.Expressions.First().GetLeadingTrivia();
                }
            }

            return node.GetLeadingTrivia();
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

        private static SyntaxToken FixOpenBraceTrivia(SyntaxToken openBraceToken, SyntaxTriviaList leadingTrivia, bool hasInnerTokens)
        {
            openBraceToken = hasInnerTokens
                ? openBraceToken.WithLeadingTrivia(leadingTrivia.Prepend(SyntaxFactory.CarriageReturnLineFeed))
                : openBraceToken.WithTrailingTrivia(SyntaxFactory.Space);
            return hasInnerTokens
                ? openBraceToken.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed)
                : openBraceToken.WithTrailingTrivia(SyntaxTriviaList.Empty);
        }

        private static SyntaxToken FixCloseBraceTrivia(SyntaxToken closeBraceToken, SyntaxTriviaList leadingTrivia)
            => closeBraceToken.WithLeadingTrivia(leadingTrivia).WithTrailingTrivia(SyntaxTriviaList.Empty);
    }
}
