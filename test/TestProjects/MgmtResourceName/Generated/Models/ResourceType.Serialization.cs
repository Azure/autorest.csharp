// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtResourceName.Models
{
    public partial class ResourceType
    {
        internal static ResourceType DeserializeResourceType(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> displayName = default;
            Optional<IReadOnlyList<ResourceOperation>> operations = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("displayName"u8))
                {
                    displayName = property.Value.GetString();
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
            }
            return new ResourceType(name.Value, displayName.Value, Optional.ToList(operations));
        }
    }
}
