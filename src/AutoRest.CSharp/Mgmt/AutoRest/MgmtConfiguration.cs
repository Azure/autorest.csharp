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
            IReadOnlyList<string> operationGroupsToOmit,
            IReadOnlyList<string> requestPathIsNonResource,
            IReadOnlyList<string> noPropertyTypeReplacement,
            JsonElement? requestPathToParent = default,
            JsonElement? requestPathToResourceName = default,
            JsonElement? requestPathToResourceData = default,
            JsonElement? requestPathToResourceType = default,
            JsonElement? requestPathToScopeResourceTypes = default,
            JsonElement? requestPathToSingletonResource = default,
            JsonElement? mergeOperations = default,
            JsonElement? armCore = default,
            JsonElement? showRequestPathAndOperationId = default,
            JsonElement? resourceModelRequiresType = default,
            JsonElement? resourceModelRequiresName = default)
        {
            RequestPathToParent = !IsValidJsonElement(requestPathToParent) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToParent.ToString());
            RequestPathToResourceName = !IsValidJsonElement(requestPathToResourceName) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToResourceName.ToString());
            RequestPathToResourceData = !IsValidJsonElement(requestPathToResourceData) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToResourceData.ToString());
            RequestPathToResourceType = !IsValidJsonElement(requestPathToResourceType) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToResourceType.ToString());
            RequestPathToScopeResourceTypes = !IsValidJsonElement(requestPathToScopeResourceTypes) ? new Dictionary<string, string[]>() : JsonSerializer.Deserialize<Dictionary<string, string[]>>(requestPathToScopeResourceTypes.ToString());
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
            OperationGroupsToOmit = operationGroupsToOmit;
            RequestPathIsNonResource = requestPathIsNonResource;
            NoPropertyTypeReplacement = noPropertyTypeReplacement;
            IsArmCore = !IsValidJsonElement(armCore) ? false : Convert.ToBoolean(armCore.ToString());
            ShowRequestPathAndOperationId = !IsValidJsonElement(showRequestPathAndOperationId) ? false : Convert.ToBoolean(showRequestPathAndOperationId.ToString());
            DoesResourceModelRequireType = !IsValidJsonElement(resourceModelRequiresType) ? true : Convert.ToBoolean(resourceModelRequiresType.ToString());
            DoesResourceModelRequireName = !IsValidJsonElement(resourceModelRequiresName) ? true : Convert.ToBoolean(resourceModelRequiresName.ToString());
        }

        public bool ShowRequestPathAndOperationId { get; }
        /// <summary>
        /// Will the resource model detection require type property? Defaults to true
        /// </summary>
        public bool DoesResourceModelRequireType { get; }
        /// <summary>
        /// Will the resource model detection require name property? Defaults to true
        /// </summary>
        public bool DoesResourceModelRequireName { get; }
        public IReadOnlyDictionary<string, string> RequestPathToParent { get; }
        public IReadOnlyDictionary<string, string> RequestPathToResourceName { get; }
        public IReadOnlyDictionary<string, string> RequestPathToResourceData { get; }
        public IReadOnlyDictionary<string, string> RequestPathToResourceType { get; }
        public IReadOnlyDictionary<string, string> RequestPathToSingletonResource { get; }
        public IReadOnlyDictionary<string, string[]> RequestPathToScopeResourceTypes { get; }
        public IReadOnlyDictionary<string, string[]> MergeOperations { get; }
        public IReadOnlyList<string> OperationGroupsToOmit { get; }
        public IReadOnlyList<string> RequestPathIsNonResource { get; }
        public IReadOnlyList<string> NoPropertyTypeReplacement { get; }

        public bool IsArmCore { get; }

        internal static MgmtConfiguration GetConfiguration(IPluginCommunication autoRest)
        {
            return new MgmtConfiguration(
                operationGroupsToOmit: autoRest.GetValue<string[]?>("operation-groups-to-omit").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                requestPathIsNonResource: autoRest.GetValue<string[]?>("request-path-is-non-resource").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                noPropertyTypeReplacement: autoRest.GetValue<string[]?>("no-property-type-replacement").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                requestPathToParent: autoRest.GetValue<JsonElement?>("request-path-to-parent").GetAwaiter().GetResult(),
                requestPathToResourceName: autoRest.GetValue<JsonElement?>("request-path-to-resource-name").GetAwaiter().GetResult(),
                requestPathToResourceData: autoRest.GetValue<JsonElement?>("request-path-to-resource-data").GetAwaiter().GetResult(),
                requestPathToResourceType: autoRest.GetValue<JsonElement?>("request-path-to-resource-type").GetAwaiter().GetResult(),
                requestPathToScopeResourceTypes: autoRest.GetValue<JsonElement?>("request-path-to-scope-resource-types").GetAwaiter().GetResult(),
                requestPathToSingletonResource: autoRest.GetValue<JsonElement?>("request-path-to-singleton-resource").GetAwaiter().GetResult(),
                mergeOperations: autoRest.GetValue<JsonElement?>("merge-operations").GetAwaiter().GetResult(),
                armCore: autoRest.GetValue<JsonElement?>("arm-core").GetAwaiter().GetResult(),
                showRequestPathAndOperationId: autoRest.GetValue<JsonElement?>("show-request-path").GetAwaiter().GetResult(),
                resourceModelRequiresType: autoRest.GetValue<JsonElement?>("resource-model-requires-type").GetAwaiter().GetResult(),
                resourceModelRequiresName: autoRest.GetValue<JsonElement?>("resource-model-requires-name").GetAwaiter().GetResult());
        }

        internal void SaveConfiguration(Utf8JsonWriter writer)
        {
            WriteNonEmptySettings(writer, nameof(MergeOperations), MergeOperations);
            WriteNonEmptySettings(writer, nameof(RequestPathIsNonResource), RequestPathIsNonResource);
            WriteNonEmptySettings(writer, nameof(NoPropertyTypeReplacement), NoPropertyTypeReplacement);
            WriteNonEmptySettings(writer, nameof(OperationGroupsToOmit), OperationGroupsToOmit);
            WriteNonEmptySettings(writer, nameof(RequestPathToParent), RequestPathToParent);
            WriteNonEmptySettings(writer, nameof(RequestPathToResourceName), RequestPathToResourceName);
            WriteNonEmptySettings(writer, nameof(RequestPathToResourceData), RequestPathToResourceData);
            WriteNonEmptySettings(writer, nameof(RequestPathToResourceType), RequestPathToResourceType);
            WriteNonEmptySettings(writer, nameof(RequestPathToScopeResourceTypes), RequestPathToScopeResourceTypes);
            WriteNonEmptySettings(writer, nameof(RequestPathToSingletonResource), RequestPathToSingletonResource);
            if (IsArmCore)
                writer.WriteBoolean("ArmCore", IsArmCore);
            if (ShowRequestPathAndOperationId)
                writer.WriteBoolean(nameof(ShowRequestPathAndOperationId), ShowRequestPathAndOperationId);
            if (!DoesResourceModelRequireType)
                writer.WriteBoolean(nameof(DoesResourceModelRequireType), DoesResourceModelRequireType);
            if (!DoesResourceModelRequireName)
                writer.WriteBoolean(nameof(DoesResourceModelRequireName), DoesResourceModelRequireName);
        }

        internal static MgmtConfiguration LoadConfiguration(JsonElement root)
        {
            root.TryGetProperty(nameof(OperationGroupsToOmit), out var operationGroupsToOmit);
            root.TryGetProperty(nameof(RequestPathIsNonResource), out var requestPathIsNonResource);
            root.TryGetProperty(nameof(NoPropertyTypeReplacement), out var noPropertyTypeReplacment);
            root.TryGetProperty(nameof(RequestPathToParent), out var requestPathToParent);
            root.TryGetProperty(nameof(RequestPathToResourceName), out var requestPathToResourceName);
            root.TryGetProperty(nameof(RequestPathToResourceData), out var requestPathToResourceData);
            root.TryGetProperty(nameof(RequestPathToResourceType), out var requestPathToResourceType);
            root.TryGetProperty(nameof(RequestPathToScopeResourceTypes), out var requestPathToScopeResourceTypes);
            root.TryGetProperty(nameof(RequestPathToSingletonResource), out var requestPathToSingletonResource);
            root.TryGetProperty(nameof(MergeOperations), out var mergeOperations);

            var operationGroupList = operationGroupsToOmit.ValueKind == JsonValueKind.Array
                ? operationGroupsToOmit.EnumerateArray().Select(t => t.ToString()).ToArray()
                : new string[0];

            var requestPathIsNonResourceList = requestPathIsNonResource.ValueKind == JsonValueKind.Array
                ? requestPathIsNonResource.EnumerateArray().Select(t => t.ToString()).ToArray()
                : new string[0];

            var noPropertyTypeReplacementList = noPropertyTypeReplacment.ValueKind == JsonValueKind.Array
                ? noPropertyTypeReplacment.EnumerateArray().Select(t => t.ToString()).ToList()
                : new List<string>();

            root.TryGetProperty("ArmCore", out var isArmCore);
            root.TryGetProperty(nameof(ShowRequestPathAndOperationId), out var showRequestPathAndOperationId);
            root.TryGetProperty(nameof(DoesResourceModelRequireType), out var resourceModelRequiresType);
            root.TryGetProperty(nameof(DoesResourceModelRequireName), out var resourceModelRequiresName);

            return new MgmtConfiguration(
                operationGroupsToOmit: operationGroupList,
                requestPathIsNonResource: requestPathIsNonResourceList,
                noPropertyTypeReplacement: noPropertyTypeReplacementList,
                requestPathToParent: requestPathToParent,
                requestPathToResourceName: requestPathToResourceName,
                requestPathToResourceData: requestPathToResourceData,
                requestPathToResourceType: requestPathToResourceType,
                requestPathToScopeResourceTypes: requestPathToScopeResourceTypes,
                requestPathToSingletonResource: requestPathToSingletonResource,
                mergeOperations: mergeOperations,
                armCore: isArmCore,
                showRequestPathAndOperationId: showRequestPathAndOperationId,
                resourceModelRequiresType: resourceModelRequiresType,
                resourceModelRequiresName: resourceModelRequiresName);
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
            IReadOnlyList<string> settings)
        {
            if (settings.Count() > 0)
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
