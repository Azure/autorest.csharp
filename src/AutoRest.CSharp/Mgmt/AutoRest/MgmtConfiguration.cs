// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.AutoRest.Communication;

namespace AutoRest.CSharp.Input
{
    public class MgmtConfiguration
    {
        public class MgmtDebugConfiguration
        {
            private const string MgmtDebugOptionsFormat = "mgmt-debug.{0}";

            public bool SuppressListException { get; }

            public bool ShowSerializedNames { get; }

            public MgmtDebugConfiguration(
                JsonElement? suppressListException = default,
                JsonElement? showSerializedNames = default
            )
            {
                SuppressListException = DeserializeBoolean(suppressListException, false);
                ShowSerializedNames = DeserializeBoolean(showSerializedNames, false);
            }

            internal static MgmtDebugConfiguration LoadConfiguration(JsonElement root)
            {
                if (root.ValueKind != JsonValueKind.Object)
                    return new MgmtDebugConfiguration();

                root.TryGetProperty(nameof(SuppressListException), out var suppressListException);
                root.TryGetProperty(nameof(ShowSerializedNames), out var showSerializedNames);

                return new MgmtDebugConfiguration(
                    suppressListException: suppressListException,
                    showSerializedNames: showSerializedNames
                );
            }

            internal static MgmtDebugConfiguration GetConfiguration(IPluginCommunication autoRest)
            {
                return new MgmtDebugConfiguration(
                    suppressListException: autoRest.GetValue<JsonElement?>(string.Format(MgmtDebugOptionsFormat, "suppress-list-exception")).GetAwaiter().GetResult(),
                    showSerializedNames: autoRest.GetValue<JsonElement?>(string.Format(MgmtDebugOptionsFormat, "show-serialized-names")).GetAwaiter().GetResult()
                );
            }

            public void Write(Utf8JsonWriter writer, string settingName)
            {
                if (!SuppressListException && !ShowSerializedNames)
                    return;

                writer.WriteStartObject(settingName);

                if (SuppressListException)
                    writer.WriteBoolean(nameof(SuppressListException), SuppressListException);

                if (ShowSerializedNames)
                    writer.WriteBoolean(nameof(ShowSerializedNames), ShowSerializedNames);

                writer.WriteEndObject();
            }
        }

        public class TestGenConfiguration
        {
            private const string TestGenOptionsFormat = "testgen.{0}";

            public string? IgnoreReason { get; }
            public string? SourceCodePath { get; }
            public bool Mock { get; }
            public bool Sample { get; }

            public TestGenConfiguration(
                JsonElement? ignoreReason = default,
                JsonElement? sourceCodePath = default,
                JsonElement? mock = default,
                JsonElement? sample = default)
            {
                IgnoreReason = !IsValidJsonElement(ignoreReason) ? null : ignoreReason.ToString();
                SourceCodePath = !IsValidJsonElement(sourceCodePath) ? null : sourceCodePath.ToString();
                Mock = DeserializeBoolean(mock, false);
                Sample = DeserializeBoolean(sample, false);
            }

            internal static TestGenConfiguration? LoadConfiguration(JsonElement root)
            {
                if (root.ValueKind != JsonValueKind.Object)
                    return null;

                root.TryGetProperty(nameof(IgnoreReason), out var ignoreReason);
                root.TryGetProperty(nameof(SourceCodePath), out var sourceCodePath);
                root.TryGetProperty(nameof(Mock), out var mock);
                root.TryGetProperty(nameof(Sample), out var sample);

                return new TestGenConfiguration(
                    ignoreReason: ignoreReason,
                    sourceCodePath: sourceCodePath,
                    mock: mock,
                    sample: sample);
            }

