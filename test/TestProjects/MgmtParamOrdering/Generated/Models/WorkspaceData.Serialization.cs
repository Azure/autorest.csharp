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
using MgmtParamOrdering.Models;

namespace MgmtParamOrdering
{
    public partial class WorkspaceData : IUtf8JsonSerializable, IModelJsonSerializable<WorkspaceData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<WorkspaceData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<WorkspaceData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(FriendlyName))
            {
                writer.WritePropertyName("friendlyName"u8);
                writer.WriteStringValue(FriendlyName);
            }
            if (Optional.IsDefined(KeyVault))
            {
                writer.WritePropertyName("keyVault"u8);
                writer.WriteStringValue(KeyVault);
            }
            if (Optional.IsDefined(ApplicationInsights))
            {
                writer.WritePropertyName("applicationInsights"u8);
                writer.WriteStringValue(ApplicationInsights);
            }
            if (Optional.IsDefined(ContainerRegistry))
            {
                if (ContainerRegistry != null)
                {
                    writer.WritePropertyName("containerRegistry"u8);
                    writer.WriteStringValue(ContainerRegistry);
                }
                else
                {
                    writer.WriteNull("containerRegistry");
                }
            }
            if (Optional.IsDefined(StorageAccount))
            {
                writer.WritePropertyName("storageAccount"u8);
                writer.WriteStringValue(StorageAccount);
            }
            if (Optional.IsDefined(DiscoveryUri))
            {
                writer.WritePropertyName("discoveryUrl"u8);
                writer.WriteStringValue(DiscoveryUri.AbsoluteUri);
            }
            if (Optional.IsDefined(HbiWorkspace))
            {
                writer.WritePropertyName("hbiWorkspace"u8);
                writer.WriteBooleanValue(HbiWorkspace.Value);
            }
            if (Optional.IsDefined(ImageBuildCompute))
            {
                writer.WritePropertyName("imageBuildCompute"u8);
                writer.WriteStringValue(ImageBuildCompute);
            }
            if (Optional.IsDefined(AllowPublicAccessWhenBehindVnet))
            {
                writer.WritePropertyName("allowPublicAccessWhenBehindVnet"u8);
                writer.WriteBooleanValue(AllowPublicAccessWhenBehindVnet.Value);
            }
            if (Optional.IsDefined(PrimaryUserAssignedIdentity))
            {
                writer.WritePropertyName("primaryUserAssignedIdentity"u8);
                writer.WriteStringValue(PrimaryUserAssignedIdentity);
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

        internal static WorkspaceData DeserializeWorkspaceData(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> workspaceId = default;
            Optional<string> description = default;
            Optional<string> friendlyName = default;
            Optional<string> keyVault = default;
            Optional<string> applicationInsights = default;
            Optional<string> containerRegistry = default;
            Optional<string> storageAccount = default;
            Optional<Uri> discoveryUrl = default;
            Optional<ProvisioningState> provisioningState = default;
            Optional<bool> hbiWorkspace = default;
            Optional<string> serviceProvisionedResourceGroup = default;
            Optional<int> privateLinkCount = default;
            Optional<string> imageBuildCompute = default;
            Optional<bool> allowPublicAccessWhenBehindVnet = default;
            Optional<string> primaryUserAssignedIdentity = default;
            Optional<Guid> tenantId = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
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
                        if (property0.NameEquals("workspaceId"u8))
                        {
                            workspaceId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("description"u8))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("friendlyName"u8))
                        {
                            friendlyName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("keyVault"u8))
                        {
                            keyVault = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("applicationInsights"u8))
                        {
                            applicationInsights = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("containerRegistry"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                containerRegistry = null;
                                continue;
                            }
                            containerRegistry = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("storageAccount"u8))
                        {
                            storageAccount = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("discoveryUrl"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            discoveryUrl = new Uri(property0.Value.GetString());
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
                        if (property0.NameEquals("hbiWorkspace"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            hbiWorkspace = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("serviceProvisionedResourceGroup"u8))
                        {
                            serviceProvisionedResourceGroup = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("privateLinkCount"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            privateLinkCount = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("imageBuildCompute"u8))
                        {
                            imageBuildCompute = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("allowPublicAccessWhenBehindVnet"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            allowPublicAccessWhenBehindVnet = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("primaryUserAssignedIdentity"u8))
                        {
                            primaryUserAssignedIdentity = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("tenantId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            tenantId = property0.Value.GetGuid();
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
            return new WorkspaceData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, workspaceId.Value, description.Value, friendlyName.Value, keyVault.Value, applicationInsights.Value, containerRegistry.Value, storageAccount.Value, discoveryUrl.Value, Optional.ToNullable(provisioningState), Optional.ToNullable(hbiWorkspace), serviceProvisionedResourceGroup.Value, Optional.ToNullable(privateLinkCount), imageBuildCompute.Value, Optional.ToNullable(allowPublicAccessWhenBehindVnet), primaryUserAssignedIdentity.Value, Optional.ToNullable(tenantId), rawData);
        }

        WorkspaceData IModelJsonSerializable<WorkspaceData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeWorkspaceData(doc.RootElement, options);
        }

        BinaryData IModelSerializable<WorkspaceData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        WorkspaceData IModelSerializable<WorkspaceData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeWorkspaceData(doc.RootElement, options);
        }

        public static implicit operator RequestContent(WorkspaceData model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator WorkspaceData(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeWorkspaceData(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
