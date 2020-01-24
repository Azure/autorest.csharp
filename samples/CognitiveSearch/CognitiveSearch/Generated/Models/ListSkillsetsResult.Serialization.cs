// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ListSkillsetsResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Skillsets != null)
            {
                writer.WritePropertyName("value");
                writer.WriteStartArray();
                foreach (var item in Skillsets)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static ListSkillsetsResult DeserializeListSkillsetsResult(JsonElement element)
        {
            ListSkillsetsResult result = new ListSkillsetsResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Skillsets = new List<Skillset>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Skillsets.Add(Skillset.DeserializeSkillset(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
