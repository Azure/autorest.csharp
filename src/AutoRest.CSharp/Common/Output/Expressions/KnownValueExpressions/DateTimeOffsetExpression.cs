// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record DateTimeOffsetExpression(ValueExpression Untyped) : TypedValueExpression<DateTimeOffset>(Untyped)
    {
        public static DateTimeOffsetExpression Now => new(StaticProperty(nameof(DateTimeOffset.Now)));
        public static DateTimeOffsetExpression UtcNow => new(StaticProperty(nameof(DateTimeOffset.UtcNow)));

        public static DateTimeOffsetExpression FromUnixTimeSeconds(ValueExpression expression)
            => new(InvokeStatic(nameof(DateTimeOffset.FromUnixTimeSeconds), expression));

        public StringExpression InvokeToString(StringExpression format, ValueExpression formatProvider)
            => new(Invoke(nameof(DateTimeOffset.ToString), new[] { format, formatProvider }));

        public LongExpression ToUnixTimeSeconds()
            => new(Invoke(nameof(DateTimeOffset.ToUnixTimeSeconds)));

        public DateTimeOffsetExpression ToUniversalTime()
            => new(Invoke(nameof(DateTimeOffset.ToUniversalTime)));

        public static DateTimeOffsetExpression Parse(string s) => Parse(Literal(s));

        public static DateTimeOffsetExpression Parse(ValueExpression value)
            => new(InvokeStatic(nameof(DateTimeOffset.Parse), value));

        public static DateTimeOffsetExpression Parse(ValueExpression value, ValueExpression formatProvider, ValueExpression style)
            => new(InvokeStatic(nameof(DateTimeOffset.Parse), new[] { value, formatProvider, style }));
    }
}
