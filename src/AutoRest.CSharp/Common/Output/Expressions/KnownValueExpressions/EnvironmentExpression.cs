// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record EnvironmentExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Environment), Untyped)
    {
        public static StringExpression NewLine() => new(new TypeReference(typeof(Environment)).Property(nameof(Environment.NewLine)));
    }
}
