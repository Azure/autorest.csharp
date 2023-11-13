// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class DatetimeWrapper : IUtf8JsonSerializable, IJsonModel<DatetimeWrapper>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DatetimeWrapper>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<DatetimeWrapper>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<DatetimeWrapper>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<DatetimeWrapper>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Field))
            {
                writer.WritePropertyName("field"u8);
                writer.WriteStringValue(Field.Value, "O");
            }
            if (Optional.IsDefined(Now))
            {
                writer.WritePropertyName("now"u8);
                writer.WriteStringValue(Now.Value, "O");
            }
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        DatetimeWrapper IJsonModel<DatetimeWrapper>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DatetimeWrapper)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDatetimeWrapper(document.RootElement, options);
        }

        internal static DatetimeWrapper DeserializeDatetimeWrapper(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DateTimeOffset> field = default;
            Optional<DateTimeOffset> now = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    field = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("now"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    now = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DatetimeWrapper(Optional.ToNullable(field), Optional.ToNullable(now), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DatetimeWrapper>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DatetimeWrapper)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DatetimeWrapper IPersistableModel<DatetimeWrapper>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DatetimeWrapper)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDatetimeWrapper(document.RootElement, options);
        }

        string IPersistableModel<DatetimeWrapper>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
