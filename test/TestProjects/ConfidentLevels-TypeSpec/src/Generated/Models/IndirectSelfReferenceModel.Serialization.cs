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
    internal partial class IndirectSelfReferenceModel : IUtf8JsonSerializable, IModelJsonSerializable<IndirectSelfReferenceModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<IndirectSelfReferenceModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<IndirectSelfReferenceModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("something"u8);
            writer.WriteStringValue(Something);
            if (Optional.IsDefined(Reference))
            {
                writer.WritePropertyName("reference"u8);
                ((IModelJsonSerializable<NonConfidentModelWithSelfReference>)Reference).Serialize(writer, options);
            }
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

        internal static IndirectSelfReferenceModel DeserializeIndirectSelfReferenceModel(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string something = default;
            Optional<NonConfidentModelWithSelfReference> reference = default;
            object unionProperty = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("something"u8))
                {
                    something = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("reference"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    reference = NonConfidentModelWithSelfReference.DeserializeNonConfidentModelWithSelfReference(property.Value);
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
            return new IndirectSelfReferenceModel(something, reference.Value, unionProperty, rawData);
        }

        IndirectSelfReferenceModel IModelJsonSerializable<IndirectSelfReferenceModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeIndirectSelfReferenceModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<IndirectSelfReferenceModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        IndirectSelfReferenceModel IModelSerializable<IndirectSelfReferenceModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeIndirectSelfReferenceModel(doc.RootElement, options);
        }

        public static implicit operator RequestContent(IndirectSelfReferenceModel model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator IndirectSelfReferenceModel(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeIndirectSelfReferenceModel(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
