// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class ListContainerItem : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(DefaultEncryptionScope))
            {
                writer.WritePropertyName("defaultEncryptionScope");
                writer.WriteStringValue(DefaultEncryptionScope);
            }
            if (Optional.IsDefined(DenyEncryptionScopeOverride))
            {
                writer.WritePropertyName("denyEncryptionScopeOverride");
                writer.WriteBooleanValue(DenyEncryptionScopeOverride.Value);
            }
            if (Optional.IsDefined(PublicAccess))
            {
                writer.WritePropertyName("publicAccess");
                writer.WriteStringValue(PublicAccess.Value.ToSerialString());
            }
            if (Optional.IsCollectionDefined(Metadata))
            {
                writer.WritePropertyName("metadata");
                writer.WriteStartObject();
                foreach (var item in Metadata)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static ListContainerItem DeserializeListContainerItem(JsonElement element)
        {
            Optional<string> etag = default;
            Optional<string> id = default;
            Optional<string> name = default;
            Optional<string> type = default;
            Optional<string> defaultEncryptionScope = default;
            Optional<bool> denyEncryptionScopeOverride = default;
            Optional<PublicAccess> publicAccess = default;
            Optional<DateTimeOffset> lastModifiedTime = default;
            Optional<LeaseStatus> leaseStatus = default;
            Optional<LeaseState> leaseState = default;
            Optional<LeaseDuration> leaseDuration = default;
            Optional<IDictionary<string, string>> metadata = default;
            Optional<ImmutabilityPolicyProperties> immutabilityPolicy = default;
            Optional<LegalHoldProperties> legalHold = default;
            Optional<bool> hasLegalHold = default;
            Optional<bool> hasImmutabilityPolicy = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
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
                    type = property.Value.GetString();
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
                        if (property0.NameEquals("defaultEncryptionScope"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            defaultEncryptionScope = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("denyEncryptionScopeOverride"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            denyEncryptionScopeOverride = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("publicAccess"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            publicAccess = property0.Value.GetString().ToPublicAccess();
                            continue;
                        }
                        if (property0.NameEquals("lastModifiedTime"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            lastModifiedTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("leaseStatus"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            leaseStatus = new LeaseStatus(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("leaseState"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            leaseState = new LeaseState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("leaseDuration"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            leaseDuration = new LeaseDuration(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("metadata"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            Dictionary<string, string> dictionary = new Dictionary<string, string>();
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                dictionary.Add(property1.Name, property1.Value.GetString());
                            }
                            metadata = dictionary;
                            continue;
                        }
                        if (property0.NameEquals("immutabilityPolicy"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            immutabilityPolicy = ImmutabilityPolicyProperties.DeserializeImmutabilityPolicyProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("legalHold"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            legalHold = LegalHoldProperties.DeserializeLegalHoldProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("hasLegalHold"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            hasLegalHold = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("hasImmutabilityPolicy"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            hasImmutabilityPolicy = property0.Value.GetBoolean();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ListContainerItem(id.Value, name.Value, type.Value, etag.Value, defaultEncryptionScope.Value, Optional.ToNullable(denyEncryptionScopeOverride), Optional.ToNullable(publicAccess), Optional.ToNullable(lastModifiedTime), Optional.ToNullable(leaseStatus), Optional.ToNullable(leaseState), Optional.ToNullable(leaseDuration), Optional.ToDictionary(metadata), immutabilityPolicy.Value, legalHold.Value, Optional.ToNullable(hasLegalHold), Optional.ToNullable(hasImmutabilityPolicy));
        }
    }
}
