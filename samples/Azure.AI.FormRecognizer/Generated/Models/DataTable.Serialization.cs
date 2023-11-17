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

namespace Azure.AI.FormRecognizer.Models
{
    public partial class DataTable : IUtf8JsonSerializable, IJsonModel<DataTable>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DataTable>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DataTable>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<DataTable>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<DataTable>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("rows"u8);
            writer.WriteNumberValue(Rows);
            writer.WritePropertyName("columns"u8);
            writer.WriteNumberValue(Columns);
            writer.WritePropertyName("cells"u8);
            writer.WriteStartArray();
            foreach (var item in Cells)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
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

        DataTable IJsonModel<DataTable>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DataTable)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDataTable(document.RootElement, options);
        }

        internal static DataTable DeserializeDataTable(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int rows = default;
            int columns = default;
            IReadOnlyList<DataTableCell> cells = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rows"u8))
                {
                    rows = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("columns"u8))
                {
                    columns = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("cells"u8))
                {
                    List<DataTableCell> array = new List<DataTableCell>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DataTableCell.DeserializeDataTableCell(item));
                    }
                    cells = array;
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DataTable(rows, columns, cells, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DataTable>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DataTable)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DataTable IPersistableModel<DataTable>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DataTable)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDataTable(document.RootElement, options);
        }

        string IPersistableModel<DataTable>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
