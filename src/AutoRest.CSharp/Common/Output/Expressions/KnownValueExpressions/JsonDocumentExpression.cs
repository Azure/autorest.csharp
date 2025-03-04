// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record JsonDocumentExpression(ValueExpression Untyped) : TypedValueExpression<JsonDocument>(Untyped)
    {
        //private static ValueExpression _jsonDocumentOptions = New.Instance(typeof(JsonDocumentOptions), new Dictionary<string, ValueExpression>() { { "MaxDepth", Literal(256) } });
        public JsonElementExpression RootElement => new(Property(nameof(JsonDocument.RootElement)));

        public static JsonDocumentExpression ParseValue(ValueExpression reader) => new(InvokeStatic(nameof(JsonDocument.ParseValue), reader));
        public static JsonDocumentExpression Parse(ValueExpression json) => new(InvokeStatic(nameof(JsonDocument.Parse), [json, ModelSerializationExtensionsProvider.Instance.JsonDocumentOptions]));
        public static JsonDocumentExpression Parse(BinaryDataExpression binaryData) => new(InvokeStatic(nameof(JsonDocument.Parse), [binaryData, ModelSerializationExtensionsProvider.Instance.JsonDocumentOptions]));
        public static JsonDocumentExpression Parse(StreamExpression stream) => new(InvokeStatic(nameof(JsonDocument.Parse), [stream]));

        public static JsonDocumentExpression Parse(StreamExpression stream, bool async)
        {
            // Sync and async methods have different set of parameters
            return async
                // non-azure libraries do not have cancellationToken parameter
                ? new JsonDocumentExpression(InvokeStatic(nameof(JsonDocument.ParseAsync), new[] { stream, ModelSerializationExtensionsProvider.Instance.JsonDocumentOptions, Configuration.IsBranded ? KnownParameters.CancellationTokenParameter : Snippets.Default }, true))
                : new JsonDocumentExpression(InvokeStatic(nameof(JsonDocument.Parse), [stream, ModelSerializationExtensionsProvider.Instance.JsonDocumentOptions]));
        }
    }
}
