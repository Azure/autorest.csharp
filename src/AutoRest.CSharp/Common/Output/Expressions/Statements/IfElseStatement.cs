// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.Statements
{
    internal record IfElseStatement(ValueExpression Condition, MethodBodyStatement If, MethodBodyStatement? Else, bool Inline = false) : MethodBodyStatement;
}
