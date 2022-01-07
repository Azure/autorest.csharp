// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtExpandResourceTypes.Models
{
    public partial class DnsResourceReference
    {
        internal static DnsResourceReference DeserializeDnsResourceReference(JsonElement element)
        {
            Optional<IReadOnlyList<WritableSubResource>> dnsResources = default;
            Optional<WritableSubResource> targetResource = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("dnsResources"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<WritableSubResource> array = new List<WritableSubResource>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.ToString()));
                    }
                    dnsResources = array;
                    continue;
                }
                if (property.NameEquals("targetResource"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    targetResource = JsonSerializer.Deserialize<WritableSubResource>(property.Value.ToString());
                    continue;
                }
            }
            return new DnsResourceReference(Optional.ToList(dnsResources), targetResource);
        }
    }
}
