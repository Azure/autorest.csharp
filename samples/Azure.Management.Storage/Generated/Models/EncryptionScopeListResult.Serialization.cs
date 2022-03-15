// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Management.Storage;

namespace Azure.Management.Storage.Models
{
    internal partial class EncryptionScopeListResult
    {
        internal static EncryptionScopeListResult DeserializeEncryptionScopeListResult(JsonElement element)
        {
            Optional<IReadOnlyList<EncryptionScopeResourceData>> value = default;
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
                    List<EncryptionScopeResourceData> array = new List<EncryptionScopeResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(EncryptionScopeResourceData.DeserializeEncryptionScopeResourceData(item));
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
            return new EncryptionScopeListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
