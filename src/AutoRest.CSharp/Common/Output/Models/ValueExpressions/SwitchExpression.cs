// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record SwitchExpression(ValueExpression MatchExpression, params SwitchCaseExpression[] Cases) : ValueExpression;
}
