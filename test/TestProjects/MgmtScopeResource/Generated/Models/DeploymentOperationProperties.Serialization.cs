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
    public partial class DeploymentOperationProperties : IUtf8JsonSerializable, IJsonModel<DeploymentOperationProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeploymentOperationProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DeploymentOperationProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<DeploymentOperationProperties>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<DeploymentOperationProperties>)} interface");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ProvisioningOperation))
                {
                    writer.WritePropertyName("provisioningOperation"u8);
                    writer.WriteStringValue(ProvisioningOperation.Value.ToSerialString());
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ProvisioningState))
                {
                    writer.WritePropertyName("provisioningState"u8);
                    writer.WriteStringValue(ProvisioningState);
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
                if (Optional.IsDefined(AnotherDuration))
                {
                    writer.WritePropertyName("anotherDuration"u8);
                    writer.WriteStringValue(AnotherDuration.Value, "c");
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ServiceRequestId))
                {
                    writer.WritePropertyName("serviceRequestId"u8);
                    writer.WriteStringValue(ServiceRequestId);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(StatusCode))
                {
                    writer.WritePropertyName("statusCode"u8);
                    writer.WriteStringValue(StatusCode);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(StatusMessage))
                {
                    writer.WritePropertyName("statusMessage"u8);
                    writer.WriteObjectValue(StatusMessage);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Request))
                {
                    writer.WritePropertyName("request"u8);
                    writer.WriteObjectValue(Request);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Response))
                {
                    writer.WritePropertyName("response"u8);
                    writer.WriteObjectValue(Response);
                }
            }
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        DeploymentOperationProperties IJsonModel<DeploymentOperationProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DeploymentOperationProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeploymentOperationProperties(document.RootElement, options);
        }

        internal static DeploymentOperationProperties DeserializeDeploymentOperationProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ProvisioningOperation> provisioningOperation = default;
            Optional<string> provisioningState = default;
            Optional<DateTimeOffset> timestamp = default;
            Optional<TimeSpan> duration = default;
            Optional<TimeSpan> anotherDuration = default;
            Optional<string> serviceRequestId = default;
            Optional<string> statusCode = default;
            Optional<StatusMessage> statusMessage = default;
            Optional<HttpMessage> request = default;
            Optional<HttpMessage> response = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("provisioningOperation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    provisioningOperation = property.Value.GetString().ToProvisioningOperation();
                    continue;
                }
                if (property.NameEquals("provisioningState"u8))
                {
                    provisioningState = property.Value.GetString();
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
                if (property.NameEquals("anotherDuration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    anotherDuration = property.Value.GetTimeSpan("c");
                    continue;
                }
                if (property.NameEquals("serviceRequestId"u8))
                {
                    serviceRequestId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("statusCode"u8))
                {
                    statusCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("statusMessage"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    statusMessage = StatusMessage.DeserializeStatusMessage(property.Value);
                    continue;
                }
                if (property.NameEquals("request"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    request = HttpMessage.DeserializeHttpMessage(property.Value);
                    continue;
                }
                if (property.NameEquals("response"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    response = HttpMessage.DeserializeHttpMessage(property.Value);
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DeploymentOperationProperties(Optional.ToNullable(provisioningOperation), provisioningState.Value, Optional.ToNullable(timestamp), Optional.ToNullable(duration), Optional.ToNullable(anotherDuration), serviceRequestId.Value, statusCode.Value, statusMessage.Value, request.Value, response.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DeploymentOperationProperties>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DeploymentOperationProperties)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DeploymentOperationProperties IPersistableModel<DeploymentOperationProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DeploymentOperationProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDeploymentOperationProperties(document.RootElement, options);
        }

        string IPersistableModel<DeploymentOperationProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
