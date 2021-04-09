// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using AutoRest.CSharp.AutoRest.Communication;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    public class MgmtConfiguration
    {
        public MgmtConfiguration(
            JsonElement? operationGroupToResourceType = default,
            JsonElement? operationGroupToResource = default,
            JsonElement? modelRename = default,
            JsonElement? operationGroupToParent = default,
            JsonElement? modelToResource = default)
        {
            OperationGroupToResourceType = operationGroupToResourceType?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResourceType.ToString());
            OperationGroupToResource = operationGroupToResource?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResource.ToString());
            ModelRename = modelRename?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(modelRename.ToString());
            OperationGroupToParent = operationGroupToParent?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToParent.ToString());
            ModelToResource = modelToResource?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(modelToResource.ToString());
        }

        public IReadOnlyDictionary<string, string> OperationGroupToResourceType { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToResource { get; }
        public IReadOnlyDictionary<string, string> ModelRename { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToParent { get; }
        public IReadOnlyDictionary<string, string> ModelToResource { get; }

        internal static MgmtConfiguration GetConfiguration(IPluginCommunication autoRest)
        {
            return new MgmtConfiguration(
                autoRest.GetValue<JsonElement?>("operation-group-to-resource-type").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-resource").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("model-rename").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-parent").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("model-to-resource").GetAwaiter().GetResult()
            );
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

            writer.WriteStartObject(nameof(ModelRename));
            foreach (var keyval in ModelRename)
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

            writer.WriteStartObject(nameof(ModelToResource));
            foreach (var keyval in ModelToResource)
            {
                writer.WriteString(keyval.Key, keyval.Value);
            }
            writer.WriteEndObject();
        }

        internal static MgmtConfiguration LoadConfiguration(JsonElement root)
        {
            return new MgmtConfiguration(
                root.GetProperty(nameof(OperationGroupToResourceType)),
                root.GetProperty(nameof(OperationGroupToResource)),
                root.GetProperty(nameof(ModelRename)),
                root.GetProperty(nameof(OperationGroupToParent)),
                root.GetProperty(nameof(ModelToResource))
            );
        }
    }
}
