// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputEnumTypeConverter : JsonConverter<InputEnumType>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputEnumTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputEnumType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputEnumType>(_referenceHandler.CurrentResolver) ?? CreateEnumType(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputEnumType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputEnumType CreateEnumType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null && name == null;
            string? crossLanguageDefinitionId = null;
            string? access = null;
            string? deprecation = null;
            string? description = null;
            string? usageString = null;
            bool isFixed = false;
            InputType? valueType = null;
            IReadOnlyList<InputEnumTypeValue>? values = null;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("crossLanguageDefinitionId", ref crossLanguageDefinitionId)
                    || reader.TryReadString("access", ref access)
                    || reader.TryReadString("deprecation", ref deprecation)
                    || reader.TryReadString("description", ref description)
                    || reader.TryReadString("usage", ref usageString)
                    || reader.TryReadBoolean("isFixed", ref isFixed)
                    || reader.TryReadWithConverter("valueType", options, ref valueType)
                    || reader.TryReadWithConverter("values", options, ref values)
                    || reader.TryReadWithConverter("decorators", options, ref decorators);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException("Enum must have name");
            // TODO: roll back to throw JSON error when there is linter on the upstream to check enum without @doc
            //description = description ?? throw new JsonException("Enum must have a description");
            if (description.IsNullOrEmpty())
            {
                Console.Error.WriteLine($"[Warn]: Enum '{name}' must have a description");
                description = $"The {name}.";
            }

            if (!Enum.TryParse<InputModelTypeUsage>(usageString, out var usage))
            {
                throw new JsonException($"Cannot parse usage {usageString}");
            }

            if (values == null || values.Count == 0)
            {
                throw new JsonException("Enum must have at least one value");
            }

            if (valueType is not InputPrimitiveType inputValueType)
            {
                throw new JsonException("The ValueType of an EnumType must be a primitive type.");
            }

            var enumType = new InputEnumType(name, crossLanguageDefinitionId ?? string.Empty, access, deprecation, description!, usage, inputValueType, values, !isFixed)
            {
                Decorators = decorators ?? []
            };
            if (id != null)
            {
                resolver.AddReference(id, enumType);
            }
            return enumType;
        }
    }
}
