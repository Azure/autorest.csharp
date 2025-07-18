// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    public partial class FirewallPolicyLogAnalyticsWorkspace : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Region))
            {
                writer.WritePropertyName("region"u8);
                writer.WriteStringValue(Region);
            }
            if (Optional.IsDefined(WorkspaceId))
            {
                writer.WritePropertyName("workspaceId"u8);
                ((IJsonModel<WritableSubResource>)WorkspaceId).Write(writer, ModelSerializationExtensions.WireOptions);
            }
            writer.WriteEndObject();
        }

        internal static FirewallPolicyLogAnalyticsWorkspace DeserializeFirewallPolicyLogAnalyticsWorkspace(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string region = default;
            WritableSubResource workspaceId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("region"u8))
                {
                    region = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("workspaceId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    workspaceId = ModelReaderWriter.Read<WritableSubResource>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, MgmtMockAndSampleContext.Default);
                    continue;
                }
            }
            return new FirewallPolicyLogAnalyticsWorkspace(region, workspaceId);
        }
    }
}
