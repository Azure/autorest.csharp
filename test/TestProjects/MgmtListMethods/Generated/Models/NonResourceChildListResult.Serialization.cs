// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtListMethods.Models
{
    public partial class NonResourceChildListResult
    {
        internal static NonResourceChildListResult DeserializeNonResourceChildListResult(JsonElement element)
        {
            Optional<IReadOnlyList<NonResourceChild>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<NonResourceChild> array = new List<NonResourceChild>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(NonResourceChild.DeserializeNonResourceChild(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new NonResourceChildListResult(Optional.ToList(value));
        }
    }
}
