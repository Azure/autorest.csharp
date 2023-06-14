// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class LastAccessTimeTrackingPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("enable"u8);
            writer.WriteBooleanValue(Enable);
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name.Value.ToString());
            }
            if (Optional.IsDefined(TrackingGranularityInDays))
            {
                writer.WritePropertyName("trackingGranularityInDays"u8);
                writer.WriteNumberValue(TrackingGranularityInDays.Value);
            }
            if (Optional.IsCollectionDefined(BlobType))
            {
                writer.WritePropertyName("blobType"u8);
                writer.WriteStartArray();
                foreach (var item in BlobType)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static LastAccessTimeTrackingPolicy DeserializeLastAccessTimeTrackingPolicy(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool enable = default;
            Optional<Name> name = default;
            Optional<int> trackingGranularityInDays = default;
            Optional<IList<string>> blobType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enable"u8))
                {
                    enable = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    name = new Name(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("trackingGranularityInDays"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    trackingGranularityInDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("blobType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    blobType = array;
                    continue;
                }
            }
            return new LastAccessTimeTrackingPolicy(enable, Optional.ToNullable(name), Optional.ToNullable(trackingGranularityInDays), Optional.ToList(blobType));
        }
    }
}
