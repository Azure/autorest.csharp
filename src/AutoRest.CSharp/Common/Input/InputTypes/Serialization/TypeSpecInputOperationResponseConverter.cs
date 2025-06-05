// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputOperationResponseConverter : JsonConverter<InputOperationResponse>
    {
        public TypeSpecInputOperationResponseConverter(TypeSpecReferenceHandler referenceHandler)
        {
        }

        public override InputOperationResponse? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => CreateOperationResponse(ref reader, options);

        public override void Write(Utf8JsonWriter writer, InputOperationResponse value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private InputOperationResponse CreateOperationResponse(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            IReadOnlyList<int>? statusCodes = null;
            InputType? bodyType = null;
            IReadOnlyList<InputOperationResponseHeader>? headers = null;
            bool isErrorResponse = default;
            IReadOnlyList<string>? contentTypes = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadComplexType("statusCodes", options, ref statusCodes)
                    || reader.TryReadComplexType("bodyType", options, ref bodyType)
                    || reader.TryReadComplexType("headers", options, ref headers)
                    || reader.TryReadBoolean("isErrorResponse", ref isErrorResponse)
                    || reader.TryReadComplexType("contentTypes", options, ref contentTypes);

                if (!isKnownProperty)
                {
                    continue;
                }
            }

            statusCodes = statusCodes ?? throw new JsonException("OperationResponse must have StatusCodes");
            contentTypes ??= [];
            headers ??= [];

            var result = new InputOperationResponse(statusCodes, bodyType, headers, isErrorResponse, contentTypes);

            return result;
        }
    }
}
