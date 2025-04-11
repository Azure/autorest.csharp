// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputPrimitiveTypeConverter : JsonConverter<InputPrimitiveType>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputPrimitiveTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputPrimitiveType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputPrimitiveType>(_referenceHandler.CurrentResolver) ?? CreatePrimitiveType(ref reader, null, null, null, options, _referenceHandler.CurrentResolver);

        public static InputPrimitiveType CreatePrimitiveType(ref Utf8JsonReader reader, string? id, string? kind, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null && kind == null && name == null;
            string? crossLanguageDefinitionId = null;
            string? encode = null;
            InputPrimitiveType? baseType = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("kind", ref kind)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("crossLanguageDefinitionId", ref crossLanguageDefinitionId)
                    || reader.TryReadString("encode", ref encode)
                    || reader.TryReadComplexType("baseType", options, ref baseType);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            kind = kind ?? throw new JsonException("Primitive types must have kind");
            name = name ?? string.Empty;
            crossLanguageDefinitionId = crossLanguageDefinitionId ?? string.Empty;

            if (!Enum.TryParse<InputPrimitiveTypeKind>(kind, true, out var primitiveTypeKind))
            {
                throw new JsonException($"Unknown primitive type kind: {kind}");
            }

            var primitiveType = new InputPrimitiveType(primitiveTypeKind, name, crossLanguageDefinitionId, encode, baseType);
            if (id != null)
            {
                resolver.AddReference(id, primitiveType);
            }
            return primitiveType;
        }

        public override void Write(Utf8JsonWriter writer, InputPrimitiveType value, JsonSerializerOptions options)
        {
            var id = _referenceHandler.CurrentResolver.GetReference(value, out var alreadyExists);
            if (alreadyExists)
            {
                writer.WriteObjectReference(id);
                return;
            }

            // if not exist
            writer.WriteStartObject();

            // the first property should always be the id
            writer.WriteReferenceId(id);
            // then we write the kind
            writer.WriteString("kind", value.Kind.ToString().FirstCharToLowerCase());
            // name
            writer.WriteString("name", value.Name);
            // encode
            writer.WriteStringIfPresent("encode", value.Encode);
            // crossLanguageDefinitionId
            writer.WriteString("crossLanguageDefinitionId", value.CrossLanguageDefinitionId);
            // baseType
            writer.WriteObjectIfPresent("baseType", value.BaseType, options);
            // decorators
            writer.WriteArray("decorators", value.Decorators, options);

            writer.WriteEndObject();
        }
    }
}
