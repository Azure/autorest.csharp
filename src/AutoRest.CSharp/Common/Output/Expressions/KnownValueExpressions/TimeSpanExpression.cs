// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record TimeSpanExpression(ValueExpression Untyped) : TypedValueExpression<TimeSpan>(Untyped)
    {
        public StringExpression InvokeToString(string? format) => new(Invoke(nameof(TimeSpan.ToString), new[] { Literal(format) }));
        public StringExpression InvokeToString(ValueExpression format, ValueExpression formatProvider)
            => new(Invoke(nameof(TimeSpan.ToString), new[] { format, formatProvider }));

        public static TimeSpanExpression FromSeconds(ValueExpression value) => new(InvokeStatic(nameof(TimeSpan.FromSeconds), value));

        public static TimeSpanExpression ParseExact(ValueExpression value, ValueExpression format, ValueExpression formatProvider)
            => new(new InvokeStaticMethodExpression(typeof(TimeSpan), nameof(TimeSpan.ParseExact), new[] { value, format, formatProvider }));
    }
}
