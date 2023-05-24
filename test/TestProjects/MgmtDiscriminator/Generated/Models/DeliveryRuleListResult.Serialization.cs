// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using MgmtDiscriminator;

namespace MgmtDiscriminator.Models
{
    internal partial class DeliveryRuleListResult
    {
        internal static DeliveryRuleListResult DeserializeDeliveryRuleListResult(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<DeliveryRuleData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DeliveryRuleData> array = new List<DeliveryRuleData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeliveryRuleData.DeserializeDeliveryRuleData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new DeliveryRuleListResult(Optional.ToList(value));
        }
    }
}
