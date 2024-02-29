// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ScoringProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (TextWeights != null)
            {
                writer.WritePropertyName("text"u8);
                writer.WriteObjectValue(TextWeights);
            }
            if (!(Functions is ChangeTrackingList<ScoringFunction> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("functions"u8);
                writer.WriteStartArray();
                foreach (var item in Functions)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (FunctionAggregation.HasValue)
            {
                writer.WritePropertyName("functionAggregation"u8);
                writer.WriteStringValue(FunctionAggregation.Value.ToSerialString());
            }
            writer.WriteEndObject();
        }

        internal static ScoringProfile DeserializeScoringProfile(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            TextWeights text = default;
            IList<ScoringFunction> functions = default;
            ScoringFunctionAggregation? functionAggregation = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("text"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    text = TextWeights.DeserializeTextWeights(property.Value);
                    continue;
                }
                if (property.NameEquals("functions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ScoringFunction> array = new List<ScoringFunction>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ScoringFunction.DeserializeScoringFunction(item));
                    }
                    functions = array;
                    continue;
                }
                if (property.NameEquals("functionAggregation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    functionAggregation = property.Value.GetString().ToScoringFunctionAggregation();
                    continue;
                }
            }
            return new ScoringProfile(name, text, functions ?? new ChangeTrackingList<ScoringFunction>(), functionAggregation);
        }
    }
}
