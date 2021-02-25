// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample
{
    public partial class RollingUpgradeRunningStatus
    {
        internal static RollingUpgradeRunningStatus DeserializeRollingUpgradeRunningStatus(JsonElement element)
        {
            Optional<RollingUpgradeStatusCode> code = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<RollingUpgradeActionType> lastAction = default;
            Optional<DateTimeOffset> lastActionTime = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    code = property.Value.GetString().ToRollingUpgradeStatusCode();
                    continue;
                }
                if (property.NameEquals("startTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    startTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastAction"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    lastAction = property.Value.GetString().ToRollingUpgradeActionType();
                    continue;
                }
                if (property.NameEquals("lastActionTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
