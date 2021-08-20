﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            string[] operationGroupIsExtension,
            string[] operationGroupsToOmit,
            JsonElement? operationGroupToResourceType = default,
            JsonElement? operationGroupToResource = default,
            JsonElement? operationGroupToParent = default,
            JsonElement? operationGroupToSingletonResource = default,
            JsonElement? mergeOperations = default,
            JsonElement? armCore = default)
        {
            OperationGroupToResourceType = !IsValidJsonElement(operationGroupToResourceType) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResourceType.ToString());
            OperationGroupToResource = !IsValidJsonElement(operationGroupToResource) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResource.ToString());
            OperationGroupToParent = !IsValidJsonElement(operationGroupToParent) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToParent.ToString());
            OperationGroupToSingletonResource = !IsValidJsonElement(operationGroupToSingletonResource) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToSingletonResource.ToString());
            // TODO: A unified way to load from both readme and configuration.json
            try
            {
                MergeOperations = !IsValidJsonElement(mergeOperations) ? new Dictionary<string, string[]>() : JsonSerializer.Deserialize<Dictionary<string, string[]>>(mergeOperations.ToString());
            }
            catch (JsonException)
            {
                var mergeOperationsStrDict = !IsValidJsonElement(mergeOperations) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(mergeOperations.ToString());
                MergeOperations = mergeOperationsStrDict.ToDictionary(kv => kv.Key, kv => kv.Value.Split(";"));
            }
            OperationGroupIsTuple = operationGroupIsTuple;
            OperationGroupIsExtension = operationGroupIsExtension;
            OperationGroupsToOmit = operationGroupsToOmit;
            IsArmCore = !IsValidJsonElement(armCore) ? false : Convert.ToBoolean(armCore.ToString());
        }

        public IReadOnlyDictionary<string, string> OperationGroupToResourceType { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToResource { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToParent { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToSingletonResource { get; }
        public IReadOnlyDictionary<string, string[]> MergeOperations { get; }
        public string[] OperationGroupIsTuple { get; }
        public string[] OperationGroupIsExtension { get; }
        public string[] OperationGroupsToOmit { get; }
        public bool IsArmCore { get; }

        internal static MgmtConfiguration GetConfiguration(IPluginCommunication autoRest)
        {
            return new MgmtConfiguration(
                autoRest.GetValue<string[]?>("operation-group-is-tuple").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<string[]?>("operation-group-is-extension").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<string[]?>("operation-groups-to-omit").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<JsonElement?>("operation-group-to-resource-type").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-resource").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-parent").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-singleton-resource").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("merge-operations").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("arm-core").GetAwaiter().GetResult());
        }

        internal void SaveConfiguration(Utf8JsonWriter writer)
        {
            WriteNonEmptySettings(writer, nameof(OperationGroupToResourceType), OperationGroupToResourceType);
            WriteNonEmptySettings(writer, nameof(OperationGroupToResource), OperationGroupToResource);
            WriteNonEmptySettings(writer, nameof(OperationGroupToParent), OperationGroupToParent);
            WriteNonEmptySettings(writer, nameof(MergeOperations), MergeOperations);
            WriteNonEmptySettings(writer, nameof(OperationGroupToSingletonResource), OperationGroupToSingletonResource);
            WriteNonEmptySettings(writer, nameof(OperationGroupIsTuple), OperationGroupIsTuple);
            WriteNonEmptySettings(writer, nameof(OperationGroupIsExtension), OperationGroupIsExtension);
            WriteNonEmptySettings(writer, nameof(OperationGroupsToOmit), OperationGroupsToOmit);
            if (IsArmCore)
                writer.WriteBoolean("ArmCore", IsArmCore);
        }

        internal static MgmtConfiguration LoadConfiguration(JsonElement root)
        {
            root.TryGetProperty(nameof(OperationGroupIsTuple), out var operationGroupIsTuple);
            root.TryGetProperty(nameof(OperationGroupIsExtension), out var operationGroupIsExtension);
            root.TryGetProperty(nameof(OperationGroupsToOmit), out var operationGroupsToOmit);
            root.TryGetProperty(nameof(OperationGroupToResourceType), out var operationGroupToResourceType);
            root.TryGetProperty(nameof(OperationGroupToResource), out var operationGroupToResource);
            root.TryGetProperty(nameof(OperationGroupToParent), out var operationGroupToParent);
            root.TryGetProperty(nameof(OperationGroupToSingletonResource), out var singletonResource);
            root.TryGetProperty(nameof(MergeOperations), out var mergeOperations);

            var operationGroupIsTupleList = operationGroupIsTuple.ValueKind == JsonValueKind.Array
                ? operationGroupIsTuple.EnumerateArray().Select(t => t.ToString()).ToArray()
                : new string[0];

            var operationGroupIsExtensionList = operationGroupIsExtension.ValueKind == JsonValueKind.Array
                ? operationGroupIsExtension.EnumerateArray().Select(t => t.ToString()).ToArray()
                : new string[0];

            var operationGroupList = operationGroupsToOmit.ValueKind == JsonValueKind.Array
                ? operationGroupsToOmit.EnumerateArray().Select(t => t.ToString()).ToArray()
                : new string[0];

            root.TryGetProperty("ArmCore", out var isArmCore);

            return new MgmtConfiguration(
                operationGroupIsTupleList,
                operationGroupIsExtensionList,
                operationGroupList,
                operationGroupToResourceType,
                operationGroupToResource,
                operationGroupToParent,
                singletonResource,
                mergeOperations,
                isArmCore);
        }

        private static bool IsValidJsonElement(JsonElement? element)
        {
            return element?.ValueKind != JsonValueKind.Null && element?.ValueKind != JsonValueKind.Undefined;
        }

        private static void WriteNonEmptySettings(
            Utf8JsonWriter writer,
            string settingName,
            IReadOnlyDictionary<string, string> settings)
        {
            if (settings.Count > 0)
            {
                writer.WriteStartObject(settingName);
                foreach (var keyval in settings)
                {
                    writer.WriteString(keyval.Key, keyval.Value);
                }

                writer.WriteEndObject();
            }
        }

        private static void WriteNonEmptySettings(
            Utf8JsonWriter writer,
            string settingName,
            IReadOnlyDictionary<string, string[]> settings)
        {
            if (settings.Count > 0)
            {
                writer.WriteStartObject(settingName);
                foreach (var keyval in settings)
                {
                    writer.WriteStartArray(keyval.Key);
                    foreach (var s in keyval.Value)
                    {
                        writer.WriteStringValue(s);
                    }

                    writer.WriteEndArray();
                }

                writer.WriteEndObject();
            }
        }

        private static void WriteNonEmptySettings(
            Utf8JsonWriter writer,
            string settingName,
            string[] settings)
        {
            if (settings.Length > 0)
            {
                writer.WriteStartArray(settingName);
                foreach (var s in settings)
                {
                    writer.WriteStringValue(s);
                }

                writer.WriteEndArray();
            }
        }
    }
}
