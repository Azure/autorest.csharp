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

namespace MgmtOmitOperationGroups.Models
{
    public partial class ModelX : IUtf8JsonSerializable, IModelJsonSerializable<ModelX>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelX>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ModelX>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ModelX>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(C))
            {
                writer.WritePropertyName("c"u8);
                writer.WriteStringValue(C);
            }
            if (Optional.IsDefined(D))
            {
                writer.WritePropertyName("d"u8);
                writer.WriteStringValue(D);
            }
            if (Optional.IsDefined(E))
            {
                writer.WritePropertyName("e"u8);
                writer.WriteStringValue(E);
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

        internal static ModelX DeserializeModelX(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> c = default;
            Optional<string> d = default;
            Optional<string> e = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("c"u8))
                {
                    c = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("d"u8))
                {
                    d = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("e"u8))
                {
                    e = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ModelX(e.Value, c.Value, d.Value, rawData);
        }

        ModelX IModelJsonSerializable<ModelX>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ModelX>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelX(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ModelX>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ModelX>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ModelX IModelSerializable<ModelX>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ModelX>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeModelX(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ModelX"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ModelX"/> to convert. </param>
        public static implicit operator RequestContent(ModelX model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ModelX"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ModelX(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeModelX(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
