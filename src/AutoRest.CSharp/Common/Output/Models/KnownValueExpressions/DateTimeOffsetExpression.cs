// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record DateTimeOffsetExpression(ValueExpression Untyped) : TypedValueExpression<DateTimeOffset>(Untyped)
    {
        public static DateTimeOffsetExpression Now => new(StaticProperty(nameof(DateTimeOffset.Now)));
        public static DateTimeOffsetExpression UtcNow => new(StaticProperty(nameof(DateTimeOffset.UtcNow)));

        public static DateTimeOffsetExpression FromUnixTimeSeconds(ValueExpression expression)
            => new(InvokeStatic(nameof(DateTimeOffset.FromUnixTimeSeconds), expression));
    }
}
