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

namespace Azure.Network.Management.Interface.Models
{
    public partial class Subnet : IUtf8JsonSerializable, IJsonModel<Subnet>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Subnet>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<Subnet>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Etag))
                {
                    writer.WritePropertyName("etag"u8);
                    writer.WriteStringValue(Etag);
                }
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(AddressPrefix))
            {
                writer.WritePropertyName("addressPrefix"u8);
                writer.WriteStringValue(AddressPrefix);
            }
            if (Optional.IsCollectionDefined(AddressPrefixes))
            {
                writer.WritePropertyName("addressPrefixes"u8);
                writer.WriteStartArray();
                foreach (var item in AddressPrefixes)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(NetworkSecurityGroup))
            {
                writer.WritePropertyName("networkSecurityGroup"u8);
                writer.WriteObjectValue(NetworkSecurityGroup);
            }
            if (Optional.IsDefined(RouteTable))
            {
                writer.WritePropertyName("routeTable"u8);
                writer.WriteObjectValue(RouteTable);
            }
            if (Optional.IsDefined(NatGateway))
            {
                writer.WritePropertyName("natGateway"u8);
                writer.WriteObjectValue(NatGateway);
            }
            if (Optional.IsCollectionDefined(ServiceEndpoints))
            {
                writer.WritePropertyName("serviceEndpoints"u8);
                writer.WriteStartArray();
                foreach (var item in ServiceEndpoints)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ServiceEndpointPolicies))
            {
                writer.WritePropertyName("serviceEndpointPolicies"u8);
                writer.WriteStartArray();
                foreach (var item in ServiceEndpointPolicies)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsCollectionDefined(PrivateEndpoints))
                {
                    writer.WritePropertyName("privateEndpoints"u8);
                    writer.WriteStartArray();
                    foreach (var item in PrivateEndpoints)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsCollectionDefined(IpConfigurations))
                {
                    writer.WritePropertyName("ipConfigurations"u8);
                    writer.WriteStartArray();
                    foreach (var item in IpConfigurations)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsCollectionDefined(IpConfigurationProfiles))
                {
                    writer.WritePropertyName("ipConfigurationProfiles"u8);
                    writer.WriteStartArray();
                    foreach (var item in IpConfigurationProfiles)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsCollectionDefined(ResourceNavigationLinks))
                {
                    writer.WritePropertyName("resourceNavigationLinks"u8);
                    writer.WriteStartArray();
                    foreach (var item in ResourceNavigationLinks)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsCollectionDefined(ServiceAssociationLinks))
                {
                    writer.WritePropertyName("serviceAssociationLinks"u8);
                    writer.WriteStartArray();
                    foreach (var item in ServiceAssociationLinks)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            if (Optional.IsCollectionDefined(Delegations))
            {
                writer.WritePropertyName("delegations"u8);
                writer.WriteStartArray();
                foreach (var item in Delegations)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Purpose))
                {
                    writer.WritePropertyName("purpose"u8);
                    writer.WriteStringValue(Purpose);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(ProvisioningState))
                {
                    writer.WritePropertyName("provisioningState"u8);
                    writer.WriteStringValue(ProvisioningState.Value.ToString());
                }
            }
            if (Optional.IsDefined(PrivateEndpointNetworkPolicies))
            {
                writer.WritePropertyName("privateEndpointNetworkPolicies"u8);
                writer.WriteStringValue(PrivateEndpointNetworkPolicies);
            }
            if (Optional.IsDefined(PrivateLinkServiceNetworkPolicies))
            {
                writer.WritePropertyName("privateLinkServiceNetworkPolicies"u8);
                writer.WriteStringValue(PrivateLinkServiceNetworkPolicies);
            }
            writer.WriteEndObject();
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

        Subnet IJsonModel<Subnet>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSubnet(document.RootElement, options);
        }

        internal static Subnet DeserializeSubnet(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> etag = default;
            Optional<string> id = default;
            Optional<string> addressPrefix = default;
            Optional<IList<string>> addressPrefixes = default;
            Optional<NetworkSecurityGroup> networkSecurityGroup = default;
            Optional<RouteTable> routeTable = default;
            Optional<SubResource> natGateway = default;
            Optional<IList<ServiceEndpointPropertiesFormat>> serviceEndpoints = default;
            Optional<IList<ServiceEndpointPolicy>> serviceEndpointPolicies = default;
            Optional<IReadOnlyList<PrivateEndpoint>> privateEndpoints = default;
            Optional<IReadOnlyList<IPConfiguration>> ipConfigurations = default;
            Optional<IReadOnlyList<IPConfigurationProfile>> ipConfigurationProfiles = default;
            Optional<IReadOnlyList<ResourceNavigationLink>> resourceNavigationLinks = default;
            Optional<IReadOnlyList<ServiceAssociationLink>> serviceAssociationLinks = default;
            Optional<IList<Delegation>> delegations = default;
            Optional<string> purpose = default;
            Optional<ProvisioningState> provisioningState = default;
            Optional<string> privateEndpointNetworkPolicies = default;
            Optional<string> privateLinkServiceNetworkPolicies = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
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
                        if (property0.NameEquals("addressPrefix"u8))
                        {
                            addressPrefix = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("addressPrefixes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            addressPrefixes = array;
                            continue;
                        }
                        if (property0.NameEquals("networkSecurityGroup"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            networkSecurityGroup = NetworkSecurityGroup.DeserializeNetworkSecurityGroup(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("routeTable"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            routeTable = RouteTable.DeserializeRouteTable(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("natGateway"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            natGateway = DeserializeSubResource(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("serviceEndpoints"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ServiceEndpointPropertiesFormat> array = new List<ServiceEndpointPropertiesFormat>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ServiceEndpointPropertiesFormat.DeserializeServiceEndpointPropertiesFormat(item));
                            }
                            serviceEndpoints = array;
                            continue;
                        }
                        if (property0.NameEquals("serviceEndpointPolicies"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ServiceEndpointPolicy> array = new List<ServiceEndpointPolicy>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ServiceEndpointPolicy.DeserializeServiceEndpointPolicy(item));
                            }
                            serviceEndpointPolicies = array;
                            continue;
                        }
                        if (property0.NameEquals("privateEndpoints"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<PrivateEndpoint> array = new List<PrivateEndpoint>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(PrivateEndpoint.DeserializePrivateEndpoint(item));
                            }
                            privateEndpoints = array;
                            continue;
                        }
                        if (property0.NameEquals("ipConfigurations"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<IPConfiguration> array = new List<IPConfiguration>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(IPConfiguration.DeserializeIPConfiguration(item));
                            }
                            ipConfigurations = array;
                            continue;
                        }
                        if (property0.NameEquals("ipConfigurationProfiles"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<IPConfigurationProfile> array = new List<IPConfigurationProfile>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(IPConfigurationProfile.DeserializeIPConfigurationProfile(item));
                            }
                            ipConfigurationProfiles = array;
                            continue;
                        }
                        if (property0.NameEquals("resourceNavigationLinks"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ResourceNavigationLink> array = new List<ResourceNavigationLink>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ResourceNavigationLink.DeserializeResourceNavigationLink(item));
                            }
                            resourceNavigationLinks = array;
                            continue;
                        }
                        if (property0.NameEquals("serviceAssociationLinks"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ServiceAssociationLink> array = new List<ServiceAssociationLink>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ServiceAssociationLink.DeserializeServiceAssociationLink(item));
                            }
                            serviceAssociationLinks = array;
                            continue;
                        }
                        if (property0.NameEquals("delegations"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<Delegation> array = new List<Delegation>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(Delegation.DeserializeDelegation(item));
                            }
                            delegations = array;
                            continue;
                        }
                        if (property0.NameEquals("purpose"u8))
                        {
                            purpose = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = new ProvisioningState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("privateEndpointNetworkPolicies"u8))
                        {
                            privateEndpointNetworkPolicies = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("privateLinkServiceNetworkPolicies"u8))
                        {
                            privateLinkServiceNetworkPolicies = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Subnet(id.Value, serializedAdditionalRawData, name.Value, etag.Value, addressPrefix.Value, Optional.ToList(addressPrefixes), networkSecurityGroup.Value, routeTable.Value, natGateway.Value, Optional.ToList(serviceEndpoints), Optional.ToList(serviceEndpointPolicies), Optional.ToList(privateEndpoints), Optional.ToList(ipConfigurations), Optional.ToList(ipConfigurationProfiles), Optional.ToList(resourceNavigationLinks), Optional.ToList(serviceAssociationLinks), Optional.ToList(delegations), purpose.Value, Optional.ToNullable(provisioningState), privateEndpointNetworkPolicies.Value, privateLinkServiceNetworkPolicies.Value);
        }

        BinaryData IModel<Subnet>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.WriteCore(this, options);
        }

        Subnet IModel<Subnet>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeSubnet(document.RootElement, options);
        }
    }
}
