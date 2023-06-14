// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtOperations.Models
{
    public partial class TestAvailabilitySet
    {
        internal static TestAvailabilitySet DeserializeTestAvailabilitySet(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> bar = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("bar"u8))
                {
                    bar = property.Value.GetString();
                    continue;
                }
            }
            return new TestAvailabilitySet(bar.Value);
        }
    }
}
