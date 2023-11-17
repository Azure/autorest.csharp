// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtParamOrdering.Models;

namespace MgmtParamOrdering
{
    public partial class WorkspaceData : IUtf8JsonSerializable, IJsonModel<WorkspaceData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<WorkspaceData>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<WorkspaceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<WorkspaceData>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<WorkspaceData>)} interface");
            }

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
            if (options.Format == "J")
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format == "J")
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == "J")
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(SystemData))
                {
                    writer.WritePropertyName("systemData"u8);
                    JsonSerializer.Serialize(writer, SystemData);
                }
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (options.Format == "J")
            {
                if (Optional.IsDefined(WorkspaceId))
                {
                    writer.WritePropertyName("workspaceId"u8);
                    writer.WriteStringValue(WorkspaceId);
                }
            }
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
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ProvisioningState))
                {
                    writer.WritePropertyName("provisioningState"u8);
                    writer.WriteStringValue(ProvisioningState.Value.ToString());
                }
            }
            if (Optional.IsDefined(HbiWorkspace))
            {
                writer.WritePropertyName("hbiWorkspace"u8);
                writer.WriteBooleanValue(HbiWorkspace.Value);
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ServiceProvisionedResourceGroup))
                {
                    writer.WritePropertyName("serviceProvisionedResourceGroup"u8);
                    writer.WriteStringValue(ServiceProvisionedResourceGroup);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(PrivateLinkCount))
                {
                    writer.WritePropertyName("privateLinkCount"u8);
                    writer.WriteNumberValue(PrivateLinkCount.Value);
                }
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
            if (options.Format == "J")
            {
                if (Optional.IsDefined(TenantId))
                {
                    writer.WritePropertyName("tenantId"u8);
                    writer.WriteStringValue(TenantId.Value);
                }
            }
            writer.WriteEndObject();
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        WorkspaceData IJsonModel<WorkspaceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(WorkspaceData)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeWorkspaceData(document.RootElement, options);
        }

        internal static WorkspaceData DeserializeWorkspaceData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new WorkspaceData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, workspaceId.Value, description.Value, friendlyName.Value, keyVault.Value, applicationInsights.Value, containerRegistry.Value, storageAccount.Value, discoveryUrl.Value, Optional.ToNullable(provisioningState), Optional.ToNullable(hbiWorkspace), serviceProvisionedResourceGroup.Value, Optional.ToNullable(privateLinkCount), imageBuildCompute.Value, Optional.ToNullable(allowPublicAccessWhenBehindVnet), primaryUserAssignedIdentity.Value, Optional.ToNullable(tenantId), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<WorkspaceData>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(WorkspaceData)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        WorkspaceData IPersistableModel<WorkspaceData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(WorkspaceData)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeWorkspaceData(document.RootElement, options);
        }

        string IPersistableModel<WorkspaceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
