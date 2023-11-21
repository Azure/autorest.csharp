// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtExpandResourceTypes.Models
{
    public partial class DnsResourceReferenceContent : IUtf8JsonSerializable, IJsonModel<DnsResourceReferenceContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DnsResourceReferenceContent>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DnsResourceReferenceContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsResourceReferenceContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(DnsResourceReferenceContent)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(TargetResources))
            {
                writer.WritePropertyName("targetResources"u8);
                writer.WriteStartArray();
                foreach (var item in TargetResources)
                {
                    JsonSerializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            if (_serializedAdditionalRawData != null && options.Format != "W")
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

        DnsResourceReferenceContent IJsonModel<DnsResourceReferenceContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsResourceReferenceContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(DnsResourceReferenceContent)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDnsResourceReferenceContent(document.RootElement, options);
        }

        internal static DnsResourceReferenceContent DeserializeDnsResourceReferenceContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<WritableSubResource>> targetResources = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("targetResources"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WritableSubResource> array = new List<WritableSubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.GetRawText()));
                            }
                            targetResources = array;
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DnsResourceReferenceContent(Optional.ToList(targetResources), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DnsResourceReferenceContent>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsResourceReferenceContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(DnsResourceReferenceContent)} does not support '{options.Format}' format.");
            }
        }

        DnsResourceReferenceContent IPersistableModel<DnsResourceReferenceContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsResourceReferenceContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDnsResourceReferenceContent(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(DnsResourceReferenceContent)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DnsResourceReferenceContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
