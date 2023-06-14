// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(PrivateLinkResourceListConverter))]
    public partial class PrivateLinkResourceList : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static PrivateLinkResourceList DeserializePrivateLinkResourceList(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<PrivateLinkResourceData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PrivateLinkResourceData> array = new List<PrivateLinkResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PrivateLinkResourceData.DeserializePrivateLinkResourceData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new PrivateLinkResourceList(Optional.ToList(value));
        }

        internal partial class PrivateLinkResourceListConverter : JsonConverter<PrivateLinkResourceList>
        {
            public override void Write(Utf8JsonWriter writer, PrivateLinkResourceList model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override PrivateLinkResourceList Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializePrivateLinkResourceList(document.RootElement);
            }
        }
    }
}
