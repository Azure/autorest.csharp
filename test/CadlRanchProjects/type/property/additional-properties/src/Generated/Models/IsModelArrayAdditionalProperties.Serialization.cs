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
    public partial class IsModelArrayAdditionalProperties : IUtf8JsonSerializable, IJsonModel<IsModelArrayAdditionalProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<IsModelArrayAdditionalProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<IsModelArrayAdditionalProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsModelArrayAdditionalProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IsModelArrayAdditionalProperties)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStartArray();
                foreach (var item0 in item.Value)
                {
                    if (item0 == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item0);
#else
                    using (JsonDocument document = JsonDocument.Parse(item0))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        IsModelArrayAdditionalProperties IJsonModel<IsModelArrayAdditionalProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsModelArrayAdditionalProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IsModelArrayAdditionalProperties)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIsModelArrayAdditionalProperties(document.RootElement, options);
        }

        internal static IsModelArrayAdditionalProperties DeserializeIsModelArrayAdditionalProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, IList<BinaryData>> additionalProperties = default;
            Dictionary<string, IList<BinaryData>> additionalPropertiesDictionary = new Dictionary<string, IList<BinaryData>>();
            foreach (var property in element.EnumerateObject())
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
                        array.Add(BinaryData.FromString(item.GetRawText()));
                    }
                }
                additionalPropertiesDictionary.Add(property.Name, array);
            }
            additionalProperties = additionalPropertiesDictionary;
            return new IsModelArrayAdditionalProperties(additionalProperties);
        }

        BinaryData IPersistableModel<IsModelArrayAdditionalProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsModelArrayAdditionalProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(IsModelArrayAdditionalProperties)} does not support writing '{options.Format}' format.");
            }
        }

        IsModelArrayAdditionalProperties IPersistableModel<IsModelArrayAdditionalProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsModelArrayAdditionalProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeIsModelArrayAdditionalProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(IsModelArrayAdditionalProperties)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<IsModelArrayAdditionalProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static IsModelArrayAdditionalProperties FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeIsModelArrayAdditionalProperties(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue<IsModelArrayAdditionalProperties>(this, new ModelReaderWriterOptions("W"));
            return content;
        }
    }
}
