// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobRestoreContent : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("timeToRestore"u8);
            writer.WriteStringValue(TimeToRestore, "O");
            writer.WritePropertyName("blobRanges"u8);
            writer.WriteStartArray();
            foreach (var item in BlobRanges)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static BlobRestoreContent DeserializeBlobRestoreContent(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DateTimeOffset timeToRestore = default;
            IList<BlobRestoreRange> blobRanges = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("timeToRestore"u8))
                {
                    timeToRestore = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("blobRanges"u8))
                {
                    List<BlobRestoreRange> array = new List<BlobRestoreRange>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BlobRestoreRange.DeserializeBlobRestoreRange(item));
                    }
                    blobRanges = array;
                    continue;
                }
            }
            return new BlobRestoreContent(timeToRestore, blobRanges);
        }
    }
}
