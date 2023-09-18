// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record GuidExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Guid), Untyped)
    {
        public static GuidExpression NewGuid()
            => new(new InvokeStaticMethodExpression(typeof(Guid), nameof(Guid.NewGuid)));
    }
}
