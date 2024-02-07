// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record BoolExpression(ValueExpression Untyped) : TypedValueExpression<bool>(Untyped)
    {
        public BoolExpression Or(ValueExpression other) => new(new BinaryOperatorExpression(" || ", this, other));

        public BoolExpression And(ValueExpression other) => new(new BinaryOperatorExpression(" && ", this, other));

        public static BoolExpression True => new(new ConstantExpression(new Constant(true, typeof(bool))));

        public static BoolExpression False => new(new ConstantExpression(new Constant(false, typeof(bool))));
    }
}
