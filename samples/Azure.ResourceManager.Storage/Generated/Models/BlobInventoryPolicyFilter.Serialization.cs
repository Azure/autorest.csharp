// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobInventoryPolicyFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(PrefixMatch))
            {
                writer.WritePropertyName("prefixMatch"u8);
                writer.WriteStartArray();
                foreach (var item in PrefixMatch)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(BlobTypes))
            {
                writer.WritePropertyName("blobTypes"u8);
                writer.WriteStartArray();
                foreach (var item in BlobTypes)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(IncludeBlobVersions))
            {
                writer.WritePropertyName("includeBlobVersions"u8);
                writer.WriteBooleanValue(IncludeBlobVersions.Value);
            }
            if (Optional.IsDefined(IncludeSnapshots))
            {
                writer.WritePropertyName("includeSnapshots"u8);
                writer.WriteBooleanValue(IncludeSnapshots.Value);
            }
            writer.WriteEndObject();
        }

        internal static BlobInventoryPolicyFilter DeserializeBlobInventoryPolicyFilter(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> prefixMatch = default;
            Optional<IList<string>> blobTypes = default;
            Optional<bool> includeBlobVersions = default;
            Optional<bool> includeSnapshots = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("prefixMatch"u8))
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
                    prefixMatch = array;
                    continue;
                }
                if (property.NameEquals("blobTypes"u8))
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
                    blobTypes = array;
                    continue;
                }
                if (property.NameEquals("includeBlobVersions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    includeBlobVersions = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("includeSnapshots"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    includeSnapshots = property.Value.GetBoolean();
                    continue;
                }
            }
            return new BlobInventoryPolicyFilter(Optional.ToList(prefixMatch), Optional.ToList(blobTypes), Optional.ToNullable(includeBlobVersions), Optional.ToNullable(includeSnapshots));
        }
    }
}
