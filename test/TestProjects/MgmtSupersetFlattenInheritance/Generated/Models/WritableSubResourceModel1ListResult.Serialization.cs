// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtSupersetFlattenInheritance.Models
{
    internal partial class WritableSubResourceModel1ListResult
    {
        internal static WritableSubResourceModel1ListResult DeserializeWritableSubResourceModel1ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<WritableSubResourceModel1>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<WritableSubResourceModel1> array = new List<WritableSubResourceModel1>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(WritableSubResourceModel1.DeserializeWritableSubResourceModel1(item));
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
            return new WritableSubResourceModel1ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
