// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class NetworkRule : IUtf8JsonSerializable, IJsonModel<NetworkRule>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<NetworkRule>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<NetworkRule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NetworkRule>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(NetworkRule)} does not support '{format}' format.");
            }

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
            if (Optional.IsCollectionDefined(DestinationIpGroups))
            {
                writer.WritePropertyName("destinationIpGroups"u8);
                writer.WriteStartArray();
                foreach (var item in DestinationIpGroups)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DestinationFqdns))
            {
                writer.WritePropertyName("destinationFqdns"u8);
                writer.WriteStartArray();
                foreach (var item in DestinationFqdns)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
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
            if (_serializedAdditionalRawData != null && options.Format != "W")
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

        NetworkRule IJsonModel<NetworkRule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NetworkRule>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(NetworkRule)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkRule(document.RootElement, options);
        }

        internal static NetworkRule DeserializeNetworkRule(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<FirewallPolicyRuleNetworkProtocol>> ipProtocols = default;
            Optional<IList<string>> sourceAddresses = default;
            Optional<IList<string>> destinationAddresses = default;
            Optional<IList<string>> destinationPorts = default;
            Optional<IList<string>> sourceIpGroups = default;
            Optional<IList<string>> destinationIpGroups = default;
            Optional<IList<string>> destinationFqdns = default;
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
                if (property.NameEquals("destinationIpGroups"u8))
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
                    destinationIpGroups = array;
                    continue;
                }
                if (property.NameEquals("destinationFqdns"u8))
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
                    destinationFqdns = array;
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
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new NetworkRule(name.Value, description.Value, ruleType, serializedAdditionalRawData, Optional.ToList(ipProtocols), Optional.ToList(sourceAddresses), Optional.ToList(destinationAddresses), Optional.ToList(destinationPorts), Optional.ToList(sourceIpGroups), Optional.ToList(destinationIpGroups), Optional.ToList(destinationFqdns));
        }

        BinaryData IPersistableModel<NetworkRule>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NetworkRule>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(NetworkRule)} does not support '{options.Format}' format.");
            }
        }

        NetworkRule IPersistableModel<NetworkRule>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NetworkRule>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeNetworkRule(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(NetworkRule)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<NetworkRule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
