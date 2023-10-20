// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtScopeResource.Models
{
    public partial class TemplateHashResult : IUtf8JsonSerializable, IModelJsonSerializable<TemplateHashResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<TemplateHashResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<TemplateHashResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
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
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        TemplateHashResult IModelJsonSerializable<TemplateHashResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTemplateHashResult(document.RootElement, options);
        }

        BinaryData IModelSerializable<TemplateHashResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        TemplateHashResult IModelSerializable<TemplateHashResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeTemplateHashResult(document.RootElement, options);
        }

        internal static TemplateHashResult DeserializeTemplateHashResult(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> minifiedTemplate = default;
            Optional<string> templateHash = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new TemplateHashResult(minifiedTemplate.Value, templateHash.Value, serializedAdditionalRawData);
        }
    }
}
