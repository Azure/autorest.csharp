// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class TagScoringParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("tagsParameter");
            writer.WriteStringValue(TagsParameter);
            writer.WriteEndObject();
        }
        internal static TagScoringParameters DeserializeTagScoringParameters(JsonElement element)
        {
            TagScoringParameters result = new TagScoringParameters();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tagsParameter"))
                {
                    result.TagsParameter = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
