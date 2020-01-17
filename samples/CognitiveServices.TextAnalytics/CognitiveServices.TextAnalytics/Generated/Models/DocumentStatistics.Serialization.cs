// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class DocumentStatistics : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("charactersCount");
            writer.WriteNumberValue(CharactersCount);
            writer.WritePropertyName("transactionsCount");
            writer.WriteNumberValue(TransactionsCount);
            writer.WriteEndObject();
        }
        internal static DocumentStatistics DeserializeDocumentStatistics(JsonElement element)
        {
            DocumentStatistics result = new DocumentStatistics();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("charactersCount"))
                {
                    result.CharactersCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("transactionsCount"))
                {
                    result.TransactionsCount = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
    }
}
