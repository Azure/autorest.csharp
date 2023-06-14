// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtSingletonResource;

namespace MgmtSingletonResource.Models
{
    internal partial class CarListResult
    {
        internal static CarListResult DeserializeCarListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<CarData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<CarData> array = new List<CarData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CarData.DeserializeCarData(item));
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
            return new CarListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
