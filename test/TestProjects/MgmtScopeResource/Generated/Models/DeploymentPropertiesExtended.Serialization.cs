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

namespace MgmtScopeResource.Models
{
    public partial class DeploymentPropertiesExtended : IUtf8JsonSerializable, IJsonModel<DeploymentPropertiesExtended>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeploymentPropertiesExtended>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DeploymentPropertiesExtended>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeploymentPropertiesExtended>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(DeploymentPropertiesExtended)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ProvisioningState))
                {
                    writer.WritePropertyName("provisioningState"u8);
                    writer.WriteStringValue(ProvisioningState.Value.ToString());
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(CorrelationId))
                {
                    writer.WritePropertyName("correlationId"u8);
                    writer.WriteStringValue(CorrelationId);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Timestamp))
                {
                    writer.WritePropertyName("timestamp"u8);
                    writer.WriteStringValue(Timestamp.Value, "O");
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Duration))
                {
                    writer.WritePropertyName("duration"u8);
                    writer.WriteStringValue(Duration.Value, "P");
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Outputs))
                {
                    writer.WritePropertyName("outputs"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Outputs);
#else
                    using (JsonDocument document = JsonDocument.Parse(Outputs))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Parameters))
                {
                    writer.WritePropertyName("parameters"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Parameters);
#else
                    using (JsonDocument document = JsonDocument.Parse(Parameters))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            if (Optional.IsDefined(Mode))
            {
                writer.WritePropertyName("mode"u8);
                writer.WriteStringValue(Mode.Value.ToSerialString());
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ErrorResponse))
                {
                    writer.WritePropertyName("errorResponse"u8);
                    writer.WriteObjectValue(ErrorResponse);
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

        DeploymentPropertiesExtended IJsonModel<DeploymentPropertiesExtended>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeploymentPropertiesExtended>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(DeploymentPropertiesExtended)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeploymentPropertiesExtended(document.RootElement, options);
        }

        internal static DeploymentPropertiesExtended DeserializeDeploymentPropertiesExtended(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ProvisioningState> provisioningState = default;
            Optional<string> correlationId = default;
            Optional<DateTimeOffset> timestamp = default;
            Optional<TimeSpan> duration = default;
            Optional<BinaryData> outputs = default;
            Optional<BinaryData> parameters = default;
            Optional<DeploymentMode> mode = default;
            Optional<ErrorResponse> errorResponse = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("provisioningState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    provisioningState = new ProvisioningState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("correlationId"u8))
                {
                    correlationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("timestamp"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    timestamp = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("duration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    duration = property.Value.GetTimeSpan("P");
                    continue;
                }
                if (property.NameEquals("outputs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    outputs = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("parameters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    parameters = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("mode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    mode = property.Value.GetString().ToDeploymentMode();
                    continue;
                }
                if (property.NameEquals("errorResponse"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    errorResponse = ErrorResponse.DeserializeErrorResponse(property.Value);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DeploymentPropertiesExtended(Optional.ToNullable(provisioningState), correlationId.Value, Optional.ToNullable(timestamp), Optional.ToNullable(duration), outputs.Value, parameters.Value, Optional.ToNullable(mode), errorResponse.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DeploymentPropertiesExtended>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeploymentPropertiesExtended>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(DeploymentPropertiesExtended)} does not support '{options.Format}' format.");
            }
        }

        DeploymentPropertiesExtended IPersistableModel<DeploymentPropertiesExtended>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeploymentPropertiesExtended>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDeploymentPropertiesExtended(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(DeploymentPropertiesExtended)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DeploymentPropertiesExtended>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