            internal static TestGenConfiguration? GetConfiguration(IPluginCommunication autoRest)
            {
                var testGen = autoRest.GetValue<JsonElement?>("testgen").GetAwaiter().GetResult();
                if (!IsValidJsonElement(testGen))
                {
                    return null;
                }
                return new TestGenConfiguration(
                    ignoreReason: autoRest.GetValue<JsonElement?>(string.Format(TestGenOptionsFormat, "ignore-reason")).GetAwaiter().GetResult(),
                    sourceCodePath: autoRest.GetValue<JsonElement?>(string.Format(TestGenOptionsFormat, "source-path")).GetAwaiter().GetResult(),
                    mock: autoRest.GetValue<JsonElement?>(string.Format(TestGenOptionsFormat, "mock")).GetAwaiter().GetResult(),
                    sample: autoRest.GetValue<JsonElement?>(string.Format(TestGenOptionsFormat, "sample")).GetAwaiter().GetResult());
            }

            public void Write(Utf8JsonWriter writer, string settingName)
            {
                writer.WriteStartObject(settingName);

                if (IgnoreReason is not null)
                    writer.WriteString(nameof(IgnoreReason), IgnoreReason);

                if (SourceCodePath is not null)
                    writer.WriteString(nameof(SourceCodePath), SourceCodePath);

                if (Mock)
                    writer.WriteBoolean(nameof(Mock), Mock);

                if (Sample)
                    writer.WriteBoolean(nameof(Sample), Sample);

                writer.WriteEndObject();
            }
        }

        public record RenameRuleTarget(string Value, string? ParameterValue)
        {
            internal static RenameRuleTarget Parse(string rawValue)
            {
                var spans = rawValue.AsSpan();
                var index = spans.IndexOf('|');
                if (index < 0)
                    return new RenameRuleTarget(rawValue, null);

                return new RenameRuleTarget(spans.Slice(0, index).ToString(), spans.Slice(index, rawValue.Length - index).ToString());
            }
        }

        private static IReadOnlyDictionary<string, RenameRuleTarget> ParseRenameRules(IReadOnlyDictionary<string, string> renameRules)
            => renameRules.ToDictionary(kv => kv.Key, kv => RenameRuleTarget.Parse(kv.Value));

