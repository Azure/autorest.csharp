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
    public partial class BlobContainer : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Etag))
            {
                writer.WritePropertyName("etag");
                writer.WriteStringValue(Etag);
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Type))
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(Type);
            }
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
            if (Optional.IsDefined(LastModifiedTime))
            {
                writer.WritePropertyName("lastModifiedTime");
                writer.WriteStringValue(LastModifiedTime.Value, "O");
            }
            if (Optional.IsDefined(LeaseStatus))
            {
                writer.WritePropertyName("leaseStatus");
                writer.WriteStringValue(LeaseStatus.Value.ToString());
            }
            if (Optional.IsDefined(LeaseState))
            {
                writer.WritePropertyName("leaseState");
                writer.WriteStringValue(LeaseState.Value.ToString());
            }
            if (Optional.IsDefined(LeaseDuration))
            {
                writer.WritePropertyName("leaseDuration");
                writer.WriteStringValue(LeaseDuration.Value.ToString());
            }
            if (Optional.IsDefined(Metadata))
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
            if (Optional.IsDefined(ImmutabilityPolicy))
            {
                writer.WritePropertyName("immutabilityPolicy");
                writer.WriteObjectValue(ImmutabilityPolicy);
            }
            if (Optional.IsDefined(LegalHold))
            {
                writer.WritePropertyName("legalHold");
                writer.WriteObjectValue(LegalHold);
            }
            if (Optional.IsDefined(HasLegalHold))
            {
                writer.WritePropertyName("hasLegalHold");
                writer.WriteBooleanValue(HasLegalHold.Value);
            }
            if (Optional.IsDefined(HasImmutabilityPolicy))
            {
                writer.WritePropertyName("hasImmutabilityPolicy");
                writer.WriteBooleanValue(HasImmutabilityPolicy.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static BlobContainer DeserializeBlobContainer(JsonElement element)
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
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("defaultEncryptionScope"))
                        {
                            defaultEncryptionScope = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("denyEncryptionScopeOverride"))
                        {
                            denyEncryptionScopeOverride = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("publicAccess"))
                        {
                            publicAccess = property0.Value.GetString().ToPublicAccess();
                            continue;
                        }
                        if (property0.NameEquals("lastModifiedTime"))
                        {
                            lastModifiedTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("leaseStatus"))
                        {
                            leaseStatus = new LeaseStatus(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("leaseState"))
                        {
                            leaseState = new LeaseState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("leaseDuration"))
                        {
                            leaseDuration = new LeaseDuration(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("metadata"))
                        {
                            Dictionary<string, string> dictionary = new Dictionary<string, string>();
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                if (property1.Value.ValueKind == JsonValueKind.Null)
                                {
                                    dictionary.Add(property1.Name, null);
                                }
                                else
                                {
                                    dictionary.Add(property1.Name, property1.Value.GetString());
                                }
                            }
                            metadata = dictionary;
                            continue;
                        }
                        if (property0.NameEquals("immutabilityPolicy"))
                        {
                            immutabilityPolicy = ImmutabilityPolicyProperties.DeserializeImmutabilityPolicyProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("legalHold"))
                        {
                            legalHold = LegalHoldProperties.DeserializeLegalHoldProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("hasLegalHold"))
                        {
                            hasLegalHold = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("hasImmutabilityPolicy"))
                        {
                            hasImmutabilityPolicy = property0.Value.GetBoolean();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new BlobContainer(id.HasValue ? id.Value : null, name.HasValue ? name.Value : null, type.HasValue ? type.Value : null, etag.HasValue ? etag.Value : null, defaultEncryptionScope.HasValue ? defaultEncryptionScope.Value : null, denyEncryptionScopeOverride.HasValue ? denyEncryptionScopeOverride.Value : (bool?)null, publicAccess.HasValue ? publicAccess.Value : (PublicAccess?)null, lastModifiedTime.HasValue ? lastModifiedTime.Value : (DateTimeOffset?)null, leaseStatus.HasValue ? leaseStatus.Value : (LeaseStatus?)null, leaseState.HasValue ? leaseState.Value : (LeaseState?)null, leaseDuration.HasValue ? leaseDuration.Value : (LeaseDuration?)null, new ChangeTrackingDictionary<string, string>(metadata), immutabilityPolicy.HasValue ? immutabilityPolicy.Value : null, legalHold.HasValue ? legalHold.Value : null, hasLegalHold.HasValue ? hasLegalHold.Value : (bool?)null, hasImmutabilityPolicy.HasValue ? hasImmutabilityPolicy.Value : (bool?)null);
        }
    }
}
