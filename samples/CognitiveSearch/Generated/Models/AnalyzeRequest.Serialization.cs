// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class AnalyzeRequest : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("text"u8);
            writer.WriteStringValue(Text);
            if (Optional.IsDefined(Analyzer))
            {
                writer.WritePropertyName("analyzer"u8);
                writer.WriteStringValue(Analyzer.Value.ToString());
            }
            if (Optional.IsDefined(Tokenizer))
            {
                writer.WritePropertyName("tokenizer"u8);
                writer.WriteStringValue(Tokenizer.Value.ToString());
            }
            if (Optional.IsCollectionDefined(TokenFilters))
            {
                writer.WritePropertyName("tokenFilters"u8);
                writer.WriteStartArray();
                foreach (var item in TokenFilters)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(CharFilters))
            {
                writer.WritePropertyName("charFilters"u8);
                writer.WriteStartArray();
                foreach (var item in CharFilters)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
    }
}
