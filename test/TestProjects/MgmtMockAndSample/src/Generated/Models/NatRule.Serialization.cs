// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtMockAndSample.Models
{
    public partial class NatRule : IUtf8JsonSerializable, IModelJsonSerializable<NatRule>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<NatRule>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<NatRule>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(IpProtocols))
            {
                writer.WritePropertyName("ipProtocols"u8);
                writer.WriteStartArray();
                foreach (var item in IpProtocols)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(SourceAddresses))
            {
                writer.WritePropertyName("sourceAddresses"u8);
                writer.WriteStartArray();
                foreach (var item in SourceAddresses)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DestinationAddresses))
            {
                writer.WritePropertyName("destinationAddresses"u8);
                writer.WriteStartArray();
                foreach (var item in DestinationAddresses)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DestinationPorts))
            {
                writer.WritePropertyName("destinationPorts"u8);
                writer.WriteStartArray();
                foreach (var item in DestinationPorts)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(TranslatedAddress))
            {
                writer.WritePropertyName("translatedAddress"u8);
                writer.WriteStringValue(TranslatedAddress);
            }
            if (Optional.IsDefined(TranslatedPort))
            {
                writer.WritePropertyName("translatedPort"u8);
                writer.WriteStringValue(TranslatedPort);
            }
            if (Optional.IsCollectionDefined(SourceIpGroups))
            {
                writer.WritePropertyName("sourceIpGroups"u8);
                writer.WriteStartArray();
                foreach (var item in SourceIpGroups)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(TranslatedFqdn))
            {
                writer.WritePropertyName("translatedFqdn"u8);
                writer.WriteStringValue(TranslatedFqdn);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            writer.WritePropertyName("ruleType"u8);
            writer.WriteStringValue(RuleType.ToString());
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

        NatRule IModelJsonSerializable<NatRule>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNatRule(document.RootElement, options);
        }

        internal static NatRule DeserializeNatRule(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<FirewallPolicyRuleNetworkProtocol>> ipProtocols = default;
            Optional<IList<string>> sourceAddresses = default;
            Optional<IList<string>> destinationAddresses = default;
            Optional<IList<string>> destinationPorts = default;
            Optional<string> translatedAddress = default;
            Optional<string> translatedPort = default;
            Optional<IList<string>> sourceIpGroups = default;
            Optional<string> translatedFqdn = default;
            Optional<string> name = default;
            Optional<string> description = default;
            FirewallPolicyRuleType ruleType = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ipProtocols"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FirewallPolicyRuleNetworkProtocol> array = new List<FirewallPolicyRuleNetworkProtocol>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new FirewallPolicyRuleNetworkProtocol(item.GetString()));
                    }
                    ipProtocols = array;
                    continue;
                }
                if (property.NameEquals("sourceAddresses"u8))
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
                    sourceAddresses = array;
                    continue;
                }
                if (property.NameEquals("destinationAddresses"u8))
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
                    destinationAddresses = array;
                    continue;
                }
                if (property.NameEquals("destinationPorts"u8))
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
                    destinationPorts = array;
                    continue;
                }
                if (property.NameEquals("translatedAddress"u8))
                {
                    translatedAddress = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("translatedPort"u8))
                {
                    translatedPort = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sourceIpGroups"u8))
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
                    sourceIpGroups = array;
                    continue;
                }
                if (property.NameEquals("translatedFqdn"u8))
                {
                    translatedFqdn = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ruleType"u8))
                {
                    ruleType = new FirewallPolicyRuleType(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new NatRule(name.Value, description.Value, ruleType, serializedAdditionalRawData, Optional.ToList(ipProtocols), Optional.ToList(sourceAddresses), Optional.ToList(destinationAddresses), Optional.ToList(destinationPorts), translatedAddress.Value, translatedPort.Value, Optional.ToList(sourceIpGroups), translatedFqdn.Value);
        }

        BinaryData IModelSerializable<NatRule>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        NatRule IModelSerializable<NatRule>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeNatRule(document.RootElement, options);
        }
    }
}
