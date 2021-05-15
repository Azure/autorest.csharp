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
            string[] operationGroupIsTuple,
            JsonElement? operationGroupToResourceType = default,
            JsonElement? operationGroupToResource = default,
            JsonElement? operationGroupToParent = default)
        {
            OperationGroupToResourceType = operationGroupToResourceType?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResourceType.ToString());
            OperationGroupToResource = operationGroupToResource?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResource.ToString());
            OperationGroupToParent = operationGroupToParent?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToParent.ToString());
            OperationGroupIsTuple = operationGroupIsTuple;
        }

        public IReadOnlyDictionary<string, string> OperationGroupToResourceType { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToResource { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToParent { get; }
        public string[] OperationGroupIsTuple { get; }

        internal static MgmtConfiguration GetConfiguration(IPluginCommunication autoRest)
        {
            return new MgmtConfiguration(
                autoRest.GetValue<string[]?>("operation-group-is-tuple").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<JsonElement?>("operation-group-to-resource-type").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-resource").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-parent").GetAwaiter().GetResult()
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

            writer.WriteStartObject(nameof(OperationGroupToParent));
            foreach (var keyval in OperationGroupToParent)
            {
                writer.WriteString(keyval.Key, keyval.Value);
            }
            writer.WriteEndObject();

            writer.WriteStartArray(nameof(OperationGroupIsTuple));
            foreach (var tuple in OperationGroupIsTuple)
            {
                writer.WriteStringValue(tuple);
            }
            writer.WriteEndArray();
        }

        internal static MgmtConfiguration LoadConfiguration(JsonElement root)
        {
            var operationGroupIsTuple = new List<string>();

            foreach (var tuple in root.GetProperty(nameof(OperationGroupIsTuple)).EnumerateArray())
            {
                operationGroupIsTuple.Add(tuple.ToString());
            }
            return new MgmtConfiguration(
                operationGroupIsTuple.ToArray(),
                root.GetProperty(nameof(OperationGroupToResourceType)),
                root.GetProperty(nameof(OperationGroupToResource)),
                root.GetProperty(nameof(OperationGroupToParent))
            );
        }
    }
}