        public MgmtConfiguration(
            IReadOnlyList<string> operationGroupsToOmit,
            IReadOnlyList<string> requestPathIsNonResource,
            IReadOnlyList<string> noPropertyTypeReplacement,
            IReadOnlyList<string> listException,
            IReadOnlyList<string> promptedEnumValues,
            IReadOnlyList<string> keepOrphanedModels,
            IReadOnlyList<string> keepPluralEnums,
            IReadOnlyList<string> keepPluralResourceData,
            IReadOnlyList<string> noResourceSuffix,
            IReadOnlyList<string> schemasToPrependRPPrefix,
            IReadOnlyList<string> generateArmResourceExtensions,
            IReadOnlyList<string> suppressAbstractBaseClass,
            MgmtDebugConfiguration mgmtDebug,
            JsonElement? requestPathToParent = default,
            JsonElement? requestPathToResourceName = default,
            JsonElement? requestPathToResourceData = default,
            JsonElement? requestPathToResourceType = default,
            JsonElement? requestPathToScopeResourceTypes = default,
            JsonElement? requestPathToSingletonResource = default,
            JsonElement? overrideOperationName = default,
            JsonElement? operationPositions = default,
            JsonElement? renameRules = default,
            JsonElement? formatByNameRules = default,
            JsonElement? renameMapping = default,
            JsonElement? irregularPluralWords = default,
            JsonElement? mergeOperations = default,
            JsonElement? armCore = default,
            JsonElement? resourceModelRequiresType = default,
            JsonElement? resourceModelRequiresName = default,
            JsonElement? singletonRequiresKeyword = default,
            TestGenConfiguration? testGen = default,
            JsonElement? operationIdMappings = default,
            JsonElement? updateRequiredCopy = default,
            JsonElement? patchInitializerCustomization = default)
        {
            RequestPathToParent = DeserializeDictionary<string, string>(requestPathToParent);
            RequestPathToResourceName = DeserializeDictionary<string, string>(requestPathToResourceName);
            RequestPathToResourceData = DeserializeDictionary<string, string>(requestPathToResourceData);
            RequestPathToResourceType = DeserializeDictionary<string, string>(requestPathToResourceType);
            RequestPathToScopeResourceTypes = DeserializeDictionary<string, string[]>(requestPathToScopeResourceTypes);
            RequestPathToSingletonResource = DeserializeDictionary<string, string>(requestPathToSingletonResource);
            OverrideOperationName = DeserializeDictionary<string, string>(overrideOperationName);
            RawRenameRules = DeserializeDictionary<string, string>(renameRules);
            FormatByNameRules = DeserializeDictionary<string, string>(formatByNameRules);
            RenameMapping = DeserializeDictionary<string, string>(renameMapping);
            IrregularPluralWords = DeserializeDictionary<string, string>(irregularPluralWords);
            try
            {
                OperationPositions = DeserializeDictionary<string, string[]>(operationPositions);
            }
            catch (JsonException)
            {
                var operationPositionsStrDict = DeserializeDictionary<string, string>(operationPositions);
                OperationPositions = operationPositionsStrDict.ToDictionary(kv => kv.Key, kv => kv.Value.Split(";"));
            }
            MgmtDebug = mgmtDebug;
            // TODO: A unified way to load from both readme and configuration.json
            try
            {
                MergeOperations = DeserializeDictionary<string, string[]>(mergeOperations);
            }
            catch (JsonException)
            {
                var mergeOperationsStrDict = DeserializeDictionary<string, string>(mergeOperations);
                MergeOperations = mergeOperationsStrDict.ToDictionary(kv => kv.Key, kv => kv.Value.Split(";"));
            }
            OperationGroupsToOmit = operationGroupsToOmit;
            RequestPathIsNonResource = requestPathIsNonResource;
            NoPropertyTypeReplacement = noPropertyTypeReplacement;
            ListException = listException;
            PromptedEnumValues = promptedEnumValues;
            KeepOrphanedModels = keepOrphanedModels;
            KeepPluralEnums = keepPluralEnums;
            KeepPluralResourceData = keepPluralResourceData;
            NoResourceSuffix = noResourceSuffix;
            PrependRPPrefix = schemasToPrependRPPrefix;
            GenerateArmResourceExtensions = generateArmResourceExtensions;
            SuppressAbstractBaseClass = suppressAbstractBaseClass;
            IsArmCore = DeserializeBoolean(armCore, false);
            DoesResourceModelRequireType = DeserializeBoolean(resourceModelRequiresType, true);
            DoesResourceModelRequireName = DeserializeBoolean(resourceModelRequiresName, true);
            DoesSingletonRequiresKeyword = DeserializeBoolean(singletonRequiresKeyword, false);
            TestGen = testGen;
            OperationIdMappings = DeserializeDictionary<string, IReadOnlyDictionary<string, string>>(operationIdMappings);
            UpdateRequiredCopy = DeserializeDictionary<string, string>(updateRequiredCopy);
            PatchInitializerCustomization = DeserializeDictionary<string, IReadOnlyDictionary<string, string>>(patchInitializerCustomization);
        }

        private static bool DeserializeBoolean(JsonElement? jsonElement, bool defaultValue = false)
            => jsonElement == null || !IsValidJsonElement(jsonElement) ? defaultValue : Convert.ToBoolean(jsonElement.ToString());

        private static IReadOnlyList<string> DeserializeArray(JsonElement jsonElement)
            => jsonElement.ValueKind != JsonValueKind.Array ? Array.Empty<string>() : jsonElement.EnumerateArray().Select(t => t.ToString()).ToArray();

