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
    public partial class FirewallPolicyNatRuleCollection : IUtf8JsonSerializable, IModelJsonSerializable<FirewallPolicyNatRuleCollection>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<FirewallPolicyNatRuleCollection>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<FirewallPolicyNatRuleCollection>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Action))
            {
                writer.WritePropertyName("action"u8);
                writer.WriteObjectValue(Action);
            }
            if (Optional.IsCollectionDefined(Rules))
            {
                writer.WritePropertyName("rules"u8);
                writer.WriteStartArray();
                foreach (var item in Rules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("ruleCollectionType"u8);
            writer.WriteStringValue(RuleCollectionType.ToString());
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Priority))
            {
                writer.WritePropertyName("priority"u8);
                writer.WriteNumberValue(Priority.Value);
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

        FirewallPolicyNatRuleCollection IModelJsonSerializable<FirewallPolicyNatRuleCollection>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFirewallPolicyNatRuleCollection(document.RootElement, options);
        }

        internal static FirewallPolicyNatRuleCollection DeserializeFirewallPolicyNatRuleCollection(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<FirewallPolicyNatRuleCollectionAction> action = default;
            Optional<IList<FirewallPolicyRule>> rules = default;
            FirewallPolicyRuleCollectionType ruleCollectionType = default;
            Optional<string> name = default;
            Optional<int> priority = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("action"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    action = FirewallPolicyNatRuleCollectionAction.DeserializeFirewallPolicyNatRuleCollectionAction(property.Value);
                    continue;
                }
                if (property.NameEquals("rules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FirewallPolicyRule> array = new List<FirewallPolicyRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FirewallPolicyRule.DeserializeFirewallPolicyRule(item));
                    }
                    rules = array;
                    continue;
                }
                if (property.NameEquals("ruleCollectionType"u8))
                {
                    ruleCollectionType = new FirewallPolicyRuleCollectionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("priority"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    priority = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new FirewallPolicyNatRuleCollection(ruleCollectionType, name.Value, Optional.ToNullable(priority), serializedAdditionalRawData, action.Value, Optional.ToList(rules));
        }

        BinaryData IModelSerializable<FirewallPolicyNatRuleCollection>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        FirewallPolicyNatRuleCollection IModelSerializable<FirewallPolicyNatRuleCollection>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFirewallPolicyNatRuleCollection(document.RootElement, options);
        }
    }
}
