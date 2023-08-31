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

namespace ConfidentLevelsInTsp.Models
{
    internal partial class NonConfidentModelWithSelfReference : IUtf8JsonSerializable, IModelJsonSerializable<NonConfidentModelWithSelfReference>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<NonConfidentModelWithSelfReference>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<NonConfidentModelWithSelfReference>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("selfReference"u8);
            writer.WriteStartArray();
            foreach (var item in SelfReference)
            {
                ((IModelJsonSerializable<NonConfidentModelWithSelfReference>)item).Serialize(writer, options);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("unionProperty"u8);
            writer.WriteObjectValue(UnionProperty);
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

        internal static NonConfidentModelWithSelfReference DeserializeNonConfidentModelWithSelfReference(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            IList<NonConfidentModelWithSelfReference> selfReference = default;
            object unionProperty = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("selfReference"u8))
                {
                    List<NonConfidentModelWithSelfReference> array = new List<NonConfidentModelWithSelfReference>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeNonConfidentModelWithSelfReference(item));
                    }
                    selfReference = array;
                    continue;
                }
                if (property.NameEquals("unionProperty"u8))
                {
                    unionProperty = property.Value.GetObject();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new NonConfidentModelWithSelfReference(name, selfReference, unionProperty, rawData);
        }

        NonConfidentModelWithSelfReference IModelJsonSerializable<NonConfidentModelWithSelfReference>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeNonConfidentModelWithSelfReference(doc.RootElement, options);
        }

        BinaryData IModelSerializable<NonConfidentModelWithSelfReference>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        NonConfidentModelWithSelfReference IModelSerializable<NonConfidentModelWithSelfReference>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeNonConfidentModelWithSelfReference(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="NonConfidentModelWithSelfReference"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="NonConfidentModelWithSelfReference"/> to convert. </param>
        public static implicit operator RequestContent(NonConfidentModelWithSelfReference model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="NonConfidentModelWithSelfReference"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator NonConfidentModelWithSelfReference(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeNonConfidentModelWithSelfReference(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
