// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    public partial class DeploymentOperationProperties
    {
        internal static DeploymentOperationProperties DeserializeDeploymentOperationProperties(JsonElement element)
        {
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
            }
            return new DeploymentOperationProperties(Optional.ToNullable(provisioningOperation), provisioningState.Value, Optional.ToNullable(timestamp), Optional.ToNullable(duration), Optional.ToNullable(anotherDuration), serviceRequestId.Value, statusCode.Value, statusMessage.Value, request.Value, response.Value);
        }
    }
}
