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

namespace Payload.MultiPart.Models
{
    public partial class BinaryArrayPartsRequest : IUtf8JsonSerializable, IJsonModel<BinaryArrayPartsRequest>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BinaryArrayPartsRequest>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<BinaryArrayPartsRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BinaryArrayPartsRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BinaryArrayPartsRequest)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("pictures"u8);
            writer.WriteStartArray();
            foreach (var item in Pictures)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteBase64StringValue(item.ToArray(), "D");
            }
            writer.WriteEndArray();
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

        BinaryArrayPartsRequest IJsonModel<BinaryArrayPartsRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BinaryArrayPartsRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BinaryArrayPartsRequest)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBinaryArrayPartsRequest(document.RootElement, options);
        }

        internal static BinaryArrayPartsRequest DeserializeBinaryArrayPartsRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            IList<BinaryData> pictures = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("pictures"u8))
                {
                    List<BinaryData> array = new List<BinaryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(BinaryData.FromBytes(item.GetBytesFromBase64("D")));
                        }
                    }
                    pictures = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new BinaryArrayPartsRequest(id, pictures, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<BinaryArrayPartsRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BinaryArrayPartsRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "MPFD":
                    {
                        string boundary = Guid.NewGuid().ToString();
                        using MultipartFormData content = new MultipartFormData(boundary);
                        content.Add(BinaryData.FromString(Id), "id");
                        foreach (BinaryData item in Pictures)
                        {
                            content.Add(item.WithMediaType("application/octet-stream"), "pictures", "pictures.wav", null);
                        }
                        BinaryData binaryData = ModelReaderWriter.Write(content, new ModelReaderWriterOptions("MPFD"));
                        return binaryData;
                    }
                default:
                    throw new FormatException($"The model {nameof(BinaryArrayPartsRequest)} does not support '{options.Format}' format.");
            }
        }

        BinaryArrayPartsRequest IPersistableModel<BinaryArrayPartsRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BinaryArrayPartsRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeBinaryArrayPartsRequest(document.RootElement, options);
                    }
                case "MPFD":
                    {
                        using MultipartFormData content = MultipartFormData.Create(data);
                        string id = default;
                        IList<BinaryData> pictures = default;
                        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
                        Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
                        IReadOnlyList<FormDataItem> multiParts = content.ParseToFormData();
                        foreach (FormDataItem part in multiParts)
                        {
                            string propertyName = part.Name;
                            if (propertyName == "id")
                            {
                                id = part.Content.ToString();
                                continue;
                            }
                            if (propertyName == "pictures")
                            {
                                pictures = part.Content.ToObjectFromJson<IList<BinaryData>>();
                                continue;
                            }
                        }
                        serializedAdditionalRawData = additionalPropertiesDictionary;
                        return new BinaryArrayPartsRequest(id, pictures, serializedAdditionalRawData);
                    }
                default:
                    throw new FormatException($"The model {nameof(BinaryArrayPartsRequest)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<BinaryArrayPartsRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static BinaryArrayPartsRequest FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeBinaryArrayPartsRequest(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
