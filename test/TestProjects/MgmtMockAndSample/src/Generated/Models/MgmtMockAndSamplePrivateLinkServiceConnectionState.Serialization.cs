// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class MgmtMockAndSamplePrivateLinkServiceConnectionState : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(ActionsRequired))
            {
                writer.WritePropertyName("actionsRequired"u8);
                writer.WriteStringValue(ActionsRequired.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static MgmtMockAndSamplePrivateLinkServiceConnectionState DeserializeMgmtMockAndSamplePrivateLinkServiceConnectionState(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<MgmtMockAndSamplePrivateEndpointServiceConnectionStatus> status = default;
            Optional<string> description = default;
            Optional<ActionsRequired> actionsRequired = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new MgmtMockAndSamplePrivateEndpointServiceConnectionStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("actionsRequired"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    actionsRequired = new ActionsRequired(property.Value.GetString());
                    continue;
                }
            }
            return new MgmtMockAndSamplePrivateLinkServiceConnectionState(Optional.ToNullable(status), description.Value, Optional.ToNullable(actionsRequired));
        }
    }
}
