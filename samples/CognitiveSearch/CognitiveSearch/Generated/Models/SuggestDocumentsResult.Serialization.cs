// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class SuggestDocumentsResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Results != null)
            {
                writer.WritePropertyName("value");
                writer.WriteStartArray();
                foreach (var item in Results)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Coverage != null)
            {
                writer.WritePropertyName("@search.coverage");
                writer.WriteNumberValue(Coverage.Value);
            }
            writer.WriteEndObject();
        }
        internal static SuggestDocumentsResult DeserializeSuggestDocumentsResult(JsonElement element)
        {
            SuggestDocumentsResult result = new SuggestDocumentsResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Results = new List<SuggestResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Results.Add(SuggestResult.DeserializeSuggestResult(item));
                    }
                    continue;
                }
                if (property.NameEquals("@search.coverage"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Coverage = property.Value.GetDouble();
                    continue;
                }
            }
            return result;
        }
    }
}
