// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    public partial class FirewallPolicyLogAnalyticsResources : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Workspaces))
            {
                writer.WritePropertyName("workspaces"u8);
                writer.WriteStartArray();
                foreach (var item in Workspaces)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(DefaultWorkspaceId))
            {
                writer.WritePropertyName("defaultWorkspaceId"u8);
                JsonSerializer.Serialize(writer, DefaultWorkspaceId);
            }
            writer.WriteEndObject();
        }

        internal static FirewallPolicyLogAnalyticsResources DeserializeFirewallPolicyLogAnalyticsResources(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<FirewallPolicyLogAnalyticsWorkspace>> workspaces = default;
            Optional<WritableSubResource> defaultWorkspaceId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("workspaces"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<FirewallPolicyLogAnalyticsWorkspace> array = new List<FirewallPolicyLogAnalyticsWorkspace>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FirewallPolicyLogAnalyticsWorkspace.DeserializeFirewallPolicyLogAnalyticsWorkspace(item));
                    }
                    workspaces = array;
                    continue;
                }
                if (property.NameEquals("defaultWorkspaceId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    defaultWorkspaceId = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
            }
            return new FirewallPolicyLogAnalyticsResources(Optional.ToList(workspaces), defaultWorkspaceId);
        }
    }
}
