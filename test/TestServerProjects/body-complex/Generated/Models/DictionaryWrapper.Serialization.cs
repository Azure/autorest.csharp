// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DictionaryWrapperSerializer
    {
        internal static void Serialize(DictionaryWrapper model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteStartObject("defaultProgram");
            foreach (var item in model.DefaultProgram)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
        internal static DictionaryWrapper Deserialize(JsonElement element)
        {
            var result = new DictionaryWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("defaultProgram"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DefaultProgram = new Dictionary<string, string?>();
                    foreach (var item in property.Value.EnumerateObject())
                    {
                        result.DefaultProgram.Add(item.Name, item.Value.GetString());
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
