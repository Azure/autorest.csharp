// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtRenameRules.Models
{
    public partial class UpgradeOperationHistoryStatus
    {
        internal static UpgradeOperationHistoryStatus DeserializeUpgradeOperationHistoryStatus(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<UpgradeState> code = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> endTime = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    code = property.Value.GetString().ToUpgradeState();
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
                if (property.NameEquals("endTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    endTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new UpgradeOperationHistoryStatus(Optional.ToNullable(code), Optional.ToNullable(startTime), Optional.ToNullable(endTime));
        }
    }
}
