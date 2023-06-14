// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class Similarity : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }

        internal static Similarity DeserializeSimilarity(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.BM25Similarity": return BM25Similarity.DeserializeBM25Similarity(element);
                    case "#Microsoft.Azure.Search.ClassicSimilarity": return ClassicSimilarity.DeserializeClassicSimilarity(element);
                }
            }
            return UnknownSimilarity.DeserializeUnknownSimilarity(element);
        }
    }
}
