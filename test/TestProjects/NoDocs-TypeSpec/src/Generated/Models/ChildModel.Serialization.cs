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

namespace NoDocsTypeSpec.Models
{
    public partial class ChildModel : IUtf8JsonSerializable, IJsonModel<ChildModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ChildModel>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ChildModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChildModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChildModel)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("parent"u8);
            writer.WriteStartArray();
            foreach (var item in Parent)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
        }

        ChildModel IJsonModel<ChildModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChildModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChildModel)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeChildModel(document.RootElement, options);
        }

        internal static ChildModel DeserializeChildModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<BaseModel> parent = default;
            sbyte level = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("parent"u8))
                {
                    List<BaseModel> array = new List<BaseModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeBaseModel(item, options));
                    }
                    parent = array;
                    continue;
                }
                if (property.NameEquals("level"u8))
                {
                    level = property.Value.GetSByte();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ChildModel(level, serializedAdditionalRawData, parent);
        }

        BinaryData IPersistableModel<ChildModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChildModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ChildModel)} does not support writing '{options.Format}' format.");
            }
        }

        ChildModel IPersistableModel<ChildModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChildModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeChildModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ChildModel)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ChildModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static new ChildModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeChildModel(document.RootElement);
        }

        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
