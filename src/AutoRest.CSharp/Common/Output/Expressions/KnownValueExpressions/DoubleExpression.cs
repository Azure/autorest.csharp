// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;

internal sealed record DoubleExpression(ValueExpression Untyped) : TypedValueExpression<double>(Untyped)
{
    public static DoubleExpression MaxValue => new(StaticProperty(nameof(double.MaxValue)));

    public static BoolExpression IsNan(ValueExpression d) => new(new InvokeStaticMethodExpression(typeof(double), nameof(double.IsNaN), new[] { d }));
}
