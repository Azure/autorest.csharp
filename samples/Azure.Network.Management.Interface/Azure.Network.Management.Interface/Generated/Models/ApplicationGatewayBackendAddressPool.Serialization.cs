// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class ApplicationGatewayBackendAddressPool : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Etag != null)
            {
                writer.WritePropertyName("etag");
                writer.WriteStringValue(Etag);
            }
            if (Type != null)
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(Type);
            }
            if (Id != null)
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (BackendIPConfigurations != null)
            {
                writer.WritePropertyName("backendIPConfigurations");
                writer.WriteStartArray();
                foreach (var item in BackendIPConfigurations)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (BackendAddresses != null)
            {
                writer.WritePropertyName("backendAddresses");
                writer.WriteStartArray();
                foreach (var item in BackendAddresses)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (ProvisioningState != null)
            {
                writer.WritePropertyName("provisioningState");
                writer.WriteStringValue(ProvisioningState.Value.ToString());
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static ApplicationGatewayBackendAddressPool DeserializeApplicationGatewayBackendAddressPool(JsonElement element)
        {
            ApplicationGatewayBackendAddressPool result;
            string name = default;
            string etag = default;
            string type = default;
            string id = default;
            IList<NetworkInterfaceIPConfiguration> backendIPConfigurations = default;
            IList<ApplicationGatewayBackendAddress> backendAddresses = default;
            ProvisioningState? provisioningState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("etag"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("backendIPConfigurations"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<NetworkInterfaceIPConfiguration> array = new List<NetworkInterfaceIPConfiguration>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(NetworkInterfaceIPConfiguration.DeserializeNetworkInterfaceIPConfiguration(item));
                            }
                            backendIPConfigurations = array;
                            continue;
                        }
                        if (property0.NameEquals("backendAddresses"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ApplicationGatewayBackendAddress> array = new List<ApplicationGatewayBackendAddress>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ApplicationGatewayBackendAddress.DeserializeApplicationGatewayBackendAddress(item));
                            }
                            backendAddresses = array;
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = new ProvisioningState(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            result = new ApplicationGatewayBackendAddressPool(name, etag, type, backendIPConfigurations, backendAddresses, provisioningState, id);
            return result;
        }
    }
}
