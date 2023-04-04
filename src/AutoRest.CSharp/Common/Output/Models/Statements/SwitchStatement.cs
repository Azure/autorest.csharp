// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.Statements
{
    internal record SwitchStatement(ValueExpression MatchExpression, params SwitchCase[] Cases) : MethodBodyStatement;
}
