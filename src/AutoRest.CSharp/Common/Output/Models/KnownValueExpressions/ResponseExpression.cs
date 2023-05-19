// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using Azure;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record ResponseExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Response), Untyped)
    {
        public ValueExpression Status => new MemberReference(Untyped, nameof(Response.Status));
        public BinaryDataExpression Content => new(new MemberReference(Untyped, nameof(Response.Content)));
        public ValueExpression ContentStream => new MemberReference(Untyped, nameof(Response.ContentStream));

        public static ResponseExpression FromValue(ValueExpression value, ResponseExpression rawResponse)
            => new(new InvokeStaticMethodExpression(typeof(Response), nameof(Response.FromValue), new[]{ value, rawResponse }));
    }
}
