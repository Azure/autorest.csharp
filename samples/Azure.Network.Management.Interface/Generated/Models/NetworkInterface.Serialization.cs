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
    public partial class NetworkInterface : IUtf8JsonSerializable, IJsonModel<NetworkInterface>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<NetworkInterface>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<NetworkInterface>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
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
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Name))
                {
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(Name);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Type))
                {
                    writer.WritePropertyName("type"u8);
                    writer.WriteStringValue(Type);
                }
            }
            if (Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location);
            }
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(VirtualMachine))
                {
                    writer.WritePropertyName("virtualMachine"u8);
                    writer.WriteObjectValue(VirtualMachine);
                }
            }
            if (Optional.IsDefined(NetworkSecurityGroup))
            {
                writer.WritePropertyName("networkSecurityGroup"u8);
                writer.WriteObjectValue(NetworkSecurityGroup);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(PrivateEndpoint))
                {
                    writer.WritePropertyName("privateEndpoint"u8);
                    writer.WriteObjectValue(PrivateEndpoint);
                }
            }
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
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsCollectionDefined(TapConfigurations))
                {
                    writer.WritePropertyName("tapConfigurations"u8);
                    writer.WriteStartArray();
                    foreach (var item in TapConfigurations)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            if (Optional.IsDefined(DnsSettings))
            {
                writer.WritePropertyName("dnsSettings"u8);
                writer.WriteObjectValue(DnsSettings);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(MacAddress))
                {
                    writer.WritePropertyName("macAddress"u8);
                    writer.WriteStringValue(MacAddress);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Primary))
                {
                    writer.WritePropertyName("primary"u8);
                    writer.WriteBooleanValue(Primary.Value);
                }
            }
            if (Optional.IsDefined(EnableAcceleratedNetworking))
            {
                writer.WritePropertyName("enableAcceleratedNetworking"u8);
                writer.WriteBooleanValue(EnableAcceleratedNetworking.Value);
            }
            if (Optional.IsDefined(EnableIPForwarding))
            {
                writer.WritePropertyName("enableIPForwarding"u8);
                writer.WriteBooleanValue(EnableIPForwarding.Value);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsCollectionDefined(HostedWorkloads))
                {
                    writer.WritePropertyName("hostedWorkloads"u8);
                    writer.WriteStartArray();
                    foreach (var item in HostedWorkloads)
                    {
                        writer.WriteStringValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(ResourceGuid))
                {
                    writer.WritePropertyName("resourceGuid"u8);
                    writer.WriteStringValue(ResourceGuid);
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

        NetworkInterface IJsonModel<NetworkInterface>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkInterface(document.RootElement, options);
        }

        internal static NetworkInterface DeserializeNetworkInterface(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> etag = default;
            Optional<string> id = default;
            Optional<string> name = default;
            Optional<string> type = default;
            Optional<string> location = default;
            Optional<IDictionary<string, string>> tags = default;
            Optional<SubResource> virtualMachine = default;
            Optional<NetworkSecurityGroup> networkSecurityGroup = default;
            Optional<PrivateEndpoint> privateEndpoint = default;
            Optional<IList<NetworkInterfaceIPConfiguration>> ipConfigurations = default;
            Optional<IReadOnlyList<NetworkInterfaceTapConfiguration>> tapConfigurations = default;
            Optional<NetworkInterfaceDnsSettings> dnsSettings = default;
            Optional<string> macAddress = default;
            Optional<bool> primary = default;
            Optional<bool> enableAcceleratedNetworking = default;
            Optional<bool> enableIPForwarding = default;
            Optional<IReadOnlyList<string>> hostedWorkloads = default;
            Optional<string> resourceGuid = default;
            Optional<ProvisioningState> provisioningState = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
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
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
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
                        if (property0.NameEquals("virtualMachine"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            virtualMachine = SubResource.DeserializeSubResource(property0.Value);
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
                        if (property0.NameEquals("privateEndpoint"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            privateEndpoint = PrivateEndpoint.DeserializePrivateEndpoint(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("ipConfigurations"u8))
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
                            ipConfigurations = array;
                            continue;
                        }
                        if (property0.NameEquals("tapConfigurations"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<NetworkInterfaceTapConfiguration> array = new List<NetworkInterfaceTapConfiguration>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(NetworkInterfaceTapConfiguration.DeserializeNetworkInterfaceTapConfiguration(item));
                            }
                            tapConfigurations = array;
                            continue;
                        }
                        if (property0.NameEquals("dnsSettings"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            dnsSettings = NetworkInterfaceDnsSettings.DeserializeNetworkInterfaceDnsSettings(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("macAddress"u8))
                        {
                            macAddress = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("primary"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            primary = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("enableAcceleratedNetworking"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            enableAcceleratedNetworking = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("enableIPForwarding"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            enableIPForwarding = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("hostedWorkloads"u8))
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
                            hostedWorkloads = array;
                            continue;
                        }
                        if (property0.NameEquals("resourceGuid"u8))
                        {
                            resourceGuid = property0.Value.GetString();
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
                    }
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new NetworkInterface(id.Value, name.Value, type.Value, location.Value, Optional.ToDictionary(tags), serializedAdditionalRawData, etag.Value, virtualMachine.Value, networkSecurityGroup.Value, privateEndpoint.Value, Optional.ToList(ipConfigurations), Optional.ToList(tapConfigurations), dnsSettings.Value, macAddress.Value, Optional.ToNullable(primary), Optional.ToNullable(enableAcceleratedNetworking), Optional.ToNullable(enableIPForwarding), Optional.ToList(hostedWorkloads), resourceGuid.Value, Optional.ToNullable(provisioningState));
        }

        BinaryData IModel<NetworkInterface>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.WriteCore(this, options);
        }

        NetworkInterface IModel<NetworkInterface>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeNetworkInterface(document.RootElement, options);
        }
    }
}
