// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtSupersetFlattenInheritance.Models
{
    internal partial class WritableSubResourceModel2ListResult
    {
        internal static WritableSubResourceModel2ListResult DeserializeWritableSubResourceModel2ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<WritableSubResourceModel2>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<WritableSubResourceModel2> array = new List<WritableSubResourceModel2>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(WritableSubResourceModel2.DeserializeWritableSubResourceModel2(item));
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
            return new WritableSubResourceModel2ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
