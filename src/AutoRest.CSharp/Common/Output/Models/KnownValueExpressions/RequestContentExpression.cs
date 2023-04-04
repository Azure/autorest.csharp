// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record RequestContentExpression(ValueExpression Untyped) : TypedValueExpression(typeof(RequestContent), Untyped)
    {
        public static RequestContentExpression Create(ValueExpression serializable) => new(new InvokeStaticMethodExpression(typeof(RequestContent), nameof(RequestContent.Create), new[]{serializable}));
    }
}
