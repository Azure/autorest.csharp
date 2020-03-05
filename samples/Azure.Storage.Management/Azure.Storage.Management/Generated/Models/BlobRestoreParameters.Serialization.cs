// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    public partial class BlobRestoreParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("timeToRestore");
            writer.WriteStringValue(TimeToRestore, "S");
            writer.WritePropertyName("blobRanges");
            writer.WriteStartArray();
            foreach (var item in BlobRanges)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static BlobRestoreParameters DeserializeBlobRestoreParameters(JsonElement element)
        {
            BlobRestoreParameters result = new BlobRestoreParameters();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("timeToRestore"))
                {
                    result.TimeToRestore = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("blobRanges"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.BlobRanges.Add(BlobRestoreRange.DeserializeBlobRestoreRange(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
