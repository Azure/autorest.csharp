// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    public partial class FirewallPolicyLogAnalyticsResources : IUtf8JsonSerializable, IModelJsonSerializable<FirewallPolicyLogAnalyticsResources>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<FirewallPolicyLogAnalyticsResources>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<FirewallPolicyLogAnalyticsResources>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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

        FirewallPolicyLogAnalyticsResources IModelJsonSerializable<FirewallPolicyLogAnalyticsResources>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFirewallPolicyLogAnalyticsResources(document.RootElement, options);
        }

        internal static FirewallPolicyLogAnalyticsResources DeserializeFirewallPolicyLogAnalyticsResources(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<FirewallPolicyLogAnalyticsWorkspace>> workspaces = default;
            Optional<WritableSubResource> defaultWorkspaceId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("workspaces"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
                        continue;
                    }
                    defaultWorkspaceId = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new FirewallPolicyLogAnalyticsResources(Optional.ToList(workspaces), defaultWorkspaceId, serializedAdditionalRawData);
        }

        BinaryData IModelSerializable<FirewallPolicyLogAnalyticsResources>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        FirewallPolicyLogAnalyticsResources IModelSerializable<FirewallPolicyLogAnalyticsResources>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFirewallPolicyLogAnalyticsResources(document.RootElement, options);
        }
    }
}
