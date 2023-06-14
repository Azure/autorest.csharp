// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class DeletedAccountListResult
    {
        internal static DeletedAccountListResult DeserializeDeletedAccountListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<DeletedAccountData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DeletedAccountData> array = new List<DeletedAccountData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeletedAccountData.DeserializeDeletedAccountData(item));
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
            return new DeletedAccountListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
