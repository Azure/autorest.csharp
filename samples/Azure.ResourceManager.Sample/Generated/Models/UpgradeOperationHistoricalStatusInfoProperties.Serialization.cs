// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class UpgradeOperationHistoricalStatusInfoProperties
    {
        internal static UpgradeOperationHistoricalStatusInfoProperties DeserializeUpgradeOperationHistoricalStatusInfoProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<UpgradeOperationHistoryStatus> runningStatus = default;
            Optional<RollingUpgradeProgressInfo> progress = default;
            Optional<ApiError> error = default;
            Optional<UpgradeOperationInvoker> startedBy = default;
            Optional<ImageReference> targetImageReference = default;
            Optional<RollbackStatusInfo> rollbackInfo = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("runningStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    runningStatus = UpgradeOperationHistoryStatus.DeserializeUpgradeOperationHistoryStatus(property.Value);
                    continue;
                }
                if (property.NameEquals("progress"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    progress = RollingUpgradeProgressInfo.DeserializeRollingUpgradeProgressInfo(property.Value);
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
                if (property.NameEquals("startedBy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startedBy = property.Value.GetString().ToUpgradeOperationInvoker();
                    continue;
                }
                if (property.NameEquals("targetImageReference"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    targetImageReference = ImageReference.DeserializeImageReference(property.Value);
                    continue;
                }
                if (property.NameEquals("rollbackInfo"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rollbackInfo = RollbackStatusInfo.DeserializeRollbackStatusInfo(property.Value);
                    continue;
                }
            }
            return new UpgradeOperationHistoricalStatusInfoProperties(runningStatus.Value, progress.Value, error.Value, Optional.ToNullable(startedBy), targetImageReference.Value, rollbackInfo.Value);
        }
    }
}
