// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputListTypeConverter : JsonConverter<InputListType>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputListTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputListType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputListType>(_referenceHandler.CurrentResolver) ?? CreateListType(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputListType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputListType CreateListType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            string? crossLanguageDefinitionId = null;
            InputType? valueType = null;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("crossLanguageDefinitionId", ref crossLanguageDefinitionId)
                    || reader.TryReadWithConverter("valueType", options, ref valueType)
                    || reader.TryReadWithConverter("decorators", options, ref decorators);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException("Array must have a name");
            valueType = valueType ?? throw new JsonException("Array must have an value type");
            var listType = new InputListType(name, crossLanguageDefinitionId ?? string.Empty, valueType) { Decorators = decorators ?? Array.Empty<InputDecoratorInfo>() };
            if (id != null)
            {
                resolver.AddReference(id, listType);
            }
            return listType;
        }
    }
}
