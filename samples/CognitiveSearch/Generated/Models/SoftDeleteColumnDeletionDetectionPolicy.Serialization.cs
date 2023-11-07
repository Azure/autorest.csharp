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

namespace CognitiveSearch.Models
{
    public partial class SoftDeleteColumnDeletionDetectionPolicy : IUtf8JsonSerializable, IJsonModel<SoftDeleteColumnDeletionDetectionPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SoftDeleteColumnDeletionDetectionPolicy>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<SoftDeleteColumnDeletionDetectionPolicy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(SoftDeleteColumnName))
            {
                writer.WritePropertyName("softDeleteColumnName"u8);
                writer.WriteStringValue(SoftDeleteColumnName);
            }
            if (Optional.IsDefined(SoftDeleteMarkerValue))
            {
                writer.WritePropertyName("softDeleteMarkerValue"u8);
                writer.WriteStringValue(SoftDeleteMarkerValue);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
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

        SoftDeleteColumnDeletionDetectionPolicy IJsonModel<SoftDeleteColumnDeletionDetectionPolicy>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SoftDeleteColumnDeletionDetectionPolicy)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSoftDeleteColumnDeletionDetectionPolicy(document.RootElement, options);
        }

        internal static SoftDeleteColumnDeletionDetectionPolicy DeserializeSoftDeleteColumnDeletionDetectionPolicy(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> softDeleteColumnName = default;
            Optional<string> softDeleteMarkerValue = default;
            string odataType = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("softDeleteColumnName"u8))
                {
                    softDeleteColumnName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("softDeleteMarkerValue"u8))
                {
                    softDeleteMarkerValue = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new SoftDeleteColumnDeletionDetectionPolicy(odataType, serializedAdditionalRawData, softDeleteColumnName.Value, softDeleteMarkerValue.Value);
        }

        BinaryData IModel<SoftDeleteColumnDeletionDetectionPolicy>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SoftDeleteColumnDeletionDetectionPolicy)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        SoftDeleteColumnDeletionDetectionPolicy IModel<SoftDeleteColumnDeletionDetectionPolicy>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SoftDeleteColumnDeletionDetectionPolicy)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeSoftDeleteColumnDeletionDetectionPolicy(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<SoftDeleteColumnDeletionDetectionPolicy>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
