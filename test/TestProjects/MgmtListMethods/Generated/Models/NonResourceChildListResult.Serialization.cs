// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtListMethods.Models
{
    internal partial class NonResourceChildListResult
    {
        internal static NonResourceChildListResult DeserializeNonResourceChildListResult(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<NonResourceChild>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
