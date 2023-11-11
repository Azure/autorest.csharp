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

namespace Azure.AI.FormRecognizer.Models
{
    public partial class DataTableCell : IUtf8JsonSerializable, IJsonModel<DataTableCell>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DataTableCell>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<DataTableCell>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<DataTableCell>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<DataTableCell>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("rowIndex"u8);
            writer.WriteNumberValue(RowIndex);
            writer.WritePropertyName("columnIndex"u8);
            writer.WriteNumberValue(ColumnIndex);
            if (Optional.IsDefined(RowSpan))
            {
                writer.WritePropertyName("rowSpan"u8);
                writer.WriteNumberValue(RowSpan.Value);
            }
            if (Optional.IsDefined(ColumnSpan))
            {
                writer.WritePropertyName("columnSpan"u8);
                writer.WriteNumberValue(ColumnSpan.Value);
            }
            writer.WritePropertyName("text"u8);
            writer.WriteStringValue(Text);
            writer.WritePropertyName("boundingBox"u8);
            writer.WriteStartArray();
            foreach (var item in BoundingBox)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("confidence"u8);
            writer.WriteNumberValue(Confidence);
            if (Optional.IsCollectionDefined(Elements))
            {
                writer.WritePropertyName("elements"u8);
                writer.WriteStartArray();
                foreach (var item in Elements)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(IsHeader))
            {
                writer.WritePropertyName("isHeader"u8);
                writer.WriteBooleanValue(IsHeader.Value);
            }
            if (Optional.IsDefined(IsFooter))
            {
                writer.WritePropertyName("isFooter"u8);
                writer.WriteBooleanValue(IsFooter.Value);
            }
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

        DataTableCell IJsonModel<DataTableCell>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DataTableCell)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDataTableCell(document.RootElement, options);
        }

        internal static DataTableCell DeserializeDataTableCell(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int rowIndex = default;
            int columnIndex = default;
            Optional<int> rowSpan = default;
            Optional<int> columnSpan = default;
            string text = default;
            IReadOnlyList<float> boundingBox = default;
            float confidence = default;
            Optional<IReadOnlyList<string>> elements = default;
            Optional<bool> isHeader = default;
            Optional<bool> isFooter = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rowIndex"u8))
                {
                    rowIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("columnIndex"u8))
                {
                    columnIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("rowSpan"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rowSpan = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("columnSpan"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    columnSpan = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boundingBox"u8))
                {
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    boundingBox = array;
                    continue;
                }
                if (property.NameEquals("confidence"u8))
                {
                    confidence = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("elements"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    elements = array;
                    continue;
                }
                if (property.NameEquals("isHeader"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isHeader = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("isFooter"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isFooter = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DataTableCell(rowIndex, columnIndex, Optional.ToNullable(rowSpan), Optional.ToNullable(columnSpan), text, boundingBox, confidence, Optional.ToList(elements), Optional.ToNullable(isHeader), Optional.ToNullable(isFooter), serializedAdditionalRawData);
        }

        BinaryData IModel<DataTableCell>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DataTableCell)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DataTableCell IModel<DataTableCell>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DataTableCell)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDataTableCell(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<DataTableCell>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