        private static Dictionary<TKey, TValue> DeserializeDictionary<TKey, TValue>(JsonElement? jsonElement) where TKey : notnull
            => !IsValidJsonElement(jsonElement) ? new Dictionary<TKey, TValue>() : JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(jsonElement.ToString()!)!;

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
        private IReadOnlyDictionary<string, string> RawRenameRules { get; }
        private IReadOnlyDictionary<string, RenameRuleTarget>? _renameRules;
        public IReadOnlyDictionary<string, RenameRuleTarget> RenameRules => _renameRules ??= ParseRenameRules(RawRenameRules);
        public IReadOnlyDictionary<string, string> FormatByNameRules { get; }
        public IReadOnlyDictionary<string, string> RenameMapping { get; }
        public IReadOnlyDictionary<string, string> IrregularPluralWords { get; }
        public IReadOnlyDictionary<string, string[]> RequestPathToScopeResourceTypes { get; }
        public IReadOnlyDictionary<string, string[]> OperationPositions { get; }
        public IReadOnlyDictionary<string, string[]> MergeOperations { get; }
        public IReadOnlyList<string> OperationGroupsToOmit { get; }
        public IReadOnlyList<string> RequestPathIsNonResource { get; }
        public IReadOnlyList<string> NoPropertyTypeReplacement { get; }
        public IReadOnlyList<string> ListException { get; }
        public IReadOnlyList<string> PromptedEnumValues { get; }
        public IReadOnlyList<string> KeepOrphanedModels { get; }
        public IReadOnlyList<string> KeepPluralEnums { get; }
        public IReadOnlyList<string> KeepPluralResourceData { get; }
        public IReadOnlyList<string> PrependRPPrefix { get; }
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> OperationIdMappings { get; }
        public IReadOnlyDictionary<string, string> UpdateRequiredCopy {get;}
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> PatchInitializerCustomization { get; }

        public IReadOnlyList<string> NoResourceSuffix { get; }
        public IReadOnlyList<string> GenerateArmResourceExtensions { get; }
        public IReadOnlyList<string> SuppressAbstractBaseClass { get; }

        public bool IsArmCore { get; }
        public TestGenConfiguration? TestGen { get; }

