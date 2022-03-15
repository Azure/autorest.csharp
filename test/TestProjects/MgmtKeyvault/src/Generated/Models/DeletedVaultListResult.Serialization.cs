// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtKeyvault;

namespace MgmtKeyvault.Models
{
    internal partial class DeletedVaultListResult
    {
        internal static DeletedVaultListResult DeserializeDeletedVaultListResult(JsonElement element)
        {
            Optional<IReadOnlyList<DeletedVaultResourceData>> value = default;
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
                    List<DeletedVaultResourceData> array = new List<DeletedVaultResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeletedVaultResourceData.DeserializeDeletedVaultResourceData(item));
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
            return new DeletedVaultListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
