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

namespace Azure.ResourceManager.Storage.Models
{
    public partial class NetworkRuleSet : IUtf8JsonSerializable, IJsonModel<NetworkRuleSet>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<NetworkRuleSet>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<NetworkRuleSet>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<NetworkRuleSet>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<NetworkRuleSet>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Bypass))
            {
                writer.WritePropertyName("bypass"u8);
                writer.WriteStringValue(Bypass.Value.ToString());
            }
            if (Optional.IsCollectionDefined(ResourceAccessRules))
            {
                writer.WritePropertyName("resourceAccessRules"u8);
                writer.WriteStartArray();
                foreach (var item in ResourceAccessRules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(VirtualNetworkRules))
            {
                writer.WritePropertyName("virtualNetworkRules"u8);
                writer.WriteStartArray();
                foreach (var item in VirtualNetworkRules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(IpRules))
            {
                writer.WritePropertyName("ipRules"u8);
                writer.WriteStartArray();
                foreach (var item in IpRules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("defaultAction"u8);
            writer.WriteStringValue(DefaultAction.ToSerialString());
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

        NetworkRuleSet IJsonModel<NetworkRuleSet>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(NetworkRuleSet)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkRuleSet(document.RootElement, options);
        }

        internal static NetworkRuleSet DeserializeNetworkRuleSet(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Bypass> bypass = default;
            Optional<IList<ResourceAccessRule>> resourceAccessRules = default;
            Optional<IList<VirtualNetworkRule>> virtualNetworkRules = default;
            Optional<IList<IPRule>> ipRules = default;
            DefaultAction defaultAction = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("bypass"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    bypass = new Bypass(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("resourceAccessRules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ResourceAccessRule> array = new List<ResourceAccessRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResourceAccessRule.DeserializeResourceAccessRule(item));
                    }
                    resourceAccessRules = array;
                    continue;
                }
                if (property.NameEquals("virtualNetworkRules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualNetworkRule> array = new List<VirtualNetworkRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualNetworkRule.DeserializeVirtualNetworkRule(item));
                    }
                    virtualNetworkRules = array;
                    continue;
                }
                if (property.NameEquals("ipRules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<IPRule> array = new List<IPRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(IPRule.DeserializeIPRule(item));
                    }
                    ipRules = array;
                    continue;
                }
                if (property.NameEquals("defaultAction"u8))
                {
                    defaultAction = property.Value.GetString().ToDefaultAction();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new NetworkRuleSet(Optional.ToNullable(bypass), Optional.ToList(resourceAccessRules), Optional.ToList(virtualNetworkRules), Optional.ToList(ipRules), defaultAction, serializedAdditionalRawData);
        }

        BinaryData IModel<NetworkRuleSet>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(NetworkRuleSet)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        NetworkRuleSet IModel<NetworkRuleSet>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(NetworkRuleSet)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeNetworkRuleSet(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<NetworkRuleSet>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
