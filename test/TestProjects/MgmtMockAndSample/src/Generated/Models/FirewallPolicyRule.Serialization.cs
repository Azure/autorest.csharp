// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    [PersistableModelProxy(typeof(UnknownFirewallPolicyRule))]
    public partial class FirewallPolicyRule : IUtf8JsonSerializable, IJsonModel<FirewallPolicyRule>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<FirewallPolicyRule>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<FirewallPolicyRule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<FirewallPolicyRule>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<FirewallPolicyRule>)} interface");
            }

            writer.WriteStartObject();
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
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        FirewallPolicyRule IJsonModel<FirewallPolicyRule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FirewallPolicyRule)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFirewallPolicyRule(document.RootElement, options);
        }

        internal static FirewallPolicyRule DeserializeFirewallPolicyRule(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("ruleType", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "ApplicationRule": return ApplicationRule.DeserializeApplicationRule(element);
                    case "NatRule": return NatRule.DeserializeNatRule(element);
                    case "NetworkRule": return NetworkRule.DeserializeNetworkRule(element);
                }
            }
            return UnknownFirewallPolicyRule.DeserializeUnknownFirewallPolicyRule(element);
        }

        BinaryData IPersistableModel<FirewallPolicyRule>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FirewallPolicyRule)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        FirewallPolicyRule IPersistableModel<FirewallPolicyRule>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(FirewallPolicyRule)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFirewallPolicyRule(document.RootElement, options);
        }

        string IPersistableModel<FirewallPolicyRule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