        internal static MgmtConfiguration GetConfiguration(IPluginCommunication autoRest)
        {
            return new MgmtConfiguration(
                operationGroupsToOmit: autoRest.GetValue<string[]?>("operation-groups-to-omit").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                requestPathIsNonResource: autoRest.GetValue<string[]?>("request-path-is-non-resource").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                noPropertyTypeReplacement: autoRest.GetValue<string[]?>("no-property-type-replacement").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                listException: autoRest.GetValue<string[]?>("list-exception").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                promptedEnumValues: autoRest.GetValue<string[]?>("prompted-enum-values").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                keepOrphanedModels: autoRest.GetValue<string[]?>("keep-orphaned-models").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                keepPluralEnums: autoRest.GetValue<string[]?>("keep-plural-enums").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                keepPluralResourceData: autoRest.GetValue<string[]?>("keep-plural-resource-data").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                noResourceSuffix: autoRest.GetValue<string[]?>("no-resource-suffix").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                schemasToPrependRPPrefix: autoRest.GetValue<string[]?>("prepend-rp-prefix").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                generateArmResourceExtensions: autoRest.GetValue<string[]?>("generate-arm-resource-extensions").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                suppressAbstractBaseClass: autoRest.GetValue<string[]?>("suppress-abstract-base-class").GetAwaiter().GetResult() ?? Array.Empty<string>(),
                mgmtDebug: MgmtDebugConfiguration.GetConfiguration(autoRest),
                requestPathToParent: autoRest.GetValue<JsonElement?>("request-path-to-parent").GetAwaiter().GetResult(),
                requestPathToResourceName: autoRest.GetValue<JsonElement?>("request-path-to-resource-name").GetAwaiter().GetResult(),
                requestPathToResourceData: autoRest.GetValue<JsonElement?>("request-path-to-resource-data").GetAwaiter().GetResult(),
                requestPathToResourceType: autoRest.GetValue<JsonElement?>("request-path-to-resource-type").GetAwaiter().GetResult(),
                requestPathToScopeResourceTypes: autoRest.GetValue<JsonElement?>("request-path-to-scope-resource-types").GetAwaiter().GetResult(),
                operationPositions: autoRest.GetValue<JsonElement?>("operation-positions").GetAwaiter().GetResult(),
                requestPathToSingletonResource: autoRest.GetValue<JsonElement?>("request-path-to-singleton-resource").GetAwaiter().GetResult(),
                overrideOperationName: autoRest.GetValue<JsonElement?>("override-operation-name").GetAwaiter().GetResult(),
                renameRules: autoRest.GetValue<JsonElement?>("rename-rules").GetAwaiter().GetResult(),
                formatByNameRules: autoRest.GetValue<JsonElement?>("format-by-name-rules").GetAwaiter().GetResult(),
                renameMapping: autoRest.GetValue<JsonElement?>("rename-mapping").GetAwaiter().GetResult(),
                irregularPluralWords: autoRest.GetValue<JsonElement?>("irregular-plural-words").GetAwaiter().GetResult(),
                mergeOperations: autoRest.GetValue<JsonElement?>("merge-operations").GetAwaiter().GetResult(),
                armCore: autoRest.GetValue<JsonElement?>("arm-core").GetAwaiter().GetResult(),
                resourceModelRequiresType: autoRest.GetValue<JsonElement?>("resource-model-requires-type").GetAwaiter().GetResult(),
                resourceModelRequiresName: autoRest.GetValue<JsonElement?>("resource-model-requires-name").GetAwaiter().GetResult(),
                singletonRequiresKeyword: autoRest.GetValue<JsonElement?>("singleton-resource-requires-keyword").GetAwaiter().GetResult(),
                testGen: TestGenConfiguration.GetConfiguration(autoRest),
                operationIdMappings: autoRest.GetValue<JsonElement?>("operation-id-mappings").GetAwaiter().GetResult(),
                updateRequiredCopy: autoRest.GetValue<JsonElement?>("update-required-copy").GetAwaiter().GetResult(),
                patchInitializerCustomization: autoRest.GetValue<JsonElement?>("patch-initializer-customization").GetAwaiter().GetResult());
        }

        internal void SaveConfiguration(Utf8JsonWriter writer)
        {
            WriteNonEmptySettings(writer, nameof(MergeOperations), MergeOperations);
            WriteNonEmptySettings(writer, nameof(RequestPathIsNonResource), RequestPathIsNonResource);
            WriteNonEmptySettings(writer, nameof(NoPropertyTypeReplacement), NoPropertyTypeReplacement);
            WriteNonEmptySettings(writer, nameof(ListException), ListException);
            WriteNonEmptySettings(writer, nameof(KeepOrphanedModels), KeepOrphanedModels);
            WriteNonEmptySettings(writer, nameof(KeepPluralEnums), KeepPluralEnums);
            WriteNonEmptySettings(writer, nameof(NoResourceSuffix), NoResourceSuffix);
            WriteNonEmptySettings(writer, nameof(PrependRPPrefix), PrependRPPrefix);
            WriteNonEmptySettings(writer, nameof(GenerateArmResourceExtensions), GenerateArmResourceExtensions);
            WriteNonEmptySettings(writer, nameof(SuppressAbstractBaseClass), SuppressAbstractBaseClass);
            WriteNonEmptySettings(writer, nameof(OperationGroupsToOmit), OperationGroupsToOmit);
            WriteNonEmptySettings(writer, nameof(RequestPathToParent), RequestPathToParent);
            WriteNonEmptySettings(writer, nameof(OperationPositions), OperationPositions);
            WriteNonEmptySettings(writer, nameof(RequestPathToResourceName), RequestPathToResourceName);
            WriteNonEmptySettings(writer, nameof(RequestPathToResourceData), RequestPathToResourceData);
            WriteNonEmptySettings(writer, nameof(RequestPathToResourceType), RequestPathToResourceType);
            WriteNonEmptySettings(writer, nameof(RequestPathToScopeResourceTypes), RequestPathToScopeResourceTypes);
            WriteNonEmptySettings(writer, nameof(RequestPathToSingletonResource), RequestPathToSingletonResource);
            WriteNonEmptySettings(writer, nameof(RawRenameRules), RawRenameRules);
            WriteNonEmptySettings(writer, nameof(FormatByNameRules), FormatByNameRules);
            WriteNonEmptySettings(writer, nameof(RenameMapping), RenameMapping);
            WriteNonEmptySettings(writer, nameof(IrregularPluralWords), IrregularPluralWords);
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
            if (TestGen is not null)
            {
                TestGen.Write(writer, nameof(TestGen));
            }
            WriteNonEmptySettings(writer, nameof(OperationIdMappings), OperationIdMappings);
            WriteNonEmptySettings(writer, nameof(PromptedEnumValues), PromptedEnumValues);
            WriteNonEmptySettings(writer, nameof(UpdateRequiredCopy), UpdateRequiredCopy);
            WriteNonEmptySettings(writer, nameof(PatchInitializerCustomization), PatchInitializerCustomization);
        }

