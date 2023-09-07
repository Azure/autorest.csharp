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
    public partial class Cookiecuttershark : IUtf8JsonSerializable, IModelJsonSerializable<Cookiecuttershark>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Cookiecuttershark>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Cookiecuttershark>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Cookiecuttershark>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Age))
            {
                writer.WritePropertyName("age"u8);
                writer.WriteNumberValue(Age.Value);
            }
            writer.WritePropertyName("birthday"u8);
            writer.WriteStringValue(Birthday, "O");
            writer.WritePropertyName("fishtype"u8);
            writer.WriteStringValue(Fishtype);
            if (Optional.IsDefined(Species))
            {
                writer.WritePropertyName("species"u8);
                writer.WriteStringValue(Species);
            }
            writer.WritePropertyName("length"u8);
            writer.WriteNumberValue(Length);
            if (Optional.IsCollectionDefined(Siblings))
            {
                writer.WritePropertyName("siblings"u8);
                writer.WriteStartArray();
                foreach (var item in Siblings)
                {
                    if (item is null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        ((IModelJsonSerializable<Fish>)item).Serialize(writer, options);
                    }
                }
                writer.WriteEndArray();
            }
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
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

        internal static Cookiecuttershark DeserializeCookiecuttershark(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> age = default;
            DateTimeOffset birthday = default;
            string fishtype = default;
            Optional<string> species = default;
            float length = default;
            Optional<IList<Fish>> siblings = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("age"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    age = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("birthday"u8))
                {
                    birthday = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("fishtype"u8))
                {
                    fishtype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"u8))
                {
                    species = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("length"u8))
                {
                    length = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("siblings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Fish> array = new List<Fish>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeFish(item));
                    }
                    siblings = array;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new Cookiecuttershark(fishtype, species.Value, length, Optional.ToList(siblings), Optional.ToNullable(age), birthday, serializedAdditionalRawData);
        }

        Cookiecuttershark IModelJsonSerializable<Cookiecuttershark>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Cookiecuttershark>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeCookiecuttershark(doc.RootElement, options);
        }

        BinaryData IModelSerializable<Cookiecuttershark>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Cookiecuttershark>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        Cookiecuttershark IModelSerializable<Cookiecuttershark>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Cookiecuttershark>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeCookiecuttershark(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="Cookiecuttershark"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="Cookiecuttershark"/> to convert. </param>
        public static implicit operator RequestContent(Cookiecuttershark model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="Cookiecuttershark"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator Cookiecuttershark(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeCookiecuttershark(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
