// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtNoTypeReplacement.Models
{
    internal partial class NoTypeReplacementModel1ListResult
    {
        internal static NoTypeReplacementModel1ListResult DeserializeNoTypeReplacementModel1ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<NoTypeReplacementModel1Data>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<NoTypeReplacementModel1Data> array = new List<NoTypeReplacementModel1Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(NoTypeReplacementModel1Data.DeserializeNoTypeReplacementModel1Data(item));
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
            return new NoTypeReplacementModel1ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
