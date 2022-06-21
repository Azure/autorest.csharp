// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class SchemaRenamer
    {
        public static void UpdateAcronyms()
        {
            if (Configuration.MgmtConfiguration.RenameRules.Count == 0)
                return;
            var transformer = new NameTransformer(Configuration.MgmtConfiguration.RenameRules);
            var wordCache = new ConcurrentDictionary<string, string>();
            // first transform all the name of schemas, properties
            UpdateAcronyms(MgmtContext.CodeModel.AllSchemas, transformer, wordCache);
            // transform all the parameter names
            UpdateAcronyms(MgmtContext.CodeModel.OperationGroups, transformer, wordCache);
        }

        public static void UpdateAcronym(Schema schema)
        {
            if (Configuration.MgmtConfiguration.RenameRules.Count == 0)
                return;
            var transformer = new NameTransformer(Configuration.MgmtConfiguration.RenameRules);
            var wordCache = new ConcurrentDictionary<string, string>();
            TransformSchema(schema, transformer, wordCache);
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
    }
}
