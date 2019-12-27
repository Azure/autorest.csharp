// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Xml;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientModelBuilderHelpers
    {
        public static ClientConstant StringConstant(string s) => ParseClientConstant(s, new FrameworkTypeReference(typeof(string)));

        public static ClientTypeReference CreateType(Schema schema, bool isNullable) => schema switch
        {
            ConstantSchema constantSchema => CreateType(constantSchema.ValueType, isNullable),
            BinarySchema _ => new FrameworkTypeReference(typeof(byte[]), isNullable),
            ByteArraySchema _ => new FrameworkTypeReference(typeof(byte[]), isNullable),
            ArraySchema array => new CollectionTypeReference(CreateType(array.ElementType, false), isNullable),
            DictionarySchema dictionary => new DictionaryTypeReference(new FrameworkTypeReference(typeof(string)), CreateType(dictionary.ElementType, false), isNullable),
            NumberSchema number => new FrameworkTypeReference(ToFrameworkNumberType(number), isNullable),
            _ when ToFrameworkType(schema.Type) is Type type => new FrameworkTypeReference(type, isNullable),
            _ => new SchemaTypeReference(schema, isNullable)
        };

        public static ClientConstant ParseClientConstant(object? value, ClientTypeReference type)
        {
            var normalizedValue = type switch
            {
                FrameworkTypeReference frameworkType when
                    frameworkType.Type == typeof(byte[]) &&
                    value is string base64String => Convert.FromBase64String(base64String),
                FrameworkTypeReference frameworkType when
                    frameworkType.Type == typeof(DateTimeOffset) &&
                    value is string dateTimeString => DateTimeOffset.Parse(dateTimeString, styles: DateTimeStyles.AssumeUniversal),
                FrameworkTypeReference frameworkType => Convert.ChangeType(value, frameworkType.Type),
                _ => null
            };
            return new ClientConstant(normalizedValue, type);
        }

        public static SerializationFormat GetSerializationFormat(Schema schema) => schema switch
        {
            ByteArraySchema byteArraySchema when byteArraySchema.Format == ByteArraySchemaFormat.Base64url => SerializationFormat.Bytes_Base64Url,
            UnixTimeSchema _ => SerializationFormat.DateTime_Unix,
            DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTime => SerializationFormat.DateTime_ISO8601,
            DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTimeRfc1123 => SerializationFormat.DateTime_RFC1123,
            DateSchema _ => SerializationFormat.Date_ISO8601,
            DurationSchema _ => SerializationFormat.Duration_ISO8601,
            _ => SerializationFormat.Default
        };


        private static Type? ToFrameworkType(AllSchemaTypes schemaType) => schemaType switch
        {
            AllSchemaTypes.Boolean => typeof(bool),
            AllSchemaTypes.ByteArray => null,
            AllSchemaTypes.Char => typeof(char),
            AllSchemaTypes.Date => typeof(DateTimeOffset),
            AllSchemaTypes.DateTime => typeof(DateTimeOffset),
            AllSchemaTypes.Duration => typeof(TimeSpan),
            AllSchemaTypes.OdataQuery => typeof(string),
            AllSchemaTypes.String => typeof(string),
            AllSchemaTypes.Unixtime => typeof(DateTimeOffset),
            AllSchemaTypes.Uri => typeof(Uri),
            AllSchemaTypes.Uuid => typeof(string),
            AllSchemaTypes.Any => typeof(object),
            AllSchemaTypes.Binary => typeof(byte[]),
            _ => null
        };

        private static Type ToFrameworkNumberType(NumberSchema schema) => schema.Type switch
        {
            AllSchemaTypes.Number => schema.Precision switch
            {
                32 => typeof(float),
                128 => typeof(decimal),
                _ => typeof(double)
            },
            // Assumes AllSchemaTypes.Integer
            _ => schema.Precision switch
            {
                16 => typeof(short),
                64 => typeof(long),
                _ => typeof(int)
            }
        };

        public static ClientConstant ParseClientConstant(ConstantSchema constant)
        {
            return ParseClientConstant(constant.Value.Value, CreateType(constant.ValueType, constant.Value.Value == null));
        }

        public static XmlSerialization CreateXmlSerialization(Schema schema, bool isNullable, string? nameHint)
        {
            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return CreateXmlSerialization(constantSchema.ValueType, constantSchema.Value.Value == null, nameHint);
                case ArraySchema arraySchema:
                    string xmlName =
                        arraySchema.ElementType.Serialization?.Xml?.Name ??
                        nameHint ??
                        throw new ArgumentNullException(nameof(nameHint), "nameHint shouldn't be null for arrays");

                    return new XmlArraySerialization(
                        CreateType(arraySchema, false),
                        CreateXmlSerialization(arraySchema.ElementType, false, null),
                        xmlName);
                case DictionarySchema dictionarySchema:
                    return new XmlDictionarySerialization(
                        CreateType(dictionarySchema, false),
                        CreateXmlSerialization(dictionarySchema.ElementType, false, null));
                default:
                    return new XmlValueSerialization(
                        CreateType(schema, isNullable),
                        GetSerializationFormat(schema));
            }
        }

        public static JsonSerialization CreateJsonSerialization(Schema schema, bool isNullable)
        {
            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return CreateJsonSerialization(constantSchema.ValueType, constantSchema.Value.Value == null);
                case ArraySchema arraySchema:
                    return new JsonArraySerialization(CreateType(arraySchema, false), CreateJsonSerialization(arraySchema.ElementType, false));
                case DictionarySchema dictionarySchema:
                    var dictionaryElementTypeReference = new DictionaryTypeReference(
                        new FrameworkTypeReference(typeof(string)),
                        CreateType(dictionarySchema.ElementType, false),
                        false);

                    return new JsonObjectSerialization(dictionaryElementTypeReference, Array.Empty<JsonPropertySerialization>(),
                        new JsonDynamicPropertiesSerialization(CreateJsonSerialization(dictionarySchema.ElementType, false)));
                default:
                    return new JsonValueSerialization(CreateType(schema, isNullable), GetSerializationFormat(schema));
            }
        }
    }
}
