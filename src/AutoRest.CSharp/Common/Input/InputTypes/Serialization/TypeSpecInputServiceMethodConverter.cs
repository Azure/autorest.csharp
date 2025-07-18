// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputServiceMethodConverter : JsonConverter<InputServiceMethod>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;
        private const string BasicKind = "basic";
        private const string PagingKind = "paging";
        private const string LongRunningKind = "lro";
        private const string LongRunningPagingKind = "lropaging";

        public TypeSpecInputServiceMethodConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputServiceMethod? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputServiceMethod>(_referenceHandler.CurrentResolver) ?? CreateInputServiceMethod(ref reader, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputServiceMethod value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private InputServiceMethod CreateInputServiceMethod(ref Utf8JsonReader reader, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            string? id = null;
            string? kind = null;
            InputServiceMethod? method = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isIdOrKind = reader.TryReadReferenceId(ref id)
                    || reader.TryReadString("kind", ref kind);

                if (isIdOrKind)
                {
                    continue;
                }
                method = CreateDerivedType(ref reader, id, kind, options);
            }

            return method ?? CreateDerivedType(ref reader, id, kind, options);
        }

        private InputServiceMethod CreateDerivedType(ref Utf8JsonReader reader, string? id, string? kind, JsonSerializerOptions options) => kind switch
        {
            null => throw new JsonException($"InputMethod (id: '{id}') must have a 'Kind' property"),
            BasicKind => TypeSpecInputBasicServiceMethodConverter.CreateInputBasicServiceMethod(ref reader, id, options, _referenceHandler.CurrentResolver),
            PagingKind => TypeSpecInputPagingServiceMethodConverter.CreateInputPagingServiceMethod(ref reader, id, options, _referenceHandler.CurrentResolver),
            LongRunningKind => TypeSpecInputLongRunningServiceMethodConverter.CreateInputLongRunningServiceMethod(ref reader, id, options, _referenceHandler.CurrentResolver),
            LongRunningPagingKind => TypeSpecInputLongRunningPagingServiceMethodConverter.CreateInputLongRunningPagingServiceMethod(ref reader, id, options, _referenceHandler.CurrentResolver),
            _ => TypeSpecInputBasicServiceMethodConverter.CreateInputBasicServiceMethod(ref reader, id, options, _referenceHandler.CurrentResolver),
        };
    }
}
