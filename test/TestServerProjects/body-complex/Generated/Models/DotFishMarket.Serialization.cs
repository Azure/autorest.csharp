// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace body_complex.Models
{
    public partial class DotFishMarket : IUtf8JsonSerializable, IModelJsonSerializable<DotFishMarket>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DotFishMarket>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DotFishMarket>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(SampleSalmon))
            {
                writer.WritePropertyName("sampleSalmon"u8);
                ((IModelJsonSerializable<DotSalmon>)SampleSalmon).Serialize(writer, options);
            }
            if (Optional.IsCollectionDefined(Salmons))
            {
                writer.WritePropertyName("salmons"u8);
                writer.WriteStartArray();
                foreach (var item in Salmons)
                {
                    ((IModelJsonSerializable<DotSalmon>)item).Serialize(writer, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(SampleFish))
            {
                writer.WritePropertyName("sampleFish"u8);
                ((IModelJsonSerializable<DotFish>)SampleFish).Serialize(writer, options);
            }
            if (Optional.IsCollectionDefined(Fishes))
            {
                writer.WritePropertyName("fishes"u8);
                writer.WriteStartArray();
                foreach (var item in Fishes)
                {
                    ((IModelJsonSerializable<DotFish>)item).Serialize(writer, options);
                }
                writer.WriteEndArray();
            }
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static DotFishMarket DeserializeDotFishMarket(JsonElement element, ModelSerializerOptions options = default)
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
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new DotFishMarket(sampleSalmon.Value, Optional.ToList(salmons), sampleFish.Value, Optional.ToList(fishes), rawData);
        }

        DotFishMarket IModelJsonSerializable<DotFishMarket>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
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

            using var doc = JsonDocument.Parse(data);
            return DeserializeDotFishMarket(doc.RootElement, options);
        }

        public static implicit operator RequestContent(DotFishMarket model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator DotFishMarket(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDotFishMarket(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
