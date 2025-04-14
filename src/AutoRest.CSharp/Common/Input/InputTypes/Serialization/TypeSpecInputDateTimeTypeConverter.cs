// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal class TypeSpecInputDateTimeTypeConverter : JsonConverter<InputDateTimeType>
    {
        internal const string UtcDateTimeKind = "utcDateTime";
        internal const string OffsetDateTimeKind = "offsetDateTime";

        private readonly TypeSpecReferenceHandler _referenceHandler;
        public TypeSpecInputDateTimeTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputDateTimeType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
           => reader.ReadReferenceAndResolve<InputDateTimeType>(_referenceHandler.CurrentResolver) ?? CreateDateTimeType(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public static InputDateTimeType CreateDateTimeType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            string? crossLanguageDefinitionId = null;
            string? encode = null;
            InputPrimitiveType? wireType = null;
            InputDateTimeType? baseType = null;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("crossLanguageDefinitionId", ref crossLanguageDefinitionId)
                    || reader.TryReadString("encode", ref encode)
                    || reader.TryReadComplexType("wireType", options, ref wireType)
                    || reader.TryReadComplexType("baseType", options, ref baseType)
                    || reader.TryReadComplexType("decorators", options, ref decorators);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException("DateTime type must have name");
            crossLanguageDefinitionId = crossLanguageDefinitionId ?? throw new JsonException("DateTime type must have crossLanguageDefinitionId");
            encode = encode ?? throw new JsonException("DateTime type must have encoding");
            wireType = wireType ?? throw new JsonException("DateTime type must have wireType");

            var dateTimeType = Enum.TryParse<DateTimeKnownEncoding>(encode, ignoreCase: true, out var encodeKind)
                ? new InputDateTimeType(encodeKind, name, crossLanguageDefinitionId, wireType, baseType)
                {
                    Decorators = decorators ?? Array.Empty<InputDecoratorInfo>()
                }
                : throw new JsonException($"Encoding of DateTime type {encode} is unknown.");

            if (id != null)
            {
                resolver.AddReference(id, dateTimeType);
            }
            return dateTimeType;
        }

        public override void Write(Utf8JsonWriter writer, InputDateTimeType value, JsonSerializerOptions options)
            => writer.WriteObjectOrReference<InputDateTimeType>(value, options, _referenceHandler.CurrentResolver, WriteInputDateTimeType);

        private static void WriteInputDateTimeType(Utf8JsonWriter writer, InputDateTimeType value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            // kind
            writer.WriteString("kind", UtcDateTimeKind); // TODO -- currently the two different kinds have exactly the same properties, therefore here we no longer have the ability to distinguish
            // name
            writer.WriteString("name", value.Name);
            // encode
            writer.WriteString("encode", value.Encode.ToString().FirstCharToLowerCase());
            // wireType
            writer.WriteObject("wireType", value.WireType, options);
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
