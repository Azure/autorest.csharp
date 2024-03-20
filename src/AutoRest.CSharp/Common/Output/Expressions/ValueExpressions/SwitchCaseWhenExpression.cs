// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record SwitchCaseWhenExpression(ValueExpression Case, BoolExpression Condition) : ValueExpression;
}
