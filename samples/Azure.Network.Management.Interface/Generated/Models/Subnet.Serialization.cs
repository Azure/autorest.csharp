// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class Subnet : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
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
            writer.WriteEndObject();
        }

        internal static Subnet DeserializeSubnet(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string etag = default;
            string id = default;
            string addressPrefix = default;
            IList<string> addressPrefixes = default;
            NetworkSecurityGroup networkSecurityGroup = default;
            RouteTable routeTable = default;
            SubResource natGateway = default;
            IList<ServiceEndpointPropertiesFormat> serviceEndpoints = default;
            IList<ServiceEndpointPolicy> serviceEndpointPolicies = default;
            IReadOnlyList<PrivateEndpoint> privateEndpoints = default;
            IReadOnlyList<IPConfiguration> ipConfigurations = default;
            IReadOnlyList<IPConfigurationProfile> ipConfigurationProfiles = default;
            IReadOnlyList<ResourceNavigationLink> resourceNavigationLinks = default;
            IReadOnlyList<ServiceAssociationLink> serviceAssociationLinks = default;
            IList<Delegation> delegations = default;
            string purpose = default;
            ProvisioningState? provisioningState = default;
            string privateEndpointNetworkPolicies = default;
            string privateLinkServiceNetworkPolicies = default;
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
            }
            return new Subnet(
                id,
                name,
                etag,
                addressPrefix,
                addressPrefixes ?? new ChangeTrackingList<string>(),
                networkSecurityGroup,
                routeTable,
                natGateway,
                serviceEndpoints ?? new ChangeTrackingList<ServiceEndpointPropertiesFormat>(),
                serviceEndpointPolicies ?? new ChangeTrackingList<ServiceEndpointPolicy>(),
                privateEndpoints ?? new ChangeTrackingList<PrivateEndpoint>(),
                ipConfigurations ?? new ChangeTrackingList<IPConfiguration>(),
                ipConfigurationProfiles ?? new ChangeTrackingList<IPConfigurationProfile>(),
                resourceNavigationLinks ?? new ChangeTrackingList<ResourceNavigationLink>(),
                serviceAssociationLinks ?? new ChangeTrackingList<ServiceAssociationLink>(),
                delegations ?? new ChangeTrackingList<Delegation>(),
                purpose,
                provisioningState,
                privateEndpointNetworkPolicies,
                privateLinkServiceNetworkPolicies);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new Subnet FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeSubnet(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
