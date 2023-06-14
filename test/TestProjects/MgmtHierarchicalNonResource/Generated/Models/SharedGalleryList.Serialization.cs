// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtHierarchicalNonResource;

namespace MgmtHierarchicalNonResource.Models
{
    internal partial class SharedGalleryList
    {
        internal static SharedGalleryList DeserializeSharedGalleryList(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<SharedGalleryData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<SharedGalleryData> array = new List<SharedGalleryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SharedGalleryData.DeserializeSharedGalleryData(item));
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
            return new SharedGalleryList(value, nextLink.Value);
        }
    }
}
