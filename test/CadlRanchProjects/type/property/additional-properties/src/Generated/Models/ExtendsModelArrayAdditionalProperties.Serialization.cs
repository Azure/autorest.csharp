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

namespace _Type.Property.AdditionalProperties.Models
{
    public partial class ExtendsModelArrayAdditionalProperties : IUtf8JsonSerializable, IJsonModel<ExtendsModelArrayAdditionalProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ExtendsModelArrayAdditionalProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ExtendsModelArrayAdditionalProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsModelArrayAdditionalProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtendsModelArrayAdditionalProperties)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStartArray();
                foreach (var item0 in item.Value)
                {
                    writer.WriteObjectValue(item0);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        ExtendsModelArrayAdditionalProperties IJsonModel<ExtendsModelArrayAdditionalProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsModelArrayAdditionalProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtendsModelArrayAdditionalProperties)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeExtendsModelArrayAdditionalProperties(document.RootElement, options);
        }

        internal static ExtendsModelArrayAdditionalProperties DeserializeExtendsModelArrayAdditionalProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, IList<ModelForRecord>> additionalProperties = default;
            Dictionary<string, IList<ModelForRecord>> additionalPropertiesDictionary = new Dictionary<string, IList<ModelForRecord>>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Array)
                {
                    List<ModelForRecord> array = new List<ModelForRecord>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ModelForRecord.DeserializeModelForRecord(item));
                    }
                    additionalPropertiesDictionary.Add(property.Name, array);
                }
            }
            additionalProperties = additionalPropertiesDictionary;
            return new ExtendsModelArrayAdditionalProperties(additionalProperties);
        }

        BinaryData IPersistableModel<ExtendsModelArrayAdditionalProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsModelArrayAdditionalProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ExtendsModelArrayAdditionalProperties)} does not support '{options.Format}' format.");
            }
        }

        ExtendsModelArrayAdditionalProperties IPersistableModel<ExtendsModelArrayAdditionalProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsModelArrayAdditionalProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeExtendsModelArrayAdditionalProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ExtendsModelArrayAdditionalProperties)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ExtendsModelArrayAdditionalProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ExtendsModelArrayAdditionalProperties FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeExtendsModelArrayAdditionalProperties(document.RootElement);
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
