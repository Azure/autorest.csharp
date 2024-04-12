// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Type.Union.Models
{
    public partial class EnumsOnlyCases : IUtf8JsonSerializable, IJsonModel<EnumsOnlyCases>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<EnumsOnlyCases>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<EnumsOnlyCases>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EnumsOnlyCases>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EnumsOnlyCases)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("lr"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Lr);
#else
            using (JsonDocument document = JsonDocument.Parse(Lr))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            writer.WritePropertyName("ud"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Ud);
#else
            using (JsonDocument document = JsonDocument.Parse(Ud))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        EnumsOnlyCases IJsonModel<EnumsOnlyCases>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EnumsOnlyCases>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EnumsOnlyCases)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEnumsOnlyCases(document.RootElement, options);
        }

        internal static EnumsOnlyCases DeserializeEnumsOnlyCases(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BinaryData lr = default;
            BinaryData ud = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("lr"u8))
                {
                    lr = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("ud"u8))
                {
                    ud = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new EnumsOnlyCases(lr, ud, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<EnumsOnlyCases>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EnumsOnlyCases>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(EnumsOnlyCases)} does not support writing '{options.Format}' format.");
            }
        }

        EnumsOnlyCases IPersistableModel<EnumsOnlyCases>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EnumsOnlyCases>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeEnumsOnlyCases(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(EnumsOnlyCases)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<EnumsOnlyCases>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static EnumsOnlyCases FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeEnumsOnlyCases(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, new ModelReaderWriterOptions("W"));
            return content;
        }
    }
}
