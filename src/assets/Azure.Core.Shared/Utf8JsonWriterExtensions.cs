// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core
{
    internal static class Utf8JsonWriterExtensions
    {
        public static void WriteStringValue(this Utf8JsonWriter writer, DateTimeOffset value, string format = "S") =>
            writer.WriteStringValue(TypeFormatters.ToString(value, format));

        public static void WriteStringValue(this Utf8JsonWriter writer, TimeSpan value, string format = "P") =>
            writer.WriteStringValue(TypeFormatters.ToString(value, format));

        public static void WriteObjectValue(this Utf8JsonWriter writer, IUtf8JsonSerializable value)
        {
            value.Write(writer);
        }
        public static void WriteObjectValue(this Utf8JsonWriter writer, object value)
        {
            switch (value)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                case IUtf8JsonSerializable serializable:
                    writer.WriteObjectValue(serializable);
                    break;
                case byte[] bytes:
                    writer.WriteStringValue(Convert.ToBase64String(bytes));
                    break;
                case int i:
                    writer.WriteNumberValue(i);
                    break;
                case decimal d:
                    writer.WriteNumberValue(d);
                    break;
                case double d:
                    writer.WriteNumberValue(d);
                    break;
                case float f:
                    writer.WriteNumberValue(f);
                    break;
                case string s:
                    writer.WriteStringValue(s);
                    break;
                case bool b:
                    writer.WriteBooleanValue(b);
                    break;
                case DateTimeOffset dateTimeOffset:
                    writer.WriteStringValue(dateTimeOffset,"S");
                    break;
                case IEnumerable<KeyValuePair<string, object>> enumerable:
                    writer.WriteStartObject();
                    foreach (KeyValuePair<string, object> pair in enumerable)
                    {
                        writer.WritePropertyName(pair.Key);
                        writer.WriteObjectValue(pair.Value);
                    }
                    writer.WriteEndObject();
                    break;
                case IEnumerable<object> objectEnumerable:
                    writer.WriteStartArray();
                    foreach (object item in objectEnumerable)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                    break;

                default:
                    throw new NotSupportedException("Not supported type " + value.GetType());
            }
        }
    }
}
