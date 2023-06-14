// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    public partial class FakePolicyAssignmentData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location);
            }
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                JsonSerializer.Serialize(writer, Identity);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(DisplayName))
            {
                writer.WritePropertyName("displayName"u8);
                writer.WriteStringValue(DisplayName);
            }
            if (Optional.IsDefined(PolicyDefinitionId))
            {
                writer.WritePropertyName("policyDefinitionId"u8);
                writer.WriteStringValue(PolicyDefinitionId);
            }
            if (Optional.IsCollectionDefined(NotScopes))
            {
                writer.WritePropertyName("notScopes"u8);
                writer.WriteStartArray();
                foreach (var item in NotScopes)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Parameters))
            {
                writer.WritePropertyName("parameters"u8);
                writer.WriteStartObject();
                foreach (var item in Parameters)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(Metadata))
            {
                writer.WritePropertyName("metadata"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Metadata);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(Metadata.ToString()).RootElement);
#endif
            }
            if (Optional.IsDefined(EnforcementMode))
            {
                writer.WritePropertyName("enforcementMode"u8);
                writer.WriteStringValue(EnforcementMode.Value.ToString());
            }
            if (Optional.IsCollectionDefined(NonComplianceMessages))
            {
                writer.WritePropertyName("nonComplianceMessages"u8);
                writer.WriteStartArray();
                foreach (var item in NonComplianceMessages)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static FakePolicyAssignmentData DeserializeFakePolicyAssignmentData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> location = default;
            Optional<ManagedServiceIdentity> identity = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> displayName = default;
            Optional<string> policyDefinitionId = default;
            Optional<string> scope = default;
            Optional<IList<string>> notScopes = default;
            Optional<IDictionary<string, ParameterValuesValue>> parameters = default;
            Optional<string> description = default;
            Optional<BinaryData> metadata = default;
            Optional<EnforcementMode> enforcementMode = default;
            Optional<IList<NonComplianceMessage>> nonComplianceMessages = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("location"u8))
                {
                    location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identity = JsonSerializer.Deserialize<ManagedServiceIdentity>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
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
                        if (property0.NameEquals("displayName"u8))
                        {
                            displayName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("policyDefinitionId"u8))
                        {
                            policyDefinitionId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("scope"u8))
                        {
                            scope = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("notScopes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            notScopes = array;
                            continue;
                        }
                        if (property0.NameEquals("parameters"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            Dictionary<string, ParameterValuesValue> dictionary = new Dictionary<string, ParameterValuesValue>();
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                dictionary.Add(property1.Name, ParameterValuesValue.DeserializeParameterValuesValue(property1.Value));
                            }
                            parameters = dictionary;
                            continue;
                        }
                        if (property0.NameEquals("description"u8))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("metadata"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            metadata = BinaryData.FromString(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("enforcementMode"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            enforcementMode = new EnforcementMode(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("nonComplianceMessages"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<NonComplianceMessage> array = new List<NonComplianceMessage>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(NonComplianceMessage.DeserializeNonComplianceMessage(item));
                            }
                            nonComplianceMessages = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new FakePolicyAssignmentData(id, name, type, systemData.Value, location.Value, identity, displayName.Value, policyDefinitionId.Value, scope.Value, Optional.ToList(notScopes), Optional.ToDictionary(parameters), description.Value, metadata.Value, Optional.ToNullable(enforcementMode), Optional.ToList(nonComplianceMessages));
        }
    }
}
