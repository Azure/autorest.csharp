// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtNoTypeReplacement;

namespace MgmtNoTypeReplacement.Models
{
    internal partial class NoTypeReplacementModel3ListResult
    {
        internal static NoTypeReplacementModel3ListResult DeserializeNoTypeReplacementModel3ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<NoTypeReplacementModel3Data>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<NoTypeReplacementModel3Data> array = new List<NoTypeReplacementModel3Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(NoTypeReplacementModel3Data.DeserializeNoTypeReplacementModel3Data(item));
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
            return new NoTypeReplacementModel3ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
