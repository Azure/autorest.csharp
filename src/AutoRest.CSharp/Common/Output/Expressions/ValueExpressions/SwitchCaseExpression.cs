// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record SwitchCaseExpression(ValueExpression Case, ValueExpression Expression)
    {
        public static SwitchCaseExpression When(ValueExpression caseExpression, BoolExpression condition, ValueExpression expression)
        {
            return new(new SwitchCaseWhenExpression(caseExpression, condition), expression);
        }
        public static SwitchCaseExpression Default(ValueExpression expression) => new SwitchCaseExpression(Dash, expression);
    }
}
