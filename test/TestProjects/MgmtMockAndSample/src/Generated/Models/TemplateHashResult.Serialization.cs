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

namespace MgmtMockAndSample.Models
{
    public partial class TemplateHashResult : IUtf8JsonSerializable, IModelJsonSerializable<TemplateHashResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<TemplateHashResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<TemplateHashResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(MinifiedTemplate))
            {
                writer.WritePropertyName("minifiedTemplate"u8);
                writer.WriteStringValue(MinifiedTemplate);
            }
            if (Optional.IsDefined(TemplateHash))
            {
                writer.WritePropertyName("templateHash"u8);
                writer.WriteStringValue(TemplateHash);
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

        internal static TemplateHashResult DeserializeTemplateHashResult(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> minifiedTemplate = default;
            Optional<string> templateHash = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("minifiedTemplate"u8))
                {
                    minifiedTemplate = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("templateHash"u8))
                {
                    templateHash = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new TemplateHashResult(minifiedTemplate.Value, templateHash.Value, serializedAdditionalRawData);
        }

        TemplateHashResult IModelJsonSerializable<TemplateHashResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeTemplateHashResult(doc.RootElement, options);
        }

        BinaryData IModelSerializable<TemplateHashResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        TemplateHashResult IModelSerializable<TemplateHashResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeTemplateHashResult(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="TemplateHashResult"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="TemplateHashResult"/> to convert. </param>
        public static implicit operator RequestContent(TemplateHashResult model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="TemplateHashResult"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator TemplateHashResult(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeTemplateHashResult(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
