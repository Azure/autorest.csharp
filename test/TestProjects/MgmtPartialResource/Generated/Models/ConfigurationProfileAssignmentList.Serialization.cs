// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtPartialResource;

namespace MgmtPartialResource.Models
{
    internal partial class ConfigurationProfileAssignmentList
    {
        internal static ConfigurationProfileAssignmentList DeserializeConfigurationProfileAssignmentList(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<ConfigurationProfileAssignmentData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ConfigurationProfileAssignmentData> array = new List<ConfigurationProfileAssignmentData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ConfigurationProfileAssignmentData.DeserializeConfigurationProfileAssignmentData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new ConfigurationProfileAssignmentList(Optional.ToList(value));
        }
    }
}
