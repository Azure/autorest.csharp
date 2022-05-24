// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtParamOrdering.Models;

namespace MgmtParamOrdering
{
    public partial class WorkspaceData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("tags");
            writer.WriteStartObject();
            foreach (var item in Tags)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("location");
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(FriendlyName))
            {
                writer.WritePropertyName("friendlyName");
                writer.WriteStringValue(FriendlyName);
            }
            if (Optional.IsDefined(KeyVault))
            {
                writer.WritePropertyName("keyVault");
                writer.WriteStringValue(KeyVault);
            }
            if (Optional.IsDefined(ApplicationInsights))
            {
                writer.WritePropertyName("applicationInsights");
                writer.WriteStringValue(ApplicationInsights);
            }
            if (Optional.IsDefined(ContainerRegistry))
            {
                if (ContainerRegistry != null)
                {
                    writer.WritePropertyName("containerRegistry");
                    writer.WriteStringValue(ContainerRegistry);
                }
                else
                {
                    writer.WriteNull("containerRegistry");
                }
            }
            if (Optional.IsDefined(StorageAccount))
            {
                writer.WritePropertyName("storageAccount");
                writer.WriteStringValue(StorageAccount);
            }
            if (Optional.IsDefined(DiscoveryUri))
            {
                writer.WritePropertyName("discoveryUrl");
                writer.WriteStringValue(DiscoveryUri.AbsoluteUri);
            }
            if (Optional.IsDefined(HbiWorkspace))
            {
                writer.WritePropertyName("hbiWorkspace");
                writer.WriteBooleanValue(HbiWorkspace.Value);
            }
            if (Optional.IsDefined(ImageBuildCompute))
            {
                writer.WritePropertyName("imageBuildCompute");
                writer.WriteStringValue(ImageBuildCompute);
            }
            if (Optional.IsDefined(AllowPublicAccessWhenBehindVnet))
            {
                writer.WritePropertyName("allowPublicAccessWhenBehindVnet");
                writer.WriteBooleanValue(AllowPublicAccessWhenBehindVnet.Value);
            }
            if (Optional.IsDefined(PrimaryUserAssignedIdentity))
            {
                writer.WritePropertyName("primaryUserAssignedIdentity");
                writer.WriteStringValue(PrimaryUserAssignedIdentity);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static WorkspaceData DeserializeWorkspaceData(JsonElement element)
        {
            IDictionary<string, string> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
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
            Optional<string> tenantId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tags"))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("location"))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"))
                {
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
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
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
                        if (property0.NameEquals("workspaceId"))
                        {
                            workspaceId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("description"))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("friendlyName"))
                        {
                            friendlyName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("keyVault"))
                        {
                            keyVault = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("applicationInsights"))
                        {
                            applicationInsights = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("containerRegistry"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                containerRegistry = null;
                                continue;
                            }
                            containerRegistry = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("storageAccount"))
                        {
                            storageAccount = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("discoveryUrl"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                discoveryUrl = null;
                                continue;
                            }
                            discoveryUrl = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            provisioningState = new ProvisioningState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("hbiWorkspace"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            hbiWorkspace = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("serviceProvisionedResourceGroup"))
                        {
                            serviceProvisionedResourceGroup = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("privateLinkCount"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            privateLinkCount = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("imageBuildCompute"))
                        {
                            imageBuildCompute = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("allowPublicAccessWhenBehindVnet"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            allowPublicAccessWhenBehindVnet = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("primaryUserAssignedIdentity"))
                        {
                            primaryUserAssignedIdentity = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("tenantId"))
                        {
                            tenantId = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new WorkspaceData(id, name, type, systemData, tags, location, workspaceId.Value, description.Value, friendlyName.Value, keyVault.Value, applicationInsights.Value, containerRegistry.Value, storageAccount.Value, discoveryUrl.Value, Optional.ToNullable(provisioningState), Optional.ToNullable(hbiWorkspace), serviceProvisionedResourceGroup.Value, Optional.ToNullable(privateLinkCount), imageBuildCompute.Value, Optional.ToNullable(allowPublicAccessWhenBehindVnet), primaryUserAssignedIdentity.Value, tenantId.Value);
        }
    }
}
