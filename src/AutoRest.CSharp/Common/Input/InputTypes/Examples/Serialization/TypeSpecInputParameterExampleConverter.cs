// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal sealed class TypeSpecInputParameterExampleConverter : JsonConverter<InputParameterExample>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputParameterExampleConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputParameterExample? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.ReadReferenceAndResolve<InputParameterExample>(_referenceHandler.CurrentResolver) ?? CreateInputParameterExample(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, InputParameterExample value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private InputParameterExample CreateInputParameterExample(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            string? id = null;
            InputParameter? parameter = null;
            InputExampleValue? value = null;
            var isFirstProperty = true;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadWithConverter("parameter", options, ref parameter)
                    || reader.TryReadWithConverter("value", options, ref value);

                if (!isKnownProperty)
                {
                    continue;
                }
            }

            var result = new InputParameterExample(parameter ?? throw new JsonException(), value ?? throw new JsonException());

            if (id != null)
            {
                _referenceHandler.CurrentResolver.AddReference(id, result);
            }

            return result;
        }
    }
}
