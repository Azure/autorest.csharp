// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtExactMatchFlattenInheritance;

namespace MgmtExactMatchFlattenInheritance.Models
{
    internal partial class CustomModel3ListResult
    {
        internal static CustomModel3ListResult DeserializeCustomModel3ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<CustomModel3Data>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<CustomModel3Data> array = new List<CustomModel3Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CustomModel3Data.DeserializeCustomModel3Data(item));
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
            return new CustomModel3ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
