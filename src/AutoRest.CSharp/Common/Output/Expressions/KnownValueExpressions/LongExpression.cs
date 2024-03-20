// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;

internal sealed record LongExpression(ValueExpression Untyped) : TypedValueExpression<long>(Untyped)
{
    public StringExpression InvokeToString(ValueExpression formatProvider)
        => new(Invoke(nameof(long.ToString), formatProvider));

    public static LongExpression Parse(StringExpression value, ValueExpression formatProvider)
        => new(new InvokeStaticMethodExpression(typeof(long), nameof(long.Parse), new[] { value, formatProvider }));
}
