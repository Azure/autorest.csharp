// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtExactMatchInheritance;

namespace MgmtExactMatchInheritance.Models
{
    internal partial class ExactMatchModel1ListResult
    {
        internal static ExactMatchModel1ListResult DeserializeExactMatchModel1ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<ExactMatchModel1Data>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ExactMatchModel1Data> array = new List<ExactMatchModel1Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ExactMatchModel1Data.DeserializeExactMatchModel1Data(item));
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
            return new ExactMatchModel1ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
