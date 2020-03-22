// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class LimitTokenFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (MaxTokenCount != null)
            {
                writer.WritePropertyName("maxTokenCount");
                writer.WriteNumberValue(MaxTokenCount.Value);
            }
            if (ConsumeAllTokens != null)
            {
                writer.WritePropertyName("consumeAllTokens");
                writer.WriteBooleanValue(ConsumeAllTokens.Value);
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static LimitTokenFilter DeserializeLimitTokenFilter(JsonElement element)
        {
            int? maxTokenCount = default;
            bool? consumeAllTokens = default;
            string odatatype = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxTokenCount"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxTokenCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("consumeAllTokens"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    consumeAllTokens = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    odatatype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new LimitTokenFilter(maxTokenCount, consumeAllTokens, odatatype, name);
        }
    }
}
