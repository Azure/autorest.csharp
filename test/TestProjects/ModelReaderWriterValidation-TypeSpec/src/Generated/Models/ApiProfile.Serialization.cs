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

namespace ModelReaderWriterValidationTypeSpec.Models
{
    public partial class ApiProfile : IUtf8JsonSerializable, IJsonModel<ApiProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ApiProfile>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ApiProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ApiProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ApiProfile)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(ProfileVersion))
            {
                writer.WritePropertyName("profileVersion"u8);
                writer.WriteStringValue(ProfileVersion);
            }
            if (Optional.IsDefined(ApiVersion))
            {
                writer.WritePropertyName("apiVersion"u8);
                writer.WriteStringValue(ApiVersion);
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

        ApiProfile IJsonModel<ApiProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ApiProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ApiProfile)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeApiProfile(document.RootElement, options);
        }

        internal static ApiProfile DeserializeApiProfile(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string profileVersion = default;
            string apiVersion = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("profileVersion"u8))
                {
                    profileVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("apiVersion"u8))
                {
                    apiVersion = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ApiProfile(profileVersion, apiVersion, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ApiProfile>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ApiProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ApiProfile)} does not support writing '{options.Format}' format.");
            }
        }

        ApiProfile IPersistableModel<ApiProfile>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ApiProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeApiProfile(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ApiProfile)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ApiProfile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ApiProfile FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeApiProfile(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            BinaryData binaryData = ModelReaderWriter.Write(this, new ModelReaderWriterOptions("W"));
            return RequestContent.Create(binaryData);
        }
    }
}
