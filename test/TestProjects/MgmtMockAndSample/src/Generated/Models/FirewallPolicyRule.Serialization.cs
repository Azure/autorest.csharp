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
    public partial class FirewallPolicyRule : IUtf8JsonSerializable, IModelJsonSerializable<FirewallPolicyRule>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<FirewallPolicyRule>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<FirewallPolicyRule>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

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

        internal static FirewallPolicyRule DeserializeFirewallPolicyRule(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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

            // Unknown type found so we will deserialize the base properties only
            Optional<string> name = default;
            Optional<string> description = default;
            FirewallPolicyRuleType ruleType = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
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
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new UnknownFirewallPolicyRule(name.Value, description.Value, ruleType, rawData);
        }

        FirewallPolicyRule IModelJsonSerializable<FirewallPolicyRule>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeFirewallPolicyRule(doc.RootElement, options);
        }

        BinaryData IModelSerializable<FirewallPolicyRule>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        FirewallPolicyRule IModelSerializable<FirewallPolicyRule>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeFirewallPolicyRule(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="FirewallPolicyRule"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="FirewallPolicyRule"/> to convert. </param>
        public static implicit operator RequestContent(FirewallPolicyRule model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="FirewallPolicyRule"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator FirewallPolicyRule(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeFirewallPolicyRule(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
