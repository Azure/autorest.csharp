// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using SupersetFlattenInheritance;

namespace SupersetFlattenInheritance.Models
{
    public partial class CustomModel2ListResult
    {
        internal static CustomModel2ListResult DeserializeCustomModel2ListResult(JsonElement element)
        {
            Optional<IReadOnlyList<CustomModel2Data>> value = default;
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
                    List<CustomModel2Data> array = new List<CustomModel2Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CustomModel2Data.DeserializeCustomModel2Data(item));
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
            return new CustomModel2ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
