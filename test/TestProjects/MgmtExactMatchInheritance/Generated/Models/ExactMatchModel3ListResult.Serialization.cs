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

namespace MgmtExactMatchInheritance.Models
{
    internal partial class ExactMatchModel3ListResult : IUtf8JsonSerializable, IJsonModel<ExactMatchModel3ListResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ExactMatchModel3ListResult>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ExactMatchModel3ListResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExactMatchModel3ListResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(ExactMatchModel3ListResult)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W")
            {
                if (Optional.IsCollectionDefined(Value))
                {
                    writer.WritePropertyName("value"u8);
                    writer.WriteStartArray();
                    foreach (var item in Value)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            if (options.Format != "W")
            {
                if (Optional.IsDefined(NextLink))
                {
                    writer.WritePropertyName("nextLink"u8);
                    writer.WriteStringValue(NextLink);
                }
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

        ExactMatchModel3ListResult IJsonModel<ExactMatchModel3ListResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExactMatchModel3ListResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(ExactMatchModel3ListResult)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeExactMatchModel3ListResult(document.RootElement, options);
        }

        internal static ExactMatchModel3ListResult DeserializeExactMatchModel3ListResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<ExactMatchModel3>> value = default;
            Optional<string> nextLink = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ExactMatchModel3> array = new List<ExactMatchModel3>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ExactMatchModel3.DeserializeExactMatchModel3(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ExactMatchModel3ListResult(Optional.ToList(value), nextLink.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ExactMatchModel3ListResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExactMatchModel3ListResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(ExactMatchModel3ListResult)} does not support '{options.Format}' format.");
            }
        }

        ExactMatchModel3ListResult IPersistableModel<ExactMatchModel3ListResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExactMatchModel3ListResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeExactMatchModel3ListResult(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(ExactMatchModel3ListResult)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ExactMatchModel3ListResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
