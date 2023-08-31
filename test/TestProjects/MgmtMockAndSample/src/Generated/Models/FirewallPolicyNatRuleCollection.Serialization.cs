// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtMockAndSample.Models
{
    public partial class FirewallPolicyNatRuleCollection : IUtf8JsonSerializable, IModelJsonSerializable<FirewallPolicyNatRuleCollection>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<FirewallPolicyNatRuleCollection>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<FirewallPolicyNatRuleCollection>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<FirewallPolicyNatRuleCollection>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Action))
            {
                writer.WritePropertyName("action"u8);
                ((IModelJsonSerializable<FirewallPolicyNatRuleCollectionAction>)Action).Serialize(writer, options);
            }
            if (Optional.IsCollectionDefined(Rules))
            {
                writer.WritePropertyName("rules"u8);
                writer.WriteStartArray();
                foreach (var item in Rules)
                {
                    ((IModelJsonSerializable<FirewallPolicyRule>)item).Serialize(writer, options);
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
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static FirewallPolicyNatRuleCollection DeserializeFirewallPolicyNatRuleCollection(JsonElement element, ModelSerializerOptions options = default)
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
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
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
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new FirewallPolicyNatRuleCollection(ruleCollectionType, name.Value, Optional.ToNullable(priority), action.Value, Optional.ToList(rules), rawData);
        }

        FirewallPolicyNatRuleCollection IModelJsonSerializable<FirewallPolicyNatRuleCollection>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<FirewallPolicyNatRuleCollection>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeFirewallPolicyNatRuleCollection(doc.RootElement, options);
        }

        BinaryData IModelSerializable<FirewallPolicyNatRuleCollection>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<FirewallPolicyNatRuleCollection>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        FirewallPolicyNatRuleCollection IModelSerializable<FirewallPolicyNatRuleCollection>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<FirewallPolicyNatRuleCollection>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeFirewallPolicyNatRuleCollection(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="FirewallPolicyNatRuleCollection"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="FirewallPolicyNatRuleCollection"/> to convert. </param>
        public static implicit operator RequestContent(FirewallPolicyNatRuleCollection model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="FirewallPolicyNatRuleCollection"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator FirewallPolicyNatRuleCollection(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeFirewallPolicyNatRuleCollection(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
