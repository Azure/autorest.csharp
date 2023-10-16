// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class ScoringProfile : IUtf8JsonSerializable, IModelJsonSerializable<ScoringProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ScoringProfile>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ScoringProfile>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(TextWeights))
            {
                writer.WritePropertyName("text"u8);
                writer.WriteObjectValue(TextWeights);
            }
            if (Optional.IsCollectionDefined(Functions))
            {
                writer.WritePropertyName("functions"u8);
                writer.WriteStartArray();
                foreach (var item in Functions)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(FunctionAggregation))
            {
                writer.WritePropertyName("functionAggregation"u8);
                writer.WriteStringValue(FunctionAggregation.Value.ToSerialString());
            }
            writer.WriteEndObject();
        }

        ScoringProfile IModelJsonSerializable<ScoringProfile>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeScoringProfile(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ScoringProfile>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ScoringProfile IModelSerializable<ScoringProfile>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeScoringProfile(document.RootElement, options);
        }

        internal static ScoringProfile DeserializeScoringProfile(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<TextWeights> text = default;
            Optional<IList<ScoringFunction>> functions = default;
            Optional<ScoringFunctionAggregation> functionAggregation = default;
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
            return new ScoringProfile(name, text.Value, Optional.ToList(functions), Optional.ToNullable(functionAggregation));
        }
    }
}
