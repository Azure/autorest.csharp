﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class CadlInputEnumTypeConverter : JsonConverter<InputEnumType>
    {
        private readonly CadlReferenceHandler _referenceHandler;

        public CadlInputEnumTypeConverter(CadlReferenceHandler referenceHandler)
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
            string? ns = null;
            string? accessibility = null;
            string? description = null;
            InputModelTypeUsage usage = InputModelTypeUsage.None;
            string? usageString = null;
            bool isExtendable = false;
            InputPrimitiveType? valueType = null;
            IReadOnlyList<InputEnumTypeValue>? allowedValues = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputEnumType.Name), ref name)
                    || reader.TryReadString(nameof(InputEnumType.Namespace), ref ns)
                    || reader.TryReadString(nameof(InputEnumType.Accessibility), ref accessibility)
                    || reader.TryReadString(nameof(InputEnumType.Description), ref description)
                    || reader.TryReadString(nameof(InputEnumType.Usage), ref usageString)
                    || reader.TryReadBoolean(nameof(InputEnumType.IsExtensible), ref isExtendable)
                    || reader.TryReadPrimitiveType(nameof(InputEnumType.EnumValueType), ref valueType)
                    || reader.TryReadWithConverter(nameof(InputEnumType.AllowedValues), options, ref allowedValues);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException("Enum must have name");
            // TODO: roll back to throw JSON error when there is linter on the upstream to check enum without @doc
            //description = description ?? throw new JsonException("Enum must have a description");
            if (description == null)
            {
                description = "";
                System.Console.Error.WriteLine($"[Warn]: Enum '{name}' must have a description");
            }

            if (usageString != null)
            {
                Enum.TryParse<InputModelTypeUsage>(usageString, ignoreCase: true, out usage);
            }

            if (allowedValues == null || allowedValues.Count == 0)
            {
                throw new JsonException("Enum must have at least one value");
            }

            var enumType = new InputEnumType(name, ns, accessibility, description, usage, valueType ?? InputPrimitiveType.Int32, allowedValues, isExtendable);
            if (id != null)
            {
                resolver.AddReference(id, enumType);
            }
            return enumType;
        }
    }
}
