// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtScopeResource;

namespace MgmtScopeResource.Models
{
    internal partial class DeploymentListResult
    {
        internal static DeploymentListResult DeserializeDeploymentListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<DeploymentExtendedData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DeploymentExtendedData> array = new List<DeploymentExtendedData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeploymentExtendedData.DeserializeDeploymentExtendedData(item));
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
            return new DeploymentListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
