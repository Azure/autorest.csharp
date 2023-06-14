// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class TagScoringParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("tagsParameter"u8);
            writer.WriteStringValue(TagsParameter);
            writer.WriteEndObject();
        }

        internal static TagScoringParameters DeserializeTagScoringParameters(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string tagsParameter = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tagsParameter"u8))
                {
                    tagsParameter = property.Value.GetString();
                    continue;
                }
            }
            return new TagScoringParameters(tagsParameter);
        }
    }
}
