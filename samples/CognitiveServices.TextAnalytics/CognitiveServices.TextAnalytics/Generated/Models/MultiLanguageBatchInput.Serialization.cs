// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class MultiLanguageBatchInput : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("documents");
            writer.WriteStartArray();
            foreach (var item in Documents)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static MultiLanguageBatchInput DeserializeMultiLanguageBatchInput(JsonElement element)
        {
            MultiLanguageBatchInput result = new MultiLanguageBatchInput();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("documents"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Documents.Add(MultiLanguageInput.DeserializeMultiLanguageInput(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
