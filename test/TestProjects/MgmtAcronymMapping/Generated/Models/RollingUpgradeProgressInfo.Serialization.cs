// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;

namespace MgmtAcronymMapping.Models
{
    public partial class RollingUpgradeProgressInfo
    {
        internal static RollingUpgradeProgressInfo DeserializeRollingUpgradeProgressInfo(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int successfulInstanceCount = default;
            int failedInstanceCount = default;
            int inProgressInstanceCount = default;
            int pendingInstanceCount = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("successfulInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    successfulInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failedInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failedInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("inProgressInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    inProgressInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("pendingInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    pendingInstanceCount = property.Value.GetInt32();
                    continue;
                }
            }
            return new RollingUpgradeProgressInfo(successfulInstanceCount, failedInstanceCount, inProgressInstanceCount, pendingInstanceCount);
        }
    }
}
