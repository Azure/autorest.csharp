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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class OrchestrationServiceSummary : IUtf8JsonSerializable, IJsonModel<OrchestrationServiceSummary>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<OrchestrationServiceSummary>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<OrchestrationServiceSummary>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OrchestrationServiceSummary>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(OrchestrationServiceSummary)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W")
            {
                if (Optional.IsDefined(ServiceName))
                {
                    writer.WritePropertyName("serviceName"u8);
                    writer.WriteStringValue(ServiceName.Value.ToString());
                }
            }
            if (options.Format != "W")
            {
                if (Optional.IsDefined(ServiceState))
                {
                    writer.WritePropertyName("serviceState"u8);
                    writer.WriteStringValue(ServiceState.Value.ToString());
                }
            }
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

        OrchestrationServiceSummary IJsonModel<OrchestrationServiceSummary>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OrchestrationServiceSummary>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(OrchestrationServiceSummary)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOrchestrationServiceSummary(document.RootElement, options);
        }

        internal static OrchestrationServiceSummary DeserializeOrchestrationServiceSummary(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<OrchestrationServiceName> serviceName = default;
            Optional<OrchestrationServiceState> serviceState = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("serviceName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    serviceName = new OrchestrationServiceName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("serviceState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    serviceState = new OrchestrationServiceState(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new OrchestrationServiceSummary(Optional.ToNullable(serviceName), Optional.ToNullable(serviceState), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<OrchestrationServiceSummary>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OrchestrationServiceSummary>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(OrchestrationServiceSummary)} does not support '{options.Format}' format.");
            }
        }

        OrchestrationServiceSummary IPersistableModel<OrchestrationServiceSummary>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OrchestrationServiceSummary>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeOrchestrationServiceSummary(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(OrchestrationServiceSummary)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<OrchestrationServiceSummary>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
