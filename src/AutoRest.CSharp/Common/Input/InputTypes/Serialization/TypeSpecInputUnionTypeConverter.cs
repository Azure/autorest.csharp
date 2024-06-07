﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal class TypeSpecInputUnionTypeConverter : JsonConverter<InputUnionType>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;
        public TypeSpecInputUnionTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputUnionType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputUnionType>(_referenceHandler.CurrentResolver) ?? CreateInputUnionType(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputUnionType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputUnionType CreateInputUnionType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            bool isNullable = false;
            var variantTypes = new List<InputType>();
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputUnionType.Name), ref name)
                    || reader.TryReadBoolean(nameof(InputUnionType.IsNullable), ref isNullable)
                    || reader.TryReadWithConverter(nameof(InputUnionType.VariantTypes), options, ref variantTypes);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException($"{nameof(InputUnionType)} must have a name.");
            if (variantTypes == null || variantTypes.Count == 0)
            {
                throw new JsonException("Union must have variant types.");
            }

            var unionType = new InputUnionType(name, variantTypes, isNullable);
            if (id != null)
            {
                resolver.AddReference(id, unionType);
            }
            return unionType;
        }
    }
}
