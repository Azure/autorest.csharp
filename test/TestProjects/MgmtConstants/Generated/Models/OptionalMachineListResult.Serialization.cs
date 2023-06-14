// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtConstants;

namespace MgmtConstants.Models
{
    internal partial class OptionalMachineListResult
    {
        internal static OptionalMachineListResult DeserializeOptionalMachineListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<OptionalMachineData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<OptionalMachineData> array = new List<OptionalMachineData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OptionalMachineData.DeserializeOptionalMachineData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new OptionalMachineListResult(value, nextLink.Value);
        }
    }
}
