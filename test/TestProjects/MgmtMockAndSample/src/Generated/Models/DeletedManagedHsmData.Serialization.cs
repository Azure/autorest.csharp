// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class DeletedManagedHsmData
    {
        internal static DeletedManagedHsmData DeserializeDeletedManagedHsmData(JsonElement element)
        {
            Optional<DeletedManagedHsmProperties> properties = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    properties = DeletedManagedHsmProperties.DeserializeDeletedManagedHsmProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
            }
            return new DeletedManagedHsmData(id, name, type, systemData.Value, properties.Value);
        }
    }
}
