// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure
{
    internal sealed record ResponseExpression(ValueExpression Untyped) : TypedValueExpression<Response>(Untyped)
    {
        public ValueExpression Status => Property(nameof(Response.Status));

        public StreamExpression ContentStream => new(Property(nameof(Response.ContentStream)));
        public BinaryDataExpression Content => new(Property(nameof(Response.Content)));

        public ValueExpression Headers => new InvokeInstanceMethodExpression(Untyped, nameof(Response.Headers), Array.Empty<ValueExpression>(), null, false);
        public ValueExpression ContentType => new InvokeInstanceMethodExpression(Headers, nameof(ResponseHeaders.TryGetValue), new ValueExpression[] { Literal("Content-Type"), new KeywordExpression("out", new ParameterReference(new Parameter("value", null, typeof(string), null, ValidationType.None, null, IsOut: true))) }, null, false);

        public static NullableResponseExpression FromValue(ValueExpression value, ResponseExpression rawResponse)
            => new(new InvokeStaticMethodExpression(typeof(Response), nameof(Response.FromValue), new[] { value, rawResponse }));

        public static NullableResponseExpression FromValue(CSharpType explicitValueType, ValueExpression value, ResponseExpression rawResponse)
            => new(new InvokeStaticMethodExpression(typeof(Response), nameof(Response.FromValue), new[] { value, rawResponse }, new[] { explicitValueType }));
    }
}
