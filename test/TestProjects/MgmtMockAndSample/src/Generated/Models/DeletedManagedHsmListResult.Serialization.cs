// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Models
{
    internal partial class DeletedManagedHsmListResult
    {
        internal static DeletedManagedHsmListResult DeserializeDeletedManagedHsmListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<DeletedManagedHsmData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DeletedManagedHsmData> array = new List<DeletedManagedHsmData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeletedManagedHsmData.DeserializeDeletedManagedHsmData(item));
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
            return new DeletedManagedHsmListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
