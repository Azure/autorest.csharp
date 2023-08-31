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

namespace _Type.Model.Inheritance.SingleDiscriminator.Models
{
    public partial class Eagle : IUtf8JsonSerializable, IModelJsonSerializable<Eagle>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Eagle>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Eagle>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Eagle>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Friends))
            {
                writer.WritePropertyName("friends"u8);
                writer.WriteStartArray();
                foreach (var item in Friends)
                {
                    ((IModelJsonSerializable<Bird>)item).Serialize(writer, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Hate))
            {
                writer.WritePropertyName("hate"u8);
                writer.WriteStartObject();
                foreach (var item in Hate)
                {
                    writer.WritePropertyName(item.Key);
                    ((IModelJsonSerializable<Bird>)item.Value).Serialize(writer, options);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Partner))
            {
                writer.WritePropertyName("partner"u8);
                ((IModelJsonSerializable<Bird>)Partner).Serialize(writer, options);
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WritePropertyName("wingspan"u8);
            writer.WriteNumberValue(Wingspan);
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

        internal static Eagle DeserializeEagle(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<Bird>> friends = default;
            Optional<IDictionary<string, Bird>> hate = default;
            Optional<Bird> partner = default;
            string kind = default;
            int wingspan = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("friends"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Bird> array = new List<Bird>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeBird(item));
                    }
                    friends = array;
                    continue;
                }
                if (property.NameEquals("hate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, Bird> dictionary = new Dictionary<string, Bird>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, DeserializeBird(property0.Value));
                    }
                    hate = dictionary;
                    continue;
                }
                if (property.NameEquals("partner"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    partner = DeserializeBird(property.Value);
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("wingspan"u8))
                {
                    wingspan = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new Eagle(kind, wingspan, Optional.ToList(friends), Optional.ToDictionary(hate), partner.Value, rawData);
        }

        Eagle IModelJsonSerializable<Eagle>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Eagle>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeEagle(doc.RootElement, options);
        }

        BinaryData IModelSerializable<Eagle>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Eagle>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        Eagle IModelSerializable<Eagle>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Eagle>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeEagle(doc.RootElement, options);
        }

        public static implicit operator RequestContent(Eagle model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator Eagle(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeEagle(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
