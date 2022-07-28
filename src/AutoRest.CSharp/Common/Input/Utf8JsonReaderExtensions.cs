// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal static class Utf8JsonReaderExtensions
    {
        public static bool TryReadReferenceId(this ref Utf8JsonReader reader, ref bool isFirstProperty, ref string? value)
        {
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            if (reader.GetString() != "$id")
            {
                return false;
            }

            if (!isFirstProperty)
            {
                throw new JsonException("$id should be the first defined property");
            }

            isFirstProperty = true;

            reader.Read();
            value = reader.GetString() ?? throw new JsonException();
            reader.Read();
            return true;
        }

        public static bool TryReadBoolean(this ref Utf8JsonReader reader, string propertyName, ref bool value)
        {
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            if (reader.GetString() != propertyName)
            {
                return false;
            }

            reader.Read();
            value = reader.GetBoolean();
            reader.Read();
            return true;
        }

        public static bool TryReadString(this ref Utf8JsonReader reader, string propertyName, ref string? value)
        {
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            if (reader.GetString() != propertyName)
            {
                return false;
            }

            reader.Read();
            value = reader.GetString() ?? throw new JsonException();
            reader.Read();
            return true;
        }

        public static bool TryReadPrimitiveType(this ref Utf8JsonReader reader, string propertyName, ref InputPrimitiveType? value)
        {
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            if (reader.GetString() != propertyName)
            {
                return false;
            }

            reader.Read();
            value = CadlInputTypeConverter.CreatePrimitiveType(ref reader) ?? throw new JsonException();
            reader.Read();
            return true;
        }

        public static bool TryReadWithConverter<T>(this ref Utf8JsonReader reader, string propertyName, JsonSerializerOptions options, ref T? value)
        {
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            if (reader.GetString() != propertyName)
            {
                return false;
            }

            reader.Read();
            value = reader.ReadWithConverter<T>(options);
            return true;
        }

        public static T? ReadWithConverter<T>(this ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var converter = (JsonConverter<T>)options.GetConverter(typeof(T));
            var value = converter.Read(ref reader, typeof(T), options);
            reader.Read();
            return value;
        }

        public static T? ReadReferenceAndResolve<T>(this ref Utf8JsonReader reader, ReferenceResolver resolver) where T : class
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            reader.Read();

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            if (reader.GetString() != "$ref")
            {
                return null;
            }

            reader.Read();
            var idRef = reader.GetString() ?? throw new JsonException("$ref can't be null");
            var result = (T)resolver.ResolveReference(idRef ?? throw new JsonException());

            reader.Read();
            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return result;
        }
    }
}
