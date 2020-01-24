// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace AppConfiguration.Models
{
    public partial class LabelListResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Items != null)
            {
                writer.WritePropertyName("items");
                writer.WriteStartArray();
                foreach (var item in Items)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (NextLink != null)
            {
                writer.WritePropertyName("@nextLink");
                writer.WriteStringValue(NextLink);
            }
            writer.WriteEndObject();
        }
        internal static LabelListResult DeserializeLabelListResult(JsonElement element)
        {
            LabelListResult result = new LabelListResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("items"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Items = new List<Label>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Items.Add(Label.DeserializeLabel(item));
                    }
                    continue;
                }
                if (property.NameEquals("@nextLink"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.NextLink = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
