// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record ResponseExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Response), Untyped)
    {
        public BinaryDataExpression Content => new(new MemberReference(Untyped, nameof(Response.Content)));
        public StringExpression ContentStream => new(new MemberReference(Untyped, nameof(Response.ContentStream)));

        public static ResponseExpression<T> FromValue<T>(T valueExpression, ResponseExpression responseExpression) where T : TypedValueExpression
            => new(valueExpression, new InvokeStaticMethodExpression(valueExpression.Type, nameof(Response.FromValue), new ValueExpression[]{ valueExpression, responseExpression }));
    }
}
