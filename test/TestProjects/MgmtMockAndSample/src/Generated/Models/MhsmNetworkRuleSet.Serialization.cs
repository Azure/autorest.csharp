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
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    public partial class MhsmNetworkRuleSet : IUtf8JsonSerializable, IJsonModel<MhsmNetworkRuleSet>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MhsmNetworkRuleSet>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<MhsmNetworkRuleSet>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<MhsmNetworkRuleSet>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<MhsmNetworkRuleSet>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Bypass))
            {
                writer.WritePropertyName("bypass"u8);
                writer.WriteStringValue(Bypass.Value.ToString());
            }
            if (Optional.IsDefined(DefaultAction))
            {
                writer.WritePropertyName("defaultAction"u8);
                writer.WriteStringValue(DefaultAction.Value.ToString());
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
            if (Optional.IsCollectionDefined(VirtualNetworkRules))
            {
                writer.WritePropertyName("virtualNetworkRules"u8);
                writer.WriteStartArray();
                foreach (var item in VirtualNetworkRules)
                {
                    JsonSerializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
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

        MhsmNetworkRuleSet IJsonModel<MhsmNetworkRuleSet>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(MhsmNetworkRuleSet)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMhsmNetworkRuleSet(document.RootElement, options);
        }

        internal static MhsmNetworkRuleSet DeserializeMhsmNetworkRuleSet(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<NetworkRuleBypassOption> bypass = default;
            Optional<NetworkRuleAction> defaultAction = default;
            Optional<IList<MhsmipRule>> ipRules = default;
            Optional<IList<WritableSubResource>> virtualNetworkRules = default;
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
                    bypass = new NetworkRuleBypassOption(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("defaultAction"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    defaultAction = new NetworkRuleAction(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("ipRules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MhsmipRule> array = new List<MhsmipRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MhsmipRule.DeserializeMhsmipRule(item));
                    }
                    ipRules = array;
                    continue;
                }
                if (property.NameEquals("virtualNetworkRules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<WritableSubResource> array = new List<WritableSubResource>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.GetRawText()));
                    }
                    virtualNetworkRules = array;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new MhsmNetworkRuleSet(Optional.ToNullable(bypass), Optional.ToNullable(defaultAction), Optional.ToList(ipRules), Optional.ToList(virtualNetworkRules), serializedAdditionalRawData);
        }

        BinaryData IModel<MhsmNetworkRuleSet>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(MhsmNetworkRuleSet)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        MhsmNetworkRuleSet IModel<MhsmNetworkRuleSet>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(MhsmNetworkRuleSet)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeMhsmNetworkRuleSet(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<MhsmNetworkRuleSet>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
