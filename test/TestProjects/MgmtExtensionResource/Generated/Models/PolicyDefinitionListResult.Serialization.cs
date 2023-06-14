// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtExtensionResource;

namespace MgmtExtensionResource.Models
{
    internal partial class PolicyDefinitionListResult
    {
        internal static PolicyDefinitionListResult DeserializePolicyDefinitionListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<PolicyDefinitionData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PolicyDefinitionData> array = new List<PolicyDefinitionData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PolicyDefinitionData.DeserializePolicyDefinitionData(item));
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
            return new PolicyDefinitionListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
