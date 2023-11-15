// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record BoolExpression(ValueExpression Untyped) : TypedValueExpression<bool>(Untyped)
    {
        public BoolExpression Or(ValueExpression other) => new(new BinaryOperatorExpression(" || ", this, other));

        public BoolExpression And(ValueExpression other) => new(new BinaryOperatorExpression(" && ", this, other));
    }
}
