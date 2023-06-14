// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageSkuInformation
    {
        internal static StorageSkuInformation DeserializeStorageSkuInformation(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            StorageSkuName name = default;
            Optional<StorageSkuTier> tier = default;
            Optional<ResourceType> resourceType = default;
            Optional<StorageKind> kind = default;
            Optional<IReadOnlyList<string>> locations = default;
            Optional<IReadOnlyList<SKUCapability>> capabilities = default;
            Optional<IReadOnlyList<Restriction>> restrictions = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = new StorageSkuName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tier"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tier = property.Value.GetString().ToStorageSkuTier();
                    continue;
                }
                if (property.NameEquals("resourceType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceType = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    kind = new StorageKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("locations"u8))
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
                    locations = array;
                    continue;
                }
                if (property.NameEquals("capabilities"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<SKUCapability> array = new List<SKUCapability>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SKUCapability.DeserializeSKUCapability(item));
                    }
                    capabilities = array;
                    continue;
                }
                if (property.NameEquals("restrictions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Restriction> array = new List<Restriction>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Restriction.DeserializeRestriction(item));
                    }
                    restrictions = array;
                    continue;
                }
            }
            return new StorageSkuInformation(name, Optional.ToNullable(tier), Optional.ToNullable(resourceType), Optional.ToNullable(kind), Optional.ToList(locations), Optional.ToList(capabilities), Optional.ToList(restrictions));
        }
    }
}
