// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;
using AzureSample.ResourceManager.Sample;

namespace AzureSample.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetIPConfiguration : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetIPConfiguration>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetIPConfiguration>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineScaleSetIPConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetIPConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetIPConfiguration)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(Subnet))
            {
                writer.WritePropertyName("subnet"u8);
                JsonSerializer.Serialize(writer, Subnet);
            }
            if (Optional.IsDefined(Primary))
            {
                writer.WritePropertyName("primary"u8);
                writer.WriteBooleanValue(Primary.Value);
            }
            if (Optional.IsDefined(PublicIPAddressConfiguration))
            {
                writer.WritePropertyName("publicIPAddressConfiguration"u8);
                writer.WriteObjectValue(PublicIPAddressConfiguration);
            }
            if (Optional.IsDefined(PrivateIPAddressVersion))
            {
                writer.WritePropertyName("privateIPAddressVersion"u8);
                writer.WriteStringValue(PrivateIPAddressVersion.Value.ToString());
            }
            if (Optional.IsCollectionDefined(ApplicationGatewayBackendAddressPools))
            {
                writer.WritePropertyName("applicationGatewayBackendAddressPools"u8);
                writer.WriteStartArray();
                foreach (var item in ApplicationGatewayBackendAddressPools)
                {
                    JsonSerializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ApplicationSecurityGroups))
            {
                writer.WritePropertyName("applicationSecurityGroups"u8);
                writer.WriteStartArray();
                foreach (var item in ApplicationSecurityGroups)
                {
                    JsonSerializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(LoadBalancerBackendAddressPools))
            {
                writer.WritePropertyName("loadBalancerBackendAddressPools"u8);
                writer.WriteStartArray();
                foreach (var item in LoadBalancerBackendAddressPools)
                {
                    JsonSerializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(LoadBalancerInboundNatPools))
            {
                writer.WritePropertyName("loadBalancerInboundNatPools"u8);
                writer.WriteStartArray();
                foreach (var item in LoadBalancerInboundNatPools)
                {
                    JsonSerializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        VirtualMachineScaleSetIPConfiguration IJsonModel<VirtualMachineScaleSetIPConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetIPConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetIPConfiguration)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetIPConfiguration(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetIPConfiguration DeserializeVirtualMachineScaleSetIPConfiguration(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string id = default;
            WritableSubResource subnet = default;
            bool? primary = default;
            VirtualMachineScaleSetPublicIPAddressConfiguration publicIPAddressConfiguration = default;
            IPVersion? privateIPAddressVersion = default;
            IList<WritableSubResource> applicationGatewayBackendAddressPools = default;
            IList<WritableSubResource> applicationSecurityGroups = default;
            IList<WritableSubResource> loadBalancerBackendAddressPools = default;
            IList<WritableSubResource> loadBalancerInboundNatPools = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
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
                        if (property0.NameEquals("subnet"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            subnet = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
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
                        if (property0.NameEquals("publicIPAddressConfiguration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            publicIPAddressConfiguration = VirtualMachineScaleSetPublicIPAddressConfiguration.DeserializeVirtualMachineScaleSetPublicIPAddressConfiguration(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("privateIPAddressVersion"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            privateIPAddressVersion = new IPVersion(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("applicationGatewayBackendAddressPools"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WritableSubResource> array = new List<WritableSubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.GetRawText()));
                            }
                            applicationGatewayBackendAddressPools = array;
                            continue;
                        }
                        if (property0.NameEquals("applicationSecurityGroups"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WritableSubResource> array = new List<WritableSubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.GetRawText()));
                            }
                            applicationSecurityGroups = array;
                            continue;
                        }
                        if (property0.NameEquals("loadBalancerBackendAddressPools"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WritableSubResource> array = new List<WritableSubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.GetRawText()));
                            }
                            loadBalancerBackendAddressPools = array;
                            continue;
                        }
                        if (property0.NameEquals("loadBalancerInboundNatPools"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WritableSubResource> array = new List<WritableSubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.GetRawText()));
                            }
                            loadBalancerInboundNatPools = array;
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineScaleSetIPConfiguration(
                id,
                serializedAdditionalRawData,
                name,
                subnet,
                primary,
                publicIPAddressConfiguration,
                privateIPAddressVersion,
                applicationGatewayBackendAddressPools ?? new ChangeTrackingList<WritableSubResource>(),
                applicationSecurityGroups ?? new ChangeTrackingList<WritableSubResource>(),
                loadBalancerBackendAddressPools ?? new ChangeTrackingList<WritableSubResource>(),
                loadBalancerInboundNatPools ?? new ChangeTrackingList<WritableSubResource>());
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.ParameterOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            if (propertyOverrides != null)
            {
                TransformFlattenedOverrides(bicepOptions, propertyOverrides);
            }

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Name), out propertyOverride);
            if (Optional.IsDefined(Name) || hasPropertyOverride)
            {
                builder.Append("  name: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (Name.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Name}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Name}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Id), out propertyOverride);
            if (Optional.IsDefined(Id) || hasPropertyOverride)
            {
                builder.Append("  id: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (Id.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Id}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Id}'");
                    }
                }
            }

            builder.Append("  properties:");
            builder.AppendLine(" {");
            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Subnet), out propertyOverride);
            if (Optional.IsDefined(Subnet) || hasPropertyOverride)
            {
                builder.Append("    subnet: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, Subnet, options, 4, false, "    subnet: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Primary), out propertyOverride);
            if (Optional.IsDefined(Primary) || hasPropertyOverride)
            {
                builder.Append("    primary: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var boolValue = Primary.Value == true ? "true" : "false";
                    builder.AppendLine($"{boolValue}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PublicIPAddressConfiguration), out propertyOverride);
            if (Optional.IsDefined(PublicIPAddressConfiguration) || hasPropertyOverride)
            {
                builder.Append("    publicIPAddressConfiguration: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, PublicIPAddressConfiguration, options, 4, false, "    publicIPAddressConfiguration: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PrivateIPAddressVersion), out propertyOverride);
            if (Optional.IsDefined(PrivateIPAddressVersion) || hasPropertyOverride)
            {
                builder.Append("    privateIPAddressVersion: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"'{PrivateIPAddressVersion.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ApplicationGatewayBackendAddressPools), out propertyOverride);
            if (Optional.IsCollectionDefined(ApplicationGatewayBackendAddressPools) || hasPropertyOverride)
            {
                if (ApplicationGatewayBackendAddressPools.Any() || hasPropertyOverride)
                {
                    builder.Append("    applicationGatewayBackendAddressPools: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
                        builder.AppendLine("[");
                        foreach (var item in ApplicationGatewayBackendAddressPools)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 6, true, "    applicationGatewayBackendAddressPools: ");
                        }
                        builder.AppendLine("    ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ApplicationSecurityGroups), out propertyOverride);
            if (Optional.IsCollectionDefined(ApplicationSecurityGroups) || hasPropertyOverride)
            {
                if (ApplicationSecurityGroups.Any() || hasPropertyOverride)
                {
                    builder.Append("    applicationSecurityGroups: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
                        builder.AppendLine("[");
                        foreach (var item in ApplicationSecurityGroups)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 6, true, "    applicationSecurityGroups: ");
                        }
                        builder.AppendLine("    ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(LoadBalancerBackendAddressPools), out propertyOverride);
            if (Optional.IsCollectionDefined(LoadBalancerBackendAddressPools) || hasPropertyOverride)
            {
                if (LoadBalancerBackendAddressPools.Any() || hasPropertyOverride)
                {
                    builder.Append("    loadBalancerBackendAddressPools: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
                        builder.AppendLine("[");
                        foreach (var item in LoadBalancerBackendAddressPools)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 6, true, "    loadBalancerBackendAddressPools: ");
                        }
                        builder.AppendLine("    ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(LoadBalancerInboundNatPools), out propertyOverride);
            if (Optional.IsCollectionDefined(LoadBalancerInboundNatPools) || hasPropertyOverride)
            {
                if (LoadBalancerInboundNatPools.Any() || hasPropertyOverride)
                {
                    builder.Append("    loadBalancerInboundNatPools: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
                        builder.AppendLine("[");
                        foreach (var item in LoadBalancerInboundNatPools)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 6, true, "    loadBalancerInboundNatPools: ");
                        }
                        builder.AppendLine("    ]");
                    }
                }
            }

            builder.AppendLine("  }");
            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        private void TransformFlattenedOverrides(BicepModelReaderWriterOptions bicepOptions, IDictionary<string, string> propertyOverrides)
        {
            foreach (var item in propertyOverrides.ToList())
            {
                switch (item.Key)
                {
                    case "SubnetId":
                        Dictionary<string, string> propertyDictionary = new Dictionary<string, string>();
                        propertyDictionary.Add("Id", item.Value);
                        bicepOptions.ParameterOverrides.Add(Subnet, propertyDictionary);
                        break;
                    default:
                        continue;
                }
            }
        }

        BinaryData IPersistableModel<VirtualMachineScaleSetIPConfiguration>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetIPConfiguration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetIPConfiguration)} does not support '{options.Format}' format.");
            }
        }

        VirtualMachineScaleSetIPConfiguration IPersistableModel<VirtualMachineScaleSetIPConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetIPConfiguration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineScaleSetIPConfiguration(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetIPConfiguration)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineScaleSetIPConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
