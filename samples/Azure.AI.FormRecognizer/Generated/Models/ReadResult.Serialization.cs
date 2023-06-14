// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class ReadResult
    {
        internal static ReadResult DeserializeReadResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int page = default;
            float angle = default;
            float width = default;
            float height = default;
            LengthUnit unit = default;
            Optional<Language> language = default;
            Optional<IReadOnlyList<TextLine>> lines = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("page"u8))
                {
                    page = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("angle"u8))
                {
                    angle = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("width"u8))
                {
                    width = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("height"u8))
                {
                    height = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("unit"u8))
                {
                    unit = property.Value.GetString().ToLengthUnit();
                    continue;
                }
                if (property.NameEquals("language"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    language = new Language(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("lines"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TextLine> array = new List<TextLine>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TextLine.DeserializeTextLine(item));
                    }
                    lines = array;
                    continue;
                }
            }
            return new ReadResult(page, angle, width, height, unit, Optional.ToNullable(language), Optional.ToList(lines));
        }
    }
}
