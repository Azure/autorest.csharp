// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class VirtualMachineScaleSetListOSUpgradeHistory
    {
        internal static VirtualMachineScaleSetListOSUpgradeHistory DeserializeVirtualMachineScaleSetListOSUpgradeHistory(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<UpgradeOperationHistoricalStatusInfo> value = default;
            Optional<ETag> etag = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<UpgradeOperationHistoricalStatusInfo> array = new List<UpgradeOperationHistoricalStatusInfo>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(UpgradeOperationHistoricalStatusInfo.DeserializeUpgradeOperationHistoricalStatusInfo(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("etag"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    etag = new ETag(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new VirtualMachineScaleSetListOSUpgradeHistory(value, Optional.ToNullable(etag), nextLink.Value);
        }
    }
}
