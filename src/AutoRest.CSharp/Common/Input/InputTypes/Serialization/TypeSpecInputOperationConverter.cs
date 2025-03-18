// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Input.Examples;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputOperationConverter : JsonConverter<InputOperation>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputOperationConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputOperation Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputOperation>(_referenceHandler.CurrentResolver) ?? CreateOperation(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputOperation value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputOperation CreateOperation(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null && name == null;
            string? resourceName = null;
            string? summary = null;
            string? deprecated = null;
            string? accessibility = null;
            string? doc = null;
            IReadOnlyList<InputParameter>? parameters = null;
            IReadOnlyList<InputOperationResponse>? responses = null;
            RequestMethod httpMethod = default;
            string? uri = null;
            string? path = null;
            string? externalDocsUri = null;
            IReadOnlyList<string>? requestMediaTypes = null;
            bool bufferResponse = false;
            InputOperationLongRunning? longRunning= null;
            OperationPaging? paging = null;
            bool generateProtocolMethod = false;
            bool generateConvenienceMethod = false;
            string? crossLanguageDefinitionId = null;
            bool keepClientDefaultValue = false;
            IReadOnlyList<InputOperationExample>? examples = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("resourceName", ref resourceName)
                    || reader.TryReadString("summary", ref summary)
                    || reader.TryReadString("deprecated", ref deprecated)
                    || reader.TryReadString("doc", ref doc)
                    || reader.TryReadString("accessibility", ref accessibility)
                    || reader.TryReadComplexType("parameters", options, ref parameters)
                    || reader.TryReadComplexType("responses", options, ref responses)
                    || reader.TryReadComplexType("httpMethod", options, ref httpMethod)
                    || reader.TryReadString("uri", ref uri)
                    || reader.TryReadString("path", ref path)
                    || reader.TryReadString("externalDocsUrl", ref externalDocsUri)
                    || reader.TryReadComplexType("requestMediaTypes", options, ref requestMediaTypes)
                    || reader.TryReadBoolean("bufferResponse", ref bufferResponse)
                    || reader.TryReadComplexType("longRunning", options, ref longRunning)
                    || reader.TryReadComplexType("paging", options, ref paging)
                    || reader.TryReadBoolean("generateProtocolMethod", ref generateProtocolMethod)
                    || reader.TryReadBoolean("generateConvenienceMethod", ref generateConvenienceMethod)
                    || reader.TryReadString("crossLanguageDefinitionId", ref crossLanguageDefinitionId)
                    || reader.TryReadBoolean("keepClientDefaultValue", ref keepClientDefaultValue)
                    || reader.TryReadComplexType("examples", options, ref examples);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException("Enum must have name");
            if (string.IsNullOrEmpty(doc) && string.IsNullOrEmpty(summary))
            {
                Console.Error.WriteLine($"[Warn]: InputOperation '{name}' must have either a summary or description");
            }
            crossLanguageDefinitionId = crossLanguageDefinitionId ?? throw new JsonException("InputOperation must have crossLanguageDefinitionId");
            uri = uri ?? throw new JsonException("InputOperation must have uri");
            path = path ?? throw new JsonException("InputOperation must have path");
            parameters = parameters ?? throw new JsonException("InputOperation must have parameters");
            responses = responses ?? throw new JsonException("InputOperation must have responses");

            var inputOperation = new InputOperation(name, resourceName, summary, deprecated, doc, accessibility, parameters, responses, httpMethod, uri, path, externalDocsUri, requestMediaTypes, bufferResponse, longRunning, paging, generateProtocolMethod, generateConvenienceMethod, crossLanguageDefinitionId, keepClientDefaultValue, examples, null)
            {
                IsNameChanged = IsNameChanged(crossLanguageDefinitionId, name)
            };
            if (id != null)
            {
                resolver.AddReference(id, inputOperation);
            }
            return inputOperation;

            static bool IsNameChanged(string crossLanguageDefinitionId, string name)
            {
                int lastDotIndex = crossLanguageDefinitionId.LastIndexOf('.');
                if (lastDotIndex < 0)
                {
                    throw new JsonException($"The crossLanguageDefinitionId of {crossLanguageDefinitionId} does not contain a dot in it, this should be impossible to happen");
                }
                var span = crossLanguageDefinitionId.AsSpan(lastDotIndex + 1);
                var nameSpan = name.AsSpan();
                if (nameSpan.Equals(span, StringComparison.Ordinal))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
