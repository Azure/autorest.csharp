// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtExpandResourceTypes.Models
{
    internal partial class RecordSetListResult
    {
        internal static RecordSetListResult DeserializeRecordSetListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<RecordSetData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<RecordSetData> array = new List<RecordSetData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(RecordSetData.DeserializeRecordSetData(item));
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
            return new RecordSetListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
