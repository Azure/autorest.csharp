// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelExtension
    {
        // max number of words to keep if trimming the property
        private const int MaxTrimmingPropertyWordCount = 2;

        private static readonly List<string> EnumValuesShouldBePrompted = new()
        {
            "None", "NotSet", "Unknown", "NotSpecified", "Unspecified", "Undefined"
        };

        public static void UpdateSealChoiceTypes(this IEnumerable<Schema> allSchemas)
        {
            var wordCandidates = new List<string>(EnumValuesShouldBePrompted.Concat(Configuration.MgmtConfiguration.PromptedEnumValues));
            foreach (var schema in allSchemas)
            {
                if (schema is not SealedChoiceSchema choiceSchema)
                    continue;

                // rearrange the sequence in the choices
                choiceSchema.Choices = RearrangeChoices(choiceSchema.Choices, wordCandidates);
            }
        }

        internal static ICollection<ChoiceValue> RearrangeChoices(ICollection<ChoiceValue> originalValues, List<string> wordCandidates)
        {
            return originalValues.OrderBy(choice =>
            {
                var name = choice.CSharpName();
                var index = wordCandidates.IndexOf(name);
                return index >= 0 ? index : wordCandidates.Count;
            }).ToList();
        }

        public static void UpdatePatchOperations(this CodeModel codeModel)
        {
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    if (operation.GetHttpMethod() == HttpMethod.Patch)
                    {
                        var bodyParameter = operation.GetBodyParameter();
                        if (bodyParameter != null)
                            bodyParameter.Required = true;
                    }
                }
            }
        }

        public static void VerifyAndUpdateFrameworkTypes(this IEnumerable<Schema> allSchemas)
        {
            foreach (var schema in allSchemas)
            {
                if (schema is not ObjectSchema objSchema)
                    continue;

                foreach (var property in objSchema.Properties)
                {
                    if (property.CSharpName().EndsWith("Uri", StringComparison.Ordinal))
                        property.Schema.Type = AllSchemaTypes.Uri;
                    if (property.CSharpName().EndsWith("Uris", StringComparison.Ordinal) && property.Schema is ArraySchema arraySchema)
                        arraySchema.ElementType.Type = AllSchemaTypes.Uri;
                    if (property.CSharpName().EndsWith("Duration", StringComparison.Ordinal) && property.Schema.Type == AllSchemaTypes.String && property.Schema.Extensions?.Format == null)
                        throw new InvalidOperationException($"The {property.Language.Default.Name} property of {objSchema.Name} ends with \"Duration\" but does not use the duration format to be generated as TimeSpan type. Add \"format\": \"duration\" with directive in autorest.md for the property if it's ISO 8601 format like P1DT2H59M59S. Add \"x-ms-format\": \"{XMsFormat.DurationConstant}\" if it's the constant format like 1.2:59:59.5000000. If the property does not conform to a TimeSpan format, please use \"x-ms-client-name\" to rename the property for the client.");
                    // Do not use property.SerializedName=="type" so that we can still use x-ms-client-name to override the auto-renaming here if there is some edge case.
                    if (property.CSharpName().Equals("Type", StringComparison.Ordinal))
                    {
                        if (objSchema.IsResourceData() || objSchema.CSharpName().Contains("NameAvailability", StringComparison.Ordinal))
                        {
                            property.Language.Default.Name = "resourceType";
                        }
                        else if (property.Schema.Name.EndsWith("Type", StringComparison.Ordinal) && property.Schema.Name.Length != 4)
                        {
                            property.Language.Default.Name = GetEnclosingTypeName(objSchema.Name, property.Schema.Name, property.Schema.Type);
                        }
                        else if (property.Schema.Name.EndsWith("Types", StringComparison.Ordinal) && property.Schema.Name.Length != 5)
                        {
                            property.Language.Default.Name = GetEnclosingTypeName(objSchema.Name, property.Schema.Name.TrimEnd('s'), property.Schema.Type);
                        }
                        else
                        {
                            throw new InvalidOperationException($"{objSchema.Name} has a property named \"Type\" which is not allowed. Please use \"x-ms-client-name\" to rename the property for the client.");
                        }
                    }
                }
            }
        }

        internal static string GetEnclosingTypeName(string parentName, string propertyTypeName, AllSchemaTypes type)
        {
            if (type == AllSchemaTypes.String)
            {
                // for string type property, return the original property name so that it's easier to identify the semantic meaning
                return propertyTypeName;
            }

            var propertyWords = propertyTypeName.SplitByCamelCaseAndGroup().ToArray();
            // we keep at most 2 words, if trim the property
            if (propertyWords.Length < MaxTrimmingPropertyWordCount)
            {
                return propertyTypeName;
            }

            var parentWords = parentName.SplitByCamelCaseAndGroup().ToArray();
            var commonPrefixes = new List<string>();
            for (int i = 0; i < parentWords.Length && i < propertyWords.Length; i++)
            {
                if (parentWords[i] == propertyWords[i])
                {
                    commonPrefixes.Add(parentWords[i]);
                }
                else
                {
                    break;
                };
            }

            if (commonPrefixes.Count == 0)
            {
                // if no common prefix, just return the original property name
                return propertyTypeName;
            }

            var newPropertyWords = propertyWords.TakeLast(propertyWords.Length - commonPrefixes.Count()).ToList();
            if (newPropertyWords.Count > MaxTrimmingPropertyWordCount)
            {
                commonPrefixes.AddRange(newPropertyWords.Take(newPropertyWords.Count - MaxTrimmingPropertyWordCount));
                newPropertyWords.RemoveRange(0, newPropertyWords.Count - MaxTrimmingPropertyWordCount);
            }

            // A property namne cannot start with number, so we need to shift another word from prefixes to new property.
            // The worst case is that new property is the original property. The loop should end eventually.
            while (newPropertyWords.Count < MaxTrimmingPropertyWordCount || int.TryParse(newPropertyWords.First(), out _))
            {
                newPropertyWords.Insert(0, commonPrefixes.Last());
                commonPrefixes.RemoveAt(commonPrefixes.Count - 1);
            }

            return String.Join("", newPropertyWords);
        }

        public static void UpdateSubscriptionIdForAllResource(this CodeModel codeModel)
        {
            bool setSubParam = false;
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                foreach (var op in operationGroup.Operations)
                {
                    foreach (var p in op.Parameters)
                    {
                        // update the first subscriptionId parameter to be 'method' parameter
                        if (!setSubParam && p.Language.Default.Name.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                        {
                            setSubParam = true;
                            p.Implementation = ImplementationLocation.Method;
                        }
                        // update the apiVersion parameter to be 'client' method
                        if (p.Language.Default.Name.Equals("apiVersion", StringComparison.OrdinalIgnoreCase))
                        {
                            p.Implementation = ImplementationLocation.Client;
                        }
                    }
                }
            }
        }

        public static void UpdateAcronym(Schema schema)
        {
            if (Configuration.MgmtConfiguration.RenameRules.Count == 0)
                return;
            var transformer = new NameTransformer(Configuration.MgmtConfiguration.RenameRules);
            var wordCache = new ConcurrentDictionary<string, string>();
            UpdateAcronyms(new Schema[] { schema }, transformer, wordCache);
        }

        public static void UpdateAcronyms(this CodeModel codeModel)
        {
            if (Configuration.MgmtConfiguration.RenameRules.Count == 0)
                return;
            var transformer = new NameTransformer(Configuration.MgmtConfiguration.RenameRules);
            var wordCache = new ConcurrentDictionary<string, string>();
            // first transform all the name of schemas, properties
            UpdateAcronyms(codeModel.AllSchemas, transformer, wordCache);
            // transform all the parameter names
            UpdateAcronyms(codeModel.OperationGroups, transformer, wordCache);
        }

        private static void UpdateAcronyms(IEnumerable<Schema> allSchemas, NameTransformer transformer, ConcurrentDictionary<string, string> wordCache)
        {
            foreach (var schema in allSchemas)
            {
                TransformSchema(schema, transformer, wordCache);
            }
        }

        private static void UpdateAcronyms(IEnumerable<OperationGroup> operationGroups, NameTransformer transformer, ConcurrentDictionary<string, string> wordCache)
        {
            foreach (var operationGroup in operationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    TransformOperation(operation, transformer, wordCache);
                }
            }
        }

        private static void TransformOperation(Operation operation, NameTransformer transformer, ConcurrentDictionary<string, string> wordCache)
        {
            TransformLanguage(operation.Language, transformer, wordCache);
            // this iteration only applies to path and query parameter (maybe headers?) but not to body parameter
            foreach (var parameter in operation.Parameters)
            {
                TransformLanguage(parameter.Language, transformer, wordCache);
            }

            // we need to iterate over the parameters in each request (actually only one request) to ensure the name of body parameters are also taken care of
            foreach (var request in operation.Requests)
            {
                foreach (var parameter in request.Parameters)
                {
                    TransformLanguage(parameter.Language, transformer, wordCache);
                }
            }
        }

        private static void TransformSchema(Schema schema, NameTransformer transformer, ConcurrentDictionary<string, string> wordCache)
        {
            switch (schema)
            {
                case ChoiceSchema choiceSchema:
                    TransformChoiceSchema(choiceSchema.Language, choiceSchema.Choices, transformer, wordCache);
                    break;
                case SealedChoiceSchema sealedChoiceSchema:
                    TransformChoiceSchema(sealedChoiceSchema.Language, sealedChoiceSchema.Choices, transformer, wordCache);
                    break;
                case ObjectSchema objSchema: // GroupSchema inherits ObjectSchema, therefore we do not need to handle that
                    TransformObjectSchema(objSchema, transformer, wordCache);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown schema type {schema.GetType()}");
            }
        }

        private static void TransformChoiceSchema(Languages languages, ICollection<ChoiceValue> choiceValues, NameTransformer transformer, ConcurrentDictionary<string, string> wordCache)
        {
            TransformLanguage(languages, transformer, wordCache);
            TransformChoices(choiceValues, transformer, wordCache);
        }

        private static void TransformChoices(ICollection<ChoiceValue> choiceValues, NameTransformer transformer, ConcurrentDictionary<string, string> wordCache)
        {
            foreach (var choiceValue in choiceValues)
            {
                TransformLanguage(choiceValue.Language, transformer, wordCache);
            }
        }

        private static void TransformLanguage(Languages languages, NameTransformer transformer, ConcurrentDictionary<string, string> wordCache)
        {
            var originalName = languages.Default.Name;
            if (wordCache.TryGetValue(originalName, out var result))
            {
                languages.Default.Name = result;
                return;
            }
            result = transformer.EnsureNameCase(originalName);
            languages.Default.Name = result;
            wordCache.TryAdd(originalName, result);
        }

        private static void TransformObjectSchema(ObjectSchema objSchema, NameTransformer transformer, ConcurrentDictionary<string, string> wordCache)
        {
            // transform the name of this schema
            TransformLanguage(objSchema.Language, transformer, wordCache);
            foreach (var property in objSchema.Properties)
            {
                TransformLanguage(property.Language, transformer, wordCache);
            }
        }

        public static void VerifyApiVersions(this CodeModel codeModel)
        {
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                VerifyApiVersionsWithinOperationGroup(operationGroup);
            }
        }

        // Operations within an operation group should use the same API version.
        // TODO: this might be able to be removed after https://github.com/Azure/autorest.csharp/issues/1917 is resolved.
        private static void VerifyApiVersionsWithinOperationGroup(OperationGroup operationGroup)
        {
            var apiVersionValues = operationGroup.Operations
                .SelectMany(op => op.Parameters.Where(p => p.Origin == "modelerfour:synthesized/api-version").Select(p => ((ConstantSchema)p.Schema).Value.Value))
                .ToHashSet();
            if (apiVersionValues.Count > 1)
            {
                throw new InvalidOperationException($"Multiple api-version values found in the operation group: {operationGroup.Key}. Please rename the operation group for some operations so that all operations in one operation group share the same API version.");
            }
        }
    }
}
