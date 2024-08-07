// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal sealed class TypeSpecInputOperationExampleConverter : JsonConverter<InputHttpOperationExample>
    {
        private const string KindPropertyName = "kind";

        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputOperationExampleConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputHttpOperationExample? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.ReadReferenceAndResolve<InputHttpOperationExample>(_referenceHandler.CurrentResolver) ?? CreateInputHttpOperationExample(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, InputHttpOperationExample value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private InputHttpOperationExample CreateInputHttpOperationExample(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var isFirstProperty = true;
            string? id = null;
            string? name = null;
            string? description = null;
            string? filePath = null;
            IReadOnlyList<InputParameterExample>? parameters = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("description", ref description)
                    || reader.TryReadString("filePath", ref filePath)
                    || reader.TryReadWithConverter("parameters", options, ref parameters);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            var result = new InputHttpOperationExample(name ?? throw new JsonException(), description, filePath ?? throw new JsonException(), parameters ?? throw new JsonException());

            if (id != null)
            {
                _referenceHandler.CurrentResolver.AddReference(id, result);
            }

            return result;
        }
    }
}
