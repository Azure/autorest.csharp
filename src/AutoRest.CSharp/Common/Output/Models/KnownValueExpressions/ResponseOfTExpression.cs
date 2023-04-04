// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
#pragma warning disable SA1649
    internal sealed record ResponseExpression<T>(T Value, ValueExpression Untyped) : TypedValueExpression(new CSharpType(typeof(Azure.Response<>), Value.Type), Untyped) where T : TypedValueExpression
#pragma warning restore SA1649
    {
    }
}
