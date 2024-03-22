// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace MgmtExactMatchFlattenInheritance.Models
{
    internal partial class CustomModel2ListResult
    {
        internal static CustomModel2ListResult DeserializeCustomModel2ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<CustomModel2Data> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new CustomModel2ListResult(value ?? new ChangeTrackingList<CustomModel2Data>(), nextLink);
        }
    }
}