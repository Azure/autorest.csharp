// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class TextWeights : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("weights"u8);
            writer.WriteStartObject();
            foreach (var item in Weights)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteNumberValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static TextWeights DeserializeTextWeights(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, double> weights = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("weights"u8))
                {
                    Dictionary<string, double> dictionary = new Dictionary<string, double>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetDouble());
                    }
                    weights = dictionary;
                    continue;
                }
            }
            return new TextWeights(weights);
        }
    }
}
