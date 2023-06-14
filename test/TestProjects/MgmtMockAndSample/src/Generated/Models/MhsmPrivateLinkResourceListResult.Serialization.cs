// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    internal partial class MhsmPrivateLinkResourceListResult
    {
        internal static MhsmPrivateLinkResourceListResult DeserializeMhsmPrivateLinkResourceListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<MhsmPrivateLinkResource>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MhsmPrivateLinkResource> array = new List<MhsmPrivateLinkResource>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MhsmPrivateLinkResource.DeserializeMhsmPrivateLinkResource(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new MhsmPrivateLinkResourceListResult(Optional.ToList(value));
        }
    }
}
