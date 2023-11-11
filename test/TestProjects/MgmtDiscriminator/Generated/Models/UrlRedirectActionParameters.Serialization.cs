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

namespace MgmtDiscriminator.Models
{
    public partial class UrlRedirectActionParameters : IUtf8JsonSerializable, IJsonModel<UrlRedirectActionParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<UrlRedirectActionParameters>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<UrlRedirectActionParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<UrlRedirectActionParameters>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<UrlRedirectActionParameters>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("redirectType"u8);
            writer.WriteStringValue(RedirectType.ToString());
            if (Optional.IsDefined(DestinationProtocol))
            {
                writer.WritePropertyName("destinationProtocol"u8);
                writer.WriteStringValue(DestinationProtocol.Value.ToString());
            }
            if (Optional.IsDefined(CustomPath))
            {
                writer.WritePropertyName("customPath"u8);
                writer.WriteStringValue(CustomPath);
            }
            if (Optional.IsDefined(CustomHostname))
            {
                writer.WritePropertyName("customHostname"u8);
                writer.WriteStringValue(CustomHostname);
            }
            if (Optional.IsDefined(CustomQueryString))
            {
                writer.WritePropertyName("customQueryString"u8);
                writer.WriteStringValue(CustomQueryString);
            }
            if (Optional.IsDefined(CustomFragment))
            {
                writer.WritePropertyName("customFragment"u8);
                writer.WriteStringValue(CustomFragment);
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

        UrlRedirectActionParameters IJsonModel<UrlRedirectActionParameters>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(UrlRedirectActionParameters)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUrlRedirectActionParameters(document.RootElement, options);
        }

        internal static UrlRedirectActionParameters DeserializeUrlRedirectActionParameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            UrlRedirectActionParametersTypeName typeName = default;
            RedirectType redirectType = default;
            Optional<DestinationProtocol> destinationProtocol = default;
            Optional<string> customPath = default;
            Optional<string> customHostname = default;
            Optional<string> customQueryString = default;
            Optional<string> customFragment = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new UrlRedirectActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("redirectType"u8))
                {
                    redirectType = new RedirectType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("destinationProtocol"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    destinationProtocol = new DestinationProtocol(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("customPath"u8))
                {
                    customPath = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customHostname"u8))
                {
                    customHostname = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customQueryString"u8))
                {
                    customQueryString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customFragment"u8))
                {
                    customFragment = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UrlRedirectActionParameters(typeName, redirectType, Optional.ToNullable(destinationProtocol), customPath.Value, customHostname.Value, customQueryString.Value, customFragment.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<UrlRedirectActionParameters>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(UrlRedirectActionParameters)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        UrlRedirectActionParameters IModel<UrlRedirectActionParameters>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(UrlRedirectActionParameters)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeUrlRedirectActionParameters(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<UrlRedirectActionParameters>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
