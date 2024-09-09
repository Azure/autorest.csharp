// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Input.Examples;
using Azure.Core;
using Humanizer;

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
            string? description = null;
            IReadOnlyList<InputParameter>? parameters = null;
            IReadOnlyList<OperationResponse>? responses = null;
            RequestMethod httpMethod = default;
            BodyMediaType requestBodyMediaType = default;
            string? uri = null;
            string? path = null;
            string? externalDocsUri = null;
            IReadOnlyList<string>? requestMediaTypes = null;
            bool bufferResponse = false;
            OperationLongRunning? longRunning= null;
            OperationPaging? paging = null;
            bool generateProtocolMethod = false;
            bool generateConvenienceMethod = false;
            string? crossLanguageDefinitionId = null;
            bool keepClientDefaultValue = false;
            IReadOnlyList<InputOperationExample>? examples = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputOperation.Name), ref name)
                    || reader.TryReadString(nameof(InputOperation.ResourceName), ref resourceName)
                    || reader.TryReadString(nameof(InputOperation.Summary), ref summary)
                    || reader.TryReadString(nameof(InputOperation.Deprecated), ref deprecated)
                    || reader.TryReadString(nameof(InputOperation.Description), ref description)
                    || reader.TryReadString(nameof(InputOperation.Accessibility), ref accessibility)
                    || reader.TryReadWithConverter(nameof(InputOperation.Parameters), options, ref parameters)
                    || reader.TryReadWithConverter(nameof(InputOperation.Responses), options, ref responses)
                    || reader.TryReadWithConverter(nameof(InputOperation.HttpMethod), options, ref httpMethod)
                    || reader.TryReadWithConverter(nameof(InputOperation.RequestBodyMediaType), options, ref requestBodyMediaType)
                    || reader.TryReadString(nameof(InputOperation.Uri), ref uri)
                    || reader.TryReadString(nameof(InputOperation.Path), ref path)
                    || reader.TryReadString(nameof(InputOperation.ExternalDocsUrl), ref externalDocsUri)
                    || reader.TryReadWithConverter(nameof(InputOperation.RequestMediaTypes), options, ref requestMediaTypes)
                    || reader.TryReadBoolean(nameof(InputOperation.BufferResponse), ref bufferResponse)
                    || reader.TryReadWithConverter(nameof(InputOperation.LongRunning), options, ref longRunning)
                    || reader.TryReadWithConverter(nameof(InputOperation.Paging), options, ref paging)
                    || reader.TryReadBoolean(nameof(InputOperation.GenerateProtocolMethod), ref generateProtocolMethod)
                    || reader.TryReadBoolean(nameof(InputOperation.GenerateConvenienceMethod), ref generateConvenienceMethod)
                    || reader.TryReadString(nameof(InputOperation.CrossLanguageDefinitionId), ref crossLanguageDefinitionId)
                    || reader.TryReadBoolean(nameof(InputOperation.KeepClientDefaultValue), ref keepClientDefaultValue)
                    || reader.TryReadWithConverter(nameof(InputOperation.Examples), options, ref examples);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException("Enum must have name");
            if (string.IsNullOrEmpty(description))
            {
                Console.Error.WriteLine($"[Warn]: InputOperation '{name}' does not have a description");
                description = $"{name.Humanize()}.";
            }
            crossLanguageDefinitionId = crossLanguageDefinitionId ?? throw new JsonException("InputOperation must have crossLanguageDefinitionId");
            uri = uri ?? throw new JsonException("InputOperation must have uri");
            path = path ?? throw new JsonException("InputOperation must have path");
            parameters = parameters ?? throw new JsonException("InputOperation must have parameters");
            responses = responses ?? throw new JsonException("InputOperation must have responses");

            var inputOperation = new InputOperation(name, resourceName, summary, deprecated, description, accessibility, parameters, responses, httpMethod, requestBodyMediaType, uri, path, externalDocsUri, requestMediaTypes, bufferResponse, longRunning, paging, generateProtocolMethod, generateConvenienceMethod, crossLanguageDefinitionId, keepClientDefaultValue, examples)
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
