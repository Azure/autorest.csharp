// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class LegalHoldProperties
    {
        internal static LegalHoldProperties DeserializeLegalHoldProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> hasLegalHold = default;
            Optional<IReadOnlyList<TagProperty>> tags = default;
            Optional<ProtectedAppendWritesHistory> protectedAppendWritesHistory = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("hasLegalHold"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hasLegalHold = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TagProperty> array = new List<TagProperty>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(TagProperty.DeserializeTagProperty(item));
                        }
                    }
                    tags = array;
                    continue;
                }
                if (property.NameEquals("protectedAppendWritesHistory"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectedAppendWritesHistory = ProtectedAppendWritesHistory.DeserializeProtectedAppendWritesHistory(property.Value);
                    continue;
                }
            }
            return new LegalHoldProperties(Optional.ToNullable(hasLegalHold), Optional.ToList(tags), protectedAppendWritesHistory.Value);
        }
    }
}
