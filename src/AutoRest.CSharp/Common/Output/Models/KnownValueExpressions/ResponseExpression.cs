// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using Azure;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record ResponseExpression(ValueExpression Untyped) : TypedValueExpression<Response>(Untyped)
    {
        public ValueExpression Status => Property(nameof(Response.Status));
        public ValueExpression Value => Property(nameof(Response<object>.Value));

        public StreamExpression ContentStream => new(Property(nameof(Response.ContentStream)));
        public BinaryDataExpression Content => new(Property(nameof(Response.Content)));

        public ResponseExpression GetRawResponse() => new(Invoke(nameof(GetRawResponse)));

        public static ResponseExpression FromValue(ValueExpression value, ResponseExpression rawResponse)
            => new(InvokeStatic(nameof(Response.FromValue), value, rawResponse));

        public static ResponseExpression FromValue(CSharpType explicitValueType, ValueExpression value, ResponseExpression rawResponse)
            => new(new InvokeStaticMethodExpression(typeof(Response), nameof(Response.FromValue), new[]{ value, rawResponse }, new[]{ explicitValueType }));
    }
}
