// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtParamOrdering.Models
{
    internal partial class WorkspaceListResult
    {
        internal static WorkspaceListResult DeserializeWorkspaceListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<WorkspaceData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<WorkspaceData> array = new List<WorkspaceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(WorkspaceData.DeserializeWorkspaceData(item));
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
            return new WorkspaceListResult(value, nextLink.Value);
        }
    }
}
