// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record IntExpression(ValueExpression Untyped) : TypedValueExpression<int>(Untyped)
    {
        public static IntExpression MaxValue => new(StaticProperty(nameof(int.MaxValue)));
    }
}
