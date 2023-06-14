// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtLRO.Models
{
    internal partial class FakePostResultProperties
    {
        internal static FakePostResultProperties DeserializeFakePostResultProperties(JsonElement element)
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
            return new FakePostResultProperties(bar.Value);
        }
    }
}
