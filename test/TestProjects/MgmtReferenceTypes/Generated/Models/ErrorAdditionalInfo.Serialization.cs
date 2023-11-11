// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(ErrorAdditionalInfoConverter))]
    public partial class ErrorAdditionalInfo : IUtf8JsonSerializable, IJsonModel<ErrorAdditionalInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ErrorAdditionalInfo>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ErrorAdditionalInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<ErrorAdditionalInfo>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<ErrorAdditionalInfo>)} interface");
            }

            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(ErrorAdditionalInfoType))
                {
                    writer.WritePropertyName("type"u8);
                    writer.WriteStringValue(ErrorAdditionalInfoType);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Info))
                {
                    writer.WritePropertyName("info"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Info);
#else
                    using (JsonDocument document = JsonDocument.Parse(Info))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        ErrorAdditionalInfo IJsonModel<ErrorAdditionalInfo>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ErrorAdditionalInfo)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeErrorAdditionalInfo(document.RootElement, options);
        }

        internal static ErrorAdditionalInfo DeserializeErrorAdditionalInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> type = default;
            Optional<BinaryData> info = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("info"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    info = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
            }
            return new ErrorAdditionalInfo(type.Value, info.Value);
        }

        BinaryData IModel<ErrorAdditionalInfo>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ErrorAdditionalInfo)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        ErrorAdditionalInfo IModel<ErrorAdditionalInfo>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ErrorAdditionalInfo)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeErrorAdditionalInfo(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<ErrorAdditionalInfo>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        internal partial class ErrorAdditionalInfoConverter : JsonConverter<ErrorAdditionalInfo>
        {
            public override void Write(Utf8JsonWriter writer, ErrorAdditionalInfo model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override ErrorAdditionalInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeErrorAdditionalInfo(document.RootElement);
            }
        }
    }
}
