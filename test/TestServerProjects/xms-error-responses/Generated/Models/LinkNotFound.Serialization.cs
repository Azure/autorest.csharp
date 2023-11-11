// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace xms_error_responses.Models
{
    internal partial class LinkNotFound : IUtf8JsonSerializable, IJsonModel<LinkNotFound>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<LinkNotFound>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<LinkNotFound>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<LinkNotFound>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<LinkNotFound>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(WhatSubAddress))
            {
                writer.WritePropertyName("whatSubAddress"u8);
                writer.WriteStringValue(WhatSubAddress);
            }
            if (Optional.IsDefined(Reason))
            {
                writer.WritePropertyName("reason"u8);
                writer.WriteStringValue(Reason);
            }
            writer.WritePropertyName("whatNotFound"u8);
            writer.WriteStringValue(WhatNotFound);
            if (Optional.IsDefined(SomeBaseProp))
            {
                writer.WritePropertyName("someBaseProp"u8);
                writer.WriteStringValue(SomeBaseProp);
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
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

        LinkNotFound IJsonModel<LinkNotFound>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(LinkNotFound)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLinkNotFound(document.RootElement, options);
        }

        internal static LinkNotFound DeserializeLinkNotFound(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> whatSubAddress = default;
            Optional<string> reason = default;
            string whatNotFound = default;
            Optional<string> someBaseProp = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("whatSubAddress"u8))
                {
                    whatSubAddress = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("reason"u8))
                {
                    reason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("whatNotFound"u8))
                {
                    whatNotFound = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("someBaseProp"u8))
                {
                    someBaseProp = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new LinkNotFound(someBaseProp.Value, serializedAdditionalRawData, reason.Value, whatNotFound, whatSubAddress.Value);
        }

        BinaryData IModel<LinkNotFound>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(LinkNotFound)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        LinkNotFound IModel<LinkNotFound>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(LinkNotFound)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeLinkNotFound(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<LinkNotFound>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
