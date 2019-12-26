// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace AppConfiguration.Models.V10
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
            KeyValue result = new KeyValue();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("key"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Key = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("label"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Label = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("content_type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ContentType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Value = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("last_modified"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.LastModified = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("tags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Tags = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        result.Tags.Add(property0.Name, property0.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("locked"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Locked = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("etag"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Etag = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
