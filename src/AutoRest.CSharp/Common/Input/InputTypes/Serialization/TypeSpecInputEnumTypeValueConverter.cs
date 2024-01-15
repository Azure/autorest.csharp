// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputEnumTypeValueConverter : JsonConverter<IEnumTypeValue>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputEnumTypeValueConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override IEnumTypeValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<IEnumTypeValue>(_referenceHandler.CurrentResolver) ?? CreateEnumTypeValue(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, IEnumTypeValue value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static IEnumTypeValue CreateEnumTypeValue(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            object? value = null;
            string? description = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(IEnumTypeValue.Name), ref name)
                    || reader.TryReadEnumValue(nameof(IEnumTypeValue.Value), ref value)
                    || reader.TryReadString(nameof(IEnumTypeValue.Description), ref description);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException("EnumValue must have name");

            value = value ?? throw new JsonException("EnumValue must have value");

            var enumValue = new InputEnumTypeValue(name, value, description);
            if (id != null)
            {
                resolver.AddReference(id, enumValue);
            }
            return enumValue;
        }
    }
}
