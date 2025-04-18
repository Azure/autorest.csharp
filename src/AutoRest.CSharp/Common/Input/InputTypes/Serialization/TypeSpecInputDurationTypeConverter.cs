﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal class TypeSpecInputDurationTypeConverter : JsonConverter<InputDurationType>
    {
        internal const string DurationKind = "duration";

        private readonly TypeSpecReferenceHandler _referenceHandler;
        public TypeSpecInputDurationTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputDurationType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
           => reader.ReadReferenceAndResolve<InputDurationType>(_referenceHandler.CurrentResolver) ?? CreateDurationType(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public static InputDurationType CreateDurationType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            string? crossLanguageDefinitionId = null;
            string? encode = null;
            InputPrimitiveType? wireType = null;
            InputDurationType? baseType = null;
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

            name = name ?? throw new JsonException("Duration type must have name");
            crossLanguageDefinitionId = crossLanguageDefinitionId ?? throw new JsonException("Duration type must have crossLanguageDefinitionId");
            encode = encode ?? throw new JsonException("Duration type must have encode");
            wireType = wireType ?? throw new JsonException("Duration type must have wireType");

            var dateTimeType = new InputDurationType(CreateDurationKnownEncoding(encode), name, crossLanguageDefinitionId, wireType, baseType) { Decorators = decorators ?? [] };

            if (id != null)
            {
                resolver.AddReference(id, dateTimeType);
            }
            return dateTimeType;
        }

        private const string DurationConstantEncode = "duration-constant";

        private static DurationKnownEncoding CreateDurationKnownEncoding(string encode)
        {
            if (encode == DurationConstantEncode)
            {
                return DurationKnownEncoding.DurationConstant;
            }
            if (Enum.TryParse<DurationKnownEncoding>(encode, ignoreCase: true, out var encodeKind))
            {
                return encodeKind;
            }
            throw new JsonException($"Encoding of Duration type {encode} is unknown.");
        }

        public override void Write(Utf8JsonWriter writer, InputDurationType value, JsonSerializerOptions options)
            => writer.WriteObjectOrReference(value, options, _referenceHandler.CurrentResolver, WriteInputDurationTypeProperties);

        private static void WriteInputDurationTypeProperties(Utf8JsonWriter writer, InputDurationType value, JsonSerializerOptions options)
        {
            // kind
            writer.WriteString("kind", DurationKind);
            // name
            writer.WriteString("name", value.Name);
            // encode
            writer.WriteString("encode", value.Encode switch
            {
                DurationKnownEncoding.DurationConstant => DurationConstantEncode,
                _ => value.Encode.ToString().ToLowerInvariant(),
            });
            // wireType
            writer.WriteObject("wireType", value.WireType, options);
            // crossLanguageDefinitionId
            writer.WriteString("crossLanguageDefinitionId", value.CrossLanguageDefinitionId);
            // baseType
            writer.WriteObjectIfPresent("baseType", value.BaseType, options);
            // decorators
            writer.WriteArray("decorators", value.Decorators, options);
        }
    }
}
