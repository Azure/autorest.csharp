// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Models.Statements
{
    internal record ForeachStatement(CodeWriterDeclaration Item, ValueExpression Enumerable, MethodBodyStatement Body) : MethodBodyStatement;
}
