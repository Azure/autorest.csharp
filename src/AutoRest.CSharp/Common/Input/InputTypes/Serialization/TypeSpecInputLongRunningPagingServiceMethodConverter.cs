// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputLongRunningPagingServiceMethodConverter : JsonConverter<InputLongRunningPagingServiceMethod>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputLongRunningPagingServiceMethodConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputLongRunningPagingServiceMethod? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.ReadReferenceAndResolve<InputLongRunningPagingServiceMethod>(_referenceHandler.CurrentResolver)
                ?? CreateInputLongRunningPagingServiceMethod(ref reader, null, options, _referenceHandler.CurrentResolver);
        }

        public override void Write(Utf8JsonWriter writer, InputLongRunningPagingServiceMethod value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputLongRunningPagingServiceMethod CreateInputLongRunningPagingServiceMethod(
            ref Utf8JsonReader reader,
            string? id,
            JsonSerializerOptions options,
            ReferenceResolver resolver)
        {
            string? name = null;
            string? accessibility = null;
            string[]? apiVersions = null;
            string? doc = null;
            string? summary = null;
            InputOperation? operation = null;
            IReadOnlyList<InputParameter>? parameters = null;
            InputServiceMethodResponse? response = null;
            InputServiceMethodResponse? exception = null;
            InputLongRunningServiceMetadata? lroMetadata = null;
            InputPagingServiceMetadata? pagingMetadata = null;
            bool isOverride = false;
            bool generateConvenient = false;
            bool generateProtocol = false;
            string? crossLanguageDefinitionId = null;
            InputLongRunningPagingServiceMethod? method;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("accessibility", ref accessibility)
                    || reader.TryReadComplexType("apiVersions", options, ref apiVersions)
                    || reader.TryReadString("summary", ref summary)
                    || reader.TryReadString("doc", ref doc)
                    || reader.TryReadComplexType("operation", options, ref operation)
                    || reader.TryReadComplexType("parameters", options, ref parameters)
                    || reader.TryReadComplexType("response", options, ref response)
                    || reader.TryReadComplexType("exception", options, ref exception)
                    || reader.TryReadBoolean("isOverride", ref isOverride)
                    || reader.TryReadBoolean("generateConvenient", ref generateConvenient)
                    || reader.TryReadBoolean("generateProtocol", ref generateProtocol)
                    || reader.TryReadString("crossLanguageDefinitionId", ref crossLanguageDefinitionId)
                    || reader.TryReadComplexType("lroMetadata", options, ref lroMetadata)
                    || reader.TryReadComplexType("pagingMetadata", options, ref pagingMetadata);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            if (id == null)
            {
                throw new JsonException($"InputLongRunningPagingServiceMethod (name: '{name}', must have an 'id' property");
            }
            if (lroMetadata == null)
            {
                throw new JsonException($"InputLongRunningPagingServiceMethod (name: '{name}') must have a 'lroMetadata' property");
            }
            if (pagingMetadata == null)
            {
                throw new JsonException($"InputLongRunningPagingServiceMethod (name: '{name}') must have a 'pagingMetadata' property");
            }

            method = new InputLongRunningPagingServiceMethod
            {
                Name = name ?? throw new JsonException("InputLongRunningPagingServiceMethod must have name"),
                Accessibility = accessibility,
                ApiVersions = apiVersions ?? [],
                Documentation = doc,
                Summary = summary,
                Operation = operation ?? throw new JsonException("InputLongRunningPagingServiceMethod must have an operation"),
                Parameters = parameters ?? [],
                Response = response ?? throw new JsonException("InputLongRunningPagingServiceMethod must have a response"),
                Exception = exception,
                IsOverride = isOverride,
                GenerateConvenient = generateConvenient,
                GenerateProtocol = generateProtocol,
                CrossLanguageDefinitionId = crossLanguageDefinitionId ?? throw new JsonException("InputLongRunningPagingServiceMethod must have crossLanguageDefinitionId"),
                LongRunningServiceMetadata = lroMetadata,
                PagingMetadata = pagingMetadata
            };

            resolver.AddReference(id, method);

            return method;
        }
    }
}
