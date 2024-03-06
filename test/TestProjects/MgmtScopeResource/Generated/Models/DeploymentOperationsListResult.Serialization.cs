// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using MgmtScopeResource;

namespace MgmtScopeResource.Models
{
    internal partial class DeploymentOperationsListResult
    {
        internal static DeploymentOperationsListResult DeserializeDeploymentOperationsListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<DeploymentOperation> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DeploymentOperation> array = new List<DeploymentOperation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeploymentOperation.DeserializeDeploymentOperation(item));
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
            return new DeploymentOperationsListResult(value ?? new ChangeTrackingList<DeploymentOperation>(), nextLink);
        }
    }
}
