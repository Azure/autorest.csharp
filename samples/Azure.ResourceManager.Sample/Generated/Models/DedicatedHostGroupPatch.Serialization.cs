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
    public partial class DedicatedHostGroupPatch : IUtf8JsonSerializable, IJsonModel<DedicatedHostGroupPatch>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DedicatedHostGroupPatch>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DedicatedHostGroupPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DedicatedHostGroupPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DedicatedHostGroupPatch)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (!(Zones is ChangeTrackingList<string> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("zones"u8);
                writer.WriteStartArray();
                foreach (var item in Zones)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (!(Tags is ChangeTrackingDictionary<string, string> collection0 && collection0.IsUndefined))
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
            if (PlatformFaultDomainCount.HasValue)
            {
                writer.WritePropertyName("platformFaultDomainCount"u8);
                writer.WriteNumberValue(PlatformFaultDomainCount.Value);
            }
            if (options.Format != "W" && !(Hosts is ChangeTrackingList<Resources.Models.SubResource> collection1 && collection1.IsUndefined))
            {
                writer.WritePropertyName("hosts"u8);
                writer.WriteStartArray();
                foreach (var item in Hosts)
                {
                    JsonSerializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && InstanceView != null)
            {
                writer.WritePropertyName("instanceView"u8);
                writer.WriteObjectValue(InstanceView);
            }
            if (SupportAutomaticPlacement.HasValue)
            {
                writer.WritePropertyName("supportAutomaticPlacement"u8);
                writer.WriteBooleanValue(SupportAutomaticPlacement.Value);
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

        DedicatedHostGroupPatch IJsonModel<DedicatedHostGroupPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DedicatedHostGroupPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DedicatedHostGroupPatch)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDedicatedHostGroupPatch(document.RootElement, options);
        }

        internal static DedicatedHostGroupPatch DeserializeDedicatedHostGroupPatch(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> zones = default;
            IDictionary<string, string> tags = default;
            Optional<int> platformFaultDomainCount = default;
            IReadOnlyList<Resources.Models.SubResource> hosts = default;
            Optional<DedicatedHostGroupInstanceView> instanceView = default;
            Optional<bool> supportAutomaticPlacement = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("zones"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    zones = array;
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
                        if (property0.NameEquals("platformFaultDomainCount"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            platformFaultDomainCount = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("hosts"u8))
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
                            hosts = array;
                            continue;
                        }
                        if (property0.NameEquals("instanceView"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            instanceView = DedicatedHostGroupInstanceView.DeserializeDedicatedHostGroupInstanceView(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("supportAutomaticPlacement"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            supportAutomaticPlacement = property0.Value.GetBoolean();
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
            return new DedicatedHostGroupPatch(
                tags ?? new ChangeTrackingDictionary<string, string>(),
                serializedAdditionalRawData,
                zones ?? new ChangeTrackingList<string>(),
                Optional.ToNullable(platformFaultDomainCount),
                hosts ?? new ChangeTrackingList<Resources.Models.SubResource>(),
                instanceView.Value,
                Optional.ToNullable(supportAutomaticPlacement));
        }

        BinaryData IPersistableModel<DedicatedHostGroupPatch>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DedicatedHostGroupPatch>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DedicatedHostGroupPatch)} does not support '{options.Format}' format.");
            }
        }

        DedicatedHostGroupPatch IPersistableModel<DedicatedHostGroupPatch>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DedicatedHostGroupPatch>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDedicatedHostGroupPatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DedicatedHostGroupPatch)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DedicatedHostGroupPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
