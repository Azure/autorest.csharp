// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record JsonDocumentExpression(ValueExpression Untyped) : TypedValueExpression(typeof(JsonDocument), Untyped)
    {
        public JsonElementExpression RootElement => new(new MemberExpression(Untyped, nameof(JsonDocument.RootElement)));

        public static JsonDocumentExpression Parse(ValueExpression json)
            => new(new InvokeStaticMethodExpression(typeof(JsonDocument), nameof(JsonDocument.Parse), new[]{json}));

        public static JsonDocumentExpression Parse(ResponseExpression response, bool async)
        {
            return async
                ? new JsonDocumentExpression(new InvokeStaticMethodExpression(typeof(JsonDocument), nameof(JsonDocument.ParseAsync), new[]{response.ContentStream, Snippets.Default, KnownParameters.CancellationTokenParameter}, null, false, true))
                : new JsonDocumentExpression(new InvokeStaticMethodExpression(typeof(JsonDocument), nameof(JsonDocument.Parse), new[]{response.ContentStream}));
        }
    }
}
