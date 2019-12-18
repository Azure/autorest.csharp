// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml;

namespace Azure.Core
{
    internal static class JsonElementExtensions
    {
        public static object? GetObject(in this JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    return element.GetInt32();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.Object:
                    var dictionary = new Dictionary<string, object?>();
                    foreach (JsonProperty jsonProperty in element.EnumerateObject())
                    {
                        dictionary.Add(jsonProperty.Name, jsonProperty.Value.GetObject());
                    }
                    return dictionary;
                default:
                    throw new NotSupportedException("Not supported value kind " + element.ValueKind);
            }
        }

        public static DateTimeOffset GetDateTimeOffset(in this JsonElement element, string format) => format switch
        {
            "D" => element.GetDateTimeOffset(),
            "S" => element.GetDateTimeOffset(),
            "R" => DateTimeOffset.Parse(element.GetString()),
            "U" => DateTimeOffset.FromUnixTimeSeconds(element.GetInt64()),
            _ => throw new ArgumentException("Format is not supported", nameof(format))
        };

        public static TimeSpan GetTimeSpan(in this JsonElement element, string format) => format switch
        {
            "P" => XmlConvert.ToTimeSpan(element.GetString()),
            _ => throw new ArgumentException("Format is not supported", nameof(format))
        };
    }
}
