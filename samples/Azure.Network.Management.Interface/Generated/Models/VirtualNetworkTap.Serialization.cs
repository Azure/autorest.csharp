// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Network.Management.Interface.Models
{
    public partial class VirtualNetworkTap : IUtf8JsonSerializable, IModelJsonSerializable<VirtualNetworkTap>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VirtualNetworkTap>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VirtualNetworkTap>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualNetworkTap>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
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
            if (Optional.IsDefined(DestinationNetworkInterfaceIPConfiguration))
            {
                writer.WritePropertyName("destinationNetworkInterfaceIPConfiguration"u8);
                ((IModelJsonSerializable<NetworkInterfaceIPConfiguration>)DestinationNetworkInterfaceIPConfiguration).Serialize(writer, options);
            }
            if (Optional.IsDefined(DestinationLoadBalancerFrontEndIPConfiguration))
            {
                writer.WritePropertyName("destinationLoadBalancerFrontEndIPConfiguration"u8);
                ((IModelJsonSerializable<FrontendIPConfiguration>)DestinationLoadBalancerFrontEndIPConfiguration).Serialize(writer, options);
            }
            if (Optional.IsDefined(DestinationPort))
            {
                writer.WritePropertyName("destinationPort"u8);
                writer.WriteNumberValue(DestinationPort.Value);
            }
            writer.WriteEndObject();
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static VirtualNetworkTap DeserializeVirtualNetworkTap(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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
            Optional<IReadOnlyList<NetworkInterfaceTapConfiguration>> networkInterfaceTapConfigurations = default;
            Optional<string> resourceGuid = default;
            Optional<ProvisioningState> provisioningState = default;
            Optional<NetworkInterfaceIPConfiguration> destinationNetworkInterfaceIPConfiguration = default;
            Optional<FrontendIPConfiguration> destinationLoadBalancerFrontEndIPConfiguration = default;
            Optional<int> destinationPort = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
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
                        if (property0.NameEquals("networkInterfaceTapConfigurations"u8))
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
                            networkInterfaceTapConfigurations = array;
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
                        if (property0.NameEquals("destinationNetworkInterfaceIPConfiguration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            destinationNetworkInterfaceIPConfiguration = NetworkInterfaceIPConfiguration.DeserializeNetworkInterfaceIPConfiguration(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("destinationLoadBalancerFrontEndIPConfiguration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            destinationLoadBalancerFrontEndIPConfiguration = FrontendIPConfiguration.DeserializeFrontendIPConfiguration(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("destinationPort"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            destinationPort = property0.Value.GetInt32();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new VirtualNetworkTap(id.Value, name.Value, type.Value, location.Value, Optional.ToDictionary(tags), etag.Value, Optional.ToList(networkInterfaceTapConfigurations), resourceGuid.Value, Optional.ToNullable(provisioningState), destinationNetworkInterfaceIPConfiguration.Value, destinationLoadBalancerFrontEndIPConfiguration.Value, Optional.ToNullable(destinationPort), rawData);
        }

        VirtualNetworkTap IModelJsonSerializable<VirtualNetworkTap>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualNetworkTap>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualNetworkTap(doc.RootElement, options);
        }

        BinaryData IModelSerializable<VirtualNetworkTap>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualNetworkTap>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        VirtualNetworkTap IModelSerializable<VirtualNetworkTap>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualNetworkTap>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeVirtualNetworkTap(doc.RootElement, options);
        }

        public static implicit operator RequestContent(VirtualNetworkTap model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator VirtualNetworkTap(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeVirtualNetworkTap(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
