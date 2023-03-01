// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtResourceName.Models;

namespace MgmtResourceName
{
    public partial class ProviderOperationData
    {
        internal static ProviderOperationData DeserializeProviderOperationData(JsonElement element)
        {
            Optional<string> displayName = default;
            Optional<IReadOnlyList<Models.ResourceType>> resourceTypes = default;
            Optional<IReadOnlyList<ResourceOperation>> operations = default;
            ResourceIdentifier id = default;
            string name = default;
            Azure.Core.ResourceType type = default;
            Optional<SystemData> systemData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("displayName"u8))
                {
                    displayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("resourceTypes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Models.ResourceType> array = new List<Models.ResourceType>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Models.ResourceType.DeserializeResourceType(item));
                    }
                    resourceTypes = array;
                    continue;
                }
                if (property.NameEquals("operations"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ResourceOperation> array = new List<ResourceOperation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResourceOperation.DeserializeResourceOperation(item));
                    }
                    operations = array;
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new Azure.Core.ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
            }
            return new ProviderOperationData(id, name, type, systemData.Value, displayName.Value, Optional.ToList(resourceTypes), Optional.ToList(operations));
        }
    }
}
