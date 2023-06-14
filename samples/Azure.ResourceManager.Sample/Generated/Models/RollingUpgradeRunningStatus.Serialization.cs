// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class RollingUpgradeRunningStatus
    {
        internal static RollingUpgradeRunningStatus DeserializeRollingUpgradeRunningStatus(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<RollingUpgradeStatusCode> code = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<RollingUpgradeActionType> lastAction = default;
            Optional<DateTimeOffset> lastActionTime = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    code = property.Value.GetString().ToRollingUpgradeStatusCode();
                    continue;
                }
                if (property.NameEquals("startTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastAction"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastAction = property.Value.GetString().ToRollingUpgradeActionType();
                    continue;
                }
                if (property.NameEquals("lastActionTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastActionTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new RollingUpgradeRunningStatus(Optional.ToNullable(code), Optional.ToNullable(startTime), Optional.ToNullable(lastAction), Optional.ToNullable(lastActionTime));
        }
    }
}
