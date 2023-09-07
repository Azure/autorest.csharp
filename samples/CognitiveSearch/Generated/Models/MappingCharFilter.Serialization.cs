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

namespace CognitiveSearch.Models
{
    public partial class MappingCharFilter : IUtf8JsonSerializable, IModelJsonSerializable<MappingCharFilter>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<MappingCharFilter>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<MappingCharFilter>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MappingCharFilter>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("mappings"u8);
            writer.WriteStartArray();
            foreach (var item in Mappings)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
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

        internal static MappingCharFilter DeserializeMappingCharFilter(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> mappings = default;
            string odataType = default;
            string name = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("mappings"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    mappings = array;
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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new MappingCharFilter(odataType, name, mappings, serializedAdditionalRawData);
        }

        MappingCharFilter IModelJsonSerializable<MappingCharFilter>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MappingCharFilter>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeMappingCharFilter(doc.RootElement, options);
        }

        BinaryData IModelSerializable<MappingCharFilter>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MappingCharFilter>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        MappingCharFilter IModelSerializable<MappingCharFilter>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MappingCharFilter>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeMappingCharFilter(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="MappingCharFilter"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="MappingCharFilter"/> to convert. </param>
        public static implicit operator RequestContent(MappingCharFilter model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="MappingCharFilter"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator MappingCharFilter(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeMappingCharFilter(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
