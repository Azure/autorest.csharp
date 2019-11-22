// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Simplification;

namespace AutoRest.CSharp.V3.Plugins.PostGen
{
    internal static class RoslynExtensions
    {
        public static T AddSimplifierAnnotation<T>(this T node) where T : SyntaxNode => node.WithAdditionalAnnotations(Simplifier.Annotation);
    }
}
