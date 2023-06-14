// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtCustomizations;

namespace MgmtCustomizations.Models
{
    internal partial class PetStoreListResult
    {
        internal static PetStoreListResult DeserializePetStoreListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<PetStoreData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PetStoreData> array = new List<PetStoreData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PetStoreData.DeserializePetStoreData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new PetStoreListResult(Optional.ToList(value));
        }
    }
}
