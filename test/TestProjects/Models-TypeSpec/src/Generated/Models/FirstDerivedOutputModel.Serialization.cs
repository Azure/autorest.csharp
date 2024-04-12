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

namespace ModelsTypeSpec.Models
{
    public partial class FirstDerivedOutputModel : IUtf8JsonSerializable, IJsonModel<FirstDerivedOutputModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<FirstDerivedOutputModel>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<FirstDerivedOutputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FirstDerivedOutputModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FirstDerivedOutputModel)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("first"u8);
            writer.WriteBooleanValue(First);
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
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

        FirstDerivedOutputModel IJsonModel<FirstDerivedOutputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FirstDerivedOutputModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FirstDerivedOutputModel)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFirstDerivedOutputModel(document.RootElement, options);
        }

        internal static FirstDerivedOutputModel DeserializeFirstDerivedOutputModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool first = default;
            string kind = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("first"u8))
                {
                    first = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new FirstDerivedOutputModel(kind, serializedAdditionalRawData, first);
        }

        BinaryData IPersistableModel<FirstDerivedOutputModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FirstDerivedOutputModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FirstDerivedOutputModel)} does not support writing '{options.Format}' format.");
            }
        }

        FirstDerivedOutputModel IPersistableModel<FirstDerivedOutputModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FirstDerivedOutputModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeFirstDerivedOutputModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FirstDerivedOutputModel)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FirstDerivedOutputModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new FirstDerivedOutputModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFirstDerivedOutputModel(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal override RequestContent ToRequestContent()
        {
            BinaryData binaryData = ModelReaderWriter.Write(this, new ModelReaderWriterOptions("W"));
            return RequestContent.Create(binaryData);
        }
    }
}
