// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record DateTimeOffsetExpression(ValueExpression Untyped) : TypedValueExpression(typeof(DateTimeOffset), Untyped)
    {
        public static DateTimeOffsetExpression Now => new(StaticProperty(typeof(DateTimeOffset), nameof(DateTimeOffset.Now)));
        public static DateTimeOffsetExpression UtcNow => new(StaticProperty(typeof(DateTimeOffset), nameof(DateTimeOffset.UtcNow)));

        public static DateTimeOffsetExpression FromUnixTimeSeconds(ValueExpression expression)
            => new(new InvokeStaticMethodExpression(typeof(DateTimeOffset), nameof(DateTimeOffset.FromUnixTimeSeconds), new[]{expression}));
    }
}
