// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Pagination
{
    public partial class LedgerEntry
    {
        internal static LedgerEntry DeserializeLedgerEntry(JsonElement element)
        {
            string contents = default;
            string collectionId = default;
            string transactionId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("contents"))
                {
                    contents = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("collectionId"))
                {
                    collectionId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("transactionId"))
                {
                    transactionId = property.Value.GetString();
                    continue;
                }
            }
            return new LedgerEntry(contents, collectionId, transactionId);
        }

        internal static LedgerEntry FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeLedgerEntry(document.RootElement);
        }
    }
}
