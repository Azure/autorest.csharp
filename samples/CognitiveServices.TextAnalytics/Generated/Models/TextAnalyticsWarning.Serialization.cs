// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class TextAnalyticsWarning : IUtf8JsonSerializable, IModelJsonSerializable<TextAnalyticsWarning>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<TextAnalyticsWarning>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<TextAnalyticsWarning>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
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
            writer.WriteEndObject();
        }

        TextAnalyticsWarning IModelJsonSerializable<TextAnalyticsWarning>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
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

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeTextAnalyticsWarning(document.RootElement, options);
        }

        internal static TextAnalyticsWarning DeserializeTextAnalyticsWarning(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            WarningCodeValue code = default;
            string message = default;
            Optional<string> targetRef = default;
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
            }
            return new TextAnalyticsWarning(code, message, targetRef.Value);
        }
    }
}
