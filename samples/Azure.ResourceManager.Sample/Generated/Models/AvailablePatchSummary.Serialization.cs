// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample
{
    public partial class AvailablePatchSummary
    {
        internal static AvailablePatchSummary DeserializeAvailablePatchSummary(JsonElement element)
        {
            Optional<PatchOperationStatus> status = default;
            Optional<string> assessmentActivityId = default;
            Optional<bool> rebootPending = default;
            Optional<int> criticalAndSecurityPatchCount = default;
            Optional<int> otherPatchCount = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> lastModifiedTime = default;
            Optional<ApiError> error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    status = new PatchOperationStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("assessmentActivityId"))
                {
                    assessmentActivityId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("rebootPending"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    rebootPending = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("criticalAndSecurityPatchCount"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    criticalAndSecurityPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("otherPatchCount"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    otherPatchCount = property.Value.GetInt32();
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
                if (property.NameEquals("lastModifiedTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    lastModifiedTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("error"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    error = ApiError.DeserializeApiError(property.Value);
                    continue;
                }
            }
            return new AvailablePatchSummary(Optional.ToNullable(status), assessmentActivityId.Value, Optional.ToNullable(rebootPending), Optional.ToNullable(criticalAndSecurityPatchCount), Optional.ToNullable(otherPatchCount), Optional.ToNullable(startTime), Optional.ToNullable(lastModifiedTime), error.Value);
        }
    }
}
