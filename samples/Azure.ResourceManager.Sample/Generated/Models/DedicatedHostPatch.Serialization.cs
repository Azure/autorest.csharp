// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class DedicatedHostPatch : IUtf8JsonSerializable, IJsonModel<DedicatedHostPatch>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DedicatedHostPatch>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DedicatedHostPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DedicatedHostPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DedicatedHostPatch)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (!(Tags is ChangeTrackingDictionary<string, string> collection && collection.IsUndefined))
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
            if (PlatformFaultDomain.HasValue)
            {
                writer.WritePropertyName("platformFaultDomain"u8);
                writer.WriteNumberValue(PlatformFaultDomain.Value);
            }
            if (AutoReplaceOnFailure.HasValue)
            {
                writer.WritePropertyName("autoReplaceOnFailure"u8);
                writer.WriteBooleanValue(AutoReplaceOnFailure.Value);
            }
            if (options.Format != "W" && HostId != null)
            {
                writer.WritePropertyName("hostId"u8);
                writer.WriteStringValue(HostId);
            }
            if (options.Format != "W" && !(VirtualMachines is ChangeTrackingList<Resources.Models.SubResource> collection0 && collection0.IsUndefined))
            {
                writer.WritePropertyName("virtualMachines"u8);
                writer.WriteStartArray();
                foreach (var item in VirtualMachines)
                {
                    JsonSerializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
            if (LicenseType.HasValue)
            {
                writer.WritePropertyName("licenseType"u8);
                writer.WriteStringValue(LicenseType.Value.ToSerialString());
            }
            if (options.Format != "W" && ProvisioningOn.HasValue)
            {
                writer.WritePropertyName("provisioningTime"u8);
                writer.WriteStringValue(ProvisioningOn.Value, "O");
            }
            if (options.Format != "W" && ProvisioningState != null)
            {
                writer.WritePropertyName("provisioningState"u8);
                writer.WriteStringValue(ProvisioningState);
            }
            if (options.Format != "W" && InstanceView != null)
            {
                writer.WritePropertyName("instanceView"u8);
                writer.WriteObjectValue(InstanceView);
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

        DedicatedHostPatch IJsonModel<DedicatedHostPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DedicatedHostPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DedicatedHostPatch)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDedicatedHostPatch(document.RootElement, options);
        }

        internal static DedicatedHostPatch DeserializeDedicatedHostPatch(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IDictionary<string, string>> tags = default;
            Optional<int> platformFaultDomain = default;
            Optional<bool> autoReplaceOnFailure = default;
            Optional<string> hostId = default;
            Optional<IReadOnlyList<Resources.Models.SubResource>> virtualMachines = default;
            Optional<DedicatedHostLicenseType> licenseType = default;
            Optional<DateTimeOffset> provisioningTime = default;
            Optional<string> provisioningState = default;
            Optional<DedicatedHostInstanceView> instanceView = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
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
                        if (property0.NameEquals("platformFaultDomain"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            platformFaultDomain = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("autoReplaceOnFailure"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            autoReplaceOnFailure = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("hostId"u8))
                        {
                            hostId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("virtualMachines"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<Resources.Models.SubResource> array = new List<Resources.Models.SubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<Resources.Models.SubResource>(item.GetRawText()));
                            }
                            virtualMachines = array;
                            continue;
                        }
                        if (property0.NameEquals("licenseType"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            licenseType = property0.Value.GetString().ToDedicatedHostLicenseType();
                            continue;
                        }
                        if (property0.NameEquals("provisioningTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("instanceView"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            instanceView = DedicatedHostInstanceView.DeserializeDedicatedHostInstanceView(property0.Value, options);
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
            return new DedicatedHostPatch(Optional.ToDictionary(tags), serializedAdditionalRawData, Optional.ToNullable(platformFaultDomain), Optional.ToNullable(autoReplaceOnFailure), hostId.Value, Optional.ToList(virtualMachines), Optional.ToNullable(licenseType), Optional.ToNullable(provisioningTime), provisioningState.Value, instanceView.Value);
        }

        BinaryData IPersistableModel<DedicatedHostPatch>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DedicatedHostPatch>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DedicatedHostPatch)} does not support '{options.Format}' format.");
            }
        }

        DedicatedHostPatch IPersistableModel<DedicatedHostPatch>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DedicatedHostPatch>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDedicatedHostPatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DedicatedHostPatch)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DedicatedHostPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
