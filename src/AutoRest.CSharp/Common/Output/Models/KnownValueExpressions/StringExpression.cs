// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record StringExpression(ValueExpression Untyped) : TypedValueExpression<string>(Untyped)
    {
        public ValueExpression Length => Property(nameof(string.Length));

        public static BoolExpression Equals(StringExpression left, StringExpression right, StringComparison comparisonType)
            => new(InvokeStatic(nameof(string.Equals), new[]{ left, right, FrameworkEnumValue(comparisonType) }));
    }
}
