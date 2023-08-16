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
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class FirewallPolicyRuleCollectionGroupData : IUtf8JsonSerializable, IModelJsonSerializable<FirewallPolicyRuleCollectionGroupData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<FirewallPolicyRuleCollectionGroupData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<FirewallPolicyRuleCollectionGroupData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<FirewallPolicyRuleCollectionGroupData>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(Priority))
            {
                writer.WritePropertyName("priority"u8);
                writer.WriteNumberValue(Priority.Value);
            }
            if (Optional.IsCollectionDefined(RuleCollections))
            {
                writer.WritePropertyName("ruleCollections"u8);
                writer.WriteStartArray();
                foreach (var item in RuleCollections)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
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

        internal static FirewallPolicyRuleCollectionGroupData DeserializeFirewallPolicyRuleCollectionGroupData(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> etag = default;
            Optional<ResourceType> type = default;
            Optional<string> id = default;
            Optional<int> priority = default;
            Optional<IList<FirewallPolicyRuleCollection>> ruleCollections = default;
            Optional<ProvisioningState> provisioningState = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
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
                        if (property0.NameEquals("priority"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            priority = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("ruleCollections"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<FirewallPolicyRuleCollection> array = new List<FirewallPolicyRuleCollection>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(FirewallPolicyRuleCollection.DeserializeFirewallPolicyRuleCollection(item));
                            }
                            ruleCollections = array;
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = new ProvisioningState(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new FirewallPolicyRuleCollectionGroupData(id.Value, name.Value, etag.Value, Optional.ToNullable(type), Optional.ToNullable(priority), Optional.ToList(ruleCollections), Optional.ToNullable(provisioningState), rawData);
        }

        FirewallPolicyRuleCollectionGroupData IModelJsonSerializable<FirewallPolicyRuleCollectionGroupData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<FirewallPolicyRuleCollectionGroupData>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeFirewallPolicyRuleCollectionGroupData(doc.RootElement, options);
        }

        BinaryData IModelSerializable<FirewallPolicyRuleCollectionGroupData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<FirewallPolicyRuleCollectionGroupData>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        FirewallPolicyRuleCollectionGroupData IModelSerializable<FirewallPolicyRuleCollectionGroupData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<FirewallPolicyRuleCollectionGroupData>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeFirewallPolicyRuleCollectionGroupData(doc.RootElement, options);
        }

        public static implicit operator RequestContent(FirewallPolicyRuleCollectionGroupData model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator FirewallPolicyRuleCollectionGroupData(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeFirewallPolicyRuleCollectionGroupData(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
