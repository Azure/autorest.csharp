// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtScopeResource;

namespace MgmtScopeResource.Models
{
    internal partial class GuestConfigurationAssignmentList
    {
        internal static GuestConfigurationAssignmentList DeserializeGuestConfigurationAssignmentList(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<GuestConfigurationAssignmentData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<GuestConfigurationAssignmentData> array = new List<GuestConfigurationAssignmentData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(GuestConfigurationAssignmentData.DeserializeGuestConfigurationAssignmentData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new GuestConfigurationAssignmentList(Optional.ToList(value));
        }
    }
}
