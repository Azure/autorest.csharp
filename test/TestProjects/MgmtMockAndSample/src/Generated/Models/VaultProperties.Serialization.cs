// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtMockAndSample.Models
{
    public partial class VaultProperties : IUtf8JsonSerializable, IModelJsonSerializable<VaultProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VaultProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VaultProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Duration))
            {
                writer.WritePropertyName("duration"u8);
                writer.WriteStringValue(Duration.Value, "P");
            }
            if (Optional.IsDefined(CreateOn))
            {
                writer.WritePropertyName("createOn"u8);
                writer.WriteStringValue(CreateOn.Value, "O");
            }
            writer.WritePropertyName("tenantId"u8);
            writer.WriteStringValue(TenantId);
            writer.WritePropertyName("sku"u8);
            writer.WriteObjectValue(Sku);
            if (Optional.IsCollectionDefined(AccessPolicies))
            {
                writer.WritePropertyName("accessPolicies"u8);
                writer.WriteStartArray();
                foreach (var item in AccessPolicies)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(VaultUri))
            {
                writer.WritePropertyName("vaultUri"u8);
                writer.WriteStringValue(VaultUri.AbsoluteUri);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(HsmPoolResourceId))
            {
                writer.WritePropertyName("hsmPoolResourceId"u8);
                writer.WriteStringValue(HsmPoolResourceId);
            }
            if (Optional.IsCollectionDefined(Deployments))
            {
                writer.WritePropertyName("deployments"u8);
                writer.WriteStartArray();
                foreach (var item in Deployments)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
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
            if (Optional.IsDefined(SoftDeleteRetentionInDays))
            {
                writer.WritePropertyName("softDeleteRetentionInDays"u8);
                writer.WriteNumberValue(SoftDeleteRetentionInDays.Value);
            }
            if (Optional.IsDefined(EnableRbacAuthorization))
            {
                writer.WritePropertyName("enableRbacAuthorization"u8);
                writer.WriteBooleanValue(EnableRbacAuthorization.Value);
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
                writer.WriteObjectValue(NetworkAcls);
            }
            if (Optional.IsDefined(ProvisioningState))
            {
                writer.WritePropertyName("provisioningState"u8);
                writer.WriteStringValue(ProvisioningState.Value.ToString());
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(PrivateEndpointConnections))
            {
                writer.WritePropertyName("privateEndpointConnections"u8);
                writer.WriteStartArray();
                foreach (var item in PrivateEndpointConnections)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PublicNetworkAccess))
            {
                writer.WritePropertyName("publicNetworkAccess"u8);
                writer.WriteStringValue(PublicNetworkAccess);
            }
            if (Optional.IsDefined(ReadWriteSingleStringProperty))
            {
                writer.WritePropertyName("readWriteSingleStringProperty"u8);
                writer.WriteObjectValue(ReadWriteSingleStringProperty);
            }
            if (Optional.IsDefined(ReadOnlySingleStringProperty))
            {
                writer.WritePropertyName("readOnlySingleStringProperty"u8);
                writer.WriteObjectValue(ReadOnlySingleStringProperty);
            }
            if (Optional.IsDefined(ExtremelyDeepStringProperty))
            {
                writer.WritePropertyName("extremelyDeepStringProperty"u8);
                writer.WriteObjectValue(ExtremelyDeepStringProperty);
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

        VaultProperties IModelJsonSerializable<VaultProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVaultProperties(document.RootElement, options);
        }

        internal static VaultProperties DeserializeVaultProperties(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<TimeSpan> duration = default;
            Optional<DateTimeOffset> createOn = default;
            Guid tenantId = default;
            MgmtMockAndSampleSku sku = default;
            Optional<IList<AccessPolicyEntry>> accessPolicies = default;
            Optional<Uri> vaultUri = default;
            Optional<string> hsmPoolResourceId = default;
            Optional<IList<string>> deployments = default;
            Optional<bool> enabledForDiskEncryption = default;
            Optional<bool> enabledForTemplateDeployment = default;
            Optional<bool> enableSoftDelete = default;
            Optional<int> softDeleteRetentionInDays = default;
            Optional<bool> enableRbacAuthorization = default;
            Optional<CreateMode> createMode = default;
            Optional<bool> enablePurgeProtection = default;
            Optional<NetworkRuleSet> networkAcls = default;
            Optional<VaultProvisioningState> provisioningState = default;
            Optional<IReadOnlyList<PrivateEndpointConnectionItem>> privateEndpointConnections = default;
            Optional<string> publicNetworkAccess = default;
            Optional<SinglePropertyModel> readWriteSingleStringProperty = default;
            Optional<ReadOnlySinglePropertyModel> readOnlySingleStringProperty = default;
            Optional<ExtremelyDeepSinglePropertyModel> extremelyDeepStringProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("duration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    duration = property.Value.GetTimeSpan("P");
                    continue;
                }
                if (property.NameEquals("createOn"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    createOn = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("tenantId"u8))
                {
                    tenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("sku"u8))
                {
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
                if (property.NameEquals("vaultUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vaultUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("hsmPoolResourceId"u8))
                {
                    hsmPoolResourceId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("deployments"u8))
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
                    deployments = array;
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
                if (property.NameEquals("softDeleteRetentionInDays"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    softDeleteRetentionInDays = property.Value.GetInt32();
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
                if (property.NameEquals("provisioningState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    provisioningState = new VaultProvisioningState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("privateEndpointConnections"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PrivateEndpointConnectionItem> array = new List<PrivateEndpointConnectionItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PrivateEndpointConnectionItem.DeserializePrivateEndpointConnectionItem(item));
                    }
                    privateEndpointConnections = array;
                    continue;
                }
                if (property.NameEquals("publicNetworkAccess"u8))
                {
                    publicNetworkAccess = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("readWriteSingleStringProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    readWriteSingleStringProperty = SinglePropertyModel.DeserializeSinglePropertyModel(property.Value);
                    continue;
                }
                if (property.NameEquals("readOnlySingleStringProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    readOnlySingleStringProperty = ReadOnlySinglePropertyModel.DeserializeReadOnlySinglePropertyModel(property.Value);
                    continue;
                }
                if (property.NameEquals("extremelyDeepStringProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    extremelyDeepStringProperty = ExtremelyDeepSinglePropertyModel.DeserializeExtremelyDeepSinglePropertyModel(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VaultProperties(Optional.ToNullable(duration), Optional.ToNullable(createOn), tenantId, sku, Optional.ToList(accessPolicies), vaultUri.Value, hsmPoolResourceId.Value, Optional.ToList(deployments), Optional.ToNullable(enabledForDiskEncryption), Optional.ToNullable(enabledForTemplateDeployment), Optional.ToNullable(enableSoftDelete), Optional.ToNullable(softDeleteRetentionInDays), Optional.ToNullable(enableRbacAuthorization), Optional.ToNullable(createMode), Optional.ToNullable(enablePurgeProtection), networkAcls.Value, Optional.ToNullable(provisioningState), Optional.ToList(privateEndpointConnections), publicNetworkAccess.Value, readWriteSingleStringProperty.Value, readOnlySingleStringProperty.Value, extremelyDeepStringProperty.Value, serializedAdditionalRawData);
        }

        BinaryData IModelSerializable<VaultProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        VaultProperties IModelSerializable<VaultProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVaultProperties(document.RootElement, options);
        }
    }
}
