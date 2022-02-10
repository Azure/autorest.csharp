// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    public class MgmtConfiguration
    {
        public class MgmtDebugConfiguration
        {
            private const string MgmtDebugOptionsFormat = "mgmt-debug.{0}";

            public bool ShowRequestPath { get; }
            public bool SuppressListException { get; }

            public MgmtDebugConfiguration(
                JsonElement? showRequestPath = default,
                JsonElement? suppressListException = default)
            {
                ShowRequestPath = showRequestPath == null || !IsValidJsonElement(showRequestPath) ? false : Convert.ToBoolean(showRequestPath.ToString());
                SuppressListException = suppressListException == null || !IsValidJsonElement(suppressListException) ? false : Convert.ToBoolean(suppressListException.ToString());
            }

            internal static MgmtDebugConfiguration LoadConfiguration(JsonElement root)
            {
                if (root.ValueKind != JsonValueKind.Object)
                    return new MgmtDebugConfiguration();

                root.TryGetProperty(nameof(ShowRequestPath), out var showRequestPath);
                root.TryGetProperty(nameof(SuppressListException), out var suppressListException);

                return new MgmtDebugConfiguration(
                    showRequestPath: showRequestPath,
                    suppressListException: suppressListException);
            }

            internal static MgmtDebugConfiguration GetConfiguration(IPluginCommunication autoRest)
            {
                return new MgmtDebugConfiguration(
                    showRequestPath: autoRest.GetValue<JsonElement?>(string.Format(MgmtDebugOptionsFormat, "show-request-path")).GetAwaiter().GetResult(),
                    suppressListException: autoRest.GetValue<JsonElement?>(string.Format(MgmtDebugOptionsFormat, "suppress-list-exception")).GetAwaiter().GetResult());
            }

            public void Write(Utf8JsonWriter writer, string settingName)
            {
                if (!ShowRequestPath && !SuppressListException)
                    return;

                writer.WriteStartObject(settingName);

                if (ShowRequestPath)
                    writer.WriteBoolean(nameof(ShowRequestPath), ShowRequestPath);
                if (SuppressListException)
                    writer.WriteBoolean(nameof(SuppressListException), SuppressListException);

                writer.WriteEndObject();
            }
        }

        public class TestModelerConfiguration
        {
            private const string TestModelerOptionsFormat = "testmodeler.{0}";

            public string? IgnoreReason { get; }

            public TestModelerConfiguration(JsonElement? ignoreReason = default)
            {
                IgnoreReason = (ignoreReason is null || ignoreReason.Value.ValueKind == JsonValueKind.Null) ? null : ignoreReason.ToString();
            }

            internal static TestModelerConfiguration? LoadConfiguration(JsonElement root)
            {
                if (root.ValueKind != JsonValueKind.Object)
                    return null;

                var hasIgnoreReason = root.TryGetProperty(nameof(IgnoreReason), out var ignoreReason);

                return new TestModelerConfiguration(ignoreReason: hasIgnoreReason ? ignoreReason : null);
            }

            internal static TestModelerConfiguration? GetConfiguration(IPluginCommunication autoRest)
            {
                var testModeler = autoRest.GetValue<JsonElement?>("testmodeler").GetAwaiter().GetResult();
                if (testModeler is null || testModeler.Value.ValueKind == JsonValueKind.Null)
                {
                    return null;
                }
                return new TestModelerConfiguration(
                    ignoreReason: autoRest.GetValue<JsonElement?>(string.Format(TestModelerOptionsFormat, "ignore-reason")).GetAwaiter().GetResult());
            }

            public void Write(Utf8JsonWriter writer, string settingName)
            {
                writer.WriteStartObject(settingName);

                if (IgnoreReason is not null)
                    writer.WriteString(nameof(IgnoreReason), IgnoreReason);

                writer.WriteEndObject();
            }
        }

        public MgmtConfiguration(
            IReadOnlyList<string> operationGroupsToOmit,
            IReadOnlyList<string> requestPathIsNonResource,
            IReadOnlyList<string> noPropertyTypeReplacement,
            IReadOnlyList<string> listException,
            MgmtDebugConfiguration mgmtDebug,
            JsonElement? requestPathToParent = default,
            JsonElement? requestPathToResourceName = default,
            JsonElement? requestPathToResourceData = default,
            JsonElement? requestPathToResourceType = default,
            JsonElement? requestPathToScopeResourceTypes = default,
            JsonElement? requestPathToSingletonResource = default,
            JsonElement? overrideOperationName = default,
            JsonElement? operationPositions = default,
            JsonElement? mergeOperations = default,
            JsonElement? armCore = default,
            JsonElement? resourceModelRequiresType = default,
            JsonElement? resourceModelRequiresName = default,
            JsonElement? singletonRequiresKeyword = default,
            TestModelerConfiguration? testmodeler = default,
            JsonElement? operationIdMappings = default)
        {
            RequestPathToParent = !IsValidJsonElement(requestPathToParent) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToParent.ToString());
            RequestPathToResourceName = !IsValidJsonElement(requestPathToResourceName) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToResourceName.ToString());
            RequestPathToResourceData = !IsValidJsonElement(requestPathToResourceData) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToResourceData.ToString());
            RequestPathToResourceType = !IsValidJsonElement(requestPathToResourceType) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToResourceType.ToString());
            RequestPathToScopeResourceTypes = !IsValidJsonElement(requestPathToScopeResourceTypes) ? new Dictionary<string, string[]>() : JsonSerializer.Deserialize<Dictionary<string, string[]>>(requestPathToScopeResourceTypes.ToString());
            RequestPathToSingletonResource = !IsValidJsonElement(requestPathToSingletonResource) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(requestPathToSingletonResource.ToString());
            OverrideOperationName = !IsValidJsonElement(overrideOperationName) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(overrideOperationName.ToString());
            try
            {
                OperationPositions = !IsValidJsonElement(operationPositions) ? new Dictionary<string, string[]>() : JsonSerializer.Deserialize<Dictionary<string, string[]>>(operationPositions.ToString());
            }
            catch (JsonException)
            {
                var operationPositionsStrDict = !IsValidJsonElement(operationPositions) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(operationPositions.ToString());
                OperationPositions = operationPositionsStrDict.ToDictionary(kv => kv.Key, kv => kv.Value.Split(";"));
            }
            MgmtDebug = mgmtDebug;
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
            ListException = listException;
            IsArmCore = !IsValidJsonElement(armCore) ? false : Convert.ToBoolean(armCore.ToString());
            DoesResourceModelRequireType = !IsValidJsonElement(resourceModelRequiresType) ? true : Convert.ToBoolean(resourceModelRequiresType.ToString());
            DoesResourceModelRequireName = !IsValidJsonElement(resourceModelRequiresName) ? true : Convert.ToBoolean(resourceModelRequiresName.ToString());
            DoesSingletonRequiresKeyword = !IsValidJsonElement(singletonRequiresKeyword) ? false : Convert.ToBoolean(singletonRequiresKeyword.ToString());
            TestModeler = testmodeler;
            OperationIdMappings = !IsValidJsonElement(operationIdMappings)
                ? new Dictionary<string, IReadOnlyDictionary<string, string>>()
                : JsonSerializer.Deserialize<Dictionary<string, IReadOnlyDictionary<string, string>>>(operationIdMappings.ToString());
        }

        public MgmtDebugConfiguration MgmtDebug { get; }
        /// <summary>
        /// Will the resource model detection require type property? Defaults to true
        /// </summary>
        public bool DoesResourceModelRequireType { get; }
        /// <summary>
        /// Will the resource model detection require name property? Defaults to true
        /// </summary>
        public bool DoesResourceModelRequireName { get; }
        /// <summary>
        /// Will we only see the resource name to be in the dictionary to make a resource singleton? Defaults to false
        /// </summary>
        public bool DoesSingletonRequiresKeyword { get; }
        public IReadOnlyDictionary<string, string> RequestPathToParent { get; }
        public IReadOnlyDictionary<string, string> RequestPathToResourceName { get; }
        public IReadOnlyDictionary<string, string> RequestPathToResourceData { get; }
        public IReadOnlyDictionary<string, string> RequestPathToResourceType { get; }
        public IReadOnlyDictionary<string, string> RequestPathToSingletonResource { get; }
        public IReadOnlyDictionary<string, string> OverrideOperationName { get; }
        public IReadOnlyDictionary<string, string[]> RequestPathToScopeResourceTypes { get; }
        public IReadOnlyDictionary<string, string[]> OperationPositions { get; }
        public IReadOnlyDictionary<string, string[]> MergeOperations { get; }
        public IReadOnlyList<string> OperationGroupsToOmit { get; }
        public IReadOnlyList<string> RequestPathIsNonResource { get; }
        public IReadOnlyList<string> NoPropertyTypeReplacement { get; }
        public IReadOnlyList<string> ListException { get; }
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> OperationIdMappings { get; }

        public bool IsArmCore { get; }
        public TestModelerConfiguration? TestModeler { get; }

        internal static MgmtConfiguration GetConfiguration(IPluginCommunication autoRest)
        {
            return new MgmtConfiguration(
                operationGroupsToOmit: autoRest.GetValue<string[]?>("operation-groups-to-omit").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                requestPathIsNonResource: autoRest.GetValue<string[]?>("request-path-is-non-resource").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                noPropertyTypeReplacement: autoRest.GetValue<string[]?>("no-property-type-replacement").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                listException: autoRest.GetValue<string[]?>("list-exception").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                mgmtDebug: MgmtDebugConfiguration.GetConfiguration(autoRest),
                requestPathToParent: autoRest.GetValue<JsonElement?>("request-path-to-parent").GetAwaiter().GetResult(),
                requestPathToResourceName: autoRest.GetValue<JsonElement?>("request-path-to-resource-name").GetAwaiter().GetResult(),
                requestPathToResourceData: autoRest.GetValue<JsonElement?>("request-path-to-resource-data").GetAwaiter().GetResult(),
                requestPathToResourceType: autoRest.GetValue<JsonElement?>("request-path-to-resource-type").GetAwaiter().GetResult(),
                requestPathToScopeResourceTypes: autoRest.GetValue<JsonElement?>("request-path-to-scope-resource-types").GetAwaiter().GetResult(),
                operationPositions: autoRest.GetValue<JsonElement?>("operation-positions").GetAwaiter().GetResult(),
                requestPathToSingletonResource: autoRest.GetValue<JsonElement?>("request-path-to-singleton-resource").GetAwaiter().GetResult(),
                overrideOperationName: autoRest.GetValue<JsonElement?>("override-operation-name").GetAwaiter().GetResult(),
                mergeOperations: autoRest.GetValue<JsonElement?>("merge-operations").GetAwaiter().GetResult(),
                armCore: autoRest.GetValue<JsonElement?>("arm-core").GetAwaiter().GetResult(),
                resourceModelRequiresType: autoRest.GetValue<JsonElement?>("resource-model-requires-type").GetAwaiter().GetResult(),
                resourceModelRequiresName: autoRest.GetValue<JsonElement?>("resource-model-requires-name").GetAwaiter().GetResult(),
                singletonRequiresKeyword: autoRest.GetValue<JsonElement?>("singleton-resource-requires-keyword").GetAwaiter().GetResult(),
                testmodeler: TestModelerConfiguration.GetConfiguration(autoRest),
                operationIdMappings: autoRest.GetValue<JsonElement?>("operation-id-mappings").GetAwaiter().GetResult());
        }

        internal void SaveConfiguration(Utf8JsonWriter writer)
        {
            WriteNonEmptySettings(writer, nameof(MergeOperations), MergeOperations);
            WriteNonEmptySettings(writer, nameof(RequestPathIsNonResource), RequestPathIsNonResource);
            WriteNonEmptySettings(writer, nameof(NoPropertyTypeReplacement), NoPropertyTypeReplacement);
            WriteNonEmptySettings(writer, nameof(ListException), ListException);
            WriteNonEmptySettings(writer, nameof(OperationGroupsToOmit), OperationGroupsToOmit);
            WriteNonEmptySettings(writer, nameof(RequestPathToParent), RequestPathToParent);
            WriteNonEmptySettings(writer, nameof(OperationPositions), OperationPositions);
            WriteNonEmptySettings(writer, nameof(RequestPathToResourceName), RequestPathToResourceName);
            WriteNonEmptySettings(writer, nameof(RequestPathToResourceData), RequestPathToResourceData);
            WriteNonEmptySettings(writer, nameof(RequestPathToResourceType), RequestPathToResourceType);
            WriteNonEmptySettings(writer, nameof(RequestPathToScopeResourceTypes), RequestPathToScopeResourceTypes);
            WriteNonEmptySettings(writer, nameof(RequestPathToSingletonResource), RequestPathToSingletonResource);
            WriteNonEmptySettings(writer, nameof(OverrideOperationName), OverrideOperationName);
            MgmtDebug.Write(writer, nameof(MgmtDebug));
            if (IsArmCore)
                writer.WriteBoolean("ArmCore", IsArmCore);
            if (!DoesResourceModelRequireType)
                writer.WriteBoolean(nameof(DoesResourceModelRequireType), DoesResourceModelRequireType);
            if (!DoesResourceModelRequireName)
                writer.WriteBoolean(nameof(DoesResourceModelRequireName), DoesResourceModelRequireName);
            if (DoesSingletonRequiresKeyword)
                writer.WriteBoolean(nameof(DoesSingletonRequiresKeyword), DoesSingletonRequiresKeyword);
            if (TestModeler is not null)
            {
                TestModeler.Write(writer, nameof(TestModeler));
            }
            WriteNonEmptySettings(writer, nameof(OperationIdMappings), OperationIdMappings);
        }

        internal static MgmtConfiguration LoadConfiguration(JsonElement root)
        {
            root.TryGetProperty(nameof(OperationGroupsToOmit), out var operationGroupsToOmit);
            root.TryGetProperty(nameof(RequestPathIsNonResource), out var requestPathIsNonResource);
            root.TryGetProperty(nameof(NoPropertyTypeReplacement), out var noPropertyTypeReplacment);
            root.TryGetProperty(nameof(ListException), out var listException);
            root.TryGetProperty(nameof(RequestPathToParent), out var requestPathToParent);
            root.TryGetProperty(nameof(RequestPathToResourceName), out var requestPathToResourceName);
            root.TryGetProperty(nameof(RequestPathToResourceData), out var requestPathToResourceData);
            root.TryGetProperty(nameof(RequestPathToResourceType), out var requestPathToResourceType);
            root.TryGetProperty(nameof(RequestPathToScopeResourceTypes), out var requestPathToScopeResourceTypes);
            root.TryGetProperty(nameof(OperationPositions), out var operationPositions);
            root.TryGetProperty(nameof(RequestPathToSingletonResource), out var requestPathToSingletonResource);
            root.TryGetProperty(nameof(OverrideOperationName), out var operationIdToName);
            root.TryGetProperty(nameof(MergeOperations), out var mergeOperations);

            var operationGroupList = operationGroupsToOmit.ValueKind == JsonValueKind.Array
                ? operationGroupsToOmit.EnumerateArray().Select(t => t.ToString()).ToArray()
                : Array.Empty<string>();

            var requestPathIsNonResourceList = requestPathIsNonResource.ValueKind == JsonValueKind.Array
                ? requestPathIsNonResource.EnumerateArray().Select(t => t.ToString()).ToArray()
                : Array.Empty<string>();

            var noPropertyTypeReplacementList = noPropertyTypeReplacment.ValueKind == JsonValueKind.Array
                ? noPropertyTypeReplacment.EnumerateArray().Select(t => t.ToString()).ToArray()
                : Array.Empty<string>();

            var listExceptionList = listException.ValueKind == JsonValueKind.Array
                ? listException.EnumerateArray().Select(t => t.ToString()).ToArray()
                : Array.Empty<string>();

            root.TryGetProperty("ArmCore", out var isArmCore);
            root.TryGetProperty(nameof(MgmtDebug), out var mgmtDebugRoot);
            root.TryGetProperty(nameof(DoesResourceModelRequireType), out var resourceModelRequiresType);
            root.TryGetProperty(nameof(DoesResourceModelRequireName), out var resourceModelRequiresName);
            root.TryGetProperty(nameof(DoesSingletonRequiresKeyword), out var singletonRequiresKeyword);
            root.TryGetProperty(nameof(TestModeler), out var testModelerRoot);
            root.TryGetProperty(nameof(OperationIdMappings), out var operationIdMappings);

            return new MgmtConfiguration(
                operationGroupsToOmit: operationGroupList,
                requestPathIsNonResource: requestPathIsNonResourceList,
                noPropertyTypeReplacement: noPropertyTypeReplacementList,
                listException: listExceptionList,
                mgmtDebug: MgmtDebugConfiguration.LoadConfiguration(mgmtDebugRoot),
                requestPathToParent: requestPathToParent,
                requestPathToResourceName: requestPathToResourceName,
                requestPathToResourceData: requestPathToResourceData,
                requestPathToResourceType: requestPathToResourceType,
                requestPathToScopeResourceTypes: requestPathToScopeResourceTypes,
                operationPositions: operationPositions,
                requestPathToSingletonResource: requestPathToSingletonResource,
                overrideOperationName: operationIdToName,
                mergeOperations: mergeOperations,
                armCore: isArmCore,
                resourceModelRequiresType: resourceModelRequiresType,
                resourceModelRequiresName: resourceModelRequiresName,
                singletonRequiresKeyword: singletonRequiresKeyword,
                testmodeler: TestModelerConfiguration.LoadConfiguration(testModelerRoot),
                operationIdMappings: operationIdMappings);
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

        private static void WriteNonEmptySettings(
            Utf8JsonWriter writer,
            string settingName,
            IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> settings)
        {
            if (settings.Count() > 0)
            {
                writer.WriteStartObject(settingName);
                foreach (var keyval in settings)
                {
                    WriteNonEmptySettings(writer, keyval.Key, keyval.Value);
                }

                writer.WriteEndObject();
            }
        }
    }
}
