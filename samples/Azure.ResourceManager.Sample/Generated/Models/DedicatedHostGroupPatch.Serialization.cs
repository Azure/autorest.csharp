// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class DedicatedHostGroupPatch : IUtf8JsonSerializable, IModelJsonSerializable<DedicatedHostGroupPatch>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DedicatedHostGroupPatch>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DedicatedHostGroupPatch>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Zones))
            {
                writer.WritePropertyName("zones"u8);
                writer.WriteStartArray();
                foreach (var item in Zones)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
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
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (Optional.IsDefined(PlatformFaultDomainCount))
                {
                    writer.WritePropertyName("platformFaultDomainCount"u8);
                    writer.WriteNumberValue(PlatformFaultDomainCount.Value);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(Hosts))
                {
                    writer.WritePropertyName("hosts"u8);
                    writer.WriteStartArray();
                    foreach (var item in Hosts)
                    {
                        JsonSerializer.Serialize(writer, item);
                    }
                    writer.WriteEndArray();
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(InstanceView))
                {
                    writer.WritePropertyName("instanceView"u8);
                    writer.WriteObjectValue(InstanceView);
                }
                if (Optional.IsDefined(SupportAutomaticPlacement))
                {
                    writer.WritePropertyName("supportAutomaticPlacement"u8);
                    writer.WriteBooleanValue(SupportAutomaticPlacement.Value);
                }
                writer.WriteEndObject();
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        DedicatedHostGroupPatch IModelJsonSerializable<DedicatedHostGroupPatch>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDedicatedHostGroupPatch(document.RootElement, options);
        }

        internal static DedicatedHostGroupPatch DeserializeDedicatedHostGroupPatch(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> zones = default;
            Optional<IDictionary<string, string>> tags = default;
            Optional<int> platformFaultDomainCount = default;
            Optional<IReadOnlyList<Resources.Models.SubResource>> hosts = default;
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
                            instanceView = DedicatedHostGroupInstanceView.DeserializeDedicatedHostGroupInstanceView(property0.Value);
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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DedicatedHostGroupPatch(Optional.ToDictionary(tags), serializedAdditionalRawData, Optional.ToList(zones), Optional.ToNullable(platformFaultDomainCount), Optional.ToList(hosts), instanceView.Value, Optional.ToNullable(supportAutomaticPlacement));
        }

        BinaryData IModelSerializable<DedicatedHostGroupPatch>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DedicatedHostGroupPatch IModelSerializable<DedicatedHostGroupPatch>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDedicatedHostGroupPatch(document.RootElement, options);
        }
    }
}
