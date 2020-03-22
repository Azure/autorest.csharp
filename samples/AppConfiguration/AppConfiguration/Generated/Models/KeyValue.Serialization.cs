// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace AppConfiguration.Models
{
    public partial class KeyValue : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Key != null)
            {
                writer.WritePropertyName("key");
                writer.WriteStringValue(Key);
            }
            if (Label != null)
            {
                writer.WritePropertyName("label");
                writer.WriteStringValue(Label);
            }
            if (ContentType != null)
            {
                writer.WritePropertyName("content_type");
                writer.WriteStringValue(ContentType);
            }
            if (Value != null)
            {
                writer.WritePropertyName("value");
                writer.WriteStringValue(Value);
            }
            if (LastModified != null)
            {
                writer.WritePropertyName("last_modified");
                writer.WriteStringValue(LastModified.Value, "S");
            }
            if (Tags != null)
            {
                writer.WritePropertyName("tags");
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Locked != null)
            {
                writer.WritePropertyName("locked");
                writer.WriteBooleanValue(Locked.Value);
            }
            if (Etag != null)
            {
                writer.WritePropertyName("etag");
                writer.WriteStringValue(Etag);
            }
            writer.WriteEndObject();
        }

        internal static KeyValue DeserializeKeyValue(JsonElement element)
        {
            string key = default;
            string label = default;
            string contentType = default;
            string value = default;
            DateTimeOffset? lastModified = default;
            IDictionary<string, string> tags = default;
            bool? locked = default;
            string etag = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("key"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    key = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("label"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    label = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("content_type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    contentType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    value = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("last_modified"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastModified = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("tags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("locked"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    locked = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("etag"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    etag = property.Value.GetString();
                    continue;
                }
            }
            return new KeyValue(key, label, contentType, value, lastModified, tags, locked, etag);
        }
    }
}
