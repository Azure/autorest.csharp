// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record TimeSpanExpression(ValueExpression Untyped) : TypedValueExpression(typeof(TimeSpan), Untyped)
    {
        public StringExpression ToString(string? format) => new(Invoke(nameof(TimeSpan.ToString), new[] { Literal(format) }));

        public static ValueExpression FromSeconds(ValueExpression value) => new InvokeStaticMethodExpression(typeof(TimeSpan), nameof(TimeSpan.FromSeconds), new[] { value });
    }
}
