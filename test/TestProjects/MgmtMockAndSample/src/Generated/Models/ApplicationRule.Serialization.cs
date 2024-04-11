// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class ApplicationRule : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
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
            if (Optional.IsCollectionDefined(Protocols))
            {
                writer.WritePropertyName("protocols"u8);
                writer.WriteStartArray();
                foreach (var item in Protocols)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TargetFqdns))
            {
                writer.WritePropertyName("targetFqdns"u8);
                writer.WriteStartArray();
                foreach (var item in TargetFqdns)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TargetUrls))
            {
                writer.WritePropertyName("targetUrls"u8);
                writer.WriteStartArray();
                foreach (var item in TargetUrls)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(FqdnTags))
            {
                writer.WritePropertyName("fqdnTags"u8);
                writer.WriteStartArray();
                foreach (var item in FqdnTags)
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
            if (Optional.IsDefined(TerminateTLS))
            {
                writer.WritePropertyName("terminateTLS"u8);
                writer.WriteBooleanValue(TerminateTLS.Value);
            }
            if (Optional.IsCollectionDefined(WebCategories))
            {
                writer.WritePropertyName("webCategories"u8);
                writer.WriteStartArray();
                foreach (var item in WebCategories)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(NewIntSerializeProperty))
            {
                if (NewIntSerializeProperty != null)
                {
                    writer.WritePropertyName("newIntSerializeProperty"u8);
                    writer.WriteNumberValue(NewIntSerializeProperty.Value);
                }
                else
                {
                    writer.WriteNull("newIntSerializeProperty");
                }
            }
            if (Optional.IsDefined(NewGeneratedTypeSerializeProperty))
            {
                writer.WritePropertyName("newGeneratedTypeSerializeProperty"u8);
                writer.WriteObjectValue<VaultKey>(NewGeneratedTypeSerializeProperty);
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
            if (Optional.IsDefined(NewStringSerializeProperty))
            {
                writer.WritePropertyName("newStringSerializeProperty"u8);
                writer.WriteStringValue(NewStringSerializeProperty);
            }
            if (Optional.IsCollectionDefined(NewArraySerializedProperty))
            {
                writer.WritePropertyName("newArraySerializedProperty"u8);
                writer.WriteStartArray();
                foreach (var item in NewArraySerializedProperty)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("fakeParent"u8);
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(NewDictionarySerializedProperty))
            {
                writer.WritePropertyName("newDictionarySerializedProperty"u8);
                SerializeNameValue(writer);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static ApplicationRule DeserializeApplicationRule(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> sourceAddresses = default;
            IList<string> destinationAddresses = default;
            IList<FirewallPolicyRuleApplicationProtocol> protocols = default;
            IList<string> targetFqdns = default;
            IList<string> targetUrls = default;
            IList<string> fqdnTags = default;
            IList<string> sourceIpGroups = default;
            bool? terminateTLS = default;
            IList<string> webCategories = default;
            int? newIntSerializeProperty = default;
            VaultKey newGeneratedTypeSerializeProperty = default;
            string name = default;
            string description = default;
            FirewallPolicyRuleType ruleType = default;
            string newStringSerializeProperty = default;
            IList<string> newArraySerializedProperty = default;
            IDictionary<string, string> newDictionarySerializedProperty = default;
            foreach (var property in element.EnumerateObject())
            {
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
                if (property.NameEquals("protocols"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FirewallPolicyRuleApplicationProtocol> array = new List<FirewallPolicyRuleApplicationProtocol>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FirewallPolicyRuleApplicationProtocol.DeserializeFirewallPolicyRuleApplicationProtocol(item));
                    }
                    protocols = array;
                    continue;
                }
                if (property.NameEquals("targetFqdns"u8))
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
                    targetFqdns = array;
                    continue;
                }
                if (property.NameEquals("targetUrls"u8))
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
                    targetUrls = array;
                    continue;
                }
                if (property.NameEquals("fqdnTags"u8))
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
                    fqdnTags = array;
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
                if (property.NameEquals("terminateTLS"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    terminateTLS = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("webCategories"u8))
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
                    webCategories = array;
                    continue;
                }
                if (property.NameEquals("newIntSerializeProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        newIntSerializeProperty = null;
                        continue;
                    }
                    newIntSerializeProperty = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("newGeneratedTypeSerializeProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    newGeneratedTypeSerializeProperty = VaultKey.DeserializeVaultKey(property.Value);
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
                if (property.NameEquals("newStringSerializeProperty"u8))
                {
                    newStringSerializeProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("newArraySerializedProperty"u8))
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
                    newArraySerializedProperty = array;
                    continue;
                }
                if (property.NameEquals("fakeParent"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("newDictionarySerializedProperty"u8))
                        {
                            DeserializeNameValue(property0, ref newDictionarySerializedProperty);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ApplicationRule(
                name,
                description,
                ruleType,
                newStringSerializeProperty,
                newArraySerializedProperty ?? new ChangeTrackingList<string>(),
                newDictionarySerializedProperty ?? new ChangeTrackingDictionary<string, string>(),
                sourceAddresses ?? new ChangeTrackingList<string>(),
                destinationAddresses ?? new ChangeTrackingList<string>(),
                protocols ?? new ChangeTrackingList<FirewallPolicyRuleApplicationProtocol>(),
                targetFqdns ?? new ChangeTrackingList<string>(),
                targetUrls ?? new ChangeTrackingList<string>(),
                fqdnTags ?? new ChangeTrackingList<string>(),
                sourceIpGroups ?? new ChangeTrackingList<string>(),
                terminateTLS,
                webCategories ?? new ChangeTrackingList<string>(),
                newIntSerializeProperty,
                newGeneratedTypeSerializeProperty);
        }
    }
}
