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
    public partial class VaultPatchProperties : IUtf8JsonSerializable, IModelJsonSerializable<VaultPatchProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VaultPatchProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VaultPatchProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(TenantId))
            {
                writer.WritePropertyName("tenantId"u8);
                writer.WriteStringValue(TenantId.Value);
            }
            if (Optional.IsDefined(Sku))
            {
                writer.WritePropertyName("sku"u8);
                ((IModelJsonSerializable<MgmtMockAndSampleSku>)Sku).Serialize(writer, options);
            }
            if (Optional.IsCollectionDefined(AccessPolicies))
            {
                writer.WritePropertyName("accessPolicies"u8);
                writer.WriteStartArray();
                foreach (var item in AccessPolicies)
                {
                    ((IModelJsonSerializable<AccessPolicyEntry>)item).Serialize(writer, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(EnabledForDeployment))
            {
                writer.WritePropertyName("enabledForDeployment"u8);
                writer.WriteBooleanValue(EnabledForDeployment.Value);
            }
            if (Optional.IsDefined(EnabledForDiskEncryption))
            {
                writer.WritePropertyName("enabledForDiskEncryption"u8);
                writer.WriteBooleanValue(EnabledForDiskEncryption.Value);
            }
            if (Optional.IsDefined(EnabledForTemplateDeployment))
            {
                writer.WritePropertyName("enabledForTemplateDeployment"u8);
                writer.WriteBooleanValue(EnabledForTemplateDeployment.Value);
            }
            if (Optional.IsDefined(EnableSoftDelete))
            {
                writer.WritePropertyName("enableSoftDelete"u8);
                writer.WriteBooleanValue(EnableSoftDelete.Value);
            }
            if (Optional.IsDefined(EnableRbacAuthorization))
            {
                writer.WritePropertyName("enableRbacAuthorization"u8);
                writer.WriteBooleanValue(EnableRbacAuthorization.Value);
            }
            if (Optional.IsDefined(SoftDeleteRetentionInDays))
            {
                writer.WritePropertyName("softDeleteRetentionInDays"u8);
                writer.WriteNumberValue(SoftDeleteRetentionInDays.Value);
            }
            if (Optional.IsDefined(CreateMode))
            {
                writer.WritePropertyName("createMode"u8);
                writer.WriteStringValue(CreateMode.Value.ToSerialString());
            }
            if (Optional.IsDefined(EnablePurgeProtection))
            {
                writer.WritePropertyName("enablePurgeProtection"u8);
                writer.WriteBooleanValue(EnablePurgeProtection.Value);
            }
            if (Optional.IsDefined(NetworkAcls))
            {
                writer.WritePropertyName("networkAcls"u8);
                ((IModelJsonSerializable<NetworkRuleSet>)NetworkAcls).Serialize(writer, options);
            }
            if (Optional.IsDefined(PublicNetworkAccess))
            {
                writer.WritePropertyName("publicNetworkAccess"u8);
                writer.WriteStringValue(PublicNetworkAccess);
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

        internal static VaultPatchProperties DeserializeVaultPatchProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Guid> tenantId = default;
            Optional<MgmtMockAndSampleSku> sku = default;
            Optional<IList<AccessPolicyEntry>> accessPolicies = default;
            Optional<bool> enabledForDeployment = default;
            Optional<bool> enabledForDiskEncryption = default;
            Optional<bool> enabledForTemplateDeployment = default;
            Optional<bool> enableSoftDelete = default;
            Optional<bool> enableRbacAuthorization = default;
            Optional<int> softDeleteRetentionInDays = default;
            Optional<CreateMode> createMode = default;
            Optional<bool> enablePurgeProtection = default;
            Optional<NetworkRuleSet> networkAcls = default;
            Optional<string> publicNetworkAccess = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tenantId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("sku"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sku = MgmtMockAndSampleSku.DeserializeMgmtMockAndSampleSku(property.Value);
                    continue;
                }
                if (property.NameEquals("accessPolicies"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AccessPolicyEntry> array = new List<AccessPolicyEntry>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AccessPolicyEntry.DeserializeAccessPolicyEntry(item));
                    }
                    accessPolicies = array;
                    continue;
                }
                if (property.NameEquals("enabledForDeployment"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enabledForDeployment = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("enabledForDiskEncryption"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enabledForDiskEncryption = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("enabledForTemplateDeployment"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enabledForTemplateDeployment = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("enableSoftDelete"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enableSoftDelete = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("enableRbacAuthorization"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enableRbacAuthorization = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("softDeleteRetentionInDays"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    softDeleteRetentionInDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("createMode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    createMode = property.Value.GetString().ToCreateMode();
                    continue;
                }
                if (property.NameEquals("enablePurgeProtection"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enablePurgeProtection = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("networkAcls"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    networkAcls = NetworkRuleSet.DeserializeNetworkRuleSet(property.Value);
                    continue;
                }
                if (property.NameEquals("publicNetworkAccess"u8))
                {
                    publicNetworkAccess = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new VaultPatchProperties(Optional.ToNullable(tenantId), sku.Value, Optional.ToList(accessPolicies), Optional.ToNullable(enabledForDeployment), Optional.ToNullable(enabledForDiskEncryption), Optional.ToNullable(enabledForTemplateDeployment), Optional.ToNullable(enableSoftDelete), Optional.ToNullable(enableRbacAuthorization), Optional.ToNullable(softDeleteRetentionInDays), Optional.ToNullable(createMode), Optional.ToNullable(enablePurgeProtection), networkAcls.Value, publicNetworkAccess.Value, rawData);
        }

        VaultPatchProperties IModelJsonSerializable<VaultPatchProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVaultPatchProperties(doc.RootElement, options);
        }

        BinaryData IModelSerializable<VaultPatchProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        VaultPatchProperties IModelSerializable<VaultPatchProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeVaultPatchProperties(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="VaultPatchProperties"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="VaultPatchProperties"/> to convert. </param>
        public static implicit operator RequestContent(VaultPatchProperties model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="VaultPatchProperties"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator VaultPatchProperties(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeVaultPatchProperties(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
