// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class RequestStatistics
    {
        internal static RequestStatistics DeserializeRequestStatistics(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int documentsCount = default;
            int validDocumentsCount = default;
            int erroneousDocumentsCount = default;
            long transactionsCount = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("documentsCount"u8))
                {
                    documentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("validDocumentsCount"u8))
                {
                    validDocumentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("erroneousDocumentsCount"u8))
                {
                    erroneousDocumentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("transactionsCount"u8))
                {
                    transactionsCount = property.Value.GetInt64();
                    continue;
                }
            }
            return new RequestStatistics(documentsCount, validDocumentsCount, erroneousDocumentsCount, transactionsCount);
        }
    }
}
