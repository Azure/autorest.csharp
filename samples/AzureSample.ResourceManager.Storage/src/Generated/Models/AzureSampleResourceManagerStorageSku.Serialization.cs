// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace AzureSample.ResourceManager.Storage.Models
{
    public partial class AzureSampleResourceManagerStorageSku : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
            writer.WriteEndObject();
        }

        internal static AzureSampleResourceManagerStorageSku DeserializeAzureSampleResourceManagerStorageSku(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            AzureSampleResourceManagerStorageSkuName name = default;
            AzureSampleResourceManagerStorageSkuTier? tier = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = new AzureSampleResourceManagerStorageSkuName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tier"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tier = property.Value.GetString().ToAzureSampleResourceManagerStorageSkuTier();
                    continue;
                }
            }
            return new AzureSampleResourceManagerStorageSku(name, tier);
        }
    }
}
