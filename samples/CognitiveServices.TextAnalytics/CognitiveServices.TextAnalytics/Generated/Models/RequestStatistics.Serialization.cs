// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class RequestStatistics : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("documentsCount");
            writer.WriteNumberValue(DocumentsCount);
            writer.WritePropertyName("validDocumentsCount");
            writer.WriteNumberValue(ValidDocumentsCount);
            writer.WritePropertyName("erroneousDocumentsCount");
            writer.WriteNumberValue(ErroneousDocumentsCount);
            writer.WritePropertyName("transactionsCount");
            writer.WriteNumberValue(TransactionsCount);
            writer.WriteEndObject();
        }
        internal static RequestStatistics DeserializeRequestStatistics(JsonElement element)
        {
            RequestStatistics result = new RequestStatistics();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("documentsCount"))
                {
                    result.DocumentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("validDocumentsCount"))
                {
                    result.ValidDocumentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("erroneousDocumentsCount"))
                {
                    result.ErroneousDocumentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("transactionsCount"))
                {
                    result.TransactionsCount = property.Value.GetInt64();
                    continue;
                }
            }
            return result;
        }
    }
}
