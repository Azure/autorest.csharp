// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input.InputTypes.Serialization
{
    internal class TypeSpecInputNullableTypeConverter : JsonConverter<InputNullableType>
    {
        internal const string NullableKind = "nullable";

        private readonly TypeSpecReferenceHandler _referenceHandler;
        public TypeSpecInputNullableTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputNullableType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputNullableType>(_referenceHandler.CurrentResolver) ?? CreateNullableType(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public static InputNullableType CreateNullableType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null && name == null;
            InputType? valueType = null;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadComplexType("type", options, ref valueType)
                    || reader.TryReadComplexType("decorators", options, ref decorators);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            valueType = valueType ?? throw new JsonException("InputNullableType must have value type");

            var nullableType = new InputNullableType(valueType)
            {
                Decorators = decorators ?? []
            };
            if (id != null)
            {
                resolver.AddReference(id, nullableType);
            }
            return nullableType;
        }

        public override void Write(Utf8JsonWriter writer, InputNullableType value, JsonSerializerOptions options)
            => writer.WriteObjectOrReference(value, options, _referenceHandler.CurrentResolver, WriteInputNullableTypeProperties);

        private static void WriteInputNullableTypeProperties(Utf8JsonWriter writer, InputNullableType value, JsonSerializerOptions options)
        {
            // kind
            writer.WriteString("kind", NullableKind);
            // type
            writer.WriteObject("type", value.Type, options);
            // namespace
            writer.WriteString("namespace", string.Empty); // swagger never supports namespace
        }
    }
}
