// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record BinaryOperatorExpression(string Operator, ValueExpression Left, ValueExpression Right) : ValueExpression;
}
