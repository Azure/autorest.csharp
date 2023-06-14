// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtHierarchicalNonResource.Models
{
    internal partial class SharedGalleryImageVersionList
    {
        internal static SharedGalleryImageVersionList DeserializeSharedGalleryImageVersionList(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<SharedGalleryImageVersion> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<SharedGalleryImageVersion> array = new List<SharedGalleryImageVersion>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SharedGalleryImageVersion.DeserializeSharedGalleryImageVersion(item));
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
            return new SharedGalleryImageVersionList(value, nextLink.Value);
        }
    }
}
