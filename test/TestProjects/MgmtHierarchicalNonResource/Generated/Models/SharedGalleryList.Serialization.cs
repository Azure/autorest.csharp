// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
            IReadOnlyList<SharedGalleryData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    List<SharedGalleryData> array = new List<SharedGalleryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SharedGalleryData.DeserializeSharedGalleryData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new SharedGalleryList(value, nextLink.Value);
        }
    }
}
