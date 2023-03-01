// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtScopeResource;

namespace MgmtScopeResource.Models
{
    internal partial class FakePolicyAssignmentListResult
    {
        internal static FakePolicyAssignmentListResult DeserializeFakePolicyAssignmentListResult(JsonElement element)
        {
            Optional<IReadOnlyList<FakePolicyAssignmentData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FakePolicyAssignmentData> array = new List<FakePolicyAssignmentData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(item));
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
            return new FakePolicyAssignmentListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
