// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal sealed class TypeSpecOperationResponseExampleConverter : JsonConverter<OperationResponseExample>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecOperationResponseExampleConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override OperationResponseExample? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.ReadReferenceAndResolve<OperationResponseExample>(_referenceHandler.CurrentResolver) ?? CreateOperationResponseExample(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, OperationResponseExample value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private OperationResponseExample CreateOperationResponseExample(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var isFirstProperty = true;
            string? id = null;
            OperationResponse? response = null;
            InputExampleValue? bodyValue = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadWithConverter("response", options, ref response)
                    || reader.TryReadWithConverter("bodyValue", options, ref bodyValue);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            var result = new OperationResponseExample(response ?? throw new JsonException(), bodyValue as InputExampleObjectValue ?? throw new JsonException());

            if (id != null)
            {
                _referenceHandler.CurrentResolver.AddReference(id, result);
            }

            return result;
        }
    }
}
