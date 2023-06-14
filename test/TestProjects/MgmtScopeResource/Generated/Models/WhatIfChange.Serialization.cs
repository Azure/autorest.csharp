// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    public partial class WhatIfChange
    {
        internal static WhatIfChange DeserializeWhatIfChange(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string resourceId = default;
            ChangeType changeType = default;
            Optional<string> unsupportedReason = default;
            Optional<BinaryData> before = default;
            Optional<BinaryData> after = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resourceId"u8))
                {
                    resourceId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("changeType"u8))
                {
                    changeType = property.Value.GetString().ToChangeType();
                    continue;
                }
                if (property.NameEquals("unsupportedReason"u8))
                {
                    unsupportedReason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("before"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    before = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("after"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    after = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
            }
            return new WhatIfChange(resourceId, changeType, unsupportedReason.Value, before.Value, after.Value);
        }
    }
}
