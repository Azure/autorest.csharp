// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Network.Management.Interface.Models
{
    public partial class ApplicationGatewayBackendAddressPool : IUtf8JsonSerializable, IModelJsonSerializable<ApplicationGatewayBackendAddressPool>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ApplicationGatewayBackendAddressPool>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ApplicationGatewayBackendAddressPool>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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
            if (Optional.IsCollectionDefined(BackendAddresses))
            {
                writer.WritePropertyName("backendAddresses"u8);
                writer.WriteStartArray();
                foreach (var item in BackendAddresses)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        ApplicationGatewayBackendAddressPool IModelJsonSerializable<ApplicationGatewayBackendAddressPool>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeApplicationGatewayBackendAddressPool(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ApplicationGatewayBackendAddressPool>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ApplicationGatewayBackendAddressPool IModelSerializable<ApplicationGatewayBackendAddressPool>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeApplicationGatewayBackendAddressPool(document.RootElement, options);
        }

        internal static ApplicationGatewayBackendAddressPool DeserializeApplicationGatewayBackendAddressPool(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> etag = default;
            Optional<string> type = default;
            Optional<string> id = default;
            Optional<IReadOnlyList<NetworkInterfaceIPConfiguration>> backendIPConfigurations = default;
            Optional<IList<ApplicationGatewayBackendAddress>> backendAddresses = default;
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
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
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
                        if (property0.NameEquals("backendIPConfigurations"u8))
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
                        if (property0.NameEquals("backendAddresses"u8))
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
            return new ApplicationGatewayBackendAddressPool(id.Value, name.Value, etag.Value, type.Value, Optional.ToList(backendIPConfigurations), Optional.ToList(backendAddresses), Optional.ToNullable(provisioningState));
        }
    }
}
