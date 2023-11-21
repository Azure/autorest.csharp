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
    public partial class DateAfterModification : IUtf8JsonSerializable, IJsonModel<DateAfterModification>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DateAfterModification>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DateAfterModification>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DateAfterModification>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(DateAfterModification)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(DaysAfterModificationGreaterThan))
            {
                writer.WritePropertyName("daysAfterModificationGreaterThan"u8);
                writer.WriteNumberValue(DaysAfterModificationGreaterThan.Value);
            }
            if (Optional.IsDefined(DaysAfterLastAccessTimeGreaterThan))
            {
                writer.WritePropertyName("daysAfterLastAccessTimeGreaterThan"u8);
                writer.WriteNumberValue(DaysAfterLastAccessTimeGreaterThan.Value);
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

        DateAfterModification IJsonModel<DateAfterModification>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DateAfterModification>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(DateAfterModification)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDateAfterModification(document.RootElement, options);
        }

        internal static DateAfterModification DeserializeDateAfterModification(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<float> daysAfterModificationGreaterThan = default;
            Optional<float> daysAfterLastAccessTimeGreaterThan = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("daysAfterModificationGreaterThan"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    daysAfterModificationGreaterThan = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("daysAfterLastAccessTimeGreaterThan"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    daysAfterLastAccessTimeGreaterThan = property.Value.GetSingle();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DateAfterModification(Optional.ToNullable(daysAfterModificationGreaterThan), Optional.ToNullable(daysAfterLastAccessTimeGreaterThan), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DateAfterModification>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DateAfterModification>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(DateAfterModification)} does not support '{options.Format}' format.");
            }
        }

        DateAfterModification IPersistableModel<DateAfterModification>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DateAfterModification>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDateAfterModification(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(DateAfterModification)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DateAfterModification>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
