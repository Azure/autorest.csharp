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
    public partial class MultiBinaryPartsRequest : IUtf8JsonSerializable, IJsonModel<MultiBinaryPartsRequest>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MultiBinaryPartsRequest>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<MultiBinaryPartsRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultiBinaryPartsRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MultiBinaryPartsRequest)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("profileImage"u8);
            writer.WriteBase64StringValue(ProfileImage.ToArray(), "D");
            if (Optional.IsDefined(Picture))
            {
                writer.WritePropertyName("picture"u8);
                writer.WriteBase64StringValue(Picture.ToArray(), "D");
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

        MultiBinaryPartsRequest IJsonModel<MultiBinaryPartsRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultiBinaryPartsRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MultiBinaryPartsRequest)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMultiBinaryPartsRequest(document.RootElement, options);
        }

        internal static MultiBinaryPartsRequest DeserializeMultiBinaryPartsRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BinaryData profileImage = default;
            Optional<BinaryData> picture = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("profileImage"u8))
                {
                    profileImage = BinaryData.FromBytes(property.Value.GetBytesFromBase64("D"));
                    continue;
                }
                if (property.NameEquals("picture"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    picture = BinaryData.FromBytes(property.Value.GetBytesFromBase64("D"));
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new MultiBinaryPartsRequest(profileImage, picture.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MultiBinaryPartsRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultiBinaryPartsRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "MPFD":
                    {
                        string boundary = Guid.NewGuid().ToString();
                        using MultipartFormData content = new MultipartFormData(boundary);
                        content.Add(ProfileImage.WithMediaType("application/octet-stream"), "profileImage", "profileImage.wav", null);
                        if (Optional.IsDefined(Picture))
                        {
                            content.Add(Picture.WithMediaType("application/octet-stream"), "picture", "picture.wav", null);
                        }
                        BinaryData binaryData = ModelReaderWriter.Write(content, new ModelReaderWriterOptions("MPFD"));
                        return binaryData;
                    }
                default:
                    throw new FormatException($"The model {nameof(MultiBinaryPartsRequest)} does not support '{options.Format}' format.");
            }
        }

        MultiBinaryPartsRequest IPersistableModel<MultiBinaryPartsRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultiBinaryPartsRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMultiBinaryPartsRequest(document.RootElement, options);
                    }
                case "MPFD":
                    {
                        using MultipartFormData content = MultipartFormData.Create(data);
                        BinaryData profileImage = default;
                        Optional<BinaryData> picture = default;
                        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
                        Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
                        IReadOnlyList<FormDataItem> multiParts = content.ParseToFormData();
                        foreach (FormDataItem part in multiParts)
                        {
                            string propertyName = part.Name;
                            if (propertyName == "profileImage")
                            {
                                profileImage = part.Content;
                                continue;
                            }
                            if (propertyName == "picture")
                            {
                                picture = part.Content;
                                continue;
                            }
                        }
                        serializedAdditionalRawData = additionalPropertiesDictionary;
                        return new MultiBinaryPartsRequest(profileImage, picture.Value, serializedAdditionalRawData);
                    }
                default:
                    throw new FormatException($"The model {nameof(MultiBinaryPartsRequest)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<MultiBinaryPartsRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MultiBinaryPartsRequest FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMultiBinaryPartsRequest(document.RootElement);
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
