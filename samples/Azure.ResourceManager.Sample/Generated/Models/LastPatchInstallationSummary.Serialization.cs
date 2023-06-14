// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class LastPatchInstallationSummary
    {
        internal static LastPatchInstallationSummary DeserializeLastPatchInstallationSummary(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<PatchOperationStatus> status = default;
            Optional<string> installationActivityId = default;
            Optional<bool> maintenanceWindowExceeded = default;
            Optional<RebootStatus> rebootStatus = default;
            Optional<int> notSelectedPatchCount = default;
            Optional<int> excludedPatchCount = default;
            Optional<int> pendingPatchCount = default;
            Optional<int> installedPatchCount = default;
            Optional<int> failedPatchCount = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> lastModifiedTime = default;
            Optional<string> startedBy = default;
            Optional<ApiError> error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new PatchOperationStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("installationActivityId"u8))
                {
                    installationActivityId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("maintenanceWindowExceeded"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maintenanceWindowExceeded = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("rebootStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rebootStatus = new RebootStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("notSelectedPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    notSelectedPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("excludedPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    excludedPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("pendingPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    pendingPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("installedPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    installedPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failedPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failedPatchCount = property.Value.GetInt32();
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
                if (property.NameEquals("lastModifiedTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastModifiedTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("startedBy"u8))
                {
                    startedBy = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    error = ApiError.DeserializeApiError(property.Value);
                    continue;
                }
            }
            return new LastPatchInstallationSummary(Optional.ToNullable(status), installationActivityId.Value, Optional.ToNullable(maintenanceWindowExceeded), Optional.ToNullable(rebootStatus), Optional.ToNullable(notSelectedPatchCount), Optional.ToNullable(excludedPatchCount), Optional.ToNullable(pendingPatchCount), Optional.ToNullable(installedPatchCount), Optional.ToNullable(failedPatchCount), Optional.ToNullable(startTime), Optional.ToNullable(lastModifiedTime), startedBy.Value, error.Value);
        }
    }
}
