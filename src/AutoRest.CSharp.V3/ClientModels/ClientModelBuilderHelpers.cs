// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientModelBuilderHelpers
    {
        public static ClientConstant StringConstant(string s) => ParseClientConstant(s, new FrameworkTypeReference(typeof(string)));

        public static ClientTypeReference CreateType(Schema schema, bool isNullable) => schema switch
        {
            BinarySchema _ => (ClientTypeReference)new BinaryTypeReference(isNullable),
            ByteArraySchema _ => new BinaryTypeReference(isNullable),
            //https://devblogs.microsoft.com/dotnet/do-more-with-patterns-in-c-8-0/
            { Type: AllSchemaTypes.Binary } => new BinaryTypeReference(false),
            ArraySchema array => new CollectionTypeReference(CreateType(array.ElementType, false), isNullable),
            DictionarySchema dictionary => new DictionaryTypeReference(new FrameworkTypeReference(typeof(string)), CreateType(dictionary.ElementType, isNullable)),
            NumberSchema number => new FrameworkTypeReference(number.ToFrameworkType(), isNullable),
            _ when schema.Type.ToFrameworkCSharpType() is Type type => new FrameworkTypeReference(type, isNullable),
            _ => new SchemaTypeReference(schema, isNullable)
        };

        public static ClientConstant ParseClientConstant(object? value, ClientTypeReference type)
        {
            var normalizedValue = type switch
            {
                BinaryTypeReference _ when value is string base64String => Convert.FromBase64String(base64String),
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
            UnixTimeSchema _ => SerializationFormat.DateTime_Unix,
            DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTime => SerializationFormat.DateTime_ISO8601,
            DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTimeRfc1123 => SerializationFormat.DateTime_RFC1123,
            DateSchema _ => SerializationFormat.Date_ISO8601,
            DurationSchema _ => SerializationFormat.Duration_ISO8601,
            _ => SerializationFormat.Default
        };
    }
}
