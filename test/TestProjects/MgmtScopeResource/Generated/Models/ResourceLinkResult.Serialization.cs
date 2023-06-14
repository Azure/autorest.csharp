// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtScopeResource;

namespace MgmtScopeResource.Models
{
    internal partial class ResourceLinkResult
    {
        internal static ResourceLinkResult DeserializeResourceLinkResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<ResourceLinkData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<ResourceLinkData> array = new List<ResourceLinkData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResourceLinkData.DeserializeResourceLinkData(item));
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
            return new ResourceLinkResult(value, nextLink.Value);
        }
    }
}
