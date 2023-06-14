// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    public partial class RollingUpgradeProgressInfo
    {
        internal static RollingUpgradeProgressInfo DeserializeRollingUpgradeProgressInfo(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> successfulInstanceCount = default;
            Optional<int> failedInstanceCount = default;
            Optional<int> inProgressInstanceCount = default;
            Optional<int> pendingInstanceCount = default;
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
            return new RollingUpgradeProgressInfo(Optional.ToNullable(successfulInstanceCount), Optional.ToNullable(failedInstanceCount), Optional.ToNullable(inProgressInstanceCount), Optional.ToNullable(pendingInstanceCount));
        }
    }
}
