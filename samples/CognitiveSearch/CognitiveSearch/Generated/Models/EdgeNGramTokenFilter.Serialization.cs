// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class EdgeNGramTokenFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(MinGram))
            {
                writer.WritePropertyName("minGram");
                writer.WriteNumberValue(MinGram.Value);
            }
            if (Optional.IsDefined(MaxGram))
            {
                writer.WritePropertyName("maxGram");
                writer.WriteNumberValue(MaxGram.Value);
            }
            if (Optional.IsDefined(Side))
            {
                writer.WritePropertyName("side");
                writer.WriteStringValue(Side.Value.ToSerialString());
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static EdgeNGramTokenFilter DeserializeEdgeNGramTokenFilter(JsonElement element)
        {
            Optional<int> minGram = default;
            Optional<int> maxGram = default;
            Optional<EdgeNGramTokenFilterSide> side = default;
            string odataType = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("minGram"))
                {
                    minGram = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxGram"))
                {
                    maxGram = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("side"))
                {
                    side = property.Value.GetString().ToEdgeNGramTokenFilterSide();
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new EdgeNGramTokenFilter(odataType, name, Optional.ToNullable(minGram), Optional.ToNullable(maxGram), Optional.ToNullable(side));
        }
    }
}
