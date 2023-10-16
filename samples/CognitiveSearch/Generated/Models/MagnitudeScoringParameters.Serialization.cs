// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class MagnitudeScoringParameters : IUtf8JsonSerializable, IModelJsonSerializable<MagnitudeScoringParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<MagnitudeScoringParameters>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<MagnitudeScoringParameters>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("boostingRangeStart"u8);
            writer.WriteNumberValue(BoostingRangeStart);
            writer.WritePropertyName("boostingRangeEnd"u8);
            writer.WriteNumberValue(BoostingRangeEnd);
            if (Optional.IsDefined(ShouldBoostBeyondRangeByConstant))
            {
                writer.WritePropertyName("constantBoostBeyondRange"u8);
                writer.WriteBooleanValue(ShouldBoostBeyondRangeByConstant.Value);
            }
            writer.WriteEndObject();
        }

        MagnitudeScoringParameters IModelJsonSerializable<MagnitudeScoringParameters>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeMagnitudeScoringParameters(doc.RootElement, options);
        }

        BinaryData IModelSerializable<MagnitudeScoringParameters>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        MagnitudeScoringParameters IModelSerializable<MagnitudeScoringParameters>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeMagnitudeScoringParameters(document.RootElement, options);
        }

        internal static MagnitudeScoringParameters DeserializeMagnitudeScoringParameters(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            double boostingRangeStart = default;
            double boostingRangeEnd = default;
            Optional<bool> constantBoostBeyondRange = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("boostingRangeStart"u8))
                {
                    boostingRangeStart = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("boostingRangeEnd"u8))
                {
                    boostingRangeEnd = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("constantBoostBeyondRange"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    constantBoostBeyondRange = property.Value.GetBoolean();
                    continue;
                }
            }
            return new MagnitudeScoringParameters(boostingRangeStart, boostingRangeEnd, Optional.ToNullable(constantBoostBeyondRange));
        }
    }
}
