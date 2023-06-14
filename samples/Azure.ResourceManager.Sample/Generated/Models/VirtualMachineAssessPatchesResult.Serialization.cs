// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineAssessPatchesResult
    {
        internal static VirtualMachineAssessPatchesResult DeserializeVirtualMachineAssessPatchesResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<PatchOperationStatus> status = default;
            Optional<string> assessmentActivityId = default;
            Optional<bool> rebootPending = default;
            Optional<int> criticalAndSecurityPatchCount = default;
            Optional<int> otherPatchCount = default;
            Optional<DateTimeOffset> startDateTime = default;
            Optional<IReadOnlyList<VirtualMachineSoftwarePatchProperties>> patches = default;
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
                if (property.NameEquals("assessmentActivityId"u8))
                {
                    assessmentActivityId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("rebootPending"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rebootPending = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("criticalAndSecurityPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    criticalAndSecurityPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("otherPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    otherPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("startDateTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("patches"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineSoftwarePatchProperties> array = new List<VirtualMachineSoftwarePatchProperties>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineSoftwarePatchProperties.DeserializeVirtualMachineSoftwarePatchProperties(item));
                    }
                    patches = array;
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
            return new VirtualMachineAssessPatchesResult(Optional.ToNullable(status), assessmentActivityId.Value, Optional.ToNullable(rebootPending), Optional.ToNullable(criticalAndSecurityPatchCount), Optional.ToNullable(otherPatchCount), Optional.ToNullable(startDateTime), Optional.ToList(patches), error.Value);
        }
    }
}
