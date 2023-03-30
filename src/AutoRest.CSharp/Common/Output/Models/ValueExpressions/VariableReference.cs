// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record VariableReference(CodeWriterDeclaration Name) : ValueExpression;
}