        internal static MgmtConfiguration LoadConfiguration(JsonElement root)
        {
            root.TryGetProperty(nameof(OperationGroupsToOmit), out var operationGroupsToOmitElement);
            root.TryGetProperty(nameof(RequestPathIsNonResource), out var requestPathIsNonResourceElement);
            root.TryGetProperty(nameof(NoPropertyTypeReplacement), out var noPropertyTypeReplacementElement);
            root.TryGetProperty(nameof(ListException), out var listExceptionElement);
            root.TryGetProperty(nameof(KeepOrphanedModels), out var keepOrphanedModelsElement);
            root.TryGetProperty(nameof(KeepPluralEnums), out var keepPluralEnumsElement);
            root.TryGetProperty(nameof(KeepPluralResourceData), out var keepPluralResourceDataElement);
            root.TryGetProperty(nameof(NoResourceSuffix), out var noResourceSuffixElement);
            root.TryGetProperty(nameof(PrependRPPrefix), out var prependRPPrefixElement);
            root.TryGetProperty(nameof(GenerateArmResourceExtensions), out var generateArmResourceExtensionsElement);
            root.TryGetProperty(nameof(SuppressAbstractBaseClass), out var suppressAbstractBaseClassElement);
            root.TryGetProperty(nameof(RequestPathToParent), out var requestPathToParent);
            root.TryGetProperty(nameof(RequestPathToResourceName), out var requestPathToResourceName);
            root.TryGetProperty(nameof(RequestPathToResourceData), out var requestPathToResourceData);
            root.TryGetProperty(nameof(RequestPathToResourceType), out var requestPathToResourceType);
            root.TryGetProperty(nameof(RequestPathToScopeResourceTypes), out var requestPathToScopeResourceTypes);
            root.TryGetProperty(nameof(OperationPositions), out var operationPositions);
            root.TryGetProperty(nameof(RequestPathToSingletonResource), out var requestPathToSingletonResource);
            root.TryGetProperty(nameof(RawRenameRules), out var renameRules);
            root.TryGetProperty(nameof(FormatByNameRules), out var formatByNameRules);
            root.TryGetProperty(nameof(RenameMapping), out var renameMapping);
            root.TryGetProperty(nameof(IrregularPluralWords), out var irregularPluralWords);
            root.TryGetProperty(nameof(OverrideOperationName), out var operationIdToName);
            root.TryGetProperty(nameof(MergeOperations), out var mergeOperations);
            root.TryGetProperty(nameof(PromptedEnumValues), out var promptedEnumValuesElement);

            var operationGroupToOmit = DeserializeArray(operationGroupsToOmitElement);
            var requestPathIsNonResource = DeserializeArray(requestPathIsNonResourceElement);
            var noPropertyTypeReplacement = DeserializeArray(noPropertyTypeReplacementElement);
            var listException = DeserializeArray(listExceptionElement);
            var promptedEnumValues = DeserializeArray(promptedEnumValuesElement);
            var keepOrphanedModels = DeserializeArray(keepOrphanedModelsElement);
            var keepPluralEnums = DeserializeArray(keepPluralEnumsElement);
            var keepPluralResourceData = DeserializeArray(keepPluralResourceDataElement);
            var noResourceSuffix = DeserializeArray(noResourceSuffixElement);
            var prependRPPrefix = DeserializeArray(prependRPPrefixElement);
            var generateArmResourceExtensions = DeserializeArray(generateArmResourceExtensionsElement);
            var suppressAbstractBaseClass = DeserializeArray(suppressAbstractBaseClassElement);

            root.TryGetProperty("ArmCore", out var isArmCore);
            root.TryGetProperty(nameof(MgmtDebug), out var mgmtDebugRoot);
            root.TryGetProperty(nameof(DoesResourceModelRequireType), out var resourceModelRequiresType);
            root.TryGetProperty(nameof(DoesResourceModelRequireName), out var resourceModelRequiresName);
            root.TryGetProperty(nameof(DoesSingletonRequiresKeyword), out var singletonRequiresKeyword);
            root.TryGetProperty(nameof(TestGen), out var testModelerRoot);
            root.TryGetProperty(nameof(OperationIdMappings), out var operationIdMappings);
            root.TryGetProperty(nameof(UpdateRequiredCopy), out var updateRequiredCopy);
            root.TryGetProperty(nameof(PatchInitializerCustomization), out var patchInitializerCustomization);

            return new MgmtConfiguration(
                operationGroupsToOmit: operationGroupToOmit,
                requestPathIsNonResource: requestPathIsNonResource,
                noPropertyTypeReplacement: noPropertyTypeReplacement,
                listException: listException,
                promptedEnumValues: promptedEnumValues,
                keepOrphanedModels: keepOrphanedModels,
                keepPluralEnums: keepPluralEnums,
                keepPluralResourceData: keepPluralResourceData,
                noResourceSuffix: noResourceSuffix,
                schemasToPrependRPPrefix: prependRPPrefix,
                generateArmResourceExtensions: generateArmResourceExtensions,
                suppressAbstractBaseClass: suppressAbstractBaseClass,
                mgmtDebug: MgmtDebugConfiguration.LoadConfiguration(mgmtDebugRoot),
                requestPathToParent: requestPathToParent,
                requestPathToResourceName: requestPathToResourceName,
                requestPathToResourceData: requestPathToResourceData,
                requestPathToResourceType: requestPathToResourceType,
                requestPathToScopeResourceTypes: requestPathToScopeResourceTypes,
                operationPositions: operationPositions,
                requestPathToSingletonResource: requestPathToSingletonResource,
                overrideOperationName: operationIdToName,
                renameRules: renameRules,
                formatByNameRules: formatByNameRules,
                renameMapping: renameMapping,
                irregularPluralWords: irregularPluralWords,
                mergeOperations: mergeOperations,
                armCore: isArmCore,
                resourceModelRequiresType: resourceModelRequiresType,
                resourceModelRequiresName: resourceModelRequiresName,
                singletonRequiresKeyword: singletonRequiresKeyword,
                testGen: TestGenConfiguration.LoadConfiguration(testModelerRoot),
                operationIdMappings: operationIdMappings,
                updateRequiredCopy: updateRequiredCopy,
                patchInitializerCustomization: patchInitializerCustomization);
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
