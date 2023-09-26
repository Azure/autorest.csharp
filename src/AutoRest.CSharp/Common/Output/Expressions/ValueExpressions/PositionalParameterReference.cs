// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record PositionalParameterReference(string ParameterName, ValueExpression ParameterValue) : ValueExpression;
}
