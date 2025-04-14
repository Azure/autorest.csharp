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
        internal const string UnionKind = "union";

        private readonly TypeSpecReferenceHandler _referenceHandler;
        public TypeSpecInputUnionTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputUnionType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputUnionType>(_referenceHandler.CurrentResolver) ?? CreateInputUnionType(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public static InputUnionType CreateInputUnionType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            var variantTypes = new List<InputType>();
            IReadOnlyList<InputDecoratorInfo>? decorators = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadComplexType("variantTypes", options, ref variantTypes)
                    || reader.TryReadComplexType("decorators", options, ref decorators);

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

            var unionType = new InputUnionType(name, variantTypes) { Decorators = decorators ?? Array.Empty<InputDecoratorInfo>() };
            if (id != null)
            {
                resolver.AddReference(id, unionType);
            }
            return unionType;
        }

        public override void Write(Utf8JsonWriter writer, InputUnionType value, JsonSerializerOptions options)
            => writer.WriteObjectOrReference(value, options, _referenceHandler.CurrentResolver, WriteInputUnionTypeProperties);

        private static void WriteInputUnionTypeProperties(Utf8JsonWriter writer, InputUnionType value, JsonSerializerOptions options)
        {
            // kind
            writer.WriteString("kind", UnionKind);
            // name
            writer.WriteString("name", value.Name);
            // variantTypes
            writer.WriteArray("variantTypes", value.VariantTypes, options);
            // namespace
            writer.WriteString("namespace", string.Empty); // swagger never has namespaces
            // decorators
            writer.WriteArray("decorators", value.Decorators, options);
        }
    }
}
