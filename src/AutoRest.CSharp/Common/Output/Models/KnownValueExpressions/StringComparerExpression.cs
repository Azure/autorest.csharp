// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record StringComparerExpression(ValueExpression Untyped) : TypedValueExpression(typeof(StringComparer), Untyped)
    {
        public BoolExpression Equals(StringExpression left, StringExpression right) => new(new InvokeInstanceMethodExpression(Untyped, nameof(StringComparer.Equals), left, right));

        public static StringComparerExpression Ordinal => new(new MemberExpression(new TypeReference(typeof(StringComparer)), nameof(StringComparer.Ordinal)));
        public static StringComparerExpression OrdinalIgnoreCase => new(new MemberExpression(new TypeReference(typeof(StringComparer)), nameof(StringComparer.OrdinalIgnoreCase)));
    }
}
