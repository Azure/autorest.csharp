// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class DeleteRetentionPolicy : IUtf8JsonSerializable, IJsonModel<DeleteRetentionPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeleteRetentionPolicy>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DeleteRetentionPolicy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteRetentionPolicy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(DeleteRetentionPolicy)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Enabled))
            {
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(Enabled.Value);
            }
            if (Optional.IsDefined(Days))
            {
                writer.WritePropertyName("days"u8);
                writer.WriteNumberValue(Days.Value);
            }
            if (_serializedAdditionalRawData != null && options.Format != "W")
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        DeleteRetentionPolicy IJsonModel<DeleteRetentionPolicy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteRetentionPolicy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(DeleteRetentionPolicy)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeleteRetentionPolicy(document.RootElement, options);
        }

        internal static DeleteRetentionPolicy DeserializeDeleteRetentionPolicy(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> enabled = default;
            Optional<int> days = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("days"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    days = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DeleteRetentionPolicy(Optional.ToNullable(enabled), Optional.ToNullable(days), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DeleteRetentionPolicy>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteRetentionPolicy>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(DeleteRetentionPolicy)} does not support '{options.Format}' format.");
            }
        }

        DeleteRetentionPolicy IPersistableModel<DeleteRetentionPolicy>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteRetentionPolicy>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDeleteRetentionPolicy(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(DeleteRetentionPolicy)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DeleteRetentionPolicy>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
