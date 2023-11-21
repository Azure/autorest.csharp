// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(ErrorAdditionalInfoConverter))]
    public partial class ErrorAdditionalInfo : IUtf8JsonSerializable, IJsonModel<ErrorAdditionalInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ErrorAdditionalInfo>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ErrorAdditionalInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ErrorAdditionalInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(ErrorAdditionalInfo)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ErrorAdditionalInfoType))
                {
                    writer.WritePropertyName("type"u8);
                    writer.WriteStringValue(ErrorAdditionalInfoType);
                }
            }
            if (options.Format == "J")
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

        ErrorAdditionalInfo IJsonModel<ErrorAdditionalInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ErrorAdditionalInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(ErrorAdditionalInfo)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeErrorAdditionalInfo(document.RootElement, options);
        }

        internal static ErrorAdditionalInfo DeserializeErrorAdditionalInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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

        BinaryData IPersistableModel<ErrorAdditionalInfo>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ErrorAdditionalInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(ErrorAdditionalInfo)} does not support '{options.Format}' format.");
            }
        }

        ErrorAdditionalInfo IPersistableModel<ErrorAdditionalInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ErrorAdditionalInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeErrorAdditionalInfo(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(ErrorAdditionalInfo)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ErrorAdditionalInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

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
