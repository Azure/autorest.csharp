// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    public partial class PrivateEndpointConnectionItem
    {
        internal static PrivateEndpointConnectionItem DeserializePrivateEndpointConnectionItem(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> id = default;
            Optional<string> etag = default;
            Optional<Azure.ResourceManager.Resources.Models.SubResource> privateEndpoint = default;
            Optional<MgmtMockAndSamplePrivateLinkServiceConnectionState> privateLinkServiceConnectionState = default;
            Optional<MgmtMockAndSamplePrivateEndpointConnectionProvisioningState> provisioningState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("privateEndpoint"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            privateEndpoint = JsonSerializer.Deserialize<Azure.ResourceManager.Resources.Models.SubResource>(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("privateLinkServiceConnectionState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            privateLinkServiceConnectionState = MgmtMockAndSamplePrivateLinkServiceConnectionState.DeserializeMgmtMockAndSamplePrivateLinkServiceConnectionState(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = new MgmtMockAndSamplePrivateEndpointConnectionProvisioningState(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new PrivateEndpointConnectionItem(id.Value, etag.Value, privateEndpoint, privateLinkServiceConnectionState.Value, Optional.ToNullable(provisioningState));
        }
    }
}
