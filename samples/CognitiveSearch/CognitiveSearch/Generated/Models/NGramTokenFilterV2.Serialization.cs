// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class NGramTokenFilterV2 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (MinGram != null)
            {
                writer.WritePropertyName("minGram");
                writer.WriteNumberValue(MinGram.Value);
            }
            if (MaxGram != null)
            {
                writer.WritePropertyName("maxGram");
                writer.WriteNumberValue(MaxGram.Value);
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }
        internal static NGramTokenFilterV2 DeserializeNGramTokenFilterV2(JsonElement element)
        {
            NGramTokenFilterV2 result = new NGramTokenFilterV2();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("minGram"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.MinGram = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxGram"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.MaxGram = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
