// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
            => reader.ReadReferenceAndResolve<InputListType>(_referenceHandler.CurrentResolver) ?? CreateListType(ref reader, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputListType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputListType CreateListType(ref Utf8JsonReader reader, string? id, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            bool isNullable = false;
            InputType? elementType = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadBoolean(nameof(InputListType.IsNullable), ref isNullable)
                    || reader.TryReadWithConverter(nameof(InputListType.ValueType), options, ref elementType);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            elementType = elementType ?? throw new JsonException("List must have element type");
            var listType = new InputListType("Array", elementType, isNullable);
            if (id != null)
            {
                resolver.AddReference(id, listType);
            }
            return listType;
        }
    }
}
