// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
                writer.WritePropertyName("location");
                writer.WriteStringValue(Location);
            }
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity");
                JsonSerializer.Serialize(writer, Identity);
            }
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(DisplayName))
            {
                writer.WritePropertyName("displayName");
                writer.WriteStringValue(DisplayName);
            }
            if (Optional.IsDefined(PolicyDefinitionId))
            {
                writer.WritePropertyName("policyDefinitionId");
                writer.WriteStringValue(PolicyDefinitionId);
            }
            if (Optional.IsCollectionDefined(NotScopes))
            {
                writer.WritePropertyName("notScopes");
                writer.WriteStartArray();
                foreach (var item in NotScopes)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Parameters))
            {
                writer.WritePropertyName("parameters");
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
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(Metadata))
            {
                writer.WritePropertyName("metadata");
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Metadata);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(Metadata.ToString()).RootElement);
#endif
            }
            if (Optional.IsDefined(EnforcementMode))
            {
                writer.WritePropertyName("enforcementMode");
                writer.WriteStringValue(EnforcementMode.Value.ToString());
            }
            if (Optional.IsCollectionDefined(NonComplianceMessages))
            {
                writer.WritePropertyName("nonComplianceMessages");
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
            Optional<string> location = default;
            Optional<SystemAssignedServiceIdentity> identity = default;
            Optional<ResourceIdentifier> id = default;
            Optional<string> name = default;
            Optional<ResourceType> type = default;
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
                if (property.NameEquals("location"))
                {
                    location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("identity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    identity = JsonSerializer.Deserialize<SystemAssignedServiceIdentity>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("displayName"))
                        {
                            displayName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("policyDefinitionId"))
                        {
                            policyDefinitionId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("scope"))
                        {
                            scope = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("notScopes"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
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
                        if (property0.NameEquals("parameters"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
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
                        if (property0.NameEquals("description"))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("metadata"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            metadata = BinaryData.FromString(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("enforcementMode"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            enforcementMode = new EnforcementMode(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("nonComplianceMessages"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
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
            return new FakePolicyAssignmentData(id, name, type, systemData, location.Value, identity, displayName.Value, policyDefinitionId.Value, scope.Value, Optional.ToList(notScopes), Optional.ToDictionary(parameters), description.Value, metadata.Value, Optional.ToNullable(enforcementMode), Optional.ToList(nonComplianceMessages));
        }
    }
}
