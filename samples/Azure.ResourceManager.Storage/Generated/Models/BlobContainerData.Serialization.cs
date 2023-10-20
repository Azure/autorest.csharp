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
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobContainerData : IUtf8JsonSerializable, IModelJsonSerializable<BlobContainerData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<BlobContainerData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<BlobContainerData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Etag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(Etag.Value.ToString());
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(SystemData))
            {
                writer.WritePropertyName("systemData"u8);
                JsonSerializer.Serialize(writer, SystemData);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Version))
                {
                    writer.WritePropertyName("version"u8);
                    writer.WriteStringValue(Version);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Deleted))
                {
                    writer.WritePropertyName("deleted"u8);
                    writer.WriteBooleanValue(Deleted.Value);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(DeletedOn))
                {
                    writer.WritePropertyName("deletedTime"u8);
                    writer.WriteStringValue(DeletedOn.Value, "O");
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(RemainingRetentionDays))
                {
                    writer.WritePropertyName("remainingRetentionDays"u8);
                    writer.WriteNumberValue(RemainingRetentionDays.Value);
                }
                if (Optional.IsDefined(DefaultEncryptionScope))
                {
                    writer.WritePropertyName("defaultEncryptionScope"u8);
                    writer.WriteStringValue(DefaultEncryptionScope);
                }
                if (Optional.IsDefined(DenyEncryptionScopeOverride))
                {
                    writer.WritePropertyName("denyEncryptionScopeOverride"u8);
                    writer.WriteBooleanValue(DenyEncryptionScopeOverride.Value);
                }
                if (Optional.IsDefined(PublicAccess))
                {
                    writer.WritePropertyName("publicAccess"u8);
                    writer.WriteStringValue(PublicAccess.Value.ToSerialString());
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(LastModifiedOn))
                {
                    writer.WritePropertyName("lastModifiedTime"u8);
                    writer.WriteStringValue(LastModifiedOn.Value, "O");
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(LeaseStatus))
                {
                    writer.WritePropertyName("leaseStatus"u8);
                    writer.WriteStringValue(LeaseStatus.Value.ToString());
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(LeaseState))
                {
                    writer.WritePropertyName("leaseState"u8);
                    writer.WriteStringValue(LeaseState.Value.ToString());
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(LeaseDuration))
                {
                    writer.WritePropertyName("leaseDuration"u8);
                    writer.WriteStringValue(LeaseDuration.Value.ToString());
                }
                if (Optional.IsCollectionDefined(Metadata))
                {
                    writer.WritePropertyName("metadata"u8);
                    writer.WriteStartObject();
                    foreach (var item in Metadata)
                    {
                        writer.WritePropertyName(item.Key);
                        writer.WriteStringValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(ImmutabilityPolicy))
                {
                    writer.WritePropertyName("immutabilityPolicy"u8);
                    writer.WriteObjectValue(ImmutabilityPolicy);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(LegalHold))
                {
                    writer.WritePropertyName("legalHold"u8);
                    writer.WriteObjectValue(LegalHold);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(HasLegalHold))
                {
                    writer.WritePropertyName("hasLegalHold"u8);
                    writer.WriteBooleanValue(HasLegalHold.Value);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(HasImmutabilityPolicy))
                {
                    writer.WritePropertyName("hasImmutabilityPolicy"u8);
                    writer.WriteBooleanValue(HasImmutabilityPolicy.Value);
                }
                if (Optional.IsDefined(ImmutableStorageWithVersioning))
                {
                    writer.WritePropertyName("immutableStorageWithVersioning"u8);
                    writer.WriteObjectValue(ImmutableStorageWithVersioning);
                }
                if (Optional.IsDefined(EnableNfsV3RootSquash))
                {
                    writer.WritePropertyName("enableNfsV3RootSquash"u8);
                    writer.WriteBooleanValue(EnableNfsV3RootSquash.Value);
                }
                if (Optional.IsDefined(EnableNfsV3AllSquash))
                {
                    writer.WritePropertyName("enableNfsV3AllSquash"u8);
                    writer.WriteBooleanValue(EnableNfsV3AllSquash.Value);
                }
                writer.WriteEndObject();
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

        BlobContainerData IModelJsonSerializable<BlobContainerData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBlobContainerData(document.RootElement, options);
        }

        internal static BlobContainerData DeserializeBlobContainerData(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ETag> etag = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> version = default;
            Optional<bool> deleted = default;
            Optional<DateTimeOffset> deletedTime = default;
            Optional<int> remainingRetentionDays = default;
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
            Optional<ImmutableStorageWithVersioning> immutableStorageWithVersioning = default;
            Optional<bool> enableNfsV3RootSquash = default;
            Optional<bool> enableNfsV3AllSquash = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    etag = new ETag(property.Value.GetString());
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
                        if (property0.NameEquals("version"u8))
                        {
                            version = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("deleted"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            deleted = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("deletedTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            deletedTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("remainingRetentionDays"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            remainingRetentionDays = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("defaultEncryptionScope"u8))
                        {
                            defaultEncryptionScope = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("denyEncryptionScopeOverride"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            denyEncryptionScopeOverride = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("publicAccess"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            publicAccess = property0.Value.GetString().ToPublicAccess();
                            continue;
                        }
                        if (property0.NameEquals("lastModifiedTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            lastModifiedTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("leaseStatus"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            leaseStatus = new LeaseStatus(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("leaseState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            leaseState = new LeaseState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("leaseDuration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            leaseDuration = new LeaseDuration(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("metadata"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
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
                        if (property0.NameEquals("immutabilityPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            immutabilityPolicy = ImmutabilityPolicyProperties.DeserializeImmutabilityPolicyProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("legalHold"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            legalHold = LegalHoldProperties.DeserializeLegalHoldProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("hasLegalHold"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            hasLegalHold = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("hasImmutabilityPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            hasImmutabilityPolicy = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("immutableStorageWithVersioning"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            immutableStorageWithVersioning = ImmutableStorageWithVersioning.DeserializeImmutableStorageWithVersioning(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("enableNfsV3RootSquash"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            enableNfsV3RootSquash = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("enableNfsV3AllSquash"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            enableNfsV3AllSquash = property0.Value.GetBoolean();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new BlobContainerData(id, name, type, systemData.Value, version.Value, Optional.ToNullable(deleted), Optional.ToNullable(deletedTime), Optional.ToNullable(remainingRetentionDays), defaultEncryptionScope.Value, Optional.ToNullable(denyEncryptionScopeOverride), Optional.ToNullable(publicAccess), Optional.ToNullable(lastModifiedTime), Optional.ToNullable(leaseStatus), Optional.ToNullable(leaseState), Optional.ToNullable(leaseDuration), Optional.ToDictionary(metadata), immutabilityPolicy.Value, legalHold.Value, Optional.ToNullable(hasLegalHold), Optional.ToNullable(hasImmutabilityPolicy), immutableStorageWithVersioning.Value, Optional.ToNullable(enableNfsV3RootSquash), Optional.ToNullable(enableNfsV3AllSquash), Optional.ToNullable(etag), serializedAdditionalRawData);
        }

        BinaryData IModelSerializable<BlobContainerData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        BlobContainerData IModelSerializable<BlobContainerData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBlobContainerData(document.RootElement, options);
        }
    }
}
