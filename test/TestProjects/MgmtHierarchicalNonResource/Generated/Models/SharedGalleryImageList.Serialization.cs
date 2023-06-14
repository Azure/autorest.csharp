// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtHierarchicalNonResource.Models
{
    internal partial class SharedGalleryImageList
    {
        internal static SharedGalleryImageList DeserializeSharedGalleryImageList(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<SharedGalleryImage> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<SharedGalleryImage> array = new List<SharedGalleryImage>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SharedGalleryImage.DeserializeSharedGalleryImage(item));
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
            return new SharedGalleryImageList(value, nextLink.Value);
        }
    }
}
