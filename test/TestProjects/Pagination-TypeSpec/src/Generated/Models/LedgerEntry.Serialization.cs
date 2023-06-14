// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Pagination.Models
{
    public partial class LedgerEntry
    {
        internal static LedgerEntry DeserializeLedgerEntry(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string contents = default;
            string collectionId = default;
            string transactionId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("contents"u8))
                {
                    contents = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("collectionId"u8))
                {
                    collectionId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("transactionId"u8))
                {
                    transactionId = property.Value.GetString();
                    continue;
                }
            }
            return new LedgerEntry(contents, collectionId, transactionId);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static LedgerEntry FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeLedgerEntry(document.RootElement);
        }
    }
}
