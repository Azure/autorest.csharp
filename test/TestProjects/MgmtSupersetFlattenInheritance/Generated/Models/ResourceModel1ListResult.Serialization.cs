// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using MgmtSupersetFlattenInheritance;

namespace MgmtSupersetFlattenInheritance.Models
{
    internal partial class ResourceModel1ListResult
    {
        internal static ResourceModel1ListResult DeserializeResourceModel1ListResult(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<ResourceModel1Data>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ResourceModel1Data> array = new List<ResourceModel1Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResourceModel1Data.DeserializeResourceModel1Data(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new ResourceModel1ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
