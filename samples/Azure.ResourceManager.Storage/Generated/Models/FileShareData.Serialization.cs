// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class FileShareData : IUtf8JsonSerializable, IJsonModel<FileShareData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<FileShareData>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<FileShareData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Etag))
                {
                    writer.WritePropertyName("etag"u8);
                    writer.WriteStringValue(Etag.Value.ToString());
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(SystemData))
                {
                    writer.WritePropertyName("systemData"u8);
                    JsonSerializer.Serialize(writer, SystemData);
                }
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(LastModifiedOn))
                {
                    writer.WritePropertyName("lastModifiedTime"u8);
                    writer.WriteStringValue(LastModifiedOn.Value, "O");
                }
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
            if (Optional.IsDefined(ShareQuota))
            {
                writer.WritePropertyName("shareQuota"u8);
                writer.WriteNumberValue(ShareQuota.Value);
            }
            if (Optional.IsDefined(EnabledProtocols))
            {
                writer.WritePropertyName("enabledProtocols"u8);
                writer.WriteStringValue(EnabledProtocols.Value.ToString());
            }
            if (Optional.IsDefined(RootSquash))
            {
                writer.WritePropertyName("rootSquash"u8);
                writer.WriteStringValue(RootSquash.Value.ToString());
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Version))
                {
                    writer.WritePropertyName("version"u8);
                    writer.WriteStringValue(Version);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Deleted))
                {
                    writer.WritePropertyName("deleted"u8);
                    writer.WriteBooleanValue(Deleted.Value);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(DeletedOn))
                {
                    writer.WritePropertyName("deletedTime"u8);
                    writer.WriteStringValue(DeletedOn.Value, "O");
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(RemainingRetentionDays))
                {
                    writer.WritePropertyName("remainingRetentionDays"u8);
                    writer.WriteNumberValue(RemainingRetentionDays.Value);
                }
            }
            if (Optional.IsDefined(AccessTier))
            {
                writer.WritePropertyName("accessTier"u8);
                writer.WriteStringValue(AccessTier.Value.ToString());
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(AccessTierChangeOn))
                {
                    writer.WritePropertyName("accessTierChangeTime"u8);
                    writer.WriteStringValue(AccessTierChangeOn.Value, "O");
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(AccessTierStatus))
                {
                    writer.WritePropertyName("accessTierStatus"u8);
                    writer.WriteStringValue(AccessTierStatus);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(ShareUsageBytes))
                {
                    writer.WritePropertyName("shareUsageBytes"u8);
                    writer.WriteNumberValue(ShareUsageBytes.Value);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(LeaseStatus))
                {
                    writer.WritePropertyName("leaseStatus"u8);
                    writer.WriteStringValue(LeaseStatus.Value.ToString());
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(LeaseState))
                {
                    writer.WritePropertyName("leaseState"u8);
                    writer.WriteStringValue(LeaseState.Value.ToString());
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(LeaseDuration))
                {
                    writer.WritePropertyName("leaseDuration"u8);
                    writer.WriteStringValue(LeaseDuration.Value.ToString());
                }
            }
            if (Optional.IsCollectionDefined(SignedIdentifiers))
            {
                writer.WritePropertyName("signedIdentifiers"u8);
                writer.WriteStartArray();
                foreach (var item in SignedIdentifiers)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(SnapshotOn))
                {
                    writer.WritePropertyName("snapshotTime"u8);
                    writer.WriteStringValue(SnapshotOn.Value, "O");
                }
            }
            writer.WriteEndObject();
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        FileShareData IJsonModel<FileShareData>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFileShareData(document.RootElement, options);
        }

        internal static FileShareData DeserializeFileShareData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ETag> etag = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<DateTimeOffset> lastModifiedTime = default;
            Optional<IDictionary<string, string>> metadata = default;
            Optional<int> shareQuota = default;
            Optional<EnabledProtocol> enabledProtocols = default;
            Optional<RootSquashType> rootSquash = default;
            Optional<string> version = default;
            Optional<bool> deleted = default;
            Optional<DateTimeOffset> deletedTime = default;
            Optional<int> remainingRetentionDays = default;
            Optional<ShareAccessTier> accessTier = default;
            Optional<DateTimeOffset> accessTierChangeTime = default;
            Optional<string> accessTierStatus = default;
            Optional<long> shareUsageBytes = default;
            Optional<LeaseStatus> leaseStatus = default;
            Optional<LeaseState> leaseState = default;
            Optional<LeaseDuration> leaseDuration = default;
            Optional<IList<SignedIdentifier>> signedIdentifiers = default;
            Optional<DateTimeOffset> snapshotTime = default;
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
                        if (property0.NameEquals("lastModifiedTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            lastModifiedTime = property0.Value.GetDateTimeOffset("O");
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
                        if (property0.NameEquals("shareQuota"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            shareQuota = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("enabledProtocols"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            enabledProtocols = new EnabledProtocol(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("rootSquash"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            rootSquash = new RootSquashType(property0.Value.GetString());
                            continue;
                        }
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
                        if (property0.NameEquals("accessTier"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            accessTier = new ShareAccessTier(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("accessTierChangeTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            accessTierChangeTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("accessTierStatus"u8))
                        {
                            accessTierStatus = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("shareUsageBytes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            shareUsageBytes = property0.Value.GetInt64();
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
                        if (property0.NameEquals("signedIdentifiers"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<SignedIdentifier> array = new List<SignedIdentifier>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(SignedIdentifier.DeserializeSignedIdentifier(item));
                            }
                            signedIdentifiers = array;
                            continue;
                        }
                        if (property0.NameEquals("snapshotTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            snapshotTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new FileShareData(id, name, type, systemData.Value, Optional.ToNullable(lastModifiedTime), Optional.ToDictionary(metadata), Optional.ToNullable(shareQuota), Optional.ToNullable(enabledProtocols), Optional.ToNullable(rootSquash), version.Value, Optional.ToNullable(deleted), Optional.ToNullable(deletedTime), Optional.ToNullable(remainingRetentionDays), Optional.ToNullable(accessTier), Optional.ToNullable(accessTierChangeTime), accessTierStatus.Value, Optional.ToNullable(shareUsageBytes), Optional.ToNullable(leaseStatus), Optional.ToNullable(leaseState), Optional.ToNullable(leaseDuration), Optional.ToList(signedIdentifiers), Optional.ToNullable(snapshotTime), Optional.ToNullable(etag), serializedAdditionalRawData);
        }

        BinaryData IModel<FileShareData>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.WriteCore(this, options);
        }

        FileShareData IModel<FileShareData>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFileShareData(document.RootElement, options);
        }
    }
}
