// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Simplification;

namespace AutoRest.CSharp.V3.Plugins.PostGen
{
    // From Roslyn FAQ: https://github.com/dotnet/roslyn/blob/56f605c41915317ccdb925f66974ee52282609e7/src/Samples/CSharp/APISampleUnitTests/FAQ.cs
    internal class SimplifyNamesRewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node) => base.VisitNamespaceDeclaration(node.AddSimplifierAnnotation());
        public override SyntaxNode VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node) => base.VisitLocalDeclarationStatement(node.AddSimplifierAnnotation());
        public override SyntaxNode VisitConstructorDeclaration(ConstructorDeclarationSyntax node) => base.VisitConstructorDeclaration(node.AddSimplifierAnnotation());
        public override SyntaxNode VisitAttribute(AttributeSyntax node) => base.VisitAttribute(node.AddSimplifierAnnotation());
        public override SyntaxNode VisitCatchDeclaration(CatchDeclarationSyntax node) => base.VisitCatchDeclaration(node.AddSimplifierAnnotation());

        // These methods below are not descending into the node to simplify the whole expression.
        public override SyntaxNode VisitAliasQualifiedName(AliasQualifiedNameSyntax node) => base.VisitAliasQualifiedName(node.AddSimplifierAnnotation());
        public override SyntaxNode VisitQualifiedName(QualifiedNameSyntax node) => base.VisitQualifiedName(node.AddSimplifierAnnotation());
        public override SyntaxNode VisitMemberAccessExpression(MemberAccessExpressionSyntax node) => base.VisitMemberAccessExpression(node.AddSimplifierAnnotation());
        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node) => base.VisitIdentifierName(node.AddSimplifierAnnotation());
        public override SyntaxNode VisitGenericName(GenericNameSyntax node) => base.VisitGenericName(node.AddSimplifierAnnotation());
    }

    internal static class RoslynExtensions
    {
        public static T AddSimplifierAnnotation<T>(this T node) where T : SyntaxNode => node.WithAdditionalAnnotations(Simplifier.Annotation);
    }
}