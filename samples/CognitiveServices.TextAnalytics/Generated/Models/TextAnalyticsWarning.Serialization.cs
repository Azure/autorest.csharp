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

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class TextAnalyticsWarning : IUtf8JsonSerializable, IModelJsonSerializable<TextAnalyticsWarning>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<TextAnalyticsWarning>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<TextAnalyticsWarning>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("code"u8);
            writer.WriteStringValue(Code.ToSerialString());
            writer.WritePropertyName("message"u8);
            writer.WriteStringValue(Message);
            if (Optional.IsDefined(TargetRef))
            {
                writer.WritePropertyName("targetRef"u8);
                writer.WriteStringValue(TargetRef);
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

        internal static TextAnalyticsWarning DeserializeTextAnalyticsWarning(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            WarningCodeValue code = default;
            string message = default;
            Optional<string> targetRef = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"u8))
                {
                    code = property.Value.GetString().ToWarningCodeValue();
                    continue;
                }
                if (property.NameEquals("message"u8))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetRef"u8))
                {
                    targetRef = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new TextAnalyticsWarning(code, message, targetRef.Value, rawData);
        }

        TextAnalyticsWarning IModelJsonSerializable<TextAnalyticsWarning>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeTextAnalyticsWarning(doc.RootElement, options);
        }

        BinaryData IModelSerializable<TextAnalyticsWarning>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        TextAnalyticsWarning IModelSerializable<TextAnalyticsWarning>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeTextAnalyticsWarning(doc.RootElement, options);
        }

        public static implicit operator RequestContent(TextAnalyticsWarning model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator TextAnalyticsWarning(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeTextAnalyticsWarning(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
