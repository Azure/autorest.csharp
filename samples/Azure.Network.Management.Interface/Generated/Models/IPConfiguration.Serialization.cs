// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Network.Management.Interface.Models
{
    public partial class IPConfiguration : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
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
            if (Optional.IsDefined(PrivateIPAddress))
            {
                writer.WritePropertyName("privateIPAddress"u8);
                writer.WriteStringValue(PrivateIPAddress);
            }
            if (Optional.IsDefined(PrivateIPAllocationMethod))
            {
                writer.WritePropertyName("privateIPAllocationMethod"u8);
                writer.WriteStringValue(PrivateIPAllocationMethod.Value.ToString());
            }
            if (Optional.IsDefined(Subnet))
            {
                writer.WritePropertyName("subnet"u8);
                writer.WriteObjectValue(Subnet);
            }
            if (Optional.IsDefined(PublicIPAddress))
            {
                writer.WritePropertyName("publicIPAddress"u8);
                writer.WriteObjectValue(PublicIPAddress);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static IPConfiguration DeserializeIPConfiguration(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> etag = default;
            Optional<string> id = default;
            Optional<string> privateIPAddress = default;
            Optional<IPAllocationMethod> privateIPAllocationMethod = default;
            Optional<Subnet> subnet = default;
            Optional<PublicIPAddress> publicIPAddress = default;
            Optional<ProvisioningState> provisioningState = default;
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
                        if (property0.NameEquals("privateIPAddress"u8))
                        {
                            privateIPAddress = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("privateIPAllocationMethod"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            privateIPAllocationMethod = new IPAllocationMethod(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("subnet"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            subnet = Subnet.DeserializeSubnet(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("publicIPAddress"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            publicIPAddress = PublicIPAddress.DeserializePublicIPAddress(property0.Value);
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
            }
            return new IPConfiguration(id.Value, name.Value, etag.Value, privateIPAddress.Value, Optional.ToNullable(privateIPAllocationMethod), subnet.Value, publicIPAddress.Value, Optional.ToNullable(provisioningState));
        }
    }
}
