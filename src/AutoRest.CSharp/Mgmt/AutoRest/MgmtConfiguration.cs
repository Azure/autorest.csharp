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
            string[] operationGroupIsExtension,
            string[] operationGroupsToOmit,
            string[] requestPathIsNonResource,
            JsonElement? operationGroupToResourceType = default,
            JsonElement? operationGroupToResource = default,
            JsonElement? operationGroupToParent = default,
            JsonElement? operationGroupToSingletonResource = default,
            JsonElement? requestPathToParent = default,
            JsonElement? requestPathToResource = default,
            JsonElement? requestPathToResourceType = default,
            JsonElement? requestPathToSingletonResource = default,
            JsonElement? mergeOperations = default,
            JsonElement? armCore = default,
            JsonElement? resourceModelRequiresType = default,
            JsonElement? resourceModelRequiresName = default)
        {
            OperationGroupToResourceType = !IsValidJsonElement(operationGroupToResourceType) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResourceType.ToString());
            OperationGroupToResource = !IsValidJsonElement(operationGroupToResource) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToResource.ToString());
            OperationGroupToParent = !IsValidJsonElement(operationGroupToParent) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToParent.ToString());
            OperationGroupToSingletonResource = !IsValidJsonElement(operationGroupToSingletonResource) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationGroupToSingletonResource.ToString());
            RequestPathToParent = !IsValidJsonElement(requestPathToParent) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToParent.ToString());
            RequestPathToResourceData = !IsValidJsonElement(requestPathToResource) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToResource.ToString());
            RequestPathToResourceType = !IsValidJsonElement(requestPathToResourceType) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToResourceType.ToString());
            RequestPathToSingletonResource = !IsValidJsonElement(requestPathToSingletonResource) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToSingletonResource.ToString());
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
            RequestPathIsNonResource = requestPathIsNonResource;
            IsArmCore = !IsValidJsonElement(armCore) ? false : Convert.ToBoolean(armCore.ToString());
            DoesResourceModelRequireType = !IsValidJsonElement(resourceModelRequiresType) ? true : Convert.ToBoolean(resourceModelRequiresType.ToString());
            DoesResourceModelRequireName = !IsValidJsonElement(resourceModelRequiresName) ? true : Convert.ToBoolean(resourceModelRequiresName.ToString());
        }

        /// <summary>
        /// Will the resource model detection require type property? Defaults to true
        /// </summary>
        public bool DoesResourceModelRequireType { get; }
        /// <summary>
        /// Will the resource model detection require name property? Defaults to true
        /// </summary>
        public bool DoesResourceModelRequireName { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToResourceType { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToResource { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToParent { get; }
        public IReadOnlyDictionary<string, string> OperationGroupToSingletonResource { get; }
        public IReadOnlyDictionary<string, string> RequestPathToParent { get; }
        public IReadOnlyDictionary<string, string> RequestPathToResourceData { get; }
        public IReadOnlyDictionary<string, string> RequestPathToResourceType { get; }
        public IReadOnlyDictionary<string, string> RequestPathToSingletonResource { get; }
        public IReadOnlyDictionary<string, string[]> MergeOperations { get; }
        public string[] OperationGroupIsTuple { get; }
        public string[] OperationGroupIsExtension { get; }
        public string[] OperationGroupsToOmit { get; }
        public string[] RequestPathIsNonResource { get; }

        public bool IsArmCore { get; }

        internal static MgmtConfiguration GetConfiguration(IPluginCommunication autoRest)
        {
            return new MgmtConfiguration(
                autoRest.GetValue<string[]?>("operation-group-is-tuple").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<string[]?>("operation-group-is-extension").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<string[]?>("operation-groups-to-omit").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<string[]?>("request-path-is-non-resource").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                autoRest.GetValue<JsonElement?>("operation-group-to-resource-type").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-resource").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-parent").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("operation-group-to-singleton-resource").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("request-path-to-parent").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("request-path-to-resource-data").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("request-path-to-resource-type").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("request-path-to-singleton-resource").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("merge-operations").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("arm-core").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("resource-model-requires-type").GetAwaiter().GetResult(),
                autoRest.GetValue<JsonElement?>("resource-model-requires-name").GetAwaiter().GetResult());
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
            WriteNonEmptySettings(writer, nameof(RequestPathIsNonResource), RequestPathIsNonResource);
            WriteNonEmptySettings(writer, nameof(OperationGroupsToOmit), OperationGroupsToOmit);
            WriteNonEmptySettings(writer, nameof(RequestPathToParent), RequestPathToParent);
            WriteNonEmptySettings(writer, nameof(RequestPathToResourceData), RequestPathToResourceData);
            WriteNonEmptySettings(writer, nameof(RequestPathToResourceType), RequestPathToResourceType);
            WriteNonEmptySettings(writer, nameof(RequestPathToSingletonResource), RequestPathToSingletonResource);
            if (IsArmCore)
                writer.WriteBoolean("ArmCore", IsArmCore);
            if (!DoesResourceModelRequireType)
                writer.WriteBoolean(nameof(DoesResourceModelRequireType), DoesResourceModelRequireType);
            if (!DoesResourceModelRequireName)
                writer.WriteBoolean(nameof(DoesResourceModelRequireName), DoesResourceModelRequireName);
        }

        internal static MgmtConfiguration LoadConfiguration(JsonElement root)
        {
            root.TryGetProperty(nameof(OperationGroupIsTuple), out var operationGroupIsTuple);
            root.TryGetProperty(nameof(OperationGroupIsExtension), out var operationGroupIsExtension);
            root.TryGetProperty(nameof(OperationGroupsToOmit), out var operationGroupsToOmit);
            root.TryGetProperty(nameof(RequestPathIsNonResource), out var requestPathIsNonResource);
            root.TryGetProperty(nameof(OperationGroupToResourceType), out var operationGroupToResourceType);
            root.TryGetProperty(nameof(OperationGroupToResource), out var operationGroupToResource);
            root.TryGetProperty(nameof(OperationGroupToParent), out var operationGroupToParent);
            root.TryGetProperty(nameof(OperationGroupToSingletonResource), out var singletonResource);
            root.TryGetProperty(nameof(RequestPathToParent), out var requestPathToParent);
            root.TryGetProperty(nameof(RequestPathToResourceData), out var requestPathToResource);
            root.TryGetProperty(nameof(RequestPathToResourceType), out var requestPathToResourceType);
            root.TryGetProperty(nameof(RequestPathToSingletonResource), out var requestPathToSingletonResource);
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

            var requestPathIsNonResourceList = requestPathIsNonResource.ValueKind == JsonValueKind.Array
                ? requestPathIsNonResource.EnumerateArray().Select(t => t.ToString()).ToArray()
                : new string[0];

            root.TryGetProperty("ArmCore", out var isArmCore);
            root.TryGetProperty(nameof(DoesResourceModelRequireType), out var resourceModelRequiresType);
            root.TryGetProperty(nameof(DoesResourceModelRequireName), out var resourceModelRequiresName);

            return new MgmtConfiguration(
                operationGroupIsTupleList,
                operationGroupIsExtensionList,
                operationGroupList,
                requestPathIsNonResourceList,
                operationGroupToResourceType,
                operationGroupToResource,
                operationGroupToParent,
                singletonResource,
                requestPathToParent,
                requestPathToResource,
                requestPathToResourceType,
                requestPathToSingletonResource,
                mergeOperations,
                isArmCore,
                resourceModelRequiresType,
                resourceModelRequiresName);
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
