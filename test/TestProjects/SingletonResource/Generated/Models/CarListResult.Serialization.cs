// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using SingletonResource;

namespace SingletonResource.Models
{
    internal partial class CarListResult
    {
        internal static CarListResult DeserializeCarListResult(JsonElement element)
        {
            Optional<IReadOnlyList<CarData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new CarListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
