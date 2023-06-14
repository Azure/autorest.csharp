// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtSupersetFlattenInheritance.Models
{
    internal partial class CustomModel2ListResult
    {
        internal static CustomModel2ListResult DeserializeCustomModel2ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<CustomModel2>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<CustomModel2> array = new List<CustomModel2>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CustomModel2.DeserializeCustomModel2(item));
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
            return new CustomModel2ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
