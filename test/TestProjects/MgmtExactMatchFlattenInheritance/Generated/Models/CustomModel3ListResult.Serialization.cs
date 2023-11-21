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
using MgmtExactMatchFlattenInheritance;

namespace MgmtExactMatchFlattenInheritance.Models
{
    internal partial class CustomModel3ListResult : IUtf8JsonSerializable, IJsonModel<CustomModel3ListResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<CustomModel3ListResult>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<CustomModel3ListResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CustomModel3ListResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(CustomModel3ListResult)} does not support '{format}' format.");
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

        CustomModel3ListResult IJsonModel<CustomModel3ListResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CustomModel3ListResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(CustomModel3ListResult)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCustomModel3ListResult(document.RootElement, options);
        }

        internal static CustomModel3ListResult DeserializeCustomModel3ListResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<CustomModel3Data>> value = default;
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
                    List<CustomModel3Data> array = new List<CustomModel3Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CustomModel3Data.DeserializeCustomModel3Data(item));
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
            return new CustomModel3ListResult(Optional.ToList(value), nextLink.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CustomModel3ListResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CustomModel3ListResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(CustomModel3ListResult)} does not support '{options.Format}' format.");
            }
        }

        CustomModel3ListResult IPersistableModel<CustomModel3ListResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CustomModel3ListResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCustomModel3ListResult(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(CustomModel3ListResult)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<CustomModel3ListResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
