// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.AutoRest.Communication;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    public class MgmtConfiguration
    {
        public MgmtConfiguration(
            string[] operationGroupIsTuple,
            string[] singletonResource,
            JsonElement? operationGroupToResourceType = default,
            JsonElement? operationGroupToResource = default,
            JsonElement? operationGroupToParent = default)
        {
            OperationGroupToResourceType = operationGroupToResourceType?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResourceType.ToString());
            OperationGroupToResource = operationGroupToResource?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResource.ToString());
            OperationGroupToParent = operationGroupToParent?.ValueKind == JsonValueKind.Null ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToParent.ToString());
            SingletonResource = singletonResource;
            OperationGroupIsTuple = operationGroupIsTuple;
        }

        public IReadOnlyDictionary<string, string> OperationGroupToResourceType { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToResource { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToParent { get; }
        public string[] SingletonResource { get; }
        public string[] OperationGroupIsTuple { get; }

        internal static MgmtConfiguration GetConfiguration(IPluginCommunication autoRest)
        {
            return new MgmtConfiguration(
                autoRest.GetValue<string[]?>("operation-group-is-tuple").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<string[]?>("singleton-resource").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<JsonElement?>("operation-group-to-resource-type").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-resource").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-parent").GetAwaiter().GetResult());
        }

        internal void SaveConfiguration(Utf8JsonWriter writer)
        {
            if (OperationGroupToResourceType.Count > 0)
            {
                writer.WriteStartObject(nameof(OperationGroupToResourceType));
                foreach (var keyval in OperationGroupToResourceType)
                {
                    writer.WriteString(keyval.Key, keyval.Value);
                }

                writer.WriteEndObject();
            }

            if (OperationGroupToResource.Count > 0)
            {
                writer.WriteStartObject(nameof(OperationGroupToResource));
                foreach (var keyval in OperationGroupToResource)
                {
                    writer.WriteString(keyval.Key, keyval.Value);
                }

                writer.WriteEndObject();
            }

            if (OperationGroupToParent.Count > 0)
            {
                writer.WriteStartObject(nameof(OperationGroupToParent));
                foreach (var keyval in OperationGroupToParent)
                {
                    writer.WriteString(keyval.Key, keyval.Value);
                }

                writer.WriteEndObject();
            }

            if (SingletonResource.Length > 0)
            {
                writer.WriteStartArray(nameof(SingletonResource));
                foreach (var r in SingletonResource)
                {
                    writer.WriteStringValue(r);
                }

                writer.WriteEndArray();
            }

            if (OperationGroupIsTuple.Length > 0)
            {
                writer.WriteStartArray(nameof(OperationGroupIsTuple));
                foreach (var tuple in OperationGroupIsTuple)
                {
                    writer.WriteStringValue(tuple);
                }

                writer.WriteEndArray();
            }
        }

        internal static MgmtConfiguration LoadConfiguration(JsonElement root)
        {
            root.TryGetProperty(nameof(OperationGroupIsTuple), out var operationGroupIsTuple);
            root.TryGetProperty(nameof(SingletonResource), out var singletonResource);
            root.TryGetProperty(nameof(OperationGroupToResourceType), out var operationGroupToResourceType);
            root.TryGetProperty(nameof(OperationGroupToResource), out var operationGroupToResource);
            root.TryGetProperty(nameof(OperationGroupToParent), out var operationGroupToParent);

            var operationGroupIsTupleList = operationGroupIsTuple.ValueKind == JsonValueKind.Array
                ? operationGroupIsTuple.EnumerateArray().Select(t => t.ToString()).ToArray()
                : new string[0];

            var singletonList = singletonResource.ValueKind == JsonValueKind.Array
                ? singletonResource.EnumerateArray().Select(t => t.ToString()).ToArray()
                : new string[0];

            return new MgmtConfiguration(
                operationGroupIsTupleList,
                singletonList,
                operationGroupToResourceType,
                operationGroupToResource,
                operationGroupToParent);
        }
    }
}
