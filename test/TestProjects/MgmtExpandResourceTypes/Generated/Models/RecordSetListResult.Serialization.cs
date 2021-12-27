// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtExpandResourceTypes;

namespace MgmtExpandResourceTypes.Models
{
    internal partial class RecordSetListResult
    {
        internal static RecordSetListResult DeserializeRecordSetListResult(JsonElement element)
        {
            Optional<IReadOnlyList<RecordSetData>> value = default;
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
                    List<RecordSetData> array = new List<RecordSetData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(RecordSetData.DeserializeRecordSetData(item));
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
            return new RecordSetListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
