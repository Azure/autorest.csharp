// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    internal partial class MgmtMockAndSamplePrivateLinkResourceListResult
    {
        internal static MgmtMockAndSamplePrivateLinkResourceListResult DeserializeMgmtMockAndSamplePrivateLinkResourceListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<MgmtMockAndSamplePrivateLinkResource>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MgmtMockAndSamplePrivateLinkResource> array = new List<MgmtMockAndSamplePrivateLinkResource>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MgmtMockAndSamplePrivateLinkResource.DeserializeMgmtMockAndSamplePrivateLinkResource(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new MgmtMockAndSamplePrivateLinkResourceListResult(Optional.ToList(value));
        }
    }
}
