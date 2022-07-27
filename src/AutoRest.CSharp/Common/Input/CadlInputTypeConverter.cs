// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class CadlInputTypeConverter : JsonConverter<InputType>
    {
        private const string InputTypeName = nameof(InputType.Name);
        private const string PrimitiveTypeKind = nameof(InputPrimitiveType.Kind);
        private const string ListElementType = nameof(InputListType.ElementType);
        private const string DictionaryKeyType = nameof(InputDictionaryType.KeyType);
        private const string DictionaryValueType = nameof(InputDictionaryType.ValueType);
        private const string EnumValueType = nameof(InputEnumType.EnumValueType);
        private const string EnumAllowedValues = nameof(InputEnumType.AllowedValues);

        private readonly CadlReferenceHandler _referenceHandler;

        public CadlInputTypeConverter(CadlReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return CreatePrimitiveType(ref reader);
            }

            return reader.ReadReferenceAndResolve<InputType>(_referenceHandler.CurrentResolver) ?? CreateObject(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, InputType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private InputType CreateObject(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            string? id = null;
            string? name = null;
            InputType? result = null;
            var isFirstProperty = true;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isIdOrName = reader.TryReadReferenceId(ref isFirstProperty, ref id) || reader.TryReadString(nameof(InputModelProperty.Name), ref name);

                if (isIdOrName)
                {
                    continue;
                }

                var propertyName = reader.GetString();
                result = CreateDerivedType(ref reader, propertyName, name, id, options);
            }

            return result ?? CadlInputModelTypeConverter.CreateModelType(ref reader, id, name, options, _referenceHandler.CurrentResolver);
        }

        private InputType CreateDerivedType(ref Utf8JsonReader reader, string? propertyName, string? name, string? id, JsonSerializerOptions options) => propertyName switch
        {
            PrimitiveTypeKind   => ReadPrimitiveType(ref reader),
            ListElementType     => CadlInputListTypeConverter.CreateListType(ref reader, id, name, options),
            DictionaryKeyType   => CadlInputDictionaryTypeConverter.CreateDictionaryType(ref reader, id, name, options),
            DictionaryValueType => CadlInputDictionaryTypeConverter.CreateDictionaryType(ref reader, id, name, options),
            EnumValueType       => CadlInputEnumTypeConverter.CreateEnumType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            EnumAllowedValues   => CadlInputEnumTypeConverter.CreateEnumType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            "" or null          => throw new JsonException("Property name can't be null or empty"),
            _                   => CadlInputModelTypeConverter.CreateModelType(ref reader, id, name, options, _referenceHandler.CurrentResolver)
        };

        public static InputPrimitiveType ReadPrimitiveType(ref Utf8JsonReader reader)
        {
            reader.Read();
            var type = CreatePrimitiveType(ref reader);
            reader.Read();
            return type;
        }

        public static InputPrimitiveType CreatePrimitiveType(ref Utf8JsonReader reader)
        {
            var stringValue = reader.GetString();
            return Enum.TryParse<InputTypeKind>(stringValue, ignoreCase: true, out var kind)
                ? new InputPrimitiveType(kind)
                : throw new InvalidOperationException($"{stringValue} type is unknown.");
        }
    }
}
