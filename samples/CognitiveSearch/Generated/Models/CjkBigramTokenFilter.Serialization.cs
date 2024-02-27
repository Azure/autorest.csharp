// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

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
            if (!(IgnoreScripts is ChangeTrackingList<CjkBigramTokenFilterScripts> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("ignoreScripts"u8);
                writer.WriteStartArray();
                foreach (var item in IgnoreScripts)
                {
                    writer.WriteStringValue(item.ToSerialString());
                }
                writer.WriteEndArray();
            }
            if (OutputUnigrams.HasValue)
            {
                writer.WritePropertyName("outputUnigrams"u8);
                writer.WriteBooleanValue(OutputUnigrams.Value);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static CjkBigramTokenFilter DeserializeCjkBigramTokenFilter(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<CjkBigramTokenFilterScripts> ignoreScripts = default;
            bool? outputUnigrams = default;
            string odataType = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ignoreScripts"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<CjkBigramTokenFilterScripts> array = new List<CjkBigramTokenFilterScripts>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString().ToCjkBigramTokenFilterScripts());
                    }
                    ignoreScripts = array;
                    continue;
                }
                if (property.NameEquals("outputUnigrams"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    outputUnigrams = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new CjkBigramTokenFilter(odataType, name, ignoreScripts ?? new ChangeTrackingList<CjkBigramTokenFilterScripts>(), outputUnigrams);
        }
    }
}
