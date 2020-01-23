// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class CjkBigramTokenFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (IgnoreScripts != null)
            {
                writer.WritePropertyName("ignoreScripts");
                writer.WriteStartArray();
                foreach (var item in IgnoreScripts)
                {
                    writer.WriteStringValue(item.ToSerialString());
                }
                writer.WriteEndArray();
            }
            if (OutputUnigrams != null)
            {
                writer.WritePropertyName("outputUnigrams");
                writer.WriteBooleanValue(OutputUnigrams.Value);
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }
        internal static CjkBigramTokenFilter DeserializeCjkBigramTokenFilter(JsonElement element)
        {
            CjkBigramTokenFilter result = new CjkBigramTokenFilter();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ignoreScripts"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.IgnoreScripts = new List<CjkBigramTokenFilterScripts>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.IgnoreScripts.Add(item.GetString().ToCjkBigramTokenFilterScripts());
                    }
                    continue;
                }
                if (property.NameEquals("outputUnigrams"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.OutputUnigrams = property.Value.GetBoolean();
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
