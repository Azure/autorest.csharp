// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record JsonDocumentExpression(ValueExpression Untyped) : TypedValueExpression(typeof(JsonDocument), Untyped)
    {
        public JsonElementExpression Get_RootElement() => new(new MemberReference(Untyped, nameof(JsonDocument.RootElement)));

        public static JsonDocumentExpression Parse(ValueExpression json)
            => new(new StaticMethodCallExpression(typeof(JsonDocument), nameof(JsonDocument.Parse), new[]{json}));

        public static JsonDocumentExpression Parse(ValueExpression response, bool async)
        {
            var contentStream = new MemberReference(response, nameof(Response.ContentStream));
            return async
                ? new JsonDocumentExpression(new StaticMethodCallExpression(typeof(JsonDocument), nameof(JsonDocument.ParseAsync), new ValueExpression[]{contentStream, Snippets.Default, KnownParameters.CancellationTokenParameter}, null, false, true))
                : new JsonDocumentExpression(new StaticMethodCallExpression(typeof(JsonDocument), nameof(JsonDocument.Parse), new[]{contentStream}));
        }
    }
}
