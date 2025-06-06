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
    public partial class GetResponse4 : IUtf8JsonSerializable, IJsonModel<GetResponse4>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<GetResponse4>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<GetResponse4>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GetResponse4>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GetResponse4)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("prop"u8);
            writer.WriteNumberValue(Prop.ToSerialSingle());
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        GetResponse4 IJsonModel<GetResponse4>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GetResponse4>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GetResponse4)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeGetResponse4(document.RootElement, options);
        }

        internal static GetResponse4 DeserializeGetResponse4(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            GetResponseProp3 prop = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("prop"u8))
                {
                    prop = property.Value.GetSingle().ToGetResponseProp3();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new GetResponse4(prop, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<GetResponse4>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GetResponse4>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, _TypeUnionContext.Default);
                default:
                    throw new FormatException($"The model {nameof(GetResponse4)} does not support writing '{options.Format}' format.");
            }
        }

        GetResponse4 IPersistableModel<GetResponse4>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GetResponse4>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeGetResponse4(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(GetResponse4)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<GetResponse4>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static GetResponse4 FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeGetResponse4(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
