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

namespace Payload.JsonMergePatch.Models
{
    public partial class NestedModel : IUtf8JsonSerializable, IJsonModel<NestedModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<NestedModel>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<NestedModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" || options.Format == "P" ? ((IPersistableModel<NestedModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NestedModel)} does not support '{format}' format.");
            }

            if (options.Format == "W")
            {
                WriteJson(writer, options);
            }
            else if (options.Format == "P")
            {
                WritePatch(writer);
            }
        }

        internal void WriteJson(Utf8JsonWriter writer, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(InnerModel))
            {
                writer.WritePropertyName("innerModel"u8);
                writer.WriteObjectValue(InnerModel);
            }
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

        internal void WritePatch(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (_description != null)
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(_description);
            }
            else if (_descriptionChanged)
            {
                writer.WritePropertyName("description"u8);
                writer.WriteNullValue();
            }
            if (_innerModel != null)
            {
                writer.WritePropertyName("innerModel"u8);
                _innerModel.WritePatch(writer);
            }
            else if (_innerModelChanged)
            {
                writer.WritePropertyName("innerModel"u8);
                writer.WriteNullValue();
            }
        }

        NestedModel IJsonModel<NestedModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NestedModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NestedModel)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNestedModel(document.RootElement, options);
        }

        internal static NestedModel DeserializeNestedModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<string> description = default;
            Optional<InnerModel> innerModel = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("innerModel"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    innerModel = InnerModel.DeserializeInnerModel(property.Value);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new NestedModel(name, description.Value, innerModel.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<NestedModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NestedModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(NestedModel)} does not support '{options.Format}' format.");
            }
        }

        NestedModel IPersistableModel<NestedModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NestedModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeNestedModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NestedModel)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<NestedModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static NestedModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeNestedModel(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal virtual RequestContent ToPatchRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            WritePatch(content.JsonWriter);
            return content;
        }
    }
}
