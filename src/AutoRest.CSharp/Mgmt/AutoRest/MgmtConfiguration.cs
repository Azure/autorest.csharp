// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using AutoRest.CSharp.AutoRest.Communication;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    public class MgmtConfiguration
    {
        public MgmtConfiguration(
            JsonElement? operationGroupToResourceType = default,
            JsonElement? operationGroupToResource = default,
            JsonElement? operationGroupToParent = default,
            JsonElement? singletonResource = default)
        {
            OperationGroupToResourceType = operationGroupToResourceType?.ValueKind == JsonValueKind.Undefined ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResourceType.ToString());
            OperationGroupToResource = operationGroupToResource?.ValueKind == JsonValueKind.Undefined ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResource.ToString());
            OperationGroupToParent = operationGroupToParent?.ValueKind == JsonValueKind.Undefined ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToParent.ToString());
            SingletonResource = singletonResource?.ValueKind == JsonValueKind.Undefined ? new List<string>() : JsonSerializer.Deserialize<List<string>>(singletonResource.ToString());
        }

        public IReadOnlyDictionary<string, string> OperationGroupToResourceType { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToResource { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToParent { get; }
        public IReadOnlyList<string> SingletonResource { get; }

        internal static MgmtConfiguration GetConfiguration(IPluginCommunication autoRest)
        {
            return new MgmtConfiguration(
                autoRest.GetValue<JsonElement?>("operation-group-to-resource-type").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-resource").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-parent").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("singleton-resource").GetAwaiter().GetResult());
        }

        internal void SaveConfiguration(Utf8JsonWriter writer)
        {
            writer.WriteStartObject(nameof(OperationGroupToResourceType));
            foreach (var keyval in OperationGroupToResourceType)
            {
                writer.WriteString(keyval.Key, keyval.Value);
            }
            writer.WriteEndObject();

            writer.WriteStartObject(nameof(OperationGroupToResource));
            foreach (var keyval in OperationGroupToResource)
            {
                writer.WriteString(keyval.Key, keyval.Value);
            }
            writer.WriteEndObject();

            writer.WriteStartObject(nameof(OperationGroupToParent));
            foreach (var keyval in OperationGroupToParent)
            {
                writer.WriteString(keyval.Key, keyval.Value);
            }
            writer.WriteEndObject();

            if (SingletonResource.Count > 0)
            {
                writer.WriteStartArray(nameof(SingletonResource));
                foreach (var r in SingletonResource)
                {
                    writer.WriteStringValue(r);
                }

                writer.WriteEndArray();
            }
        }

        internal static MgmtConfiguration LoadConfiguration(JsonElement root)
        {
            root.TryGetProperty(nameof(SingletonResource), out var singletonList);
            root.TryGetProperty(nameof(OperationGroupToResourceType), out var operationGroupToResourceType);
            root.TryGetProperty(nameof(OperationGroupToResource), out var operationGroupToResource);
            root.TryGetProperty(nameof(OperationGroupToParent), out var operationGroupToParent);

            return new MgmtConfiguration(
                operationGroupToResourceType,
                operationGroupToResource,
                operationGroupToParent,
                singletonList);
        }
    }
}
