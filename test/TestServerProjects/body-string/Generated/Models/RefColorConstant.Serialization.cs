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

namespace body_string.Models
{
    public partial class RefColorConstant : IUtf8JsonSerializable, IModelJsonSerializable<RefColorConstant>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RefColorConstant>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RefColorConstant>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("ColorConstant"u8);
            writer.WriteStringValue(ColorConstant.ToString());
            if (Optional.IsDefined(Field1))
            {
                writer.WritePropertyName("field1"u8);
                writer.WriteStringValue(Field1);
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

        internal static RefColorConstant DeserializeRefColorConstant(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ColorConstant colorConstant = default;
            Optional<string> field1 = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ColorConstant"u8))
                {
                    colorConstant = new ColorConstant(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("field1"u8))
                {
                    field1 = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new RefColorConstant(colorConstant, field1.Value, rawData);
        }

        RefColorConstant IModelJsonSerializable<RefColorConstant>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeRefColorConstant(doc.RootElement, options);
        }

        BinaryData IModelSerializable<RefColorConstant>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        RefColorConstant IModelSerializable<RefColorConstant>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeRefColorConstant(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="RefColorConstant"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="RefColorConstant"/> to convert. </param>
        public static implicit operator RequestContent(RefColorConstant model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="RefColorConstant"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator RefColorConstant(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeRefColorConstant(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
