// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    internal partial class DataTableCell
    {
        internal static DataTableCell DeserializeDataTableCell(JsonElement element)
        {
            int rowIndex = default;
            int columnIndex = default;
            Optional<int> rowSpan = default;
            Optional<int> columnSpan = default;
            string text = default;
            IReadOnlyList<float> boundingBox = default;
            float confidence = default;
            Optional<IReadOnlyList<string>> elements = default;
            Optional<bool> isHeader = default;
            Optional<bool> isFooter = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rowIndex"))
                {
                    rowIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("columnIndex"))
                {
                    columnIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("rowSpan"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    rowSpan = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("columnSpan"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    columnSpan = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("text"))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boundingBox"))
                {
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    boundingBox = array;
                    continue;
                }
                if (property.NameEquals("confidence"))
                {
                    confidence = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("elements"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    elements = array;
                    continue;
                }
                if (property.NameEquals("isHeader"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    isHeader = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("isFooter"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    isFooter = property.Value.GetBoolean();
                    continue;
                }
            }
            return new DataTableCell(rowIndex, columnIndex, Optional.ToNullable(rowSpan), Optional.ToNullable(columnSpan), text, boundingBox, confidence, Optional.ToList(elements), Optional.ToNullable(isHeader), Optional.ToNullable(isFooter));
        }
    }
}
