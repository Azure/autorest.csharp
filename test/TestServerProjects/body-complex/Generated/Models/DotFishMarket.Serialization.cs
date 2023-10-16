// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace body_complex.Models
{
    public partial class DotFishMarket : IUtf8JsonSerializable, IModelJsonSerializable<DotFishMarket>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DotFishMarket>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DotFishMarket>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(SampleSalmon))
            {
                writer.WritePropertyName("sampleSalmon"u8);
                writer.WriteObjectValue(SampleSalmon);
            }
            if (Optional.IsCollectionDefined(Salmons))
            {
                writer.WritePropertyName("salmons"u8);
                writer.WriteStartArray();
                foreach (var item in Salmons)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(SampleFish))
            {
                writer.WritePropertyName("sampleFish"u8);
                writer.WriteObjectValue(SampleFish);
            }
            if (Optional.IsCollectionDefined(Fishes))
            {
                writer.WritePropertyName("fishes"u8);
                writer.WriteStartArray();
                foreach (var item in Fishes)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        DotFishMarket IModelJsonSerializable<DotFishMarket>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDotFishMarket(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DotFishMarket>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        DotFishMarket IModelSerializable<DotFishMarket>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDotFishMarket(document.RootElement, options);
        }

        internal static DotFishMarket DeserializeDotFishMarket(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DotSalmon> sampleSalmon = default;
            Optional<IReadOnlyList<DotSalmon>> salmons = default;
            Optional<DotFish> sampleFish = default;
            Optional<IReadOnlyList<DotFish>> fishes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sampleSalmon"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sampleSalmon = DotSalmon.DeserializeDotSalmon(property.Value);
                    continue;
                }
                if (property.NameEquals("salmons"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DotSalmon> array = new List<DotSalmon>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DotSalmon.DeserializeDotSalmon(item));
                    }
                    salmons = array;
                    continue;
                }
                if (property.NameEquals("sampleFish"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sampleFish = DotFish.DeserializeDotFish(property.Value);
                    continue;
                }
                if (property.NameEquals("fishes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DotFish> array = new List<DotFish>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DotFish.DeserializeDotFish(item));
                    }
                    fishes = array;
                    continue;
                }
            }
            return new DotFishMarket(sampleSalmon.Value, Optional.ToList(salmons), sampleFish.Value, Optional.ToList(fishes));
        }
    }
}
