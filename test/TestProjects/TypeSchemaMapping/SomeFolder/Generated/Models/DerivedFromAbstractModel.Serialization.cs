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

namespace TypeSchemaMapping.Models
{
    public partial class DerivedFromAbstractModel : IUtf8JsonSerializable, IModelJsonSerializable<DerivedFromAbstractModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DerivedFromAbstractModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DerivedFromAbstractModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DerivedFromAbstractModel>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("DiscriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty);
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

        internal static DerivedFromAbstractModel DeserializeDerivedFromAbstractModel(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string discriminatorProperty = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("DiscriminatorProperty"u8))
                {
                    discriminatorProperty = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new DerivedFromAbstractModel(discriminatorProperty, rawData);
        }

        DerivedFromAbstractModel IModelJsonSerializable<DerivedFromAbstractModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DerivedFromAbstractModel>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDerivedFromAbstractModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DerivedFromAbstractModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DerivedFromAbstractModel>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DerivedFromAbstractModel IModelSerializable<DerivedFromAbstractModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DerivedFromAbstractModel>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDerivedFromAbstractModel(doc.RootElement, options);
        }

        public static implicit operator RequestContent(DerivedFromAbstractModel model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator DerivedFromAbstractModel(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDerivedFromAbstractModel(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
